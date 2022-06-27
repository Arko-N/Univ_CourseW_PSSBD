namespace Client
{
    partial class FORM_menu_w
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_menu_w));
            this.BTN_logout = new System.Windows.Forms.Button();
            this.MENU_strip = new System.Windows.Forms.MenuStrip();
            this.SEPARATOR_1 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_2 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_21 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_22 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_23 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_24 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_21 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_26 = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_item_27 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_22 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_28 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_3 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_item_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SEPARATOR_5 = new System.Windows.Forms.ToolStripSeparator();
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
            this.SEPARATOR_2,
            this.MENU_item_2,
            this.SEPARATOR_3,
            this.MENU_item_3,
            this.SEPARATOR_5});
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
            this.MENU_item_1.Text = "ORDERS";
            this.MENU_item_1.Click += new System.EventHandler(this.MENU_item_1_Click);
            // 
            // SEPARATOR_2
            // 
            this.SEPARATOR_2.Name = "SEPARATOR_2";
            this.SEPARATOR_2.Size = new System.Drawing.Size(177, 6);
            // 
            // MENU_item_2
            // 
            this.MENU_item_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENU_item_21,
            this.MENU_item_22,
            this.MENU_item_23,
            this.MENU_item_24,
            this.MENU_item_25,
            this.SEPARATOR_21,
            this.MENU_item_26,
            this.MENU_item_27,
            this.SEPARATOR_22,
            this.MENU_item_28});
            this.MENU_item_2.ForeColor = System.Drawing.Color.DarkBlue;
            this.MENU_item_2.Name = "MENU_item_2";
            this.MENU_item_2.Size = new System.Drawing.Size(177, 23);
            this.MENU_item_2.Text = "REPORTS";
            // 
            // MENU_item_21
            // 
            this.MENU_item_21.Name = "MENU_item_21";
            this.MENU_item_21.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_21.Text = "Count of clients in groups";
            this.MENU_item_21.Click += new System.EventHandler(this.MENU_item_21_Click);
            // 
            // MENU_item_22
            // 
            this.MENU_item_22.Name = "MENU_item_22";
            this.MENU_item_22.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_22.Text = "Clients in groups";
            this.MENU_item_22.Click += new System.EventHandler(this.MENU_item_22_Click);
            // 
            // MENU_item_23
            // 
            this.MENU_item_23.Name = "MENU_item_23";
            this.MENU_item_23.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_23.Text = "Clients orders";
            this.MENU_item_23.Click += new System.EventHandler(this.MENU_item_23_Click);
            // 
            // MENU_item_24
            // 
            this.MENU_item_24.Name = "MENU_item_24";
            this.MENU_item_24.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_24.Text = "Clients at birthday";
            this.MENU_item_24.Click += new System.EventHandler(this.MENU_item_24_Click);
            // 
            // MENU_item_25
            // 
            this.MENU_item_25.Name = "MENU_item_25";
            this.MENU_item_25.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_25.Text = "Clients at groups";
            this.MENU_item_25.Click += new System.EventHandler(this.MENU_item_25_Click);
            // 
            // SEPARATOR_21
            // 
            this.SEPARATOR_21.Name = "SEPARATOR_21";
            this.SEPARATOR_21.Size = new System.Drawing.Size(399, 6);
            // 
            // MENU_item_26
            // 
            this.MENU_item_26.Name = "MENU_item_26";
            this.MENU_item_26.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_26.Text = "Barbers phones at rank";
            this.MENU_item_26.Click += new System.EventHandler(this.MENU_item_26_Click);
            // 
            // MENU_item_27
            // 
            this.MENU_item_27.Name = "MENU_item_27";
            this.MENU_item_27.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_27.Text = "Barbers at rank AND factors of other";
            this.MENU_item_27.Click += new System.EventHandler(this.MENU_item_27_Click);
            // 
            // SEPARATOR_22
            // 
            this.SEPARATOR_22.Name = "SEPARATOR_22";
            this.SEPARATOR_22.Size = new System.Drawing.Size(399, 6);
            // 
            // MENU_item_28
            // 
            this.MENU_item_28.Name = "MENU_item_28";
            this.MENU_item_28.Size = new System.Drawing.Size(402, 24);
            this.MENU_item_28.Text = "Orders at date";
            this.MENU_item_28.Click += new System.EventHandler(this.MENU_item_28_Click);
            // 
            // SEPARATOR_3
            // 
            this.SEPARATOR_3.Name = "SEPARATOR_3";
            this.SEPARATOR_3.Size = new System.Drawing.Size(177, 6);
            // 
            // MENU_item_3
            // 
            this.MENU_item_3.ForeColor = System.Drawing.Color.DarkBlue;
            this.MENU_item_3.Name = "MENU_item_3";
            this.MENU_item_3.Size = new System.Drawing.Size(177, 23);
            this.MENU_item_3.Text = "CLIENTS";
            this.MENU_item_3.Click += new System.EventHandler(this.MENU_item_3_Click);
            // 
            // SEPARATOR_5
            // 
            this.SEPARATOR_5.Name = "SEPARATOR_5";
            this.SEPARATOR_5.Size = new System.Drawing.Size(177, 6);
            // 
            // FORM_menu_w
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
            this.Name = "FORM_menu_w";
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
        private System.Windows.Forms.ToolStripMenuItem MENU_item_2;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_3;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_1;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_2;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_3;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_5;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_21;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_22;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_23;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_26;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_24;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_25;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_28;
        private System.Windows.Forms.ToolStripMenuItem MENU_item_27;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_21;
        private System.Windows.Forms.ToolStripSeparator SEPARATOR_22;
    }
}