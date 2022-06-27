namespace Client
{
    partial class FORM_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_main));
            this.BTN_menu = new System.Windows.Forms.Button();
            this.TXT_title = new System.Windows.Forms.TextBox();
            this.DGRID_table = new System.Windows.Forms.DataGridView();
            this.CONTEXT_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NUM_page = new System.Windows.Forms.NumericUpDown();
            this.LBL_page = new System.Windows.Forms.Label();
            this.TXT_max = new System.Windows.Forms.TextBox();
            this.TXT_search = new System.Windows.Forms.TextBox();
            this.BTN_clear = new System.Windows.Forms.Button();
            this.BTN_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGRID_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_page)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_menu
            // 
            this.BTN_menu.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_menu.Location = new System.Drawing.Point(685, -1);
            this.BTN_menu.Name = "BTN_menu";
            this.BTN_menu.Size = new System.Drawing.Size(100, 25);
            this.BTN_menu.TabIndex = 2;
            this.BTN_menu.Text = "MENU";
            this.BTN_menu.UseVisualStyleBackColor = true;
            this.BTN_menu.Click += new System.EventHandler(this.BTN_menu_Click);
            // 
            // TXT_title
            // 
            this.TXT_title.BackColor = System.Drawing.SystemColors.Window;
            this.TXT_title.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TXT_title.Location = new System.Drawing.Point(0, 0);
            this.TXT_title.Name = "TXT_title";
            this.TXT_title.ReadOnly = true;
            this.TXT_title.Size = new System.Drawing.Size(685, 23);
            this.TXT_title.TabIndex = 3;
            this.TXT_title.TabStop = false;
            this.TXT_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DGRID_table
            // 
            this.DGRID_table.AllowUserToAddRows = false;
            this.DGRID_table.AllowUserToDeleteRows = false;
            this.DGRID_table.AllowUserToResizeRows = false;
            this.DGRID_table.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGRID_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGRID_table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGRID_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGRID_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGRID_table.ContextMenuStrip = this.CONTEXT_menu;
            this.DGRID_table.Location = new System.Drawing.Point(0, 24);
            this.DGRID_table.Name = "DGRID_table";
            this.DGRID_table.ReadOnly = true;
            this.DGRID_table.RowHeadersVisible = false;
            this.DGRID_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGRID_table.Size = new System.Drawing.Size(784, 400);
            this.DGRID_table.TabIndex = 4;
            // 
            // CONTEXT_menu
            // 
            this.CONTEXT_menu.Name = "CONTEXT_menu";
            this.CONTEXT_menu.Size = new System.Drawing.Size(61, 4);
            // 
            // NUM_page
            // 
            this.NUM_page.Location = new System.Drawing.Point(635, 430);
            this.NUM_page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_page.Name = "NUM_page";
            this.NUM_page.Size = new System.Drawing.Size(80, 23);
            this.NUM_page.TabIndex = 8;
            this.NUM_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUM_page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_page.ValueChanged += new System.EventHandler(this.NUM_page_ValueChanged);
            this.NUM_page.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUM_page_KeyDown);
            // 
            // LBL_page
            // 
            this.LBL_page.AutoSize = true;
            this.LBL_page.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_page.Location = new System.Drawing.Point(594, 434);
            this.LBL_page.Name = "LBL_page";
            this.LBL_page.Size = new System.Drawing.Size(35, 15);
            this.LBL_page.TabIndex = 9;
            this.LBL_page.Text = "PAGE";
            // 
            // TXT_max
            // 
            this.TXT_max.Location = new System.Drawing.Point(714, 430);
            this.TXT_max.Name = "TXT_max";
            this.TXT_max.ReadOnly = true;
            this.TXT_max.Size = new System.Drawing.Size(70, 23);
            this.TXT_max.TabIndex = 10;
            // 
            // TXT_search
            // 
            this.TXT_search.Location = new System.Drawing.Point(0, 430);
            this.TXT_search.Name = "TXT_search";
            this.TXT_search.Size = new System.Drawing.Size(300, 23);
            this.TXT_search.TabIndex = 11;
            this.TXT_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_search_KeyDown);
            this.TXT_search.Leave += new System.EventHandler(this.TXT_search_Leave);
            // 
            // BTN_clear
            // 
            this.BTN_clear.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_clear.ForeColor = System.Drawing.Color.DarkRed;
            this.BTN_clear.Location = new System.Drawing.Point(300, 430);
            this.BTN_clear.Name = "BTN_clear";
            this.BTN_clear.Size = new System.Drawing.Size(23, 23);
            this.BTN_clear.TabIndex = 12;
            this.BTN_clear.Text = "X";
            this.BTN_clear.UseVisualStyleBackColor = true;
            this.BTN_clear.Click += new System.EventHandler(this.BTN_clear_Click);
            // 
            // BTN_search
            // 
            this.BTN_search.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_search.Location = new System.Drawing.Point(329, 430);
            this.BTN_search.Name = "BTN_search";
            this.BTN_search.Size = new System.Drawing.Size(75, 23);
            this.BTN_search.TabIndex = 13;
            this.BTN_search.Text = "SEARCH";
            this.BTN_search.UseVisualStyleBackColor = true;
            this.BTN_search.Click += new System.EventHandler(this.BTN_search_Click);
            // 
            // FORM_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.BTN_search);
            this.Controls.Add(this.BTN_clear);
            this.Controls.Add(this.TXT_search);
            this.Controls.Add(this.TXT_max);
            this.Controls.Add(this.LBL_page);
            this.Controls.Add(this.NUM_page);
            this.Controls.Add(this.DGRID_table);
            this.Controls.Add(this.TXT_title);
            this.Controls.Add(this.BTN_menu);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FORM_main_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.FORM_main_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DGRID_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_page)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_menu;
        private System.Windows.Forms.TextBox TXT_title;
        private System.Windows.Forms.ContextMenuStrip CONTEXT_menu;
        private System.Windows.Forms.NumericUpDown NUM_page;
        private System.Windows.Forms.Label LBL_page;
        private System.Windows.Forms.TextBox TXT_max;
        private System.Windows.Forms.TextBox TXT_search;
        private System.Windows.Forms.Button BTN_clear;
        private System.Windows.Forms.Button BTN_search;
        public System.Windows.Forms.DataGridView DGRID_table;
    }
}

