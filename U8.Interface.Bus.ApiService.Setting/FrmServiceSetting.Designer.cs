namespace U8.Interface.Bus.ApiService.Setting
{
    partial class FrmServiceSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServiceSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsService = new System.Windows.Forms.ToolStrip();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbPause = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbRecover = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAllRun = new System.Windows.Forms.ToolStripButton();
            this.tsbAllStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.cmsService = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRevover = new System.Windows.Forms.ToolStripMenuItem();
            this.tssLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAllRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllStop = new System.Windows.Forms.ToolStripMenuItem();
            this.tssLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tssLine3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRunMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsService.SuspendLayout();
            this.gbServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.cmsService.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsService
            // 
            this.tsService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRun,
            this.tsbPause,
            this.tsbStop,
            this.tsbRecover,
            this.toolStripSeparator3,
            this.tsbAllRun,
            this.tsbAllStop,
            this.toolStripSeparator4,
            this.tsbRefresh});
            this.tsService.Location = new System.Drawing.Point(0, 0);
            this.tsService.Name = "tsService";
            this.tsService.Size = new System.Drawing.Size(594, 25);
            this.tsService.TabIndex = 0;
            this.tsService.Tag = "2";
            this.tsService.Text = "服务状态设置工具条";
            // 
            // tsbRun
            // 
            this.tsbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbRun.Image")));
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(59, 22);
            this.tsbRun.Text = "启动服务";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsbPause
            // 
            this.tsbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPause.Image = ((System.Drawing.Image)(resources.GetObject("tsbPause.Image")));
            this.tsbPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPause.Name = "tsbPause";
            this.tsbPause.Size = new System.Drawing.Size(59, 22);
            this.tsbPause.Text = "暂停服务";
            this.tsbPause.Visible = false;
            this.tsbPause.Click += new System.EventHandler(this.tsbPause_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(59, 22);
            this.tsbStop.Text = "停止服务";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbRecover
            // 
            this.tsbRecover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRecover.Image = ((System.Drawing.Image)(resources.GetObject("tsbRecover.Image")));
            this.tsbRecover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecover.Name = "tsbRecover";
            this.tsbRecover.Size = new System.Drawing.Size(59, 22);
            this.tsbRecover.Text = "恢复服务";
            this.tsbRecover.Visible = false;
            this.tsbRecover.Click += new System.EventHandler(this.tsbRecover_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAllRun
            // 
            this.tsbAllRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAllRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbAllRun.Image")));
            this.tsbAllRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAllRun.Name = "tsbAllRun";
            this.tsbAllRun.Size = new System.Drawing.Size(59, 22);
            this.tsbAllRun.Text = "全部启动";
            this.tsbAllRun.Click += new System.EventHandler(this.tsbAllRun_Click);
            // 
            // tsbAllStop
            // 
            this.tsbAllStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAllStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbAllStop.Image")));
            this.tsbAllStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAllStop.Name = "tsbAllStop";
            this.tsbAllStop.Size = new System.Drawing.Size(59, 22);
            this.tsbAllStop.Text = "全部停止";
            this.tsbAllStop.Click += new System.EventHandler(this.tsbAllStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(35, 22);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // gbServices
            // 
            this.gbServices.Controls.Add(this.dgvServices);
            this.gbServices.Controls.Add(this.lblMessage);
            this.gbServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServices.Location = new System.Drawing.Point(0, 25);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(594, 133);
            this.gbServices.TabIndex = 1;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "服务列表";
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AllowUserToResizeRows = false;
            this.dgvServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNum,
            this.colID,
            this.colMachine,
            this.colName,
            this.colDesc,
            this.colState,
            this.colMode,
            this.colPath});
            this.dgvServices.ContextMenuStrip = this.cmsService;
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(3, 17);
            this.dgvServices.MultiSelect = false;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersVisible = false;
            this.dgvServices.RowTemplate.Height = 23;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(588, 113);
            this.dgvServices.TabIndex = 0;
            this.dgvServices.Visible = false;
            this.dgvServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvServices_MouseDown);
            // 
            // cmsService
            // 
            this.cmsService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRun,
            this.tsmiPause,
            this.tsmiStop,
            this.tsmiRevover,
            this.tssLine1,
            this.tsmiAllRun,
            this.tsmiAllStop,
            this.tssLine2,
            this.tsmiRefresh,
            this.tssLine3,
            this.tsmiRunMode});
            this.cmsService.Name = "cmsService";
            this.cmsService.Size = new System.Drawing.Size(123, 198);
            // 
            // tsmiRun
            // 
            this.tsmiRun.Name = "tsmiRun";
            this.tsmiRun.Size = new System.Drawing.Size(122, 22);
            this.tsmiRun.Text = "启动服务";
            this.tsmiRun.Click += new System.EventHandler(this.tsmiRun_Click);
            // 
            // tsmiPause
            // 
            this.tsmiPause.Name = "tsmiPause";
            this.tsmiPause.Size = new System.Drawing.Size(122, 22);
            this.tsmiPause.Text = "暂停服务";
            this.tsmiPause.Visible = false;
            this.tsmiPause.Click += new System.EventHandler(this.tsmiPause_Click);
            // 
            // tsmiStop
            // 
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(122, 22);
            this.tsmiStop.Text = "停止服务";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // tsmiRevover
            // 
            this.tsmiRevover.Name = "tsmiRevover";
            this.tsmiRevover.Size = new System.Drawing.Size(122, 22);
            this.tsmiRevover.Text = "恢复服务";
            this.tsmiRevover.Visible = false;
            this.tsmiRevover.Click += new System.EventHandler(this.tsmiRevover_Click);
            // 
            // tssLine1
            // 
            this.tssLine1.Name = "tssLine1";
            this.tssLine1.Size = new System.Drawing.Size(119, 6);
            // 
            // tsmiAllRun
            // 
            this.tsmiAllRun.Name = "tsmiAllRun";
            this.tsmiAllRun.Size = new System.Drawing.Size(122, 22);
            this.tsmiAllRun.Text = "全部启动";
            this.tsmiAllRun.Click += new System.EventHandler(this.tsmiAllRun_Click);
            // 
            // tsmiAllStop
            // 
            this.tsmiAllStop.Name = "tsmiAllStop";
            this.tsmiAllStop.Size = new System.Drawing.Size(122, 22);
            this.tsmiAllStop.Text = "全部停止";
            this.tsmiAllStop.Click += new System.EventHandler(this.tsmiAllStop_Click);
            // 
            // tssLine2
            // 
            this.tssLine2.Name = "tssLine2";
            this.tssLine2.Size = new System.Drawing.Size(119, 6);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(122, 22);
            this.tsmiRefresh.Text = "刷新";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tssLine3
            // 
            this.tssLine3.Name = "tssLine3";
            this.tssLine3.Size = new System.Drawing.Size(119, 6);
            // 
            // tsmiRunMode
            // 
            this.tsmiRunMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHand,
            this.tsmiAuto});
            this.tsmiRunMode.Name = "tsmiRunMode";
            this.tsmiRunMode.Size = new System.Drawing.Size(122, 22);
            this.tsmiRunMode.Text = "启动类型";
            // 
            // tsmiHand
            // 
            this.tsmiHand.Name = "tsmiHand";
            this.tsmiHand.Size = new System.Drawing.Size(98, 22);
            this.tsmiHand.Text = "手动";
            this.tsmiHand.Click += new System.EventHandler(this.tsmiHand_Click);
            // 
            // tsmiAuto
            // 
            this.tsmiAuto.Name = "tsmiAuto";
            this.tsmiAuto.Size = new System.Drawing.Size(98, 22);
            this.tsmiAuto.Text = "自动";
            this.tsmiAuto.Click += new System.EventHandler(this.tsmiAuto_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.Location = new System.Drawing.Point(3, 17);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(588, 113);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "获取不到PC上的协同服务";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(160, 172);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // colNum
            // 
            this.colNum.DataPropertyName = "SerNo";
            this.colNum.HeaderText = "序号";
            this.colNum.Name = "colNum";
            this.colNum.ReadOnly = true;
            this.colNum.Visible = false;
            this.colNum.Width = 60;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "编号";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 60;
            // 
            // colMachine
            // 
            this.colMachine.DataPropertyName = "Machine";
            this.colMachine.HeaderText = "机器名";
            this.colMachine.Name = "colMachine";
            this.colMachine.ReadOnly = true;
            this.colMachine.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 120;
            // 
            // colDesc
            // 
            this.colDesc.DataPropertyName = "Desc";
            this.colDesc.HeaderText = "描述";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            this.colDesc.Width = 150;
            // 
            // colState
            // 
            this.colState.DataPropertyName = "Status";
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 80;
            // 
            // colMode
            // 
            this.colMode.DataPropertyName = "StartMod";
            this.colMode.HeaderText = "启动类型";
            this.colMode.Name = "colMode";
            this.colMode.ReadOnly = true;
            this.colMode.Width = 80;
            // 
            // colPath
            // 
            this.colPath.DataPropertyName = "Path";
            this.colPath.HeaderText = "文件路径";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Visible = false;
            this.colPath.Width = 250;
            // 
            // FrmServiceSetting
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 158);
            this.Controls.Add(this.gbServices);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tsService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServiceSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务状态设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmServiceSetting_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmServiceSetting_MouseClick);
            this.Shown += new System.EventHandler(this.FrmServiceSetting_Shown);
            this.tsService.ResumeLayout(false);
            this.tsService.PerformLayout();
            this.gbServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.cmsService.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsService;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripButton tsbPause;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbRecover;
        private System.Windows.Forms.ToolStripButton tsbAllRun;
        private System.Windows.Forms.ToolStripButton tsbAllStop;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.ContextMenuStrip cmsService;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiRun;
        private System.Windows.Forms.ToolStripMenuItem tsmiPause;
        private System.Windows.Forms.ToolStripMenuItem tsmiStop;
        private System.Windows.Forms.ToolStripMenuItem tsmiRevover;
        private System.Windows.Forms.ToolStripSeparator tssLine1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllRun;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllStop;
        private System.Windows.Forms.ToolStripSeparator tssLine2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiRunMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiHand;
        private System.Windows.Forms.ToolStripMenuItem tsmiAuto;
        private System.Windows.Forms.ToolStripSeparator tssLine3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
    }
}