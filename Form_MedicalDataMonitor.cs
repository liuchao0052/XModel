using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using Netron.GraphLib;
using XModel.BasicLibrary;


namespace XModel
{
    public partial class Form_MedicalDataMonitor : Form
    {
        private Component component; //显示控制器表单对应的组件

        //血压数据列表
        public List<BloodPressureDataType> bloodPressureDatas = new List<BloodPressureDataType>();
        public BloodPressureDataType bloodPressure = null;
        private static string[] BloodPressure_DataType = { "HighPressure", "LowPressure" };

        //体温数据列表
        public List<TemperatureDataType> temperatureDatas = new List<TemperatureDataType>();
        public TemperatureDataType temperature = null;
        private static string[] Temperature_DataType = { "Temperature" };

        //心率数据列表
        public List<HeartRateDataType> heartRateDatas = new List<HeartRateDataType>();
        public HeartRateDataType heartRate = null;
        private static string[] HeartRate_DataType = { "HeartRate" };

        public Form_MedicalDataMonitor(Component component)
        {
            this.component = component;
            InitializeComponent();

        }
        private void Form_MedicalDataMonitor_Load(object sender, EventArgs e)
        {
            timer1.Interval = 300; //设定定时器timer1间隔时间0.3s
            this.timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.stop)
            {
                this.component.EmptyingQueue();
                this.timer1.Stop();
                return;
            }
            if (component.input_ports == null)
                return;
            
            foreach (Input_port input_port in component.input_ports)
            {
                if (input_port.Port_queue1.Count > 0) //若input端口内部队列有数据
                {        
                    Object data = (Object)input_port.Port_queue1.Dequeue();
                    switch(data.GetType().Name)
                    {
                        case "BloodPressureDataType":
                            bloodPressure = (BloodPressureDataType)data;
                            break;
                        case "TemperatureDataType":
                            temperature = (TemperatureDataType)data;
                            break;
                        case "HeartRateDataType":
                            heartRate = (HeartRateDataType)data;
                            break;
                    }
                }
                else  //若input端口内部队列无数据
                {
                    bloodPressure = null;
                    temperature = null;
                    heartRate = null;
                }
            }

            Set_BloodPressureMonitoringChart();             //设置血压监控图表
            Add_BloodPressureDatas();                       //添加血压数据
            Series series1 = BloodPressureChart.Series[0];   //设置点在血压监控图表首次出现位置
            BloodPressureChart.ChartAreas[0].AxisX.ScaleView.Position = series1.Points.Count - 145;

            Set_TemperatureMonitoringChart();               //设置体温监控图表
            Add_TemperatureDatas();                         //添加体温数据
            Series series2 = TemperatureChart.Series[0];     //设置点在体温监控图表首次出现位置
            TemperatureChart.ChartAreas[0].AxisX.ScaleView.Position = series2.Points.Count - 145;

            Set_HeartRateMonitoringChart();                 //设置心率监控图表
            Add_HeartRateDatas();                           //添加心率数据
            Series series3 = HeartRateChart.Series[0];       //设置点在心率监控图表首次出现位置
            HeartRateChart.ChartAreas[0].AxisX.ScaleView.Position = series3.Points.Count - 145;
        }


        /**********************************************
         *  函数名称：Set_BloodPressureMonitoringChart
         *  功能：设置血压实时监控图表
         *  参数：无
         *  返回值：无
         * ********************************************/
        private void Set_BloodPressureMonitoringChart()
        {
            //定义图表区域
            this.BloodPressureChart.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("Blood pressure monitoring");
            this.BloodPressureChart.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示X轴网格线
            chartarea.AxisX.MajorGrid.Enabled = false;

            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示Y轴网格线
            //chartarea.AxisY.MajorGrid.Enabled = false;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = true;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 6;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = true;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 20;

            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 155;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = bloodPressureDatas.Count;
            //chartarea.AxisX.Maximum = bpVolume;
            //chartarea.AxisX.Maximum = 200;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            chartarea.AxisX.ScaleView.Size = 150;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 5;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            chartarea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);
            //设置Y轴单位名
            chartarea.AxisY.Title = "pressure value (mmHg)";
            chartarea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);

            //设置表头
            this.BloodPressureChart.Titles.Clear();
            this.BloodPressureChart.Titles.Add("Blood pressure monitoring");
            this.BloodPressureChart.Titles[0].Text = "Blood pressure monitoring";
            this.BloodPressureChart.Titles[0].ForeColor = Color.Blue;
            this.BloodPressureChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.BloodPressureChart.Series.Clear();

