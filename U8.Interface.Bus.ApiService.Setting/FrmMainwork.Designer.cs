namespace U8.Interface.Bus.ApiService.Setting
{
    partial class FrmMainwork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainwork));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnConnectSetting = new System.Windows.Forms.ToolStripButton();
            this.btnServiceState = new System.Windows.Forms.ToolStripButton();
            this.btnUISetting = new System.Windows.Forms.ToolStripButton();
            this.btnOutPut = new System.Windows.Forms.ToolStripButton();
            this.btnDebug = new System.Windows.Forms.ToolStripButton();
            this.btnCheck = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scBasic = new System.Windows.Forms.SplitContainer();
            this.gboxSearch = new System.Windows.Forms.GroupBox();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxVoucherType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxRefresh = new System.Windows.Forms.CheckBox();
            this.scShown = new System.Windows.Forms.SplitContainer();
            this.gbxList = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colHOpera = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.colHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAcccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAccid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHAccname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scDetail = new System.Windows.Forms.SplitContainer();
            this.gbxTask = new System.Windows.Forms.GroupBox();
            this.tvTask = new System.Windows.Forms.TreeView();
            this.gbxDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.colBOpera = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.colBAutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAcccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAccid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBAccname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCpk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCpkname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBInsert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHandwork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBVerify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBErrNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBFatherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblServiceImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServiceState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrSearch = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewDisableButtonColumn1 = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.dataGridViewDisableButtonColumn2 = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.tsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.scBasic.Panel1.SuspendLayout();
            this.scBasic.Panel2.SuspendLayout();
            this.scBasic.SuspendLayout();
            this.gboxSearch.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.scShown.Panel1.SuspendLayout();
            this.scShown.Panel2.SuspendLayout();
            this.scShown.SuspendLayout();
            this.gbxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.scDetail.Panel1.SuspendLayout();
            this.scDetail.Panel2.SuspendLayout();
            this.scDetail.SuspendLayout();
            this.gbxTask.SuspendLayout();
            this.gbxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            this.skinEngine1.SkinStreamMain = ((System.IO.Stream)(resources.GetObject("skinEngine1.SkinStreamMain")));
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnectSetting,
            this.btnServiceState,
            this.btnUISetting,
            this.btnOutPut,
            this.btnDebug,
            this.btnCheck});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1017, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnConnectSetting
            // 
            this.btnConnectSetting.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.LINK;
            this.btnConnectSetting.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnConnectSetting.Name = "btnConnectSetting";
            this.btnConnectSetting.Size = new System.Drawing.Size(97, 22);
            this.btnConnectSetting.Text = "服务链接设置";
            this.btnConnectSetting.Click += new System.EventHandler(this.btnConnectSetting_Click);
            // 
            // btnServiceState
            // 
            this.btnServiceState.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.SERVICES;
            this.btnServiceState.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnServiceState.Name = "btnServiceState";
            this.btnServiceState.Size = new System.Drawing.Size(97, 22);
            this.btnServiceState.Text = "服务状态设置";
            this.btnServiceState.Click += new System.EventHandler(this.btnServiceState_Click);
            // 
            // btnUISetting
            // 
            this.btnUISetting.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.UI;
            this.btnUISetting.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUISetting.Name = "btnUISetting";
            this.btnUISetting.Size = new System.Drawing.Size(97, 22);
            this.btnUISetting.Text = "日志界面设置";
            this.btnUISetting.Click += new System.EventHandler(this.btnUISetting_Click);
            // 
            // btnOutPut
            // 
            this.btnOutPut.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.OUTPUT;
            this.btnOutPut.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOutPut.Name = "btnOutPut";
            this.btnOutPut.Size = new System.Drawing.Size(73, 22);
            this.btnOutPut.Text = "导出日志";
            this.btnOutPut.Click += new System.EventHandler(this.btnOutPut_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.DEBUG;
            this.btnDebug.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(73, 22);
            this.btnDebug.Text = "单条执行";
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.DEBUG;
            this.btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(73, 22);
            this.btnCheck.Text = "状态核查";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.scBasic);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 620);
            this.panel1.TabIndex = 1;
            // 
            // scBasic
            // 
            this.scBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBasic.Enabled = false;
            this.scBasic.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scBasic.IsSplitterFixed = true;
            this.scBasic.Location = new System.Drawing.Point(0, 0);
            this.scBasic.Name = "scBasic";
            this.scBasic.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scBasic.Panel1
            // 
            this.scBasic.Panel1.Controls.Add(this.gboxSearch);
            // 
            // scBasic.Panel2
            // 
            this.scBasic.Panel2.Controls.Add(this.scShown);
            this.scBasic.Size = new System.Drawing.Size(993, 620);
            this.scBasic.SplitterDistance = 100;
            this.scBasic.TabIndex = 3;
            this.scBasic.Visible = false;
            // 
            // gboxSearch
            // 
            this.gboxSearch.Controls.Add(this.tlpSearch);
            this.gboxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxSearch.Location = new System.Drawing.Point(0, 0);
            this.gboxSearch.Name = "gboxSearch";
            this.gboxSearch.Size = new System.Drawing.Size(993, 100);
            this.gboxSearch.TabIndex = 0;
            this.gboxSearch.TabStop = false;
            this.gboxSearch.Text = "筛选条件";
            // 
            // tlpSearch
            // 
            this.tlpSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpSearch.ColumnCount = 8;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSearch.Controls.Add(this.label7, 0, 0);
            this.tlpSearch.Controls.Add(this.cbxAddress, 1, 0);
            this.tlpSearch.Controls.Add(this.label1, 2, 0);
            this.tlpSearch.Controls.Add(this.txtAccount, 3, 0);
            this.tlpSearch.Controls.Add(this.label8, 4, 0);
            this.tlpSearch.Controls.Add(this.cbxVoucherType, 5, 0);
            this.tlpSearch.Controls.Add(this.label2, 6, 0);
            this.tlpSearch.Controls.Add(this.txtOrder, 7, 0);
            this.tlpSearch.Controls.Add(this.label3, 0, 1);
            this.tlpSearch.Controls.Add(this.cbxState, 1, 1);
            this.tlpSearch.Controls.Add(this.label4, 2, 1);
            this.tlpSearch.Controls.Add(this.cbxType, 3, 1);
            this.tlpSearch.Controls.Add(this.label5, 4, 1);
            this.tlpSearch.Controls.Add(this.dtpStart, 5, 1);
            this.tlpSearch.Controls.Add(this.label6, 6, 1);
            this.tlpSearch.Controls.Add(this.dtpEnd, 7, 1);
            this.tlpSearch.Controls.Add(this.btnSearch, 3, 2);
            this.tlpSearch.Controls.Add(this.cbxRefresh, 4, 2);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 17);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 3;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch.Size = new System.Drawing.Size(987, 80);
            this.tlpSearch.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(5, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "数据服务器：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAddress
            // 
            this.cbxAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(103, 5);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(139, 20);
            this.cbxAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(250, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "协同账套：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccount
            // 
            this.txtAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAccount.Location = new System.Drawing.Point(348, 5);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(139, 21);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccount_KeyPress);
            this.txtAccount.Enter += new System.EventHandler(this.txtAccount_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(495, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 24);
            this.label8.TabIndex = 10;
            this.label8.Text = "单据类型：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxVoucherType
            // 
            this.cbxVoucherType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVoucherType.FormattingEnabled = true;
            this.cbxVoucherType.Location = new System.Drawing.Point(593, 5);
            this.cbxVoucherType.Name = "cbxVoucherType";
            this.cbxVoucherType.Size = new System.Drawing.Size(139, 20);
            this.cbxVoucherType.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(740, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "关键字：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrder
            // 
            this.txtOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrder.Location = new System.Drawing.Point(838, 5);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(144, 21);
            this.txtOrder.TabIndex = 2;
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrder_KeyPress);
            this.txtOrder.Enter += new System.EventHandler(this.txtOrder_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "协同状态：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxState
            // 
            this.cbxState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(103, 31);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(139, 20);
            this.cbxState.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(250, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "协同类型：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxType
            // 
            this.cbxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(348, 31);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(139, 20);
            this.cbxType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(495, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "开始时间：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStart
            // 
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStart.Location = new System.Drawing.Point(593, 31);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.RightToLeftLayout = true;
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(139, 21);
            this.dtpStart.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(740, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "结束时间：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEnd.Location = new System.Drawing.Point(838, 31);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.RightToLeftLayout = true;
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(144, 21);
            this.dtpEnd.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(395, 55);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(50, 1, 50, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(45, 22);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxRefresh
            // 
            this.cbxRefresh.AutoSize = true;
            this.cbxRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRefresh.Location = new System.Drawing.Point(495, 57);
            this.cbxRefresh.Name = "cbxRefresh";
            this.cbxRefresh.Size = new System.Drawing.Size(90, 18);
            this.cbxRefresh.TabIndex = 8;
            this.cbxRefresh.Text = "自动刷新";
            this.cbxRefresh.UseVisualStyleBackColor = true;
            this.cbxRefresh.CheckedChanged += new System.EventHandler(this.cbxRefresh_CheckedChanged);
            // 
            // scShown
            // 
            this.scShown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scShown.Enabled = false;
            this.scShown.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scShown.Location = new System.Drawing.Point(0, 0);
            this.scShown.Name = "scShown";
            // 
            // scShown.Panel1
            // 
            this.scShown.Panel1.Controls.Add(this.gbxList);
            // 
            // scShown.Panel2
            // 
            this.scShown.Panel2.Controls.Add(this.scDetail);
            this.scShown.Size = new System.Drawing.Size(993, 516);
            this.scShown.SplitterDistance = 280;
            this.scShown.TabIndex = 0;
            this.scShown.Visible = false;
            this.scShown.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scShown_SplitterMoved);
            // 
            // gbxList
            // 
            this.gbxList.Controls.Add(this.dgvList);
            this.gbxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxList.Location = new System.Drawing.Point(0, 0);
            this.gbxList.Name = "gbxList";
            this.gbxList.Size = new System.Drawing.Size(280, 516);
            this.gbxList.TabIndex = 0;
            this.gbxList.TabStop = false;
            this.gbxList.Text = "任务列表";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHOpera,
            this.colHID,
            this.colHNumber,
            this.colHType,
            this.colHAcccode,
            this.colHAddress,
            this.colHAccid,
            this.colHAccname,
            this.colHOrderType,
            this.colHOrder,
            this.colHName,
            this.colHStart,
            this.colHEnd,
            this.colHState});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(274, 496);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvList_DataBindingComplete);
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            this.dgvList.MouseEnter += new System.EventHandler(this.dgvList_MouseEnter);
            // 
            // colHOpera
            // 
            this.colHOpera.DataPropertyName = "Opname";
            this.colHOpera.Frozen = true;
            this.colHOpera.HeaderText = "操作";
            this.colHOpera.Name = "colHOpera";
            this.colHOpera.ReadOnly = true;
            this.colHOpera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHOpera.Width = 80;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "Id";
            this.colHID.HeaderText = "ID";
            this.colHID.Name = "colHID";
            this.colHID.ReadOnly = true;
            this.colHID.Visible = false;
            this.colHID.Width = 40;
            // 
            // colHNumber
            // 
            this.colHNumber.DataPropertyName = "Cserialno";
            this.colHNumber.HeaderText = "序号";
            this.colHNumber.Name = "colHNumber";
            this.colHNumber.ReadOnly = true;
            this.colHNumber.Width = 70;
            // 
            // colHType
            // 
            this.colHType.DataPropertyName = "Croutetype";
            this.colHType.HeaderText = "同步类型";
            this.colHType.Name = "colHType";
            this.colHType.ReadOnly = true;
            // 
            // colHAcccode
            // 
            this.colHAcccode.DataPropertyName = "Caccid";
            this.colHAcccode.HeaderText = "账套代码";
            this.colHAcccode.Name = "colHAcccode";
            this.colHAcccode.ReadOnly = true;
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Caddress";
            this.colHAddress.HeaderText = "数据服务器";
            this.colHAddress.Name = "colHAddress";
            this.colHAddress.ReadOnly = true;
            // 
            // colHAccid
            // 
            this.colHAccid.DataPropertyName = "Cacc_Id";
            this.colHAccid.HeaderText = "账套号";
            this.colHAccid.Name = "colHAccid";
            this.colHAccid.ReadOnly = true;
            this.colHAccid.Width = 80;
            // 
            // colHAccname
            // 
            this.colHAccname.DataPropertyName = "Cacc_Name";
            this.colHAccname.HeaderText = "账套名";
            this.colHAccname.Name = "colHAccname";
            this.colHAccname.ReadOnly = true;
            this.colHAccname.Width = 120;
            // 
            // colHOrderType
            // 
            this.colHOrderType.DataPropertyName = "Cvouchertype";
            this.colHOrderType.HeaderText = "单据类型";
            this.colHOrderType.Name = "colHOrderType";
            this.colHOrderType.ReadOnly = true;
            // 
            // colHOrder
            // 
            this.colHOrder.DataPropertyName = "Cvoucherno";
            this.colHOrder.HeaderText = "单据号/关键字";
            this.colHOrder.Name = "colHOrder";
            this.colHOrder.ReadOnly = true;
            this.colHOrder.Width = 120;
            // 
            // colHName
            // 
            this.colHName.DataPropertyName = "CDataName";
            this.colHName.HeaderText = "档案名称";
            this.colHName.Name = "colHName";
            this.colHName.ReadOnly = true;
            this.colHName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHName.Width = 120;
            // 
            // colHStart
            // 
            this.colHStart.DataPropertyName = "Starttime";
            this.colHStart.HeaderText = "开始时间";
            this.colHStart.Name = "colHStart";
            this.colHStart.ReadOnly = true;
            this.colHStart.Width = 120;
            // 
            // colHEnd
            // 
            this.colHEnd.DataPropertyName = "Endtime";
            this.colHEnd.HeaderText = "结束时间";
            this.colHEnd.Name = "colHEnd";
            this.colHEnd.ReadOnly = true;
            this.colHEnd.Width = 120;
            // 
            // colHState
            // 
            this.colHState.DataPropertyName = "Cstatus";
            this.colHState.HeaderText = "协同状态";
            this.colHState.Name = "colHState";
            this.colHState.ReadOnly = true;
            this.colHState.Width = 80;
            // 
            // scDetail
            // 
            this.scDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scDetail.Location = new System.Drawing.Point(0, 0);
            this.scDetail.Name = "scDetail";
            this.scDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDetail.Panel1
            // 
            this.scDetail.Panel1.Controls.Add(this.gbxTask);
            // 
            // scDetail.Panel2
            // 
            this.scDetail.Panel2.Controls.Add(this.gbxDetail);
            this.scDetail.Size = new System.Drawing.Size(709, 516);
            this.scDetail.SplitterDistance = 220;
            this.scDetail.TabIndex = 0;
            this.scDetail.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scDetail_SplitterMoved);
            // 
            // gbxTask
            // 
            this.gbxTask.Controls.Add(this.tvTask);
            this.gbxTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTask.Location = new System.Drawing.Point(0, 0);
            this.gbxTask.Name = "gbxTask";
            this.gbxTask.Size = new System.Drawing.Size(709, 220);
            this.gbxTask.TabIndex = 0;
            this.gbxTask.TabStop = false;
            this.gbxTask.Tag = "";
            this.gbxTask.Text = "任务结构";
            // 
            // tvTask
            // 
            this.tvTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTask.Location = new System.Drawing.Point(3, 17);
            this.tvTask.Name = "tvTask";
            this.tvTask.Size = new System.Drawing.Size(703, 200);
            this.tvTask.TabIndex = 0;
            this.tvTask.Tag = "";
            this.tvTask.MouseEnter += new System.EventHandler(this.tvTask_MouseEnter);
            this.tvTask.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTask_NodeMouseClick);
            // 
            // gbxDetail
            // 
            this.gbxDetail.Controls.Add(this.dgvDetail);
            this.gbxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetail.Location = new System.Drawing.Point(0, 0);
            this.gbxDetail.Name = "gbxDetail";
            this.gbxDetail.Size = new System.Drawing.Size(709, 292);
            this.gbxDetail.TabIndex = 0;
            this.gbxDetail.TabStop = false;
            this.gbxDetail.Text = "详细信息";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBOpera,
            this.colBAutoID,
            this.colBID,
            this.colBRow,
            this.colBAcccode,
            this.colBAddress,
            this.colBAccid,
            this.colBAccname,
            this.colBOrderType,
            this.colBOrder,
            this.colBName,
            this.colBCpk,
            this.colBCpkname,
            this.colBInsert,
            this.colBCreate,
            this.colBError,
            this.colBState,
            this.colBHandwork,
            this.colBVerify,
            this.colBErrNum,
            this.colBWay,
            this.colBFatherId});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(703, 272);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetail_DataBindingComplete);
            this.dgvDetail.MouseEnter += new System.EventHandler(this.dgvDetail_MouseEnter);
            // 
            // colBOpera
            // 
            this.colBOpera.DataPropertyName = "Opname";
            this.colBOpera.Frozen = true;
            this.colBOpera.HeaderText = "操作";
            this.colBOpera.Name = "colBOpera";
            this.colBOpera.ReadOnly = true;
            this.colBOpera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBOpera.Width = 80;
            // 
            // colBAutoID
            // 
            this.colBAutoID.DataPropertyName = "Autoid";
            this.colBAutoID.HeaderText = "子表ID";
            this.colBAutoID.Name = "colBAutoID";
            this.colBAutoID.ReadOnly = true;
            this.colBAutoID.Visible = false;
            this.colBAutoID.Width = 40;
            // 
            // colBID
            // 
            this.colBID.DataPropertyName = "Id";
            this.colBID.HeaderText = "主表ID";
            this.colBID.Name = "colBID";
            this.colBID.ReadOnly = true;
            this.colBID.Visible = false;
            this.colBID.Width = 40;
            // 
            // colBRow
            // 
            this.colBRow.DataPropertyName = "Ilineno";
            this.colBRow.HeaderText = "行号";
            this.colBRow.Name = "colBRow";
            this.colBRow.ReadOnly = true;
            this.colBRow.Width = 70;
            // 
            // colBAcccode
            // 
            this.colBAcccode.DataPropertyName = "Accid";
            this.colBAcccode.HeaderText = "账套代码";
            this.colBAcccode.Name = "colBAcccode";
            this.colBAcccode.ReadOnly = true;
            // 
            // colBAddress
            // 
            this.colBAddress.DataPropertyName = "Caddress";
            this.colBAddress.HeaderText = "数据服务器";
            this.colBAddress.Name = "colBAddress";
            this.colBAddress.ReadOnly = true;
            // 
            // colBAccid
            // 
            this.colBAccid.DataPropertyName = "Acc_id";
            this.colBAccid.HeaderText = "账套号";
            this.colBAccid.Name = "colBAccid";
            this.colBAccid.ReadOnly = true;
            this.colBAccid.Width = 80;
            // 
            // colBAccname
            // 
            this.colBAccname.DataPropertyName = "Accname";
            this.colBAccname.HeaderText = "账套名";
            this.colBAccname.Name = "colBAccname";
            this.colBAccname.ReadOnly = true;
            this.colBAccname.Width = 120;
            // 
            // colBOrderType
            // 
            this.colBOrderType.DataPropertyName = "Cvouchertypename";
            this.colBOrderType.HeaderText = "单据类型";
            this.colBOrderType.Name = "colBOrderType";
            this.colBOrderType.ReadOnly = true;
            this.colBOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBOrder
            // 
            this.colBOrder.DataPropertyName = "Cvoucherno";
            this.colBOrder.HeaderText = "单据号/关键字";
            this.colBOrder.Name = "colBOrder";
            this.colBOrder.ReadOnly = true;
            this.colBOrder.Width = 120;
            // 
            // colBName
            // 
            this.colBName.DataPropertyName = "CDataName";
            this.colBName.HeaderText = "档案名称";
            this.colBName.Name = "colBName";
            this.colBName.ReadOnly = true;
            this.colBName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBName.Width = 120;
            // 
            // colBCpk
            // 
            this.colBCpk.DataPropertyName = "Cpk";
            this.colBCpk.HeaderText = "更新方案号";
            this.colBCpk.Name = "colBCpk";
            this.colBCpk.ReadOnly = true;
            this.colBCpk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBCpkname
            // 
            this.colBCpkname.DataPropertyName = "CpkName";
            this.colBCpkname.HeaderText = "更新方案名";
            this.colBCpkname.Name = "colBCpkname";
            this.colBCpkname.ReadOnly = true;
            this.colBCpkname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBInsert
            // 
            this.colBInsert.DataPropertyName = "Dinputtime";
            this.colBInsert.HeaderText = "插入时间";
            this.colBInsert.Name = "colBInsert";
            this.colBInsert.ReadOnly = true;
            this.colBInsert.Width = 120;
            // 
            // colBCreate
            // 
            this.colBCreate.DataPropertyName = "Dmaketime";
            this.colBCreate.HeaderText = "生成时间";
            this.colBCreate.Name = "colBCreate";
            this.colBCreate.ReadOnly = true;
            this.colBCreate.Width = 120;
            // 
            // colBError
            // 
            this.colBError.DataPropertyName = "Cerrordesc";
            this.colBError.HeaderText = "错误描述";
            this.colBError.Name = "colBError";
            this.colBError.ReadOnly = true;
            this.colBError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBError.Width = 250;
            // 
            // colBState
            // 
            this.colBState.DataPropertyName = "Cstatus";
            this.colBState.HeaderText = "协同状态";
            this.colBState.Name = "colBState";
            this.colBState.ReadOnly = true;
            this.colBState.Width = 80;
            // 
            // colBHandwork
            // 
            this.colBHandwork.DataPropertyName = "Ismanualc";
            this.colBHandwork.HeaderText = "手工单";
            this.colBHandwork.Name = "colBHandwork";
            this.colBHandwork.ReadOnly = true;
            this.colBHandwork.Width = 80;
            // 
            // colBVerify
            // 
            this.colBVerify.DataPropertyName = "Isauditc";
            this.colBVerify.HeaderText = "自动审核";
            this.colBVerify.Name = "colBVerify";
            this.colBVerify.ReadOnly = true;
            this.colBVerify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBVerify.Width = 80;
            // 
            // colBErrNum
            // 
            this.colBErrNum.DataPropertyName = "Errortimes";
            this.colBErrNum.HeaderText = "错误次数";
            this.colBErrNum.Name = "colBErrNum";
            this.colBErrNum.ReadOnly = true;
            this.colBErrNum.Width = 80;
            // 
            // colBWay
            // 
            this.colBWay.DataPropertyName = "Cdealmothedc";
            this.colBWay.HeaderText = "处理方式";
            this.colBWay.Name = "colBWay";
            this.colBWay.ReadOnly = true;
            this.colBWay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBWay.Width = 80;
            // 
            // colBFatherId
            // 
            this.colBFatherId.DataPropertyName = "Fatherid";
            this.colBFatherId.HeaderText = "父ID";
            this.colBFatherId.Name = "colBFatherId";
            this.colBFatherId.ReadOnly = true;
            this.colBFatherId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBFatherId.Visible = false;
            this.colBFatherId.Width = 40;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblServiceImage,
            this.lblServiceState});
            this.ssMain.Location = new System.Drawing.Point(0, 651);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1017, 22);
            this.ssMain.TabIndex = 2;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblServiceImage
            // 
            this.lblServiceImage.Image = global::U8.Interface.Bus.ApiService.Setting.Properties.Resources.STOP;
            this.lblServiceImage.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblServiceImage.Name = "lblServiceImage";
            this.lblServiceImage.Size = new System.Drawing.Size(81, 17);
            this.lblServiceImage.Text = "服务状态：";
            // 
            // lblServiceState
            // 
            this.lblServiceState.Name = "lblServiceState";
            this.lblServiceState.Size = new System.Drawing.Size(29, 17);
            this.lblServiceState.Text = "停用";
            // 
            // tmrSearch
            // 
            this.tmrSearch.Interval = 1000;
            this.tmrSearch.Tick += new System.EventHandler(this.tmrSearch_Tick);
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.DataPropertyName = "Opname";
            this.dataGridViewDisableButtonColumn1.Frozen = true;
            this.dataGridViewDisableButtonColumn1.HeaderText = "操作";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewDisableButtonColumn1.Width = 80;
            // 
            // dataGridViewDisableButtonColumn2
            // 
            this.dataGridViewDisableButtonColumn2.DataPropertyName = "Opname";
            this.dataGridViewDisableButtonColumn2.Frozen = true;
            this.dataGridViewDisableButtonColumn2.HeaderText = "操作";
            this.dataGridViewDisableButtonColumn2.Name = "dataGridViewDisableButtonColumn2";
            this.dataGridViewDisableButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewDisableButtonColumn2.Width = 80;
            // 
            // FrmMainwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 673);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsMain);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmMainwork";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同步平台日志";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMainwork_Load);
            this.Shown += new System.EventHandler(this.FrmMainwork_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainwork_FormClosing);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.scBasic.Panel1.ResumeLayout(false);
            this.scBasic.Panel2.ResumeLayout(false);
            this.scBasic.ResumeLayout(false);
            this.gboxSearch.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.scShown.Panel1.ResumeLayout(false);
            this.scShown.Panel2.ResumeLayout(false);
            this.scShown.ResumeLayout(false);
            this.gbxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.scDetail.Panel1.ResumeLayout(false);
            this.scDetail.Panel2.ResumeLayout(false);
            this.scDetail.ResumeLayout(false);
            this.gbxTask.ResumeLayout(false);
            this.gbxDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnConnectSetting;
        private System.Windows.Forms.ToolStripButton btnServiceState;
        private System.Windows.Forms.ToolStripButton btnDebug;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer scBasic;
        private System.Windows.Forms.GroupBox gboxSearch;
        private System.Windows.Forms.SplitContainer scShown;
        private System.Windows.Forms.GroupBox gbxList;
        private System.Windows.Forms.SplitContainer scDetail;
        private System.Windows.Forms.GroupBox gbxTask;
        private System.Windows.Forms.GroupBox gbxDetail;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TreeView tvTask;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblServiceImage;
        private System.Windows.Forms.ToolStripStatusLabel lblServiceState;
        private System.Windows.Forms.Timer tmrSearch;
        private System.Windows.Forms.ToolStripButton btnUISetting;
        private System.Windows.Forms.CheckBox cbxRefresh;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn2;
        private DataGridViewDisableButtonColumn colHOpera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAcccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAccid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAccname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHState;
        private DataGridViewDisableButtonColumn colBOpera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAcccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAccid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBAccname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCpk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCpkname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBInsert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHandwork;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBVerify;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBErrNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBFatherId;
        private System.Windows.Forms.ToolStripButton btnOutPut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.ComboBox cbxVoucherType;
        private System.Windows.Forms.ToolStripButton btnCheck;
    }
}