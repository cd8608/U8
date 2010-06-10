namespace U8.Interface.Bus.ApiService.Setting
{
    partial class FrmOutput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbOutputView = new System.Windows.Forms.GroupBox();
            this.tcOutputInfo = new System.Windows.Forms.TabControl();
            this.tpList = new System.Windows.Forms.TabPage();
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
            this.tpDetails = new System.Windows.Forms.TabPage();
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridViewDisableButtonColumn1 = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.dataGridViewDisableButtonColumn2 = new U8.Interface.Bus.ApiService.Setting.DataGridViewDisableButtonColumn();
            this.gbOutputView.SuspendLayout();
            this.tcOutputInfo.SuspendLayout();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOutputView
            // 
            this.gbOutputView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutputView.Controls.Add(this.tcOutputInfo);
            this.gbOutputView.Location = new System.Drawing.Point(12, 12);
            this.gbOutputView.Name = "gbOutputView";
            this.gbOutputView.Size = new System.Drawing.Size(818, 450);
            this.gbOutputView.TabIndex = 0;
            this.gbOutputView.TabStop = false;
            this.gbOutputView.Text = "导出预览";
            // 
            // tcOutputInfo
            // 
            this.tcOutputInfo.Controls.Add(this.tpList);
            this.tcOutputInfo.Controls.Add(this.tpDetails);
            this.tcOutputInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOutputInfo.Location = new System.Drawing.Point(3, 17);
            this.tcOutputInfo.Name = "tcOutputInfo";
            this.tcOutputInfo.SelectedIndex = 0;
            this.tcOutputInfo.Size = new System.Drawing.Size(812, 430);
            this.tcOutputInfo.TabIndex = 0;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.dgvList);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(804, 404);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "任务列表";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
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
            this.dgvList.Location = new System.Drawing.Point(3, 3);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.Size = new System.Drawing.Size(798, 398);
            this.dgvList.TabIndex = 1;
            // 
            // colHOpera
            // 
            this.colHOpera.DataPropertyName = "Opname";
            this.colHOpera.Frozen = true;
            this.colHOpera.HeaderText = "操作";
            this.colHOpera.Name = "colHOpera";
            this.colHOpera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHOpera.Visible = false;
            this.colHOpera.Width = 80;
            // 
            // colHID
            // 
            this.colHID.DataPropertyName = "Id";
            this.colHID.HeaderText = "任务ID";
            this.colHID.Name = "colHID";
            this.colHID.Width = 80;
            // 
            // colHNumber
            // 
            this.colHNumber.DataPropertyName = "Cserialno";
            this.colHNumber.HeaderText = "序号";
            this.colHNumber.Name = "colHNumber";
            this.colHNumber.Width = 60;
            // 
            // colHType
            // 
            this.colHType.DataPropertyName = "Croutetype";
            this.colHType.HeaderText = "同步类型";
            this.colHType.Name = "colHType";
            // 
            // colHAcccode
            // 
            this.colHAcccode.DataPropertyName = "Caccid";
            this.colHAcccode.HeaderText = "账套代码";
            this.colHAcccode.Name = "colHAcccode";
            // 
            // colHAddress
            // 
            this.colHAddress.DataPropertyName = "Caddress";
            this.colHAddress.HeaderText = "数据服务器";
            this.colHAddress.Name = "colHAddress";
            // 
            // colHAccid
            // 
            this.colHAccid.DataPropertyName = "Cacc_Id";
            this.colHAccid.HeaderText = "账套号";
            this.colHAccid.Name = "colHAccid";
            this.colHAccid.Width = 80;
            // 
            // colHAccname
            // 
            this.colHAccname.DataPropertyName = "Cacc_Name";
            this.colHAccname.HeaderText = "账套名";
            this.colHAccname.Name = "colHAccname";
            this.colHAccname.Width = 120;
            // 
            // colHOrderType
            // 
            this.colHOrderType.DataPropertyName = "Cvouchertype";
            this.colHOrderType.HeaderText = "单据类型";
            this.colHOrderType.Name = "colHOrderType";
            // 
            // colHOrder
            // 
            this.colHOrder.DataPropertyName = "Cvoucherno";
            this.colHOrder.HeaderText = "单据号/关键字";
            this.colHOrder.Name = "colHOrder";
            this.colHOrder.Width = 120;
            // 
            // colHName
            // 
            this.colHName.DataPropertyName = "CDataName";
            this.colHName.HeaderText = "档案名称";
            this.colHName.Name = "colHName";
            this.colHName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHName.Visible = false;
            this.colHName.Width = 120;
            // 
            // colHStart
            // 
            this.colHStart.DataPropertyName = "Starttime";
            this.colHStart.HeaderText = "开始时间";
            this.colHStart.Name = "colHStart";
            this.colHStart.Width = 120;
            // 
            // colHEnd
            // 
            this.colHEnd.DataPropertyName = "Endtime";
            this.colHEnd.HeaderText = "结束时间";
            this.colHEnd.Name = "colHEnd";
            this.colHEnd.Width = 120;
            // 
            // colHState
            // 
            this.colHState.DataPropertyName = "Cstatus";
            this.colHState.HeaderText = "协同状态";
            this.colHState.Name = "colHState";
            this.colHState.Width = 80;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.dgvDetail);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(798, 398);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "任务明细";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
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
            this.dgvDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(792, 392);
            this.dgvDetail.TabIndex = 1;
            // 
            // colBOpera
            // 
            this.colBOpera.DataPropertyName = "Opname";
            this.colBOpera.Frozen = true;
            this.colBOpera.HeaderText = "操作";
            this.colBOpera.Name = "colBOpera";
            this.colBOpera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBOpera.Visible = false;
            this.colBOpera.Width = 60;
            // 
            // colBAutoID
            // 
            this.colBAutoID.DataPropertyName = "Autoid";
            this.colBAutoID.HeaderText = "子表ID";
            this.colBAutoID.Name = "colBAutoID";
            this.colBAutoID.Visible = false;
            this.colBAutoID.Width = 40;
            // 
            // colBID
            // 
            this.colBID.DataPropertyName = "Id";
            this.colBID.HeaderText = "任务ID";
            this.colBID.Name = "colBID";
            this.colBID.Width = 80;
            // 
            // colBRow
            // 
            this.colBRow.DataPropertyName = "Ilineno";
            this.colBRow.HeaderText = "行号";
            this.colBRow.Name = "colBRow";
            this.colBRow.Width = 70;
            // 
            // colBAcccode
            // 
            this.colBAcccode.DataPropertyName = "Accid";
            this.colBAcccode.HeaderText = "账套代码";
            this.colBAcccode.Name = "colBAcccode";
            // 
            // colBAddress
            // 
            this.colBAddress.DataPropertyName = "Caddress";
            this.colBAddress.HeaderText = "数据服务器";
            this.colBAddress.Name = "colBAddress";
            // 
            // colBAccid
            // 
            this.colBAccid.DataPropertyName = "Cacc_Id";
            this.colBAccid.HeaderText = "账套号";
            this.colBAccid.Name = "colBAccid";
            this.colBAccid.Width = 80;
            // 
            // colBAccname
            // 
            this.colBAccname.DataPropertyName = "Cacc_Name";
            this.colBAccname.HeaderText = "账套名";
            this.colBAccname.Name = "colBAccname";
            this.colBAccname.Width = 120;
            // 
            // colBOrderType
            // 
            this.colBOrderType.DataPropertyName = "Cvouchertype";
            this.colBOrderType.HeaderText = "单据类型";
            this.colBOrderType.Name = "colBOrderType";
            this.colBOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBOrder
            // 
            this.colBOrder.DataPropertyName = "Cvoucherno";
            this.colBOrder.HeaderText = "单据号/关键字";
            this.colBOrder.Name = "colBOrder";
            this.colBOrder.Width = 120;
            // 
            // colBName
            // 
            this.colBName.DataPropertyName = "CDataName";
            this.colBName.HeaderText = "档案名称";
            this.colBName.Name = "colBName";
            this.colBName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBName.Visible = false;
            this.colBName.Width = 120;
            // 
            // colBCpk
            // 
            this.colBCpk.DataPropertyName = "Cpk";
            this.colBCpk.HeaderText = "更新方案号";
            this.colBCpk.Name = "colBCpk";
            this.colBCpk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBCpk.Visible = false;
            // 
            // colBCpkname
            // 
            this.colBCpkname.DataPropertyName = "CpkName";
            this.colBCpkname.HeaderText = "更新方案名";
            this.colBCpkname.Name = "colBCpkname";
            this.colBCpkname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBInsert
            // 
            this.colBInsert.DataPropertyName = "Dinputtime";
            this.colBInsert.HeaderText = "插入时间";
            this.colBInsert.Name = "colBInsert";
            this.colBInsert.Width = 120;
            // 
            // colBCreate
            // 
            this.colBCreate.DataPropertyName = "Dmaketime";
            this.colBCreate.HeaderText = "生成时间";
            this.colBCreate.Name = "colBCreate";
            this.colBCreate.Width = 120;
            // 
            // colBError
            // 
            this.colBError.DataPropertyName = "Cerrordesc";
            this.colBError.HeaderText = "错误描述";
            this.colBError.Name = "colBError";
            this.colBError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBError.Width = 250;
            // 
            // colBState
            // 
            this.colBState.DataPropertyName = "Cstatus";
            this.colBState.HeaderText = "协同状态";
            this.colBState.Name = "colBState";
            this.colBState.Width = 80;
            // 
            // colBHandwork
            // 
            this.colBHandwork.DataPropertyName = "Ismanualc";
            this.colBHandwork.HeaderText = "是否手工单";
            this.colBHandwork.Name = "colBHandwork";
            // 
            // colBVerify
            // 
            this.colBVerify.DataPropertyName = "Isauditc";
            this.colBVerify.HeaderText = "是否审核";
            this.colBVerify.Name = "colBVerify";
            this.colBVerify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBVerify.Width = 80;
            // 
            // colBErrNum
            // 
            this.colBErrNum.DataPropertyName = "Errortimes";
            this.colBErrNum.HeaderText = "错误次数";
            this.colBErrNum.Name = "colBErrNum";
            this.colBErrNum.Width = 80;
            // 
            // colBWay
            // 
            this.colBWay.DataPropertyName = "Cdealmothedc";
            this.colBWay.HeaderText = "处理方式";
            this.colBWay.Name = "colBWay";
            this.colBWay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBWay.Width = 80;
            // 
            // colBFatherId
            // 
            this.colBFatherId.DataPropertyName = "Fatherid";
            this.colBFatherId.HeaderText = "父ID";
            this.colBFatherId.Name = "colBFatherId";
            this.colBFatherId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBFatherId.Visible = false;
            this.colBFatherId.Width = 40;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Location = new System.Drawing.Point(284, 477);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(484, 477);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.DataPropertyName = "Opname";
            this.dataGridViewDisableButtonColumn1.Frozen = true;
            this.dataGridViewDisableButtonColumn1.HeaderText = "操作";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn1.Visible = false;
            this.dataGridViewDisableButtonColumn1.Width = 80;
            // 
            // dataGridViewDisableButtonColumn2
            // 
            this.dataGridViewDisableButtonColumn2.DataPropertyName = "Opname";
            this.dataGridViewDisableButtonColumn2.Frozen = true;
            this.dataGridViewDisableButtonColumn2.HeaderText = "操作";
            this.dataGridViewDisableButtonColumn2.Name = "dataGridViewDisableButtonColumn2";
            this.dataGridViewDisableButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn2.Visible = false;
            this.dataGridViewDisableButtonColumn2.Width = 60;
            // 
            // FrmOutput
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(842, 503);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbOutputView);
            this.Name = "FrmOutput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出日志";
            this.Load += new System.EventHandler(this.FrmOutput_Load);
            this.gbOutputView.ResumeLayout(false);
            this.tcOutputInfo.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOutputView;
        private System.Windows.Forms.TabControl tcOutputInfo;
        private System.Windows.Forms.TabPage tpList;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridView dgvDetail;
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
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn2;

    }
}