using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoOp_ServerBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView Dgv { get; set; }
        void populateListGUI()
        {
            int totalplayers = 0;
            for (int i = 0; i < CL_API.sList.Count(); i++)
            {
                ServerList.Rows.Add(CL_API.sList[i].password, CL_API.sList[i].ip + ":" + CL_API.sList[i].port, CL_API.sList[i].hostname, CL_API.sList[i].playersdata, CL_API.sList[i].gamemode);
                totalplayers += CL_API.sList[i].playersraw;
                lbl_ServersFoundInf.Text = i+1 + " " + "servers found and" + " " + totalplayers + " " + "players" + " " + "online.";
                Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CL_API.StartConnection();
            showServers();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            showServers();
        }
        private void showServers()
        {
            double curtime = CL_API.GetCurrentTime();
            ServerList.Rows.Clear();
            CL_API.sList.Clear();
            if (curtime - CL_API.lastrefresh > CL_API.MAX_REFRESH_HOLD() || CL_API.lastrefresh == 0)
            {
                string data = CL_API.getJSONData(CL_API.MasterListURL);
                JObject ser = JObject.Parse(data);
                JArray array = (JArray)ser["list"];
                short port;
                foreach (string value in array)
                {
                    string[] spl = value.Split(':');
                    short.TryParse(spl[1], out port);
                    CL_API.DiscoverPeer(CL_API.peer, spl[0], port);
                }
                CL_API.lastrefresh = CL_API.GetCurrentTime();
                Thread.Sleep(2000);
                Application.DoEvents();
                populateListGUI();
            }
            else
            {
                lbl_ServersFoundInf.Text = "Please wait before requests, thank you!";
            }
        }

        private void txt_hostname_TextChanged(object sender, EventArgs e)
        {
            String searchValue = txt_hostname.Text.ToString().ToLower();
            //int rowIndex = -1;
            foreach (DataGridViewRow row in ServerList.Rows)
            {
                if (searchValue.Length < 1)
                {
                    row.Visible = true;
                }
                if (!row.Cells["ServerList_ServerName"].Value.ToString().ToLower().Contains(searchValue))
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = true;
                }
            }
        }
    }
}
