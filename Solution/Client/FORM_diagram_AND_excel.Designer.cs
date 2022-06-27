namespace Client
{
    partial class FORM_diagram_AND_excel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_diagram_AND_excel));
            this.DIAGRAM_query = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BTN_load = new System.Windows.Forms.Button();
            this.DIALOG_load = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DIAGRAM_query)).BeginInit();
            this.SuspendLayout();
            // 
            // DIAGRAM_query
            // 
            chartArea1.AxisX.Title = "Client groups";
            chartArea1.AxisY.Title = "Count of clients";
            chartArea1.Name = "ChartArea1";
            this.DIAGRAM_query.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DIAGRAM_query.Legends.Add(legend1);
            this.DIAGRAM_query.Location = new System.Drawing.Point(14, 14);
            this.DIAGRAM_query.Name = "DIAGRAM_query";
            series1.BorderColor = System.Drawing.Color.DarkBlue;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelBorderColor = System.Drawing.Color.DarkBlue;
            series1.LabelForeColor = System.Drawing.Color.DarkBlue;
            series1.Legend = "Legend1";
            series1.Name = "Clients";
            this.DIAGRAM_query.Series.Add(series1);
            this.DIAGRAM_query.Size = new System.Drawing.Size(658, 435);
            this.DIAGRAM_query.TabIndex = 0;
            this.DIAGRAM_query.Text = "DIAGRAM";
            // 
            // BTN_load
            // 
            this.BTN_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_load.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_load.ForeColor = System.Drawing.Color.DarkBlue;
            this.BTN_load.Location = new System.Drawing.Point(572, 409);
            this.BTN_load.Name = "BTN_load";
            this.BTN_load.Size = new System.Drawing.Size(100, 40);
            this.BTN_load.TabIndex = 1;
            this.BTN_load.Text = "LOAD REPORT";
            this.BTN_load.UseVisualStyleBackColor = true;
            this.BTN_load.Click += new System.EventHandler(this.BTN_load_Click);
            // 
            // FORM_diagram_AND_excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.BTN_load);
            this.Controls.Add(this.DIAGRAM_query);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_diagram_AND_excel";
            this.Text = "DIAGRAM";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DIAGRAM_query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart DIAGRAM_query;
        private System.Windows.Forms.Button BTN_load;
        private System.Windows.Forms.SaveFileDialog DIALOG_load;
    }
}