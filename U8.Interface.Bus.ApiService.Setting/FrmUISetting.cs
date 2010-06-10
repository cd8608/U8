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
    public partial class FrmUISetting : Form
    {
        private bool bInit;
        private int befUStayle;
        private long befUState;
        private long befHState;
        private long befBState;
        private int aftUStayle;
        private long aftUState;
        private long aftHState;
        private long aftBState;

        public FrmUISetting()
        {
            InitializeComponent();
        }

        private void FrmUISetting_Load(object sender, EventArgs e)
        {
            bInit = true;
            InitForm();
        }

        private void FrmUISetting_Shown(object sender, EventArgs e)
        {
            bInit = false;
        }

        private void cbU_CheckedChanged(object sender, EventArgs e)
        {
            if (bInit) return;
            aftUState = GetCheckValue(tlpUI);
        }

        private void cbH_CheckedChanged(object sender, EventArgs e)
        {
            if (bInit) return;
            aftHState = GetCheckValue(tlpList);
        }

        private void cbB_CheckedChanged(object sender, EventArgs e)
        {
            if (bInit) return;
            aftBState = GetCheckValue(tlpDetail);
        }

        private void rbUI1_Click(object sender, EventArgs e)
        {
            SetUIStyle(1, false);
        }

        private void rbUI2_Click(object sender, EventArgs e)
        {
            SetUIStyle(2, false);
        }

        private void rbUI3_Click(object sender, EventArgs e)
        {
            SetUIStyle(3, false);
        }

        private void tsmiUSelect_Click(object sender, EventArgs e)
        {
            SetSelected(tlpUI, true);
        }

        private void tsmiUCancel_Click(object sender, EventArgs e)
        {
            SetSelected(tlpUI, false);
        }

        private void tsmiURepeal_Click(object sender, EventArgs e)
        {
            aftUState = befUState;
            SetCheckValue(tlpUI, aftUState);
        }

        private void tsmiUDefault_Click(object sender, EventArgs e)
        {
            aftUState = long.Parse(Common.Display);
            SetCheckValue(tlpUI, aftUState);
            SetUIStyle(1, false);
        }

        private void tsmiMSelect_Click(object sender, EventArgs e)
        {
            SetSelected(tlpList, true);
        }

        private void tsmiMCancel_Click(object sender, EventArgs e)
        {
            SetSelected(tlpList, false);
        }

        private void tsmiMRepeal_Click(object sender, EventArgs e)
        {
            aftHState = befHState;
            SetCheckValue(tlpList, aftHState);
        }

        private void tsmiMDefault_Click(object sender, EventArgs e)
        {
            aftHState = long.Parse(Common.HColumn);
            SetCheckValue(tlpList, aftHState);
        }

        private void tsmiDSelect_Click(object sender, EventArgs e)
        {
            SetSelected(tlpDetail, true);
        }

        private void tsmiDCancel_Click(object sender, EventArgs e)
        {
            SetSelected(tlpDetail, false);
        }

        private void tsmiDRepeal_Click(object sender, EventArgs e)
        {
            aftBState = befBState;
            SetCheckValue(tlpDetail, aftBState);
        }

        private void tsmiDDefault_Click(object sender, EventArgs e)
        {
            aftBState = long.Parse(Common.BColumn);
            SetCheckValue(tlpDetail, aftBState);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (aftUStayle != befUStayle) SetUIStyle(aftUStayle, true);
            if (aftHState != befHState) Common.dicRegist["hcolumn"] = aftHState.ToString();
            if (aftBState != befBState) Common.dicRegist["bcolumn"] = aftBState.ToString();
            if (aftUState != befUState) Common.dicRegist["display"] = aftUState.ToString();
            //Common.SetRegist();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            aftUStayle = befUStayle;
            aftHState = befHState;
            aftBState = befBState;
            aftUState = befUState;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            //设置排版样式
            befUStayle = int.Parse(Common.dicRegist["uistyle"].ToString());
            aftUStayle = befUStayle;
            SetUIStyle(befUStayle, false);
            befUState = long.Parse(Common.dicRegist["display"].ToString());
            aftUState = befUState;
            SetCheckValue(tlpUI, befUState);

            //设置列表显示列
            befHState = long.Parse(Common.dicRegist["hcolumn"].ToString());
            aftHState = befHState;
            SetCheckValue(tlpList, befHState);

            //设置详细显示列
            befBState = long.Parse(Common.dicRegist["bcolumn"].ToString());
            aftBState = befBState;
            SetCheckValue(tlpDetail, befBState);
        }

        /// <summary>
        /// 设置窗体排版选项
        /// </summary>
        /// <param name="ui_no"></param>
        private void SetUIStyle(int ui_no,bool isApply)
        {
            switch (ui_no)
            {
                case 2:
                    aftUStayle = 2;
                    rbUI1.Checked = false;
                    plUI1.BorderStyle = BorderStyle.FixedSingle;
                    rbUI2.Checked = true;
                    plUI2.BorderStyle = BorderStyle.Fixed3D;
                    rbUI3.Checked = false;
                    plUI3.BorderStyle = BorderStyle.FixedSingle;

                    if (isApply)
                    {
                        Common.dicRegist["uistyle"] = "2";
                        Common.dicRegist["listsize"] = "280";
                        Common.dicRegist["tasksize"] = "280";
                    }
                    break;
                case 3:
                    aftUStayle = 3;
                    rbUI1.Checked = false;
                    plUI1.BorderStyle = BorderStyle.FixedSingle;
                    rbUI2.Checked = false;
                    plUI2.BorderStyle = BorderStyle.FixedSingle;
                    rbUI3.Checked = true;
                    plUI3.BorderStyle = BorderStyle.Fixed3D;

                    if (isApply)
                    {
                        Common.dicRegist["uistyle"] = "3";
                        Common.dicRegist["listsize"] = "220";
                        Common.dicRegist["tasksize"] = "140";
                    }
                    break;
                default:
                    aftUStayle = 1;
                    rbUI1.Checked = true;
                    plUI1.BorderStyle = BorderStyle.Fixed3D;
                    rbUI2.Checked = false;
                    plUI2.BorderStyle = BorderStyle.FixedSingle;
                    rbUI3.Checked = false;
                    plUI3.BorderStyle = BorderStyle.FixedSingle;

                    if (isApply)
                    {
                        Common.dicRegist["uistyle"] = "1";
                        Common.dicRegist["listsize"] = "490";
                        Common.dicRegist["tasksize"] = "220";
                    }
                    break;
            }
        }

        /// <summary>
        /// 获取复选框取值
        /// </summary>
        /// <param name="tlp"></param>
        /// <returns></returns>
        private long GetCheckValue(TableLayoutPanel tlp)
        {
            long state = 0;
            CheckBox cBox;
            foreach (Control c in tlp.Controls)
            {
                if (!(c is CheckBox)) continue;

                cBox = c as CheckBox;
                if (cBox.Checked)
                {
                    state = state | long.Parse(cBox.Tag.ToString());
                }
            }
            return state;
        }

        /// <summary>
        /// 设置复选框状态
        /// </summary>
        /// <param name="tlp"></param>
        /// <param name="state"></param>
        private void SetCheckValue(TableLayoutPanel tlp, long state)
        {
            CheckBox cBox;
            foreach (Control c in tlp.Controls)
            {
                if (!(c is CheckBox)) continue;

                cBox = c as CheckBox;
                cBox.Checked = (state & long.Parse(cBox.Tag.ToString())) > 0;
            }
        }

        /// <summary>
        /// 设置全选/全消
        /// </summary>
        /// <param name="tlp"></param>
        /// <param name="isCheck"></param>
        private void SetSelected(TableLayoutPanel tlp, bool isCheck)
        {
            CheckBox cBox;
            foreach (Control c in tlp.Controls)
            {
                if (!(c is CheckBox)) continue;

                cBox = c as CheckBox;
                cBox.Checked = isCheck;
            }
        }
    }
}
