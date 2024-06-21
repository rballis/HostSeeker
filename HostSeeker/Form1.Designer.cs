namespace HostSeeker
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.Sub1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbInterface = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Sub3 = new System.Windows.Forms.TextBox();
			this.btnGetLocalIP = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Sub2 = new System.Windows.Forms.TextBox();
			this.btnStartSeek = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.hostEntry = new System.Windows.Forms.ListBox();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnHostList = new System.Windows.Forms.Button();
			this.dgvHostTable = new System.Windows.Forms.DataGridView();
			this.bsHost = new System.Windows.Forms.BindingSource(this.components);
			this.cHostPingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.hostTableIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hostTableHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.statusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHostTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsHost)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cHostPingBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// Sub1
			// 
			this.Sub1.AccessibleDescription = "";
			this.Sub1.AccessibleName = "";
			this.Sub1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.Sub1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Sub1.CausesValidation = false;
			this.Sub1.Location = new System.Drawing.Point(294, 16);
			this.Sub1.MaxLength = 3;
			this.Sub1.Name = "Sub1";
			this.Sub1.Size = new System.Drawing.Size(24, 20);
			this.Sub1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.cbInterface);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.Sub3);
			this.panel1.Controls.Add(this.btnGetLocalIP);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Sub1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.Sub2);
			this.panel1.Location = new System.Drawing.Point(13, 11);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(466, 48);
			this.panel1.TabIndex = 1;
			// 
			// cbInterface
			// 
			this.cbInterface.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbInterface.FormattingEnabled = true;
			this.cbInterface.Location = new System.Drawing.Point(6, 17);
			this.cbInterface.Name = "cbInterface";
			this.cbInterface.Size = new System.Drawing.Size(178, 21);
			this.cbInterface.TabIndex = 9;
			this.cbInterface.SelectedIndexChanged += new System.EventHandler(this.interfaceBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(416, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(10, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = ".";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(426, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "XXX";
			// 
			// Sub3
			// 
			this.Sub3.AccessibleDescription = "";
			this.Sub3.AccessibleName = "";
			this.Sub3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.Sub3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Sub3.CausesValidation = false;
			this.Sub3.Location = new System.Drawing.Point(386, 16);
			this.Sub3.MaxLength = 3;
			this.Sub3.Name = "Sub3";
			this.Sub3.Size = new System.Drawing.Size(24, 20);
			this.Sub3.TabIndex = 5;
			// 
			// btnGetLocalIP
			// 
			this.btnGetLocalIP.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnGetLocalIP.Enabled = false;
			this.btnGetLocalIP.Location = new System.Drawing.Point(190, 15);
			this.btnGetLocalIP.Name = "btnGetLocalIP";
			this.btnGetLocalIP.Size = new System.Drawing.Size(97, 23);
			this.btnGetLocalIP.TabIndex = 7;
			this.btnGetLocalIP.Text = "Get local sub. >";
			this.btnGetLocalIP.UseVisualStyleBackColor = true;
			this.btnGetLocalIP.Click += new System.EventHandler(this.GetLocalIP_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(370, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(10, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = ".";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Subnet IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(324, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = ".";
			// 
			// Sub2
			// 
			this.Sub2.AccessibleDescription = "";
			this.Sub2.AccessibleName = "";
			this.Sub2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.Sub2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Sub2.CausesValidation = false;
			this.Sub2.Location = new System.Drawing.Point(340, 16);
			this.Sub2.MaxLength = 3;
			this.Sub2.Name = "Sub2";
			this.Sub2.Size = new System.Drawing.Size(24, 20);
			this.Sub2.TabIndex = 2;
			// 
			// btnStartSeek
			// 
			this.btnStartSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStartSeek.Enabled = false;
			this.btnStartSeek.Location = new System.Drawing.Point(485, 38);
			this.btnStartSeek.Name = "btnStartSeek";
			this.btnStartSeek.Size = new System.Drawing.Size(84, 23);
			this.btnStartSeek.TabIndex = 2;
			this.btnStartSeek.Text = "Start seeking";
			this.btnStartSeek.UseVisualStyleBackColor = true;
			this.btnStartSeek.Click += new System.EventHandler(this.StartSeek_Click);
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel1,
            this.progressBar1});
			this.statusBar.Location = new System.Drawing.Point(0, 452);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(583, 22);
			this.statusBar.TabIndex = 12;
			this.statusBar.Text = "statusStrip1";
			// 
			// statusBarLabel1
			// 
			this.statusBarLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.statusBarLabel1.Name = "statusBarLabel1";
			this.statusBarLabel1.Size = new System.Drawing.Size(237, 17);
			this.statusBarLabel1.Text = "Fil in Subnet IP fields and push start seeking";
			// 
			// progressBar1
			// 
			this.progressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 16);
			this.progressBar1.Visible = false;
			// 
			// hostEntry
			// 
			this.hostEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hostEntry.FormattingEnabled = true;
			this.hostEntry.Location = new System.Drawing.Point(13, 335);
			this.hostEntry.Name = "hostEntry";
			this.hostEntry.Size = new System.Drawing.Size(556, 108);
			this.hostEntry.TabIndex = 13;
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.Location = new System.Drawing.Point(485, 9);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(84, 23);
			this.btnAbout.TabIndex = 14;
			this.btnAbout.Text = "About";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.ShowAbout_Click);
			// 
			// btnHostList
			// 
			this.btnHostList.Enabled = false;
			this.btnHostList.Location = new System.Drawing.Point(488, 309);
			this.btnHostList.Name = "btnHostList";
			this.btnHostList.Size = new System.Drawing.Size(81, 20);
			this.btnHostList.TabIndex = 15;
			this.btnHostList.Text = "Print Host List";
			this.btnHostList.UseVisualStyleBackColor = true;
			this.btnHostList.Click += new System.EventHandler(this.hostList_Click);
			// 
			// dgvHostTable
			// 
			this.dgvHostTable.AllowUserToAddRows = false;
			this.dgvHostTable.AllowUserToDeleteRows = false;
			this.dgvHostTable.AllowUserToResizeColumns = false;
			this.dgvHostTable.AllowUserToResizeRows = false;
			this.dgvHostTable.AutoGenerateColumns = false;
			this.dgvHostTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHostTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hostTableIP,
            this.hostTableHostName});
			this.dgvHostTable.DataSource = this.bsHost;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvHostTable.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvHostTable.Location = new System.Drawing.Point(13, 66);
			this.dgvHostTable.MultiSelect = false;
			this.dgvHostTable.Name = "dgvHostTable";
			this.dgvHostTable.ReadOnly = true;
			this.dgvHostTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvHostTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHostTable.Size = new System.Drawing.Size(556, 237);
			this.dgvHostTable.TabIndex = 16;
			this.dgvHostTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHostTable_CellClick);
			// 
			// bsHost
			// 
			this.bsHost.DataSource = typeof(HostSeeker.PresentationHost);
			// 
			// cHostPingBindingSource
			// 
			this.cHostPingBindingSource.DataSource = typeof(HostSeeker.CHostPing);
			// 
			// hostTableIP
			// 
			this.hostTableIP.DataPropertyName = "IP";
			this.hostTableIP.HeaderText = "IP";
			this.hostTableIP.Name = "hostTableIP";
			this.hostTableIP.ReadOnly = true;
			this.hostTableIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// hostTableHostName
			// 
			this.hostTableHostName.DataPropertyName = "HostName";
			this.hostTableHostName.HeaderText = "Host Name";
			this.hostTableHostName.Name = "hostTableHostName";
			this.hostTableHostName.ReadOnly = true;
			this.hostTableHostName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.hostTableHostName.Width = 395;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Orange;
			this.ClientSize = new System.Drawing.Size(583, 474);
			this.Controls.Add(this.dgvHostTable);
			this.Controls.Add(this.btnHostList);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.hostEntry);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.btnStartSeek);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(589, 498);
			this.Name = "Form1";
			this.Text = "HostSeeker";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHostTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsHost)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cHostPingBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sub1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartSeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Sub2;
        private System.Windows.Forms.TextBox Sub3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetLocalIP;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel1;
        private System.Windows.Forms.ListBox hostEntry;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHostList;
        private System.Windows.Forms.ComboBox cbInterface;
        private System.Windows.Forms.DataGridView dgvHostTable;
        private System.Windows.Forms.BindingSource cHostPingBindingSource;
		private System.Windows.Forms.BindingSource bsHost;
		private System.Windows.Forms.DataGridViewTextBoxColumn hostTableIP;
		private System.Windows.Forms.DataGridViewTextBoxColumn hostTableHostName;
	}
}

