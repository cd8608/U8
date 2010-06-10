using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace U8.Interface.Bus.ApiService.Setting.CQ
{
    public partial class FrmU8AppSetting : Form
    {
        bool isExit;
        bool bFixedYear;

        public FrmU8AppSetting()
        {
            InitializeComponent();
        }

        private void FrmConfigSetting_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmConfigSetting_Shown(object sender, EventArgs e)
        {
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtAddress.SelectAll();
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDBName.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape) txtAddress.Text = "";
                SetChange();
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = txtAddress.Text.Trim();
            //if (string.IsNullOrEmpty(txtAddress.Text))
            //{
            //    Common.MessageShow("服务器地址不能为空");
            //    txtAddress.Focus();
            //}
        }

        private void txtDBName_Enter(object sender, EventArgs e)
        {
            txtDBName.SelectAll();
        }

        private void txtDBName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDBUser.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape) txtDBName.Text = "";
                SetChange();
            }
        }

        private void txtDBName_Leave(object sender, EventArgs e)
        {
            txtDBName.Text = txtDBName.Text.Trim();
            //if (string.IsNullOrEmpty(txtDBName.Text))
            //{
            //    Common.MessageShow("数据库不能为空");
            //    txtDBName.Focus();
            //}
        }

        private void txtDBUser_Enter(object sender, EventArgs e)
        {
            txtDBUser.SelectAll();
        }

        private void txtDBUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDBPwd.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape) txtDBUser.Text = "";
                SetChange();
            }
        }

        private void txtDBUser_Leave(object sender, EventArgs e)
        {
            txtDBUser.Text = txtDBUser.Text.Trim();
            //if (string.IsNullOrEmpty(txtDBUser.Text))
            //{
            //    Common.MessageShow("用户名不能为空");
            //    txtDBUser.Focus();
            //}
        }

        private void txtDBPwd_Enter(object sender, EventArgs e)
        {
            txtDBPwd.SelectAll();
        }

        private void txtDBPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnLinkTest.Enabled) btnLinkTest.Focus();
                else if (btnConfirm.Enabled) btnConfirm.Focus();
                else btnCancel.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape) txtDBPwd.Text = "";
                SetChange();
            }
        }

        private void txtDBPwd_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDBPwd.Text))
            //{
            //    Common.MessageShow("数据库密码不应为空");
            //    txtDBPwd.Focus();
            //}
        }

        private void btnLinkTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Common.MessageShow("应用服务器不能为空");
                txtAddress.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDBName.Text))
            {
                Common.MessageShow("账套号不能为空");
                txtDBName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDBUser.Text))
            {
                Common.MessageShow("用户名不能为空");
                txtDBUser.Focus();
                return;
            }
            //else if (string.IsNullOrEmpty(txtDBPwd.Text))
            //{
            //    Common.MessageShow("登录密码不应为空");
            //    txtDBPwd.Focus();
            //    return;
            //}



            string errmsg = "";
            int iLink = U8.Interface.Bus.ApiService.BLL.Common.TestU8Login("", txtAddress.Text, "(default)", txtDBName.Text,
                txtDBUser.Text, txtDBPwd.Text, txtYear.Text, txtDate.Text, out errmsg);
            if (iLink == 1)
            {
                btnLinkTest.Enabled = false;
                btnConfirm.Enabled = true;
                Common.MessageShow("测试连接成功");
            }
            else if (iLink == 0)
            {
                Common.MessageShow("当前链接【" + U8.Interface.Bus.SysInfo.productName + "】模块未正确安装,请重试");
            }
            else
            {
                Common.MessageShow("测试连接失败:" + errmsg);
            }
        }

        private void btnRepeal_Click(object sender, EventArgs e)
        {
            if (Common.MessageShow("确认撤消修改吗？", "提示") == DialogResult.No)
                return;

            InitForm();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Common.IsIPAddress(txtAddress.Text))
            {
                Common.MessageShow("请使用机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["u8servername"].ToString();
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }
            else if (txtAddress.Text == "LOCALHOST")
            {
                Common.MessageShow("请使用明确的机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["u8servername"].ToString();
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }

            if (
                (txtAddress.Text == Common.dicRegist["u8servername"])
            && (txtDBName.Text == Common.dicRegist["u8acc"])
            && (txtDBUser.Text == Common.dicRegist["u8username"])
            && (txtDBPwd.Text == Common.dicRegist["u8pwd"])
                 && (txtYear.Text == Common.dicRegist["u8year"])
                && (bFixedYear == chkYear.Checked)
                )
            {

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            Common.dicRegist["u8servername"] = txtAddress.Text;
            Common.dicRegist["u8acc"] = txtDBName.Text;
            Common.dicRegist["u8username"] = txtDBUser.Text;
            Common.dicRegist["u8pwd"] = txtDBPwd.Text;

            if (chkYear.Checked)
            {
                Common.dicRegist["u8year"] = txtYear.Text;
            }
            else
            {
                Common.dicRegist["u8year"] = "";
            }

            string strError = string.Empty;
            if (Common.SetConfig(out strError))
            {
                Common.bIsLinked = true;
                Common.MessageShow("设置成功,请重新打开日志查询界面应用更改");
                Application.Exit();
            }
            else
            {
                Common.MessageShow("设置失败," + strError);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Common.IsIPAddress(txtAddress.Text))
            {
                //Common.MessageShow("请使用机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["u8servername"].ToString();
                //txtAddress.SelectAll();
                //txtAddress.Focus();
                //return;
            }
            else if (txtAddress.Text == "LOCALHOST")
            {
                //Common.MessageShow("请使用明确的机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["u8servername"].ToString();
                //txtAddress.SelectAll();
                //txtAddress.Focus();
                //return;
            }
        }

        private void FrmConfigSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(Common.dicRegist["u8servername"]) || string.IsNullOrEmpty(Common.dicRegist["u8acc"]) || string.IsNullOrEmpty(Common.dicRegist["u8username"]))
            {
                if (string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtDBName.Text) || string.IsNullOrEmpty(txtDBUser.Text))
                {
                    if (!isExit) Common.MessageShow("服务链接尚未正确设置,程序即将退出");
                    isExit = true;
                    Application.Exit();
                }
                else if (btnLinkTest.Enabled)
                {
                    if (!isExit) Common.MessageShow("服务链接尚未正确设置,程序即将退出");
                    isExit = true;
                    Application.Exit();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                //this.Close();
            }
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            isExit = false;
            txtAddress.Text = Common.dicRegist["u8servername"].ToString();
            txtDBName.Text = Common.dicRegist["u8acc"].ToString();
            txtDBUser.Text = Common.dicRegist["u8username"].ToString();
            txtDBPwd.Text = Common.dicRegist["u8pwd"].ToString(); 
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btnLinkTest.Enabled = false;
            btnRepeal.Enabled = false;
            btnConfirm.Enabled = true;

            if (string.IsNullOrEmpty(Common.dicRegist["u8year"]))
            {
                txtYear.Text = DateTime.Now.ToString("yyyy");
                chkYear.Checked = false;
                bFixedYear = false;
            }
            else
            {
                txtYear.Text = Common.dicRegist["u8year"].ToString();
                chkYear.Checked = true;
                bFixedYear = true;
            }
        }

        /// <summary>
        /// 设置编辑状态
        /// </summary>
        private void SetChange()
        {
            btnLinkTest.Enabled = true;
            btnRepeal.Enabled = true;
            btnConfirm.Enabled = false;
        }

        private void chkYear_CheckedChanged(object sender, EventArgs e)
        { 
            SetChange(); 
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        { 
            SetChange(); 
        }
 
    }
}
