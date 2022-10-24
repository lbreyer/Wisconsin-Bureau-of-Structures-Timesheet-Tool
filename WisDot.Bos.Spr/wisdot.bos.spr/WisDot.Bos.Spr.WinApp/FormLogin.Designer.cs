namespace WisDot.Bos.Spr.WinApp
{
    partial class FormLogin
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textBoxUserPassword = new System.Windows.Forms.TextBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.labelUserPassword = new System.Windows.Forms.Label();
            this.checkBoxAuthenticated = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(194, 128);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(194, 27);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(100, 22);
            this.textBoxUserId.TabIndex = 1;
            // 
            // textBoxUserPassword
            // 
            this.textBoxUserPassword.Location = new System.Drawing.Point(194, 73);
            this.textBoxUserPassword.Name = "textBoxUserPassword";
            this.textBoxUserPassword.Size = new System.Drawing.Size(100, 22);
            this.textBoxUserPassword.TabIndex = 2;
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Location = new System.Drawing.Point(115, 31);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(59, 17);
            this.labelUserId.TabIndex = 3;
            this.labelUserId.Text = "User ID:";
            // 
            // labelUserPassword
            // 
            this.labelUserPassword.AutoSize = true;
            this.labelUserPassword.Location = new System.Drawing.Point(118, 73);
            this.labelUserPassword.Name = "labelUserPassword";
            this.labelUserPassword.Size = new System.Drawing.Size(69, 17);
            this.labelUserPassword.TabIndex = 4;
            this.labelUserPassword.Text = "Password";
            // 
            // checkBoxAuthenticated
            // 
            this.checkBoxAuthenticated.AutoSize = true;
            this.checkBoxAuthenticated.Location = new System.Drawing.Point(208, 185);
            this.checkBoxAuthenticated.Name = "checkBoxAuthenticated";
            this.checkBoxAuthenticated.Size = new System.Drawing.Size(125, 21);
            this.checkBoxAuthenticated.TabIndex = 5;
            this.checkBoxAuthenticated.Text = "Authenticated?";
            this.checkBoxAuthenticated.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 253);
            this.Controls.Add(this.checkBoxAuthenticated);
            this.Controls.Add(this.labelUserPassword);
            this.Controls.Add(this.labelUserId);
            this.Controls.Add(this.textBoxUserPassword);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.buttonLogin);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TextBox textBoxUserPassword;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.Label labelUserPassword;
        private System.Windows.Forms.CheckBox checkBoxAuthenticated;
    }
}

