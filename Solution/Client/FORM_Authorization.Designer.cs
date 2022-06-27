namespace Client
{
    partial class FORM_authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_authorization));
            this.TXT_user = new System.Windows.Forms.TextBox();
            this.TXT_password = new System.Windows.Forms.TextBox();
            this.BTN_login = new System.Windows.Forms.Button();
            this.LBL_password = new System.Windows.Forms.Label();
            this.LBL_user = new System.Windows.Forms.Label();
            this.LBL_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXT_user
            // 
            this.TXT_user.ForeColor = System.Drawing.Color.DarkBlue;
            this.TXT_user.Location = new System.Drawing.Point(12, 39);
            this.TXT_user.Name = "TXT_user";
            this.TXT_user.Size = new System.Drawing.Size(260, 23);
            this.TXT_user.TabIndex = 1;
            this.TXT_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_user_KeyDown);
            // 
            // TXT_password
            // 
            this.TXT_password.ForeColor = System.Drawing.Color.DarkBlue;
            this.TXT_password.Location = new System.Drawing.Point(12, 64);
            this.TXT_password.Name = "TXT_password";
            this.TXT_password.PasswordChar = '*';
            this.TXT_password.Size = new System.Drawing.Size(260, 23);
            this.TXT_password.TabIndex = 2;
            this.TXT_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_password_KeyDown);
            // 
            // BTN_login
            // 
            this.BTN_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_login.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_login.ForeColor = System.Drawing.Color.DarkGreen;
            this.BTN_login.Location = new System.Drawing.Point(90, 104);
            this.BTN_login.Name = "BTN_login";
            this.BTN_login.Size = new System.Drawing.Size(100, 25);
            this.BTN_login.TabIndex = 3;
            this.BTN_login.Text = "LOG IN";
            this.BTN_login.UseVisualStyleBackColor = true;
            this.BTN_login.Click += new System.EventHandler(this.BTN_login_Click);
            // 
            // LBL_password
            // 
            this.LBL_password.AutoSize = true;
            this.LBL_password.BackColor = System.Drawing.SystemColors.Window;
            this.LBL_password.Location = new System.Drawing.Point(208, 67);
            this.LBL_password.Name = "LBL_password";
            this.LBL_password.Size = new System.Drawing.Size(63, 15);
            this.LBL_password.TabIndex = 3;
            this.LBL_password.Text = "password";
            // 
            // LBL_user
            // 
            this.LBL_user.AutoSize = true;
            this.LBL_user.BackColor = System.Drawing.SystemColors.Window;
            this.LBL_user.Location = new System.Drawing.Point(201, 42);
            this.LBL_user.Name = "LBL_user";
            this.LBL_user.Size = new System.Drawing.Size(70, 15);
            this.LBL_user.TabIndex = 4;
            this.LBL_user.Text = "user name";
            // 
            // LBL_title
            // 
            this.LBL_title.AutoSize = true;
            this.LBL_title.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_title.ForeColor = System.Drawing.Color.DarkBlue;
            this.LBL_title.Location = new System.Drawing.Point(78, 9);
            this.LBL_title.Name = "LBL_title";
            this.LBL_title.Size = new System.Drawing.Size(126, 19);
            this.LBL_title.TabIndex = 5;
            this.LBL_title.Text = "AUTHORIZATION";
            // 
            // FORM_authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.LBL_title);
            this.Controls.Add(this.LBL_user);
            this.Controls.Add(this.LBL_password);
            this.Controls.Add(this.BTN_login);
            this.Controls.Add(this.TXT_password);
            this.Controls.Add(this.TXT_user);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FORM_authorization_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_user;
        private System.Windows.Forms.TextBox TXT_password;
        private System.Windows.Forms.Button BTN_login;
        private System.Windows.Forms.Label LBL_password;
        private System.Windows.Forms.Label LBL_user;
        private System.Windows.Forms.Label LBL_title;
    }
}