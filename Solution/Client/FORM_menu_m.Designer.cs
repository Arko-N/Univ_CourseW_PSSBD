namespace Client
{
    partial class FORM_menu_m
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_menu_m));
            this.BTN_logout = new System.Windows.Forms.Button();
            this.MENU_strip = new System.Windows.Forms.MenuStrip();
            this.SEPARATOR_1 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_2 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_logout
            // 
            this.BTN_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_logout.ForeColor = System.Drawing.Color.DarkRed;
            this.BTN_logout.Location = new System.Drawing.Point(12, 419);
            this.BTN_logout.Name = "BTN_logout";
            this.BTN_logout.Size = new System.Drawing.Size(160, 30);
            this.BTN_logout.TabIndex = 0;
            this.BTN_logout.Text = "LOG OUT";
            this.BTN_logout.UseVisualStyleBackColor = true;
            this.BTN_logout.Click += new System.EventHandler(this.BTN_logout_Click);
            // 
            // MENU_strip
            // 
            this.MENU_strip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MENU_strip.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MENU_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SEPARATOR_1,
            this.MENU_item_1,
            this.SEPARATOR_2});
            this.MENU_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MENU_strip.Location = new System.Drawing.Point(0, 0);
            this.MENU_strip.Name = "MENU_strip";
            this.MENU_strip.Size = new System.Drawing.Size(184, 461);
            this.MENU_strip.TabIndex = 2;
            this.MENU_strip.Text = "MENU_strip";
            // 
            // SEPARATOR_1
            // 
            this.SEPARATOR_1.Name = "SEPARATOR_1";
            this.SEPARATOR_1.Size = new System.Drawing.Size(177, 6);
            // 
            // MENU_item_1
            // 
            this.MENU_item_1.ForeColor = System.Drawing.Color.DarkBlue;
            this.MENU_item_1.Name = "MENU_item_1";
            this.MENU_item_1.Size = new System.Drawing.Size(177, 23);
            this.MENU_item_1.Text = "WORKERS";
            this.MENU_item_1.Click += new System.EventHandler(this.MENU_item_1_Click);
            // 
            // SEPARATOR_2
            // 
            this.SEPARATOR_2.Name = "SEPARATOR_2";
            this.SEPARATOR_2.Size = new System.Drawing.Size(177, 6);
            // 
            // FORM_menu_m
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 461);
            this.Controls.Add(this.BTN_logout);
            this.Controls.Add(this.MENU_strip);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENU_strip;
            this.Name = "FORM_menu_m";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.MENU_strip.ResumeLayout(false);
            this.MENU_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_logout;
        private System.Windows.Forms.MenuStrip MENU_strip;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_1;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_1;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_2;
    }
}