
namespace GomiBean
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.export = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.accounts = new System.Windows.Forms.ListBox();
            this.passwdInput = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountInput = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGamestart = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOneClick = new System.Windows.Forms.Button();
            this.lblTimeTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.gamaotp_challenge_code_output = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radHK = new System.Windows.Forms.RadioButton();
            this.radTW = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(273, 249);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(50, 30);
            this.export.TabIndex = 59;
            this.export.Text = "讀取";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(328, 248);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(50, 30);
            this.import.TabIndex = 58;
            this.import.Text = "儲存";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(384, 248);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(50, 30);
            this.delete.TabIndex = 57;
            this.delete.Text = "刪除";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // accounts
            // 
            this.accounts.FormattingEnabled = true;
            this.accounts.ItemHeight = 12;
            this.accounts.Location = new System.Drawing.Point(273, 24);
            this.accounts.Name = "accounts";
            this.accounts.Size = new System.Drawing.Size(160, 208);
            this.accounts.TabIndex = 56;
            // 
            // passwdInput
            // 
            this.passwdInput.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.passwdInput.Location = new System.Drawing.Point(89, 153);
            this.passwdInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwdInput.Name = "passwdInput";
            this.passwdInput.PasswordChar = '*';
            this.passwdInput.Size = new System.Drawing.Size(142, 22);
            this.passwdInput.TabIndex = 50;
            // 
            // passLabel
            // 
            this.passLabel.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.passLabel.Location = new System.Drawing.Point(15, 153);
            this.passLabel.Name = "passLabel";
            this.passLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passLabel.Size = new System.Drawing.Size(69, 19);
            this.passLabel.TabIndex = 49;
            this.passLabel.Text = "密碼";
            this.passLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountLabel
            // 
            this.accountLabel.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.accountLabel.Location = new System.Drawing.Point(15, 112);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(69, 19);
            this.accountLabel.TabIndex = 48;
            this.accountLabel.Text = "帳號";
            this.accountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountInput
            // 
            this.accountInput.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.accountInput.Location = new System.Drawing.Point(89, 112);
            this.accountInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.accountInput.Name = "accountInput";
            this.accountInput.Size = new System.Drawing.Size(142, 22);
            this.accountInput.TabIndex = 47;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(159)))));
            this.loginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginButton.Location = new System.Drawing.Point(35, 205);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(87, 29);
            this.loginButton.TabIndex = 46;
            this.loginButton.Text = "登入";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 8.8F);
            this.button2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Location = new System.Drawing.Point(35, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 40);
            this.button2.TabIndex = 64;
            this.button2.Text = "*設定遊戲路徑";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGamestart
            // 
            this.btnGamestart.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnGamestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(159)))));
            this.btnGamestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGamestart.Location = new System.Drawing.Point(136, 205);
            this.btnGamestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGamestart.Name = "btnGamestart";
            this.btnGamestart.Size = new System.Drawing.Size(95, 29);
            this.btnGamestart.TabIndex = 65;
            this.btnGamestart.Text = "啟動遊戲";
            this.btnGamestart.UseVisualStyleBackColor = true;
            this.btnGamestart.Click += new System.EventHandler(this.btnGamestart_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("微軟正黑體", 19.25F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(29, 289);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 33);
            this.lblMessage.TabIndex = 66;
            // 
            // btnOneClick
            // 
            this.btnOneClick.Font = new System.Drawing.Font("微軟正黑體", 15.75F);
            this.btnOneClick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOneClick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneClick.Location = new System.Drawing.Point(110, 242);
            this.btnOneClick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOneClick.Name = "btnOneClick";
            this.btnOneClick.Size = new System.Drawing.Size(121, 34);
            this.btnOneClick.TabIndex = 67;
            this.btnOneClick.Text = "一鍵登入";
            this.btnOneClick.UseVisualStyleBackColor = true;
            this.btnOneClick.Click += new System.EventHandler(this.btnOneClick_Click);
            // 
            // lblTimeTitle
            // 
            this.lblTimeTitle.AutoSize = true;
            this.lblTimeTitle.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.lblTimeTitle.ForeColor = System.Drawing.Color.Crimson;
            this.lblTimeTitle.Location = new System.Drawing.Point(269, 328);
            this.lblTimeTitle.Name = "lblTimeTitle";
            this.lblTimeTitle.Size = new System.Drawing.Size(87, 24);
            this.lblTimeTitle.TabIndex = 68;
            this.lblTimeTitle.Text = "耗時(ms)";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.lblTime.ForeColor = System.Drawing.Color.Crimson;
            this.lblTime.Location = new System.Drawing.Point(362, 328);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 24);
            this.lblTime.TabIndex = 69;
            // 
            // gamaotp_challenge_code_output
            // 
            this.gamaotp_challenge_code_output.AutoSize = true;
            this.gamaotp_challenge_code_output.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gamaotp_challenge_code_output.ForeColor = System.Drawing.Color.Red;
            this.gamaotp_challenge_code_output.Location = new System.Drawing.Point(106, 196);
            this.gamaotp_challenge_code_output.Name = "gamaotp_challenge_code_output";
            this.gamaotp_challenge_code_output.Size = new System.Drawing.Size(0, 21);
            this.gamaotp_challenge_code_output.TabIndex = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radHK);
            this.groupBox1.Controls.Add(this.radTW);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 34);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // radHK
            // 
            this.radHK.AutoSize = true;
            this.radHK.Location = new System.Drawing.Point(54, 12);
            this.radHK.Name = "radHK";
            this.radHK.Size = new System.Drawing.Size(39, 16);
            this.radHK.TabIndex = 1;
            this.radHK.Text = "HK";
            this.radHK.UseVisualStyleBackColor = true;
            this.radHK.CheckedChanged += new System.EventHandler(this.radHK_CheckedChanged);
            // 
            // radTW
            // 
            this.radTW.AutoSize = true;
            this.radTW.Checked = true;
            this.radTW.Location = new System.Drawing.Point(6, 12);
            this.radTW.Name = "radTW";
            this.radTW.Size = new System.Drawing.Size(41, 16);
            this.radTW.TabIndex = 0;
            this.radTW.TabStop = true;
            this.radTW.Text = "TW";
            this.radTW.UseVisualStyleBackColor = true;
            this.radTW.CheckedChanged += new System.EventHandler(this.radTW_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeTitle);
            this.Controls.Add(this.btnOneClick);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnGamestart);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gamaotp_challenge_code_output);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.accounts);
            this.Controls.Add(this.passwdInput);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.accountInput);
            this.Controls.Add(this.loginButton);
            this.Name = "Form1";
            this.Text = "GomiBean";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ListBox accounts;
        private System.Windows.Forms.TextBox passwdInput;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TextBox accountInput;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGamestart;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOneClick;
        private System.Windows.Forms.Label lblTimeTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label gamaotp_challenge_code_output;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radHK;
        private System.Windows.Forms.RadioButton radTW;
    }
}

