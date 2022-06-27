namespace Client
{
    partial class FORM_t_group
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_t_group));
            this.DGRID_table = new System.Windows.Forms.DataGridView();
            this.CONTEXT_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGRID_table)).BeginInit();
            this.SuspendLayout();
            // 
            // DGRID_table
            // 
            this.DGRID_table.AllowUserToAddRows = false;
            this.DGRID_table.AllowUserToDeleteRows = false;
            this.DGRID_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.DGRID_table.Location = new System.Drawing.Point(0, 0);
            this.DGRID_table.MultiSelect = false;
            this.DGRID_table.Name = "DGRID_table";
            this.DGRID_table.ReadOnly = true;
            this.DGRID_table.RowHeadersVisible = false;
            this.DGRID_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGRID_table.Size = new System.Drawing.Size(184, 261);
            this.DGRID_table.TabIndex = 0;
            // 
            // CONTEXT_menu
            // 
            this.CONTEXT_menu.Name = "CONTEXT_menu";
            this.CONTEXT_menu.Size = new System.Drawing.Size(61, 4);
            // 
            // FORM_t_group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 261);
            this.ControlBox = false;
            this.Controls.Add(this.DGRID_table);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_t_group";
            this.ShowInTaskbar = false;
            this.Text = "CLIENT GROUPs";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DGRID_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ContextMenuStrip CONTEXT_menu;
        public System.Windows.Forms.DataGridView DGRID_table;
    }
}