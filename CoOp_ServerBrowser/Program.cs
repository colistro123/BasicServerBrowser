using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using ProtoBuf;
using CoOp_ServerBrowser;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Reflection;

#region myprotobufs protos
[ProtoContract]
public class DiscoveryResponse
{
    [ProtoMember(1)]
    public string ServerName { get; set; }
    [ProtoMember(2)]
    public int MaxPlayers { get; set; }
    [ProtoMember(3)]
    public int PlayerCount { get; set; }
    [ProtoMember(4)]
    public bool PasswordProtected { get; set; }
    [ProtoMember(5)]
    public int Port { get; set; }
    [ProtoMember(6)]
    public string Gamemode { get; set; }
}
#endregion

public class CL_API
{
    public class ServerListC
    {
        public string ip { set; get; }
        public string port { set; get; }
        public string password { set; get; }
        public string hostname { set; get; }
        public int playersraw { set; get; }
        public string playersdata { set; get; }
        public string gamemode { set; get; }
    }
    public static List<ServerListC> sList = new List<ServerListC>(); 
    public static string MasterListURL = "http://46.101.1.92/";
    public static NetPeer peer;
    public static double lastrefresh;
    public enum PacketType
    {
        VehiclePositionData = 0,
        ChatData = 1,
        PlayerDisconnect = 2,
        PedPositionData = 3,
        NpcVehPositionData = 4,
        NpcPedPositionData = 5,
        WorldSharingStop = 6,
        DiscoveryResponse = 7,
        ConnectionRequest = 8,
        NativeCall = 9,
        NativeResponse = 10,
        PlayerKilled = 11,
        NativeTick = 12,
        NativeTickRecall = 13,
        NativeOnDisconnect = 14,
        NativeOnDisconnectRecall = 15,
    }
    public static double MAX_REFRESH_HOLD() //So it doesn't spam requests
    {
        return 1.0;
    }
    public static string getJSONData(string url) {
        string html;
        WebRequest request = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        html = reader.ReadToEnd();
        reader.Close();
        response.Close();
        return html;
    }
    public static int StartConnection()
    {
        SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        NetPeerConfiguration config = new NetPeerConfiguration("GTAVOnlineRaces");
        config.Port = new Random().Next(1000, 9999);
        peer = new NetPeer(config);
        peer.Start();
        peer.RegisterReceivedCallback(ProcessMessages, SynchronizationContext.Current);
        return 1;
    }
    public static void sendMessage(NetPeer peer, string adr, short port, string msg)
    {
        var om = peer.CreateMessage();
        om.Write(msg);

        try
        {
            peer.SendUnconnectedMessage(om, new IPEndPoint(NetUtility.Resolve(adr), port));
        }
        catch (NetException nex)
        {
            if (nex.Message != "This message has already been sent! Use NetPeer.SendMessage() to send to multiple recipients efficiently")
                throw;
        }
    }
    public static void DiscoverPeer(NetPeer peer, string adr, short port)
    {
        try
        {
            peer.DiscoverKnownPeer(new IPEndPoint(NetUtility.Resolve(adr), port));
        }
        catch (NetException nex)
        {
            if (nex.Message != "This message has already been sent! Use NetPeer.SendMessage() to send to multiple recipients efficiently")
                throw;
        }
    }
    public static double GetCurrentTime()
    {
        return Stopwatch.GetTimestamp() / Stopwatch.Frequency;
    }
    public static void ProcessMessages(object sender)
    {
        Console.WriteLine("Received message.");
        var peer = (NetPeer)sender;
        NetIncomingMessage msg;
        while (peer != null && (msg = peer.ReadMessage()) != null)
        {
            Console.WriteLine("Data is " + msg.MessageType);
            if (msg.MessageType == NetIncomingMessageType.DiscoveryResponse)
            {
                var rType = msg.ReadInt32();
                var len = msg.ReadInt32();
                var bin = msg.ReadBytes(len);
                var data = DeserializeBinary<DiscoveryResponse>(bin) as DiscoveryResponse;
                if (data == null) return;
                bool pwProtected = data.PasswordProtected;
                var servername = data.ServerName;
                var playersraw = data.PlayerCount;
                var playersdata = data.PlayerCount + "/" + data.MaxPlayers;
                var gamemode = data.Gamemode == null ? "Unknown" : data.Gamemode;
                string ipAdr = msg.SenderEndPoint.Address.ToString();
                AddToList(ipAdr, data.Port.ToString(), !pwProtected ? "No" : "Yes", servername, playersraw, playersdata, gamemode);
                break;
            }
        }
    }
    public static void AddToList(string ipAdr, string port, string password, string hostname, int playersraw, string players, string gamemode)
    {
        ServerListC data = new ServerListC();
        data.ip = ipAdr;
        data.port = port;
        data.password = password;
        data.hostname = hostname;
        data.playersraw = playersraw;
        data.playersdata = players;
        data.gamemode = gamemode;

        sList.Add(data);
        return;
    }

    public static byte[] SerializeBinary(object data)
    {
        using (var stream = new MemoryStream())
        {
            stream.SetLength(0);
            Serializer.Serialize(stream, data);
            return stream.ToArray();
        }
    }
    public static object DeserializeBinary<T>(byte[] data)
    {
        object output;
        using (var stream = new MemoryStream(data))
        {
            try
            {
                output = Serializer.Deserialize<T>(stream);
            }
            catch (ProtoException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }
        return output;
    }
}

namespace CoOp_ServerBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}