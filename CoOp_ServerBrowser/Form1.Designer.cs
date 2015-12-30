namespace CoOp_ServerBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.ServerList = new System.Windows.Forms.DataGridView();
            this.lbl_ServersFoundInf = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_hostname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerList_PW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerList_IPPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerList_ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerList_Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerList_GM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ServerList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.Location = new System.Drawing.Point(397, 26);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 1;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // ServerList
            // 
            this.ServerList.AllowUserToAddRows = false;
            this.ServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerList_PW,
            this.ServerList_IPPort,
            this.ServerList_ServerName,
            this.ServerList_Players,
            this.ServerList_GM});
            this.ServerList.Location = new System.Drawing.Point(13, 35);
            this.ServerList.MaximumSize = new System.Drawing.Size(486, 900);
            this.ServerList.MinimumSize = new System.Drawing.Size(486, 186);
            this.ServerList.MultiSelect = false;
            this.ServerList.Name = "ServerList";
            this.ServerList.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ServerList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ServerList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerList.Size = new System.Drawing.Size(486, 290);
            this.ServerList.TabIndex = 2;
            // 
            // lbl_ServersFoundInf
            // 
            this.lbl_ServersFoundInf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ServersFoundInf.AutoSize = true;
            this.lbl_ServersFoundInf.Location = new System.Drawing.Point(192, 31);
            this.lbl_ServersFoundInf.Name = "lbl_ServersFoundInf";
            this.lbl_ServersFoundInf.Size = new System.Drawing.Size(85, 13);
            this.lbl_ServersFoundInf.TabIndex = 3;
            this.lbl_ServersFoundInf.Text = "0 Servers Found";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_hostname);
            this.panel1.Controls.Add(this.lbl_ServersFoundInf);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Location = new System.Drawing.Point(13, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 61);
            this.panel1.TabIndex = 4;
            // 
            // txt_hostname
            // 
            this.txt_hostname.Location = new System.Drawing.Point(12, 28);
            this.txt_hostname.Name = "txt_hostname";
            this.txt_hostname.Size = new System.Drawing.Size(100, 20);
            this.txt_hostname.TabIndex = 4;
            this.txt_hostname.TextChanged += new System.EventHandler(this.txt_hostname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hostname";
            // 
            // ServerList_PW
            // 
            this.ServerList_PW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ServerList_PW.HeaderText = "Password";
            this.ServerList_PW.Name = "ServerList_PW";
            this.ServerList_PW.ReadOnly = true;
            this.ServerList_PW.Width = 65;
            // 
            // ServerList_IPPort
            // 
            this.ServerList_IPPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServerList_IPPort.HeaderText = "IP/Port";
            this.ServerList_IPPort.Name = "ServerList_IPPort";
            this.ServerList_IPPort.ReadOnly = true;
            // 
            // ServerList_ServerName
            // 
            this.ServerList_ServerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServerList_ServerName.HeaderText = "HostName";
            this.ServerList_ServerName.Name = "ServerList_ServerName";
            this.ServerList_ServerName.ReadOnly = true;
            // 
            // ServerList_Players
            // 
            this.ServerList_Players.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServerList_Players.HeaderText = "Players";
            this.ServerList_Players.Name = "ServerList_Players";
            this.ServerList_Players.ReadOnly = true;
            // 
            // ServerList_GM
            // 
            this.ServerList_GM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServerList_GM.HeaderText = "Game Mode";
            this.ServerList_GM.Name = "ServerList_GM";
            this.ServerList_GM.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 384);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ServerList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(532, 844);
            this.MinimumSize = new System.Drawing.Size(532, 422);
            this.Name = "Form1";
            this.Text = "Co-Op Server Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServerList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DataGridView ServerList;
        private System.Windows.Forms.Label lbl_ServersFoundInf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerList_PW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerList_IPPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerList_ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerList_Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerList_GM;
    }
}

