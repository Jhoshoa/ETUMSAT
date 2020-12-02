namespace UMSAT_ET_v1._1
{
    partial class ClaseGiroscopio
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtGiroscopio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chtGiroscopio)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGiroscopio
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
            chartArea1.AxisY.MajorTickMark.Interval = 2D;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Maximum = 20D;
            chartArea1.AxisY.Minimum = -20D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 1D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.MinorTickMark.Interval = 1D;
            chartArea1.AxisY.MinorTickMark.Size = 0.25F;
            chartArea1.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Title = "Aceleracion [m/s²]";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 12F);
            chartArea1.Name = "ChartArea1";
            this.chtGiroscopio.ChartAreas.Add(chartArea1);
            this.chtGiroscopio.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Arial Narrow", 8F);
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15F;
            legend1.Position.Width = 30F;
            legend1.Position.X = 15F;
            legend1.Position.Y = 3F;
            this.chtGiroscopio.Legends.Add(legend1);
            this.chtGiroscopio.Location = new System.Drawing.Point(0, 0);
            this.chtGiroscopio.Margin = new System.Windows.Forms.Padding(2);
            this.chtGiroscopio.Name = "chtGiroscopio";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "G_X";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "G_Y";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "G_Z";
            this.chtGiroscopio.Series.Add(series1);
            this.chtGiroscopio.Series.Add(series2);
            this.chtGiroscopio.Series.Add(series3);
            this.chtGiroscopio.Size = new System.Drawing.Size(682, 221);
            this.chtGiroscopio.TabIndex = 2;
            this.chtGiroscopio.Text = "chart1";
            // 
            // ClaseGiroscopio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 221);
            this.Controls.Add(this.chtGiroscopio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClaseGiroscopio";
            this.Text = "ClaseGiroscopio";
            ((System.ComponentModel.ISupportInitialize)(this.chtGiroscopio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chtGiroscopio;
    }
}