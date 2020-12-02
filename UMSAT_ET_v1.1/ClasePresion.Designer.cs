namespace UMSAT_ET_v1._1
{
    partial class ClasePresion
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
            this.chtPresion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chtPresion)).BeginInit();
            this.SuspendLayout();
            // 
            // chtPresion
            // 
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.Interval = 5D;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 9;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 9;
            chartArea1.AxisX.MajorGrid.Interval = 5D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorTickMark.Interval = 5D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 1D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.Title = "Time (seconds)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Arial", 12F);
            chartArea1.AxisX2.IsStartedFromZero = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorTickMark.Interval = 100D;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Maximum = 670D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 50D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.MinorTickMark.Interval = 50D;
            chartArea1.AxisY.MinorTickMark.Size = 0.25F;
            chartArea1.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Title = "Presión [hPa]";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 12F);
            chartArea1.Name = "ChartArea1";
            this.chtPresion.ChartAreas.Add(chartArea1);
            this.chtPresion.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtPresion.Legends.Add(legend1);
            this.chtPresion.Location = new System.Drawing.Point(0, 0);
            this.chtPresion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chtPresion.Name = "chtPresion";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Presion";
            this.chtPresion.Series.Add(series1);
            this.chtPresion.Size = new System.Drawing.Size(931, 320);
            this.chtPresion.TabIndex = 0;
            this.chtPresion.Text = "chart1";
            // 
            // ClasePresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 320);
            this.Controls.Add(this.chtPresion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClasePresion";
            this.Text = "ClasePresion";
            ((System.ComponentModel.ISupportInitialize)(this.chtPresion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chtPresion;
    }
}