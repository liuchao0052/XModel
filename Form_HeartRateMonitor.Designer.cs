namespace XModel
{
    partial class Form_HeartRateMonitor
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.HeartRateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeartRateChart)).BeginInit();
            this.SuspendLayout();
            // 
            // HeartRateChart
            // 
            this.HeartRateChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeartRateChart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.HeartRateChart.BackImageTransparentColor = System.Drawing.SystemColors.ButtonShadow;
            this.HeartRateChart.BorderlineColor = System.Drawing.Color.Navy;
            this.HeartRateChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.HeartRateChart.BorderlineWidth = 2;
            this.HeartRateChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.HeartRateChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.HeartRateChart.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.HeartRateChart.BorderSkin.BorderWidth = 0;
            legend5.Alignment = System.Drawing.StringAlignment.Far;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend5.IsDockedInsideChartArea = false;
            legend5.Name = "Legend1";
            legend5.Position.Auto = false;
            legend5.Position.Height = 6.595541F;
            legend5.Position.Width = 17.50381F;
            legend5.Position.X = 79.49619F;
            legend5.Position.Y = 3F;
            legend5.TextWrapThreshold = 15;
            legend5.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend5.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartRateChart.Legends.Add(legend5);
            this.HeartRateChart.Location = new System.Drawing.Point(2, 2);
            this.HeartRateChart.Name = "HeartRateChart";
            this.HeartRateChart.Size = new System.Drawing.Size(658, 472);
            this.HeartRateChart.TabIndex = 3;
            this.HeartRateChart.Text = "HeartRateChart";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_HeartRateMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.HeartRateChart);
            this.Name = "Form_HeartRateMonitor";
            this.Text = "Heart Rate Monitor";
            this.Load += new System.EventHandler(this.Form_HeartRateMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeartRateChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart HeartRateChart;
        private System.Windows.Forms.Timer timer1;
    }
}