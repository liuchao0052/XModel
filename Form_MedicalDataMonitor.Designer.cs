namespace XModel
{
    partial class Form_MedicalDataMonitor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TemperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BloodPressureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.HeartRateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BloodPressureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartRateChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.chart2.BackImageTransparentColor = System.Drawing.SystemColors.ButtonShadow;
            this.chart2.BorderlineColor = System.Drawing.Color.Navy;
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 2;
            this.chart2.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.chart2.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.chart2.BorderSkin.BorderWidth = 0;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Title = "时间(s)";
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.Title = "体温(°C)";
            chartArea1.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 9.125475F;
            legend1.Position.Width = 23.40425F;
            legend1.Position.X = 73.59575F;
            legend1.Position.Y = 3F;
            legend1.TextWrapThreshold = 15;
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend1.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(386, 3);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.LabelForeColor = System.Drawing.Color.Empty;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(377, 197);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TemperatureChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BloodPressureChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.HeartRateChart, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 636);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.TemperatureChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.TemperatureChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.TemperatureChart.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.TemperatureChart.BorderSkin.BorderWidth = 0;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsDockedInsideChartArea = false;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 6.125475F;
            legend2.Position.Width = 23.40425F;
            legend2.Position.X = 73.59575F;
            legend2.Position.Y = 3F;
            legend2.TextWrapThreshold = 15;
            legend2.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend2.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureChart.Legends.Add(legend2);
            this.TemperatureChart.Location = new System.Drawing.Point(1, 212);
            this.TemperatureChart.Margin = new System.Windows.Forms.Padding(1);
            this.TemperatureChart.Name = "TemperatureChart";
            this.TemperatureChart.Size = new System.Drawing.Size(613, 210);
            this.TemperatureChart.TabIndex = 3;
            this.TemperatureChart.Text = "TemperatureChart";
            // 
            // BloodPressureChart
            // 
            this.BloodPressureChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BloodPressureChart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BloodPressureChart.BackImageTransparentColor = System.Drawing.SystemColors.ButtonShadow;
            this.BloodPressureChart.BorderlineColor = System.Drawing.Color.Navy;
            this.BloodPressureChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.BloodPressureChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.BloodPressureChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.BloodPressureChart.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.BloodPressureChart.BorderSkin.BorderWidth = 0;
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            legend3.IsDockedInsideChartArea = false;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            legend3.Position.Auto = false;
            legend3.Position.Height = 6.125475F;
            legend3.Position.Width = 23.40425F;
            legend3.Position.X = 73.59575F;
            legend3.Position.Y = 3F;
            legend3.TextWrapThreshold = 15;
            legend3.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend3.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BloodPressureChart.Legends.Add(legend3);
            this.BloodPressureChart.Location = new System.Drawing.Point(1, 1);
            this.BloodPressureChart.Margin = new System.Windows.Forms.Padding(1);
            this.BloodPressureChart.Name = "BloodPressureChart";
            this.BloodPressureChart.Size = new System.Drawing.Size(613, 209);
            this.BloodPressureChart.TabIndex = 1;
            this.BloodPressureChart.Text = "BloodPressureChart";
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
            this.HeartRateChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.HeartRateChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.HeartRateChart.BorderSkin.BorderColor = System.Drawing.Color.CadetBlue;
            this.HeartRateChart.BorderSkin.BorderWidth = 0;
            legend4.Alignment = System.Drawing.StringAlignment.Far;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.IsDockedInsideChartArea = false;
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            legend4.Position.Auto = false;
            legend4.Position.Height = 6.125475F;
            legend4.Position.Width = 23.40425F;
            legend4.Position.X = 73.59575F;
            legend4.Position.Y = 3F;
            legend4.TextWrapThreshold = 15;
            legend4.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend4.TitleFont = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartRateChart.Legends.Add(legend4);
            this.HeartRateChart.Location = new System.Drawing.Point(1, 424);
            this.HeartRateChart.Margin = new System.Windows.Forms.Padding(1);
            this.HeartRateChart.Name = "HeartRateChart";
            this.HeartRateChart.Size = new System.Drawing.Size(613, 211);
            this.HeartRateChart.TabIndex = 4;
            this.HeartRateChart.Text = "HeartRateChart";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_MedicalDataMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(619, 640);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_MedicalDataMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Medical Data Monitor";
            this.Load += new System.EventHandler(this.Form_MedicalDataMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BloodPressureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeartRateChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart BloodPressureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart TemperatureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart HeartRateChart;
        private System.Windows.Forms.Timer timer1;

    }
}