namespace XModel
{
    partial class Form_TemperatureMonitor
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TemperatureChart
            // 
            this.TemperatureChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemperatureChart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.TemperatureChart.BackImageTransparentColor = System.Drawing.SystemColors.ButtonShadow;
            this.TemperatureChart.BorderlineColor = System.Drawing.Color.Navy;
            this.TemperatureChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.TemperatureChart.BorderlineWidth = 2;
            this.TemperatureChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.TemperatureChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.TemperatureChart.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.TemperatureChart.BorderSkin.BorderWidth = 0;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 6.595541F;
            legend1.Position.Width = 17.50381F;
            legend1.Position.X = 79.49619F;
            legend1.Position.Y = 3F;
            legend1.TextWrapThreshold = 15;
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend1.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureChart.Legends.Add(legend1);
            this.TemperatureChart.Location = new System.Drawing.Point(2, 1);
            this.TemperatureChart.Name = "TemperatureChart";
            this.TemperatureChart.Size = new System.Drawing.Size(658, 472);
            this.TemperatureChart.TabIndex = 2;
            this.TemperatureChart.Text = "TemperatureChart";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_TemperatureMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.TemperatureChart);
            this.Name = "Form_TemperatureMonitor";
            this.Text = "Temperature Monitor";
            this.Load += new System.EventHandler(this.Form_BloodPressureMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}