            //for (int i = 0; i < 2; i++)
            //{
            Series series = new Series(BloodPressure_DataType[0]);
            //设置样条图类型
            series.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series.ChartArea = "Blood pressure monitoring";
            //设置数据序列点颜色
            series.Color = Color.DarkRed;
            series.BorderWidth = 1;

            //设置标记点边框和大小
            series.MarkerBorderWidth = 3;
            series.MarkerSize = 6;
            //设置标记点形状
            series.MarkerStyle = MarkerStyle.Cross;
            series.ToolTip = BloodPressure_DataType[0] + "#VAL \r\n #AXISLABEL";

            BloodPressureChart.Series.Add(series);
            //}

            Series series2 = new Series(BloodPressure_DataType[1]);
            //设置样条图类型
            series2.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series2.ChartArea = "Blood pressure monitoring";
            //设置数据序列点颜色
            series2.Color = Color.Blue;
            series2.BorderWidth = 1;


            //设置标记点边框和大小
            series2.MarkerBorderWidth = 5;
            series2.MarkerSize = 6;
            //设置标记点形状
            series2.MarkerStyle = MarkerStyle.Triangle;
            series2.ToolTip = BloodPressure_DataType[1] + "#VAL \r\n #AXISLABEL";

            BloodPressureChart.Series.Add(series2);


