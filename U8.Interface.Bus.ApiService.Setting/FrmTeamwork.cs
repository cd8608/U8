using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using U8.Interface.Bus.DBUtility;
using U8.Interface.Bus.ApiService.DAL; 
namespace U8.Interface.Bus.ApiService.Setting
{
    public partial class FrmTeamwork : Form
    {
        private bool bInit;
        private int iSecond;
        private int curRow;
        private Model.ShowLog curLog;
        private Model.ShowLogDt curLogDt;
        private List<Model.ShowLog> lstLog;
        private List<Model.ShowLogDt> lstLogDt;
        private Dictionary<string, string> dicLog;
        private Dictionary<string, string> dicLogDt;
        private string strAddress, strAccID, strVoucherType, strVoucherNo;



        /// <summary>
        /// 
        /// </summary>
        public FrmTeamwork()
        {
            InitializeComponent();

            strAddress = string.Empty;
            strAccID = string.Empty;
            strVoucherType = string.Empty;
            strVoucherNo = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cAddress"></param>
        /// <param name="Acc_ID"></param>
        /// <param name="cOrderType"></param>
        /// <param name="cCode"></param>
        public FrmTeamwork(string cAddress, string Acc_ID, string cOrderType, string cCode)
        {
            InitializeComponent();

            strAddress = cAddress.ToUpper();
            strAccID = Acc_ID;
            strVoucherType = cOrderType;
            strVoucherNo = cCode;
        }

        private void FrmTeamwork_Load(object sender, EventArgs e)
        {
            this.Hide();
#if DEBUG
            btnDebug.Visible = true;
#endif
            
            bInit = true;
            InitForm();

        }

        private void FrmTeamwork_Shown(object sender, EventArgs e)
        {
            if (!Common.bIsValid)
            {
                Application.Exit();
                return;
            }

            bInit = false;
            if (!CheckConnect()) return;
            InitData();

            scShown.Visible = true;
            scShown.Enabled = true;
            scBasic.Visible = true;
            scBasic.Enabled = true;
            this.Opacity = 1;
            this.ShowInTaskbar = true;
            this.Enabled = true;
            this.Show();

            if (VerifyU8Button())
            {
                btnSearch_Click(sender, e);
                this.Refresh();
            }
        }

        private void FrmTeamwork_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Opacity = 0;
            //this.Refresh();
        }


        private void btnConnectSetting_Click(object sender, EventArgs e)
        {
            using (Form f = new FrmConnectSetting())
            {
                f.ShowDialog();
            }
        }

        private void btnServiceState_Click(object sender, EventArgs e)
        {
            if (!Common.bIsLinked)
            {
                Common.MessageShow("请先设置服务链接");
                return;
            }

            using (Form f = new FrmServiceSetting())
            {
                f.ShowDialog();
            }

            if (Common.bIsLinked)
                btnSearch_Click(sender, e);
        }

        private void btnUISetting_Click(object sender, EventArgs e)
        {
            using (Form f = new FrmUISetting())
            {
                f.ShowDialog();
            }

            RefreshForm();
            this.Refresh();
        }

        private void btnOutPut_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                Common.MessageShow("没有需要导出的记录");
                return;
            }

