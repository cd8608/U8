using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U8.Interface.Bus.ApiService.Model;

namespace U8.Interface.Bus.ApiService.Setting
{
    public partial class FrmServiceSetting : Form
    {
        public FrmServiceSetting()
        {
            InitializeComponent();
        }

        private void FrmServiceSetting_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmServiceSetting_Shown(object sender, EventArgs e)
        {

        }

        private void FrmServiceSetting_MouseClick(object sender, MouseEventArgs e)
        {
            if (!tsService.Enabled || !gbServices.Enabled || !dgvServices.Enabled)
            {
                Common.MessageShow("请在服务器" + Common.dicRegist["servername"] + "上操作服务");
            }
        }

        private void dgvServices_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Y - dgvServices.TopLeftHeaderCell.Size.Height >= dgvServices.Rows[0].Height)
                {
                    dgvServices.ClearSelection();
                    dgvServices.Rows[1].Selected = true;
                }
                else
                {
                    dgvServices.ClearSelection();
                    dgvServices.Rows[0].Selected = true;
                }
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            RefreshServices();
            tmrRefresh.Enabled = false;
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Run, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsbPause_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Pause, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Stop, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsbRecover_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Continue, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsbAllRun_Click(object sender, EventArgs e)
        {
            SetAllServices(ServiceOpear.Run);
        }

        private void tsbAllStop_Click(object sender, EventArgs e)
        {
            SetAllServices(ServiceOpear.Stop);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshServices();
        }

        private void tsmiRun_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Run, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsmiPause_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Pause, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Stop, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsmiRevover_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetService(ServiceOpear.Continue, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsmiAllRun_Click(object sender, EventArgs e)
        {
            SetAllServices(ServiceOpear.Run);
        }

        private void tsmiAllStop_Click(object sender, EventArgs e)
        {
            SetAllServices(ServiceOpear.Stop);
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            RefreshServices();
        }

        private void tsmiHand_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetServiceMode(ServiceMode.Demand, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void tsmiAuto_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0)
            {
                Common.MessageShow("请先选择一条服务");
                return;
            }

            Common.SetServiceMode(ServiceMode.Auto, Common.lstService[dgvServices.SelectedRows[0].Index].Name);
            RefreshServices();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            tsService.Visible = (int.Parse(Common.dicRegist["display"].ToString()) & 8) > 0;
            Common.GetServices();

            if (Common.CheckLocalMain())
            {
                lblMessage.Text = string.Empty;
                gbServices.Enabled = true;
                tsService.Enabled = true;
                cmsService.Enabled = true;
                colMachine.Visible = false;

                foreach (ServiceModel sm in Common.lstService)
                {
                    if (sm.StartMod == "禁用") Common.SetServiceMode(ServiceMode.Demand, sm.Name);
                }

                if (Common.lstService != null && Common.lstService.Count > 1)
                {
                    dgvServices.Visible = true;
                    dgvServices.DataSource = Common.lstService;
                }
                else
                {
                    dgvServices.Visible = false;
                    lblMessage.Text = "获取不到本机服务或服务未正确安装";
                }
            }
            else
            {
                lblMessage.Text = string.Empty;
                gbServices.Enabled = false;
                tsService.Enabled = false;
                cmsService.Enabled = false;
                colMachine.Visible = true;

                List<Model.ServiceModel> lstService;
                lstService = Common.GetServices(Common.sHostName);
                foreach (ServiceModel sm in lstService)
                {
                    if (sm.StartMod != "禁用") Common.SetServiceMode(ServiceMode.Disabled, sm.Name);
                }

                if (Common.lstService != null && Common.lstService.Count > 1)
                {
                    dgvServices.Visible = true;
                    dgvServices.DataSource = Common.lstService;
                }
                else
                {
                    dgvServices.Visible = false;
                    lblMessage.Text = "请在服务器" + Common.dicRegist["servername"] + "上查看服务";
                }
            }

        }

        /// <summary>
        /// 刷新服务
        /// </summary>
        private void RefreshServices()
        {
            foreach (ServiceModel sm in Common.lstService)
            {
                sm.Status = Common.GetServiceStatus(sm.Name);
                sm.StartMod = Common.GetServiceStartType(sm.Name);
            }

            if (!tmrRefresh.Enabled) tmrRefresh.Enabled = true;
            dgvServices.DataSource = Common.lstService;
            dgvServices.Refresh();
        }

        /// <summary>
        /// 设置全部服务
        /// </summary>
        /// <param name="opear"></param>
        private void SetAllServices(ServiceOpear opear)
        {
            foreach (ServiceModel sm in Common.lstService)
            {
                Common.SetService(opear, sm.Name);
                sm.Status = Common.GetServiceStatus(sm.Name);
                sm.StartMod = Common.GetServiceStartType(sm.Name);
            }

            if (!tmrRefresh.Enabled) tmrRefresh.Enabled = true;
            dgvServices.DataSource = Common.lstService;
            dgvServices.Refresh();
        }
    }
}
