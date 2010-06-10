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
    public partial class FrmOutput : Form
    {
        public DataSet dsLog;
        public DataSet dsLogDt;
        private DataView dvOutLog;
        private DataView dvOutLogDt;

        public FrmOutput()
        {
            InitializeComponent();
        }

        private void FrmOutput_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Save2Excel();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitForm()
        {
            dgvList.AutoGenerateColumns = false;
            dgvDetail.AutoGenerateColumns = false;

            dvOutLog = new DataView();
            dvOutLog.Table = dsLog.Tables[0];
            dvOutLogDt = new DataView();
            dvOutLogDt.Table = dsLogDt.Tables[0];

            dgvList.DataSource = dvOutLog;
            dgvDetail.DataSource = dvOutLogDt;
            
        }

        private void Save2Excel()
        {
            #region 弹出窗口
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl 97-2003 Files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            #endregion

            string strPath = saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.LastIndexOf('\\') + 1);
            string strName = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1, saveFileDialog.FileName.LastIndexOf('.') - saveFileDialog.FileName.LastIndexOf('\\') - 1);
            string strExpand = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('.') , saveFileDialog.FileName.Length - saveFileDialog.FileName.LastIndexOf('.') );
            if (Common.isExcelInstalled())
            {
                saveFileDialog.FileName = strPath + strName + "_List" + strExpand;
                if (!Common.SaveToExcel(saveFileDialog.FileName, dgvList, "协同日志任务列表")) return;
                saveFileDialog.FileName = strPath + strName + "_Detail" + strExpand;
                if (!Common.SaveToExcel(saveFileDialog.FileName, dgvDetail, "协同日志任务明细")) return;
            }
            else
            {
                saveFileDialog.FileName = strPath + strName + "_List" + strExpand;
                if (!Common.SaveToExcel(saveFileDialog, dgvList)) return;
                saveFileDialog.FileName = strPath + strName + "_Detail" + strExpand;
                if (!Common.SaveToExcel(saveFileDialog, dgvDetail)) return;
            }

            Common.MessageShow("导出成功!");
        }
    }
}
