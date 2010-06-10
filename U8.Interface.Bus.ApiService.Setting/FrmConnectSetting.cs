using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace U8.Interface.Bus.ApiService.Setting
{
    public partial class FrmConnectSetting : Form
    {
        bool isExit;

        public FrmConnectSetting()
        {
            InitializeComponent();
        }

        private void FrmConnectSetting_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void FrmConnectSetting_Shown(object sender, EventArgs e)
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
                Common.MessageShow("服务器地址不能为空");
                txtAddress.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDBName.Text))
            {
                Common.MessageShow("数据库不能为空");
                txtDBName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDBUser.Text))
            {
                Common.MessageShow("用户名不能为空");
                txtDBUser.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDBPwd.Text))
            {
                Common.MessageShow("数据库密码不应为空");
                txtDBPwd.Focus();
                return;
            }

            int iLink = Common.TestLink(txtAddress.Text, txtDBName.Text, txtDBUser.Text, txtDBPwd.Text);
            if (iLink == 1)
            {
                btnLinkTest.Enabled = false;
                btnConfirm.Enabled = true;
                Common.MessageShow("测试连接成功");
            }
            else if (iLink == 0)
            {
                Common.MessageShow("当前链接【业务协同平台】模块未正确安装,请重试");
            }
            else
            {
                Common.MessageShow("测试连接失败");
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
                txtAddress.Text = Common.dicRegist["servername"].ToString();
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }
            else if (txtAddress.Text == "LOCALHOST")
            {
                Common.MessageShow("请使用明确的机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["servername"].ToString();
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }

            if ((txtAddress.Text == Common.dicRegist["servername"])
            && (txtDBName.Text == Common.dicRegist["dbname"])
            && (txtDBUser.Text == Common.dicRegist["username"])
            && (txtDBPwd.Text == Common.dicRegist["pwd"]))
            {

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            Common.dicRegist["servername"] = txtAddress.Text;
            Common.dicRegist["dbname"] = txtDBName.Text;
            Common.dicRegist["username"] = txtDBUser.Text;
            Common.dicRegist["pwd"] = txtDBPwd.Text;

            string strError = string.Empty;
            if (Common.SetRegist(out strError))
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
                txtAddress.Text = Common.dicRegist["servername"].ToString();
                //txtAddress.SelectAll();
                //txtAddress.Focus();
                //return;
            }
            else if (txtAddress.Text == "LOCALHOST")
            {
                //Common.MessageShow("请使用明确的机器名作为服务器地址");
                txtAddress.Text = Common.dicRegist["servername"].ToString();
                //txtAddress.SelectAll();
                //txtAddress.Focus();
                //return;
            }
        }

        private void FrmConnectSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(Common.dicRegist["servername"]) || string.IsNullOrEmpty(Common.dicRegist["dbname"]) || string.IsNullOrEmpty(Common.dicRegist["username"]))
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
            txtAddress.Text = Common.dicRegist["servername"].ToString();
            txtDBName.Text = Common.dicRegist["dbname"].ToString();
            txtDBUser.Text = Common.dicRegist["username"].ToString();
            txtDBPwd.Text = Common.dicRegist["pwd"].ToString();
            btnLinkTest.Enabled = false;
            btnRepeal.Enabled = false;
            btnConfirm.Enabled = true;
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
    }
}
