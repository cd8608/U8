namespace U8.Interface.Bus.ApiService.Setting
{
    partial class FrmConfigSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRepeal = new System.Windows.Forms.Button();
            this.btnLinkTest = new System.Windows.Forms.Button();
            this.txtDBPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "链接属性";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnRepeal);
            this.panel1.Controls.Add(this.btnLinkTest);
            this.panel1.Controls.Add(this.txtDBPwd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDBUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDBName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 274);
            this.panel1.TabIndex = 4;
            // 
            // btnRepeal
            // 
            this.btnRepeal.Location = new System.Drawing.Point(262, 209);
            this.btnRepeal.Name = "btnRepeal";
            this.btnRepeal.Size = new System.Drawing.Size(75, 23);
            this.btnRepeal.TabIndex = 6;
            this.btnRepeal.Text = "撤销修改";
            this.btnRepeal.UseVisualStyleBackColor = true;
            this.btnRepeal.Click += new System.EventHandler(this.btnRepeal_Click);
            // 
            // btnLinkTest
            // 
            this.btnLinkTest.Location = new System.Drawing.Point(165, 209);
            this.btnLinkTest.Name = "btnLinkTest";
            this.btnLinkTest.Size = new System.Drawing.Size(75, 23);
            this.btnLinkTest.TabIndex = 5;
            this.btnLinkTest.Text = "联接测试";
            this.btnLinkTest.UseVisualStyleBackColor = true;
            this.btnLinkTest.Click += new System.EventHandler(this.btnLinkTest_Click);
            // 
            // txtDBPwd
            // 
            this.txtDBPwd.Location = new System.Drawing.Point(165, 160);
            this.txtDBPwd.Name = "txtDBPwd";
            this.txtDBPwd.PasswordChar = '*';
            this.txtDBPwd.Size = new System.Drawing.Size(250, 21);
            this.txtDBPwd.TabIndex = 4;
            this.txtDBPwd.Leave += new System.EventHandler(this.txtDBPwd_Leave);
            this.txtDBPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDBPwd_KeyPress);
            this.txtDBPwd.Enter += new System.EventHandler(this.txtDBPwd_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "密码:";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(165, 116);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(250, 21);
            this.txtDBUser.TabIndex = 3;
            this.txtDBUser.Leave += new System.EventHandler(this.txtDBUser_Leave);
            this.txtDBUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDBUser_KeyPress);
            this.txtDBUser.Enter += new System.EventHandler(this.txtDBUser_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名:";
            // 
            // txtDBName
            // 
            this.txtDBName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDBName.Location = new System.Drawing.Point(165, 74);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(250, 21);
            this.txtDBName.TabIndex = 2;
            this.txtDBName.Leave += new System.EventHandler(this.txtDBName_Leave);
            this.txtDBName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDBName_KeyPress);
            this.txtDBName.Enter += new System.EventHandler(this.txtDBName_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据库名称:";
            // 
            // txtAddress
            // 
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Location = new System.Drawing.Point(165, 30);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 21);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器地址:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(160, 323);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmConfigSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 358);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务链接设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmConfigSetting_Load);
            this.Shown += new System.EventHandler(this.FrmConfigSetting_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfigSetting_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRepeal;
        private System.Windows.Forms.Button btnLinkTest;
        private System.Windows.Forms.TextBox txtDBPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}