            OutPut2Excel();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Exec_Task();
        }

        private void Exec_Cor(object sender, EventArgs e)
        {
            //U8TeamworkService服务的LookFor()方法
            try
            {
                string strService = DbHelperSQL.GetSingle("SELECT CONVERT(NVARCHAR(200),SERVERPROPERTY('ServerName'))").ToString();
                string strDBName = DbHelperSQL.GetSingle("SELECT CONVERT(NVARCHAR(200),DB_NAME())").ToString();
                DbHelperSQL.ExecuteSql("EXEC PROC_HY_DZ_K7_INITITEMT '" + strService + "','" + strDBName + "',0 ");
            }
            catch { }
            try
            {
                BLL.TaskOperator sy = new BLL.TaskOperator();
                BLL.SynergismLog log = new BLL.SynergismLog();
                //List<Model.Synergismlog> llog = log.GetServiceList(" (s.cstatus in ('处理中','未处理')) OR (s.cstatus ='等待中' AND d.cstatus='未审核' AND d.ismanual<>1 AND d.isaudit=1 ) ");
                List<Model.Synergismlog> llog = log.GetServiceList(" (s.cstatus in ('处理中','未处理')) ");
                if (llog.Count < 1) return;
                sy.Run(llog[0]);
            }
            catch (Exception ex)
            {
                Common.MessageShow(ex.Message);
            }
            finally
            {
                btnSearch_Click(sender, e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Exec_Task()
        {
            U8.Interface.Bus.ApiService.BLL.TaskOperator oper = new U8.Interface.Bus.ApiService.BLL.TaskOperator();
            try
            {
                U8.Interface.Bus.ApiService.Model.TaskList tasklist = oper.GetTask();
                if (tasklist.Count > 0)
                {
                    foreach (U8.Interface.Bus.ApiService.Model.Task task in tasklist)
                    {
                        U8.Interface.Bus.ApiService.Model.Synergismlog log = new U8.Interface.Bus.ApiService.Model.Synergismlog();

                        log.Cvouchertype = task.VouchType.CardNo;
                        log.Id = task.id;
                        log.TaskType = task.taskType;
                        log.OPClass = task.VouchType.VoucherClass;

                        if (U8.Interface.Bus.SysInfo.multiThread)
                        {
                            //threadTask = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(oper.Run));
                            //threadTask.Start(task);

                            oper.Run(log);
                        }
                        else
                        {
                            oper.Run(log);
                        }
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(10 * 1000);
                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(U8.Interface.Bus.SysInfo.productName, ex.ToString(), EventLogEntryType.Error, 0, 0);
            }

        }

        private void txtAccount_Enter(object sender, EventArgs e)
        {
            txtAccount.SelectAll();
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtOrder.Focus();
            }
        }

        private void txtOrder_Enter(object sender, EventArgs e)
        {
            txtOrder.SelectAll();
        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cbxState.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetSearchTime();
            Query();
            ShowLogDT();
            GetLogDTTree();
        }

        private void cbxRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRefresh.Checked)
            {
                if (btnSearch.Enabled)
                {
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetListColor();
        }

        private void dgvList_MouseEnter(object sender, EventArgs e)
        {
            dgvList.Focus();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bInit) return;
            if (lstLog == null || lstLog.Count <= 0) return;

            if (e.RowIndex < 0)
            {
                if (e.ColumnIndex <= 0) return;

                SetListField(dicLog, dgvList, e.ColumnIndex);
                Query();
                return;
            }

            if (e.ColumnIndex < 0) return;
            if (dgvList.Columns[e.ColumnIndex].DataPropertyName.ToLower() != "opname") return;
            //if (curLog.Opname != "作废") return;  modified by liuxzha 2015.04.10
            BLL.TaskOperator blldeal;
            if (curLog.Opname == "还原")
            {
                blldeal = new BLL.TaskOperator();
                blldeal.DoRecover(curLog.Id.ToString());
            }
            else if (curLog.Opname == "作废")
            {
                blldeal = new BLL.TaskOperator(); 
                blldeal.DoScrap(curLog.Id.ToString());
            }
            else
            {
                return;
            } 
            curLogDt = null;
            curLog = null;
            curRow = 0;
            Query();
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (bInit) return;
            if (dgvList.SelectedRows.Count >= 1 && dgvList.SelectedRows[0].Index >= 0)
            {
                if (dgvList.SelectedRows[0].Index == curRow) return;
                curRow = dgvList.SelectedRows[0].Index;
                curLog = lstLog.Find(delegate(Model.ShowLog model) { return model.Id == int.Parse(dgvList.SelectedRows[0].Cells["colHID"].Value.ToString()).ToString(); });
                ShowLogDT();
                GetLogDTTree();
            }
        }

        private void tvTask_MouseEnter(object sender, EventArgs e)
        {
            tvTask.Focus();
        }

        private void tvTask_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level == 0) curLogDt = null;
            if (e.Node.Tag == null || !(e.Node.Tag is Model.ShowLogDt)) curLogDt = null; 

            curLogDt = e.Node.Tag as Model.ShowLogDt;
            int index;
            if (curLogDt == null)
                index = 0;
            else
                index = lstLogDt.FindIndex(delegate(Model.ShowLogDt model) { return model.Autoid == curLogDt.Autoid; });
            if (index <= 0) index = 0;
            dgvDetail.CurrentCell = dgvDetail.Rows[index].Cells[0];
            dgvDetail.Rows[index].Selected = true;
        }

        private void dgvDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetDetailColor();
        }

        private void dgvDetail_MouseEnter(object sender, EventArgs e)
        {
            dgvDetail.Focus();
        }

        /// <summary>
        /// 详细列表按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bInit) return;
            if (lstLogDt == null || lstLogDt.Count <= 0) return;

            if (e.RowIndex < 0)
            {
                if (e.ColumnIndex <= 0) return;

                SetListField(dicLogDt, dgvDetail,e.ColumnIndex);
                ShowLogDT();
                return;
            }

            if (e.ColumnIndex < 0) return;
            curLogDt = lstLogDt[e.RowIndex];
            if (tvTask.Nodes.Count > 0) SetCurNode(tvTask.Nodes[0]);

            if (dgvDetail.Columns[e.ColumnIndex].DataPropertyName.ToLower() != "opname") return;
            string opname = dgvDetail[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (opname != "删除" && opname != "重发") return;

            string autoid = dgvDetail.Rows[e.RowIndex].Cells["colBAutoID"].Value.ToString();
            BLL.TaskOperator blldeal = new BLL.TaskOperator();
            BLL.ShowLogDt logbll = new BLL.ShowLogDt();
            List<Model.ShowLogDt> lst = logbll.GetModelList("10", " SY.id='" + curLog.Id + "' AND SY.autoid='" + autoid + "'", "", "");
            SetOpname(lst);
            if (lst == null || lst.Count <= 0)
            {
                Common.MessageShow("此记录已被其他用户修改,请刷新后重试");
                //ShowLogDT();
                return;
            }
            if (lst[0].Opname != opname)
            {
                if (!string.IsNullOrEmpty(lst[0].Opname))
                    Common.MessageShow("此行记录已被其他用户修改,请重试");
                ShowLogDT();
                return;
            }


            if (opname == "重发")
            {
                blldeal.ReDo(autoid, curLog.Id.ToString());
            }

            if (opname == "删除")
            {
                Model.DealResult dr = blldeal.DeleteSyncDt(1,autoid, curLog.Id.ToString());
                if (dr.ResultNum < 0)
                {
                    int iStart = dr.ResultMsg.IndexOf("System.Exception:");
                    if (iStart < 0) iStart = 0;
                    int iEnd = dr.ResultMsg.IndexOf("在", iStart);
                    if (iEnd < 0) iEnd = dr.ResultMsg.Length;
                    if (iEnd - iStart > 0)
                    {
                        string strMsg = dr.ResultMsg.Substring(iStart, iEnd - iStart);
                        Common.MessageShow(strMsg);
                    }
                    else
                    {
                        Common.MessageShow(dr.ResultMsg);
                    }
                }
            }

            ShowLogDT();
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bInit) return;
            if (lstLogDt == null || lstLogDt.Count <= 0) return;

            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return;


            Clipboard.Clear();
            DataGridViewCell cell = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell == null || cell.Value == null) return;
            string strText = cell.Value.ToString().Trim();
            if (string.IsNullOrEmpty(strText)) return;
            Clipboard.Clear();
            Clipboard.SetDataObject(strText, false, 3, 100);
        }

        private void scShown_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Common.dicRegist["listsize"] = scShown.SplitterDistance.ToString();
        }

        private void scDetail_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Common.dicRegist["tasksize"] = scDetail.SplitterDistance.ToString();
        }

        private void tmrSearch_Tick(object sender, EventArgs e)
        {
            if (iSecond <= 0)
            {
                btnSearch.Text = "查询";
                btnSearch.Enabled = true;
                tmrSearch.Enabled = false;
                if (cbxRefresh.Checked)
                {
                    //SetSearchTime();
                    //Query();
                    //ShowLogDT();
                    //GetLogDTTree();
                    btnSearch_Click(sender, e);
                }
            }
            else
            {
                btnSearch.Text = "查询" + "（" + iSecond + "）";
                btnSearch.Enabled = false;
                iSecond--;
            }
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            if (VerifyU8Button())
            {
                this.TopMost = true;
                //this.MinimizeBox = false;
            }
            else
            {
                this.TopMost = false;
                this.MinimizeBox = true;
            }

            SetColumnTag();

            //设置显示排版
            dgvList.AutoGenerateColumns = false;
            dgvDetail.AutoGenerateColumns = false;
            RefreshForm();

            GetServiceStatus(Common.mainServiceName);

            if (Common.dicRegist == null || !Common.bIsLinked)
            {
                cbxAddress.Items.Clear();
                cbxAddress.Items.AddRange(new object[] { "全部" });
                cbxAddress.SelectedIndex = 0;

                cbxType.Items.Clear();
                cbxType.Items.AddRange(new object[] { "全部" });
                cbxType.SelectedIndex = 0;

                cbxVoucherType.Items.Clear();
                cbxVoucherType.Items.AddRange(new object[] { "全部" });
                cbxVoucherType.SelectedIndex = 0;
            }
            else
            {
                //装载数据服务器下拉框
                cbxAddress.DataSource = DAL.Common.getAddressList();
                cbxAddress.DisplayMember = "U8FieldName";
                cbxAddress.ValueMember = "U8FieldValue";
                cbxAddress.SelectedIndex = 0;

                //装载协同类型下拉框
                cbxType.DataSource = DAL.Common.getRoutesetName();
                cbxType.DisplayMember = "U8FieldName";
                cbxType.ValueMember = "U8FieldValue";
                cbxType.SelectedIndex = 0;

                //装载单据类型下拉框
                cbxVoucherType.DataSource = DAL.Common.getOrderType();
                cbxVoucherType.DisplayMember = "U8FieldName";
                cbxVoucherType.ValueMember = "U8FieldValue";
                cbxVoucherType.SelectedIndex = 0;
            }

            //装载下拉框
            cbxState.Items.Clear();
            cbxState.Items.AddRange(new object[] { "全部", "未处理", "处理中", "等待中", "已作废", "错误", "完成" });
            cbxState.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置窗体排版
        /// </summary>
        private void SetFormStyle()
        {
            int iStyle = int.Parse(Common.dicRegist["uistyle"].ToString());
            int iList = int.Parse(Common.dicRegist["listsize"].ToString());
            int iTask = int.Parse(Common.dicRegist["tasksize"].ToString());

            switch (iStyle)
            {
                case 2:
                    scShown.Orientation = Orientation.Horizontal;
                    scDetail.Orientation = Orientation.Vertical;
                    break;
                case 3:
                    scShown.Orientation = Orientation.Horizontal;
                    scDetail.Orientation = Orientation.Horizontal;
                    break;
                default:
                    scShown.Orientation = Orientation.Vertical;
                    scDetail.Orientation = Orientation.Horizontal;
                    break;
            }

            scShown.SplitterDistance = iList;
            scDetail.SplitterDistance = iTask;
        }

        /// <summary>
        /// 检查服务器链接
        /// </summary>
        private bool CheckConnect()
        {
            if (string.IsNullOrEmpty(Common.dicRegist["servername"]) || string.IsNullOrEmpty(Common.dicRegist["dbname"]) || string.IsNullOrEmpty(Common.dicRegist["username"]))
            {
                Common.bIsLinked = false;
                Common.MessageShow("服务链接尚未设置,请先设置");
                Common.SetServiceMode(ServiceMode.Demand, Common.mainServiceName);
                Common.SetServiceMode(ServiceMode.Demand, Common.checkServiceName);
                Common.SetService(ServiceOpear.Stop, Common.mainServiceName);
                Common.SetService(ServiceOpear.Stop, Common.checkServiceName);


                using (Form f = new FrmConnectSetting())
                {
                    f.ShowDialog();
                }

                return false;
            }
            else
            {
                int iLink = Common.TestLink(Common.dicRegist["servername"], Common.dicRegist["dbname"], Common.dicRegist["username"], Common.dicRegist["pwd"]);
                if (iLink == -1)
                {
                    Common.bIsLinked = false;
                    Common.MessageShow("服务链接不存在或拒绝访问,请重设");
                    Common.SetServiceMode(ServiceMode.Demand, Common.mainServiceName);
                    Common.SetServiceMode(ServiceMode.Demand, Common.checkServiceName);
                    Common.SetService(ServiceOpear.Stop, Common.mainServiceName);
                    Common.SetService(ServiceOpear.Stop, Common.checkServiceName);

                    using (Form f = new FrmConnectSetting())
                    {
                        f.ShowDialog();
                    }

                    return false;
                }
                else if (iLink == 0)
                {
                    Common.bIsLinked = false;
                    Common.MessageShow("当前链接【MES/ERP接口】模块未正确安装,请重设");
                    Common.SetServiceMode(ServiceMode.Demand, Common.mainServiceName);
                    Common.SetServiceMode(ServiceMode.Demand, Common.checkServiceName);
                    Common.SetService(ServiceOpear.Stop, Common.mainServiceName);
                    Common.SetService(ServiceOpear.Stop, Common.checkServiceName);

                    using (Form f = new FrmConnectSetting())
                    {
                        f.ShowDialog();
                    }

                    return false;
                }
                else if (!Common.CheckInstall())
                {
                    Common.bIsLinked = false;
                    Common.MessageShow("当前链接未设置主账套或主账套数据丢失,             " + Environment.NewLine + "             请在用友【账套档案设置】中设置后重试");
                    Application.Exit();

                    return false;
                }
                else if (!Common.CheckMain())
                {
                    if (Common.MessageShow("当前链接与主账套设置不一致，是否重设？", "提示") == DialogResult.Yes)
                    {
                        Common.bIsLinked = false;
                        Common.SetServiceMode(ServiceMode.Demand, Common.mainServiceName);
                        Common.SetServiceMode(ServiceMode.Demand, Common.checkServiceName);
                        Common.SetService(ServiceOpear.Stop, Common.mainServiceName);
                        Common.SetService(ServiceOpear.Stop, Common.checkServiceName);

                        using (Form f = new FrmConnectSetting())
                        {
                            f.ShowDialog();
                        }

                        return false;
                    }
                    else
                    {
                        Common.SetServiceMode(ServiceMode.Demand, Common.mainServiceName);
                        Common.SetServiceMode(ServiceMode.Demand, Common.checkServiceName);
                        Common.SetService(ServiceOpear.Stop, Common.mainServiceName);
                        Common.SetService(ServiceOpear.Stop, Common.checkServiceName);

                        Common.MessageShow("程序即将退出，请检查主账套设置后重试");
                        Application.Exit();

                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            curLog = null;

            dicLog = new Dictionary<string, string>();
            dicLogDt = new Dictionary<string, string>();
            lstLog = new List<Model.ShowLog>();
            lstLogDt = new List<Model.ShowLogDt>();

            dicLog.Add("Top", "1000");
            dicLog.Add("Field", "id");
            dicLog.Add("Order", "desc");
            dicLog.Add("Name", "colHID");

            dicLogDt.Add("Top", "200");
            dicLogDt.Add("Field", "ilineno");
            dicLogDt.Add("Order", "asc");
            dicLogDt.Add("Name", "colBRow");

            dgvList.DataSource = lstLog;
            dgvDetail.DataSource = lstLogDt;

            if (VerifyU8Button())
            {
                dtpStart.Checked = false;
                dtpEnd.Checked = false;
                cbxRefresh.Checked = true;

                //cbxAddress.SelectedValue = strAddress;
                //cbxVoucherType.SelectedValue = strVoucherType;
                txtAccount.Text = strAccID;
                txtOrder.Text = strVoucherNo;
                List<Model.U8NameValue> cbxList;
                Model.U8NameValue cbxModel;
                cbxList = cbxAddress.DataSource as List<Model.U8NameValue>;
                cbxModel = cbxList.Find(delegate(Model.U8NameValue model) { return model.U8FieldValue == strAddress; });
                if (cbxModel != null) cbxAddress.SelectedValue = strAddress;
                cbxList = cbxVoucherType.DataSource as List<Model.U8NameValue>;
                cbxModel = cbxList.Find(delegate(Model.U8NameValue model) { return model.U8FieldValue == strVoucherType; });
                if (cbxModel != null) cbxVoucherType.SelectedValue = strVoucherType;
            }
        }

        /// <summary>
        /// 刷新界面显示
        /// </summary>
        private void RefreshForm()
        {
            if (VerifyU8Button())
            {
                tsMain.Visible = false;
                scBasic.Panel1Collapsed = true;
                scShown.Panel1Collapsed = true;
                scDetail.Panel1Collapsed = true;
                SetColumnVisible(dgvDetail, 1044990);
            } 
            else
            {
                tsMain.Visible = true;
                scBasic.Panel1Collapsed = false;
                bool bTask, bDetail;
                SetFormStyle();
                bTask = !((int.Parse(Common.dicRegist["display"].ToString()) & 2) > 0);
                bDetail = !((int.Parse(Common.dicRegist["display"].ToString()) & 4) > 0);
                scShown.Panel2Collapsed = bTask && bDetail;
                scDetail.Panel1Collapsed = bTask;
                scDetail.Panel2Collapsed = bDetail;
                SetColumnVisible(dgvList, long.Parse(Common.dicRegist["hcolumn"].ToString()));
                if (!bDetail) SetColumnVisible(dgvDetail, long.Parse(Common.dicRegist["bcolumn"].ToString()));
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="sServiceName"></param>
        public void GetServiceStatus(string sServiceName)
        {
            lblServiceState.Text = Common.GetServiceStatus(sServiceName);
            if (string.IsNullOrEmpty(lblServiceState.Text))
                lblServiceImage.Image = null;
            else if (lblServiceState.Text == "运行中")
                lblServiceImage.Image = Properties.Resources.RUN;
            else
                lblServiceImage.Image = Properties.Resources.STOP;
        }

        /// <summary>
        /// 设置查询按钮状态
        /// </summary>
        private void SetSearchTime()
        {
            if (!Common.bIsLinked)
            {
                Common.MessageShow("请先设置服务链接后重试");
                return;
            }

            iSecond = 2;
            btnSearch.Text = "查询" + "（" + iSecond + "）";
            btnSearch.Enabled = false;
            iSecond--;
            tmrSearch.Enabled = true;

            GetServiceStatus(Common.mainServiceName);
        }

        /// <summary>
        /// 控件是否不为空
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        private bool CheckCtrlNotEmpty(Control ct)
        {
            if (ct is TextBox)
            {

                if (!string.IsNullOrEmpty(ct.Text)) return true;
                return false;
            }

            else if (ct is DateTimePicker)
            {

                DateTimePicker dtp = (DateTimePicker)ct;

                return dtp.Checked;
            }

            else if (ct is ComboBox)
            {
                if (!string.IsNullOrEmpty(ct.Text) && ct.Text != "全部") return true;
                return false;
            }

            return false;
        }

        /// <summary>
        /// 获取主表查询数据
        /// </summary>
        /// <param name="field"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private bool Query()
        {
            if (!Common.bIsLinked) return false;

            try
            {
                bInit = true;
                BLL.ShowLog logbll = new BLL.ShowLog();
                string strWhere = GetWhereStr();

                lstLog = logbll.GetModelList(dicLog["Top"], strWhere, dicLog["Field"], dicLog["Order"]);
                if (lstLog == null) lstLog = new List<Model.ShowLog>();
                SetLogOpname();
                dgvList.DataSource = lstLog;
                if (lstLog.Count <= 0)
                {
                    curRow = 0;
                    curLog = null;
                    return false;
                }

                if (curLog == null)
                    curRow = 0;
                else
                    curRow = lstLog.FindIndex(delegate(Model.ShowLog model) { return model.Id == curLog.Id; });
                if (curRow <= 0) curRow = 0;
                curLog = lstLog[curRow];
                dgvList.CurrentCell = dgvList.Rows[curRow].Cells[0];
                dgvList.Rows[curRow].Selected = true;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                bInit = false;
                dgvList.Refresh();
            }
        }

        /// <summary>
        /// 获取查询筛选条件
        /// </summary>
        /// <returns></returns>
        private string GetWhereStr()
        {

            StringBuilder whereStr = new StringBuilder(" 1=1 ");

            if (CheckCtrlNotEmpty(dtpStart)) whereStr.Append(" and (ISNULL(SY.[starttime],GETDATE()) >= '" + dtpStart.Value.ToShortDateString() + "')");

            if (CheckCtrlNotEmpty(dtpEnd)) whereStr.Append(" and (ISNULL(SY.[starttime],GETDATE()) <= '" + dtpEnd.Value.AddDays(1).ToShortDateString() + "')");

            if (CheckCtrlNotEmpty(cbxType)) whereStr.Append(" and (SY.[croutetype] = '" + cbxType.SelectedValue + "')");

            //if (CheckCtrlNotEmpty(cbxState)) whereStr.Append(" and (SY.[cstatus] = '" + cbxState.Text + "')");

            StringBuilder whereSYStr = new StringBuilder();
            StringBuilder whereDTStr = new StringBuilder();

            if (CheckCtrlNotEmpty(cbxState))
            {
                whereSYStr.Append(" and (SY.[cstatus] = '" + cbxState.Text + "') ");
                whereDTStr.Append(" and (DT.[cstatus] = '" + cbxState.Text + "') ");
            }

            if (CheckCtrlNotEmpty(cbxAddress))
            {
                whereSYStr.Append(" and (RE.[caddress] = '" + cbxAddress.SelectedValue + "') ");
                whereDTStr.Append(" and (RT.[caddress] = '" + cbxAddress.SelectedValue + "') ");
            }

            if (CheckCtrlNotEmpty(txtAccount))
            {
                whereSYStr.Append(" and (SY.[caccid] like '%" + txtAccount.Text + "%' or RE.[cacc_id] like '%" + txtAccount.Text + "%' or RE.[cdatabase] like '%" + txtAccount.Text + "%')");
                whereDTStr.Append(" and (DT.[accid] like '%" + txtAccount.Text + "%' or RT.[cacc_id] like '%" + txtAccount.Text + "%' or RT.[cdatabase] like '%" + txtAccount.Text + "%')");
            }

            if (CheckCtrlNotEmpty(cbxVoucherType))
            {
                if (cbxVoucherType.SelectedValue.ToString() == "0")
                {
                    whereSYStr.Append(" and (SY.[cvouchertype] NOT IN (SELECT [cbillname] FROM HY_DZ_K7_BILLSCOPE)) ");
                    whereDTStr.Append(" and (ISNUMERIC(DT.[cvouchertype]) = 0) ");
                }
                else
                {   
                    whereSYStr.Append(" and (SY.[cvouchertype] = '" + cbxVoucherType.Text + "') ");
                    whereDTStr.Append(" and (DT.[cvouchertype] = '" + cbxVoucherType.SelectedValue + "') ");
                }
            }

            if (CheckCtrlNotEmpty(txtOrder))
            {
                whereSYStr.Append(" and (SY.[cvoucherno] like '%" + txtOrder.Text + "%') ");
                whereDTStr.Append(" and (DT.[cvoucherno] like '%" + txtOrder.Text + "%') ");
            }

            if (whereSYStr.Length >= 1 && whereDTStr.Length >= 1)
            {
                whereStr.Append(" and ((1=1 " + whereSYStr + ") or (1=1 " + whereDTStr + "))");
            }
            else if (whereSYStr.Length >= 1)
            {
                whereStr.Append(whereSYStr);
            }
            else if (whereDTStr.Length >= 1)
            {
                whereStr.Append(whereDTStr);
            }

            return whereStr.ToString();
        }

        /// <summary>
        /// 设置主表操作
        /// </summary>
        private void SetLogOpname()
        {
            foreach (Model.Synergismlog log in lstLog)
            {
                //if (log.Cstatus != "完成" && log.Cstatus != "已作废") log.Opname = "作废";  modified by liuxzha 2015.04.10
                if (log.Cstatus == "已作废")
                {
                    log.Opname = "还原";
                }
                else if (log.Cstatus != "完成")
                {
                    log.Opname = "作废";
                }
            }
        }

        /// <summary>
        /// 刷新当前主表行操作
        /// </summary>
        private void RefreshLogOpname()
        {
            try
            {
                BLL.ShowLog logbll = new BLL.ShowLog();
                List<Model.ShowLog> lst = logbll.GetModelList("1", " SY.id='" + curLog.Id + "' ", "", "");
                if (lst == null || lst.Count <= 0) return;

                //if (lst[0].Cstatus != "完成" && lst[0].Cstatus != "已作废") lst[0].Opname = "作废";  modified by liuxzha 2015.04.10
                if (lst[0].Cstatus == "已作废")
                {
                    lst[0].Opname = "还原";
                }
                else if (lst[0].Cstatus != "完成")
                {
                    lst[0].Opname = "作废";
                }
                curLog = lst[0];
                if (curLog == null)
                    curRow = 0;
                else
                    curRow = lstLog.FindIndex(delegate(Model.ShowLog model) { return model.Id == curLog.Id; });
                if (curRow <= 0) curRow = 0;

                dgvList.CurrentCell = dgvList.Rows[curRow].Cells[0];
                DataGridViewRow dgvr = dgvList.Rows[curRow];
                dgvr.Selected = true;
                dgvr.Cells["colHOpera"].Value = curLog.Opname;
                if (string.IsNullOrEmpty(curLog.Opname)) ((DataGridViewDisableButtonCell)dgvr.Cells["colHOpera"]).Enabled = false;
                else ((DataGridViewDisableButtonCell)dgvr.Cells["colHOpera"]).Enabled = true;
                if (curLog.Cstatus == "错误") dgvr.DefaultCellStyle.ForeColor = Color.Red;
                else if (curLog.Cstatus == "") dgvr.DefaultCellStyle.ForeColor = Color.Gray;
                else dgvr.DefaultCellStyle.ForeColor = dgvList.RowsDefaultCellStyle.ForeColor;
            }
            catch { }
        }

        /// <summary>
        /// 主表日志上色
        /// </summary>
        private void SetListColor()
        {
            DataGridViewDisableButtonCell btnOpera;
            foreach (DataGridViewRow vr in dgvList.Rows)
            {
                btnOpera = (DataGridViewDisableButtonCell)vr.Cells["colHOpera"];
                if (btnOpera.Value == null || string.IsNullOrEmpty(btnOpera.Value.ToString().Trim())) btnOpera.Enabled = false;

                if (vr.Cells["colHState"].Value == null || string.IsNullOrEmpty(vr.Cells["colHState"].Value.ToString().Trim())) continue;

                if (vr.Cells["colHState"].Value.ToString() == "错误")
                    vr.DefaultCellStyle.ForeColor = Color.Red;
                else if (vr.Cells["colHState"].Value.ToString() == "已作废")
                    vr.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// 获取关联子表数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="field"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private bool ShowLogDT()
        {
            if (!Common.bIsLinked) return false;

            try
            {
                if (scShown.Panel2Collapsed || scDetail.Panel2Collapsed) return true;
                if (curLog == null || int.Parse(curLog.Id) <= 0)
                {
                    lstLogDt = new List<Model.ShowLogDt>();
                }
                else
                {
                    BLL.ShowLogDt logbll = new BLL.ShowLogDt();
                    lstLogDt = logbll.GetModelList(dicLogDt["Top"], " SY.id='" + curLog.Id + "'", dicLogDt["Field"], dicLogDt["Order"]);
                    SetOpname(lstLogDt);
                }
                dgvDetail.DataSource = lstLogDt;

                if (lstLogDt.Count <= 0) return true;

                int index;
                if (curLogDt == null)
                    index = 0;
                else
                    index = lstLogDt.FindIndex(delegate(Model.ShowLogDt model) { return model.Autoid == curLogDt.Autoid; });
                if (index <= 0) index = 0;
                curLogDt = lstLogDt[index];
                dgvDetail.CurrentCell = dgvDetail.Rows[index].Cells[0];
                dgvDetail.Rows[index].Selected = true;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                RefreshLogOpname();
                dgvDetail.Refresh();
            }
        }

        /// <summary>
        /// 设置子表操作
        /// </summary>
        /// <param name="lsgldt"></param>
        private void SetOpname(List<Model.ShowLogDt> lstLogDt)
        {

            if (lstLogDt.Count == 0) return;
            Model.ShowLogDt temp;
            temp = lstLogDt.Find(delegate(Model.ShowLogDt model) { return model.Cdealmothed == 0; });

            if (temp != null)
            {
                Model.ShowLogDt odt = new Model.ShowLogDt();

                foreach (Model.ShowLogDt dt in lstLogDt)
                {
                    if ((dt.Cstatus == "完成" || dt.Cstatus == "未审核") && odt.Ilineno < dt.Ilineno && dt.Ismanual == 0) odt = dt;
                }

                odt.Opname = "删除";
            }
        }

        /// <summary>
        /// 子表日志上色
        /// </summary>
        private void SetDetailColor()
        {
            DataGridViewDisableButtonCell btnOpera;
            foreach (DataGridViewRow vr in dgvDetail.Rows)
            {
                btnOpera = (DataGridViewDisableButtonCell)vr.Cells["colBOpera"];
                if (curLog.Cstatus == "已作废")
                {
                    btnOpera.Enabled = false;
                    vr.DefaultCellStyle.ForeColor = Color.Gray;
                    continue;
                }

                if (btnOpera.Value == null || string.IsNullOrEmpty(btnOpera.Value.ToString().Trim())) btnOpera.Enabled = false;

                if (vr.Cells["colBState"].Value == null || vr.Cells["colBHandwork"].Value == null) continue;

                if (vr.Cells["colBState"].Value.ToString() == "错误")
                    vr.DefaultCellStyle.ForeColor = Color.Red;

                if (vr.Cells["colBHandwork"].Value.ToString() == "是")
                    vr.DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// 获取子表日志树形展示
        /// </summary>
        /// <returns></returns>
        private bool GetLogDTTree()
        {
            if (!Common.bIsLinked) return false;

            try
            {
                if (scShown.Panel2Collapsed || scDetail.Panel1Collapsed) return true;
                if (curLog == null || int.Parse(curLog.Id) <= 0)
                {
                    tvTask.Nodes.Clear();
                    return true;
                }

                BLL.ShowLogDt logdtbll = new BLL.ShowLogDt();
                List<Model.ShowLogDt> lstTreeDt = logdtbll.GetModelList("1", " SY.id='" + curLog.Id + "' and SY.ilineno='1' ", "ilineno", "asc");
                SetOpname(lstTreeDt);
                if (lstTreeDt == null || lstTreeDt.Count <= 0) return false;

                tvTask.Nodes.Clear();
                TreeNode rootNode = new TreeNode(curLog.Cvouchertype);
                if (curLog.Croutetype.IndexOf("类") < 0)
                    rootNode.Text = string.Format("{0}({1}) ", curLog.Croutetype, curLog.Cstatus);
                else
                    rootNode.Text = string.Format("{0}({1}) ", curLog.Cvouchertype, curLog.Cstatus);
                if (curLog.Cstatus == "错误") rootNode.ForeColor = Color.Red;
                //else if (curLog.Cstatus == "完成") rootNode.ForeColor = Color.Green;
                rootNode.NodeFont = new Font(new Font("宋体", 9), FontStyle.Bold);
                tvTask.Nodes.Add(rootNode);

                TreeNode childNode;
                Model.ShowLogDt model = lstTreeDt[0];
                childNode = new TreeNode();
                childNode.Tag = model;
                childNode.Text = string.Format("[{0}]{1}:{2}({3}) ", model.Accname, model.Cvouchertypename, model.CDataName, model.Cstatus);
                if (dgvDetail.Columns["colBAddress"].Visible) childNode.Text = model.Caddress + "-" + childNode.Text;

                if (model.Cstatus == "错误") childNode.ForeColor = Color.Red;
                else if (model.Ismanual == 1) childNode.ForeColor = Color.Green;
                rootNode.Nodes.Add(childNode);
                tvTask.SelectedNode = childNode;
                
                GetChildLogDT(model.Autoid, childNode);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                tvTask.ExpandAll();
                tvTask.Refresh();
                //tvTask.Focus();
            }
        }

        /// <summary>
        /// 递归获取下级子表日志
        /// </summary>
        /// <returns></returns>
        private bool GetChildLogDT(string fatherID, TreeNode tnParent)
        {
            try
            {
                BLL.ShowLogDt logdtbll = new BLL.ShowLogDt();
                List<Model.ShowLogDt> lstTreeDt = logdtbll.GetModelList("100", " SY.id='" + curLog.Id + "' and SY.fatherid='" + fatherID + "'", "ilineno", "asc");
                SetOpname(lstTreeDt);

                TreeNode childNode;
                foreach (Model.ShowLogDt model in lstTreeDt)
                {
                    childNode = new TreeNode();
                    childNode.Tag = model;
                    childNode.Text = string.Format("[{0}]{1}:{2}({3}) ", model.Accname, model.Cvouchertypename, model.CDataName, model.Cstatus);
                    if (dgvDetail.Columns["colBAddress"].Visible) childNode.Text = model.Caddress + "-" + childNode.Text;

                    if (model.Cstatus == "错误") childNode.ForeColor = Color.Red;
                    else if (model.Ismanual == 1) childNode.ForeColor = Color.Green;
                    tnParent.Nodes.Add(childNode);
                    GetChildLogDT(model.Autoid, childNode);

                    if (curLogDt != null && model.Autoid == curLogDt.Autoid)
                    {
                        tvTask.SelectedNode = childNode;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置关联节点
        /// </summary>
        /// <param name="node"></param>
        private void SetCurNode(TreeNode node)
        {
            try
            {
                if (scShown.Panel2Collapsed || scDetail.Panel1Collapsed) return;

                if (node.Tag is Model.ShowLogDt)
                {
                    if (((Model.ShowLogDt)node.Tag).Autoid == curLogDt.Autoid)
                    {
                        tvTask.SelectedNode = node;
                        //tvTask.Focus();
                        return;
                    }
                }

                if (node.Nodes.Count > 0)
                    foreach (TreeNode n in node.Nodes)
                        SetCurNode(n);
            }
            catch
            { }
        }

        /// <summary>
        /// 设置列显示标记
        /// </summary>
        private void SetColumnTag()
        {
            long tag;
            int i;

            tag = 2;
            for (i = 0; i < dgvList.Columns.Count; i++)
            {
                if (dgvList.Columns[i].Visible)
                {
                    dgvList.Columns[i].Tag = tag.ToString();
                    tag = tag * 2;
                }
                else
                {
                    dgvDetail.Columns[i].Tag = "0";
                }
            }

            tag = 2;
            for (i = 0; i < dgvDetail.Columns.Count; i++)
            {
                if (dgvDetail.Columns[i].Visible)
                {
                    dgvDetail.Columns[i].Tag = tag.ToString();
                    tag = tag * 2;
                }
                else
                {
                    dgvDetail.Columns[i].Tag = "0";
                }
            }
        }

        /// <summary>
        /// 设置列显示状态
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="state"></param>
        private void SetColumnVisible(DataGridView dgv, long state)
        {
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (c.Tag == null || long.Parse(c.Tag.ToString()) == 0)
                    c.Visible = false;
                else
                    c.Visible = (state & long.Parse(c.Tag.ToString())) > 0;
            }

            dgv.Refresh();
        }

        /// <summary>
        /// 设置列表排序列
        /// </summary>
        /// <param name="dic">排序字典</param>
        /// <param name="dgv">排序控件</param>
        /// <param name="index">排序列索引</param>
        private void SetListField(Dictionary<string, string> dic, DataGridView dgv, int index)
        {
            //△▽▲▼
            if (dic == null) return;

            if (!string.IsNullOrEmpty(dic["Name"]))
            {
                dgv.Columns[dic["Name"]].HeaderText = dgv.Columns[dic["Name"]].HeaderText.Replace("▲", "").Replace("▼", "");
                dgv.Columns[dic["Name"]].Width -= 10;
            }

            if (dgv.Columns[index].SortMode == DataGridViewColumnSortMode.NotSortable)
            {
                dic["Name"] = "";
                dic["Field"] = "";
                dic["Order"] = "";
                return;
            }

            if (dic["Name"] == dgv.Columns[index].Name)
            {
                if (dic["Order"] == "desc")
                    dic["Order"] = "asc";
                else
                    dic["Order"] = "desc";
            }
            else
            {
                dic["Name"] = dgv.Columns[index].Name;
                if (dgv.Columns[index].DataPropertyName == "Ismanualc")
                    dic["Field"] = "ismanual";
                else if (dgv.Columns[index].DataPropertyName == "Isauditc")
                    dic["Field"] = "isaudit";
                else if (dgv.Columns[index].DataPropertyName == "Cdealmothedc")
                    dic["Field"] = "cdealmothed";
                else
                    dic["Field"] = dgv.Columns[index].DataPropertyName.ToLower();
                dic["Order"] = "desc";
            }

            if (dic["Order"] == "asc")
                dgv.Columns[dic["Name"]].HeaderText = "▲" + dgv.Columns[dic["Name"]].HeaderText;
            else
                dgv.Columns[dic["Name"]].HeaderText = "▼" + dgv.Columns[dic["Name"]].HeaderText;
            dgv.Columns[dic["Name"]].Width += 10;

        }

        /// <summary>
        /// 导出协同日志到Excel
        /// </summary>
        private void OutPut2Excel()
        {
            BLL.ShowLog logbll = new BLL.ShowLog();
            DataSet dsLog;
            DataSet dsLogDt;
            string strWhere;

            strWhere = GetWhereStr();
            dsLog = logbll.GetOutputInfo(true, "1000", strWhere, "id", "desc");
            dsLogDt = logbll.GetOutputInfo(false, "10000", strWhere, "id,ilineno", "desc,");


            using (FrmOutput f = new FrmOutput())
            {
                f.dsLog = dsLog;
                f.dsLogDt = dsLogDt;
                f.ShowDialog();
            }
        }

        /// <summary>
        /// 是否U8按钮调用
        /// </summary>
        /// <returns></returns>
        public bool VerifyU8Button()
        {
            return !(string.IsNullOrEmpty(strAddress) || string.IsNullOrEmpty(strAccID) || string.IsNullOrEmpty(strVoucherType) || string.IsNullOrEmpty(strVoucherNo));
        }


        /// <summary>
        /// 状态核对  added by liuxzha 2015.03.23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count <= 0)
            {
                Common.MessageShow("请先选择需要核查的数据!");
                return;
            }

            string status = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBState"].Value.ToString();  //完成\已删除\未处理\错误\未审核\等待中
            string autoid = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBAutoID"].Value.ToString();
            string verify = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBVerify"].Value.ToString();  //是否自动审核

            //string accid = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBAccid"].Value.ToString();   //666 、888
            //string acccode = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBAcccode"].Value.ToString();   //0000000001
            //string voucherNo = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBOrder"].Value.ToString();
            string voucherType = dgvDetail.Rows[dgvDetail.CurrentRow.Index].Cells["colBOrderType"].Value.ToString();


            if (!DAL.Common.IsVoucher(voucherType))
            {
                Common.MessageShow("不支持档案协同核对.");
                return;
            }

            BLL.TaskOperator blldeal = new BLL.TaskOperator();
            BLL.ShowLogDt logdt = new BLL.ShowLogDt(); 
            DAL.SynergismLogDt dal = new DAL.SynergismLogDt();
            int res = blldeal.ChkExistsInData(autoid);
            bool hasProblem = false;
 
            Model.Synergismlogdt dt = dal.GetModel(autoid);


        //    0 本节点没有生成，子结点也没生成;
        //    10 本节点生成，子结点没有生成,单据为未审核状态
        //          11 本节点生成，子结点没有生成,单据为已审核状态
        //          100 本节点没有生成，子结点已经生成
        //        110 本节点生成，子结点也已经生成,单据为未审核状态
        //          111 本节点生成，子结点也已经生成,单据为已审核状态
            switch (res)
            { 
                case 0:
                    if (status.Equals("完成") || status.Equals("未审核"))
                    {
                        hasProblem = true;
                        if (MessageBox.Show("状态存在问题,是否自动修复?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        { 
                            //改成未处理
                            dt.Cstatus = Constant.SynergisnLogDT_Cstatus_NoDeal;
                            dt.Cerrordesc = string.Empty;
                            dal.Update(dt);
 
                        }
                    }
                    break;
                case 10:
                    if (verify.Equals("是"))
                    {
                        if (!status.Equals("错误"))
                        {
                            hasProblem = true;

                            if (MessageBox.Show("状态存在问题,是否自动修复?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //改成错误
                                dt.Cstatus = Constant.SynergisnLogDT_Cstatus_Error;
                                dt.Cerrordesc = string.Empty;
                                dal.Update(dt);
 
                            }
                        }
                    }
                    else
                    {
                        if (!status.Equals("未审核"))
                        {
                            hasProblem = true;

                            if (MessageBox.Show("状态存在问题,是否自动修复?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //未审核
                                dt.Cstatus = Constant.SynergisnLogDT_Cstatus_NoAudit;
                                dt.Cerrordesc = string.Empty;
                                dal.Update(dt);
 
                            }
                        }
                    }
                    break;
                case 11:
                    if (!status.Equals("完成"))
                    {
                        hasProblem = true;
                        
                        if (MessageBox.Show("状态存在问题,是否自动修复?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //改成完成
                            dt.Cstatus = Constant.SynergisnLogDT_Cstatus_Complete;
                            dt.Cerrordesc = string.Empty;
                            dal.Update(dt);
                        }
                    }
                    break;
                case 100:
                    if (!status.Equals("完成"))
                    {
                        hasProblem = true;
                        MessageBox.Show("状态存在问题,请从最新生成的任务节点开始进行倒序核对!"); 
                    }
                    break;
                case 110:
                    if (!status.Equals("完成"))
                    {
                        hasProblem = true;
                        MessageBox.Show("状态存在问题,请从最新生成的任务节点开始进行倒序核对!"); 
                    
                    }
                    break;
                default :
                    break;
            }

            if (!hasProblem)
            {
                Common.MessageShow("状态不存在问题!");
            }
               
 
            
        }

    }
}