            //this.chart1.Series[0].YAxisType = AxisType.Primary;
            //this.chart1.Series[1].YAxisType = AxisType.Secondary;
        }

        /**********************************************
         *  函数名称：Add_BloodPressureDatas
         *  功能：添加血压数据
         *  参数：无
         *  返回值：无
         * ********************************************/
        public void Add_BloodPressureDatas()
        {
            //Console.WriteLine("血压数据计数："+bloodPressureDatas.Count);
            //当血压数据不为空
            if (bloodPressure != null)
            {
                //向血压数据列表中添加数据
                bloodPressureDatas.Add(bloodPressure);

                foreach (BloodPressureDataType array in bloodPressureDatas)
                {
                    this.BloodPressureChart.Series[0].Points.AddY(array.HighBP);
                    this.BloodPressureChart.Series[1].Points.AddY(array.LowBP);
                }

            }
            else
            {
                //BloodPressureDataType bp = new BloodPressureDataType();
                //bp.HighBP = 0;
                //bp.LowBP = 0;
                //bloodPressureDatas.Add(bp);
                foreach (BloodPressureDataType array in bloodPressureDatas)
                {
                    //Console.WriteLine(array.HighBP + " ," + array.LowBP);
                    this.BloodPressureChart.Series[0].Points.AddY(array.HighBP);
                    this.BloodPressureChart.Series[1].Points.AddY(array.LowBP);
                }
            }
        }

        /**********************************************
        *  函数名称：Set_TemperatureMonitoringChart
        *  功能：设置体温实时监控图表
        *  参数：无
        *  返回值：无
        * ********************************************/
        private void Set_TemperatureMonitoringChart()
        {
            //定义图表区域
            this.TemperatureChart.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("Temperature monitoring");
            this.TemperatureChart.ChartAreas.Add(chartarea);

            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示X轴网格线
            chartarea.AxisX.MajorGrid.Enabled = false;

            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示Y轴网格线
            //chartarea.AxisY.MajorGrid.Enabled = false;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = true;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 6;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = true;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 24;
            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 155;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = temperatureDatas.Count;
            //chartarea.AxisX.Maximum = bpVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            chartarea.AxisX.ScaleView.Size = 150;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 0.5;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            chartarea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);
            //设置Y轴单位名
            chartarea.AxisY.Title = "temperature value(°C)";
            chartarea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);

            //设置表头
            this.TemperatureChart.Titles.Clear();
            this.TemperatureChart.Titles.Add("Temperature monitoring");
            this.TemperatureChart.Titles[0].Text = "Temperature monitoring";
            this.TemperatureChart.Titles[0].ForeColor = Color.Blue;
            this.TemperatureChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.TemperatureChart.Series.Clear();

            //for (int i = 0; i < 2; i++)
            //{
            Series series = new Series(Temperature_DataType[0]);
            //设置样条图类型
            series.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series.ChartArea = "Temperature monitoring";
            //设置数据序列点颜色
            series.Color = Color.DarkRed;
            series.BorderWidth = 1;

            //设置标记点边框和大小
            series.MarkerBorderWidth = 5;
            series.MarkerSize = 5;
            //设置标记点形状
            series.MarkerStyle = MarkerStyle.Circle;
            series.ToolTip = Temperature_DataType[0] + "#VAL \r\n #AXISLABEL";

            TemperatureChart.Series.Add(series);
            //}
            //this.chart1.Series[0].YAxisType = AxisType.Primary;
            //this.chart1.Series[1].YAxisType = AxisType.Secondary;
        }

        /**********************************************
         *  函数名称：Add_TemperatureDatas
         *  功能：添加体温数据
         *  参数：无
         *  返回值：无
         * ********************************************/
        public void Add_TemperatureDatas()
        {
            if (temperature != null)
            {
                //向体温数据列表中添加数据
                temperatureDatas.Add(temperature);

                foreach (TemperatureDataType temp in temperatureDatas)
                {
                    String str = temp.TemperatureInteger + "." + temp.TemperatureDecimal;

                    this.TemperatureChart.Series[0].Points.AddY(System.Convert.ToDouble(str));
                }

            }
            else
            {
                //TemperatureDataType temp = new TemperatureDataType();
                //temp.TemperatureInteger = 0;
                //temp.TemperatureDecimal = 0;                
                //temperatureDatas.Add(temp);
                foreach (TemperatureDataType t in temperatureDatas)
                {
                    String str = t.TemperatureInteger + "." + t.TemperatureDecimal;
                    this.TemperatureChart.Series[0].Points.AddY(System.Convert.ToDouble(str));
                }
            }
        }

        /**********************************************
       *  函数名称：Set_HeartRateMonitoringChart
       *  功能：设置心率实时监控图表
       *  参数：无
       *  返回值：无
       * ********************************************/
        private void Set_HeartRateMonitoringChart()
        {
            //定义图表区域
            this.HeartRateChart.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("Heart rate monitoring");
            this.HeartRateChart.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示X轴网格线
            chartarea.AxisX.MajorGrid.Enabled = false;

            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //不显示Y轴网格线
            //chartarea.AxisY.MajorGrid.Enabled = false;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = true;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 6;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = true;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 15;

            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 100;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = heartRateDatas.Count;
            //chartarea.AxisX.Maximum = hrVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            chartarea.AxisX.ScaleView.Size = 150;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 5;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            chartarea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);
            //设置Y轴单位名
            chartarea.AxisY.Title = "heart rate value (bpm)";
            chartarea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Regular);

            //设置表头
            this.HeartRateChart.Titles.Clear();
            this.HeartRateChart.Titles.Add("Heart rate monitoring");
            this.HeartRateChart.Titles[0].Text = "Heart rate monitoring";
            this.HeartRateChart.Titles[0].ForeColor = Color.Blue;
            this.HeartRateChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 10f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.HeartRateChart.Series.Clear();

            Series series = new Series(HeartRate_DataType[0]);
            //设置样条图类型
            series.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series.ChartArea = "Heart rate monitoring";
            //设置数据序列点颜色
            series.Color = Color.Red;
            series.BorderWidth = 1;
            //设置标记点边框和大小
            series.MarkerBorderWidth = 6;
            series.MarkerSize = 6;
            //设置标记点形状
            series.MarkerStyle = MarkerStyle.Diamond;
            series.ToolTip = HeartRate_DataType[0] + "#VAL \r\n #AXISLABEL";
            HeartRateChart.Series.Add(series);

        }

        /**********************************************
        *  函数名称：Add_HeartRateDatas
        *  功能：添加心率数据
        *  参数：无
        *  返回值：无
        * ********************************************/
        public void Add_HeartRateDatas()
        {
            if (heartRate != null)
            {
                //向心率数据列表中添加数据
                heartRateDatas.Add(heartRate);

                foreach (HeartRateDataType hr in heartRateDatas)
                {
                    this.HeartRateChart.Series[0].Points.AddY(hr.HeartRate);
                }
            }
            else
            {
                //HeartRateDataType hr = new HeartRateDataType();
                //hr.HeartRate = 0;
                //heartRateDatas.Add(hr);
                foreach (HeartRateDataType h in heartRateDatas)
                {
                    this.HeartRateChart.Series[0].Points.AddY(h.HeartRate);
                }
            }
        }




    }
}
