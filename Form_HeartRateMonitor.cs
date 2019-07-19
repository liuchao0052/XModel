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
    public partial class Form_HeartRateMonitor : Form
    {
        private Component component; //监控器表单对应的组件

        //心率数据列表
        public List<HeartRateDataType> heartRateDatas = new List<HeartRateDataType>();
        public HeartRateDataType heartRate = null;
        private static string[] HeartRate_DataType = { "HeartRate" };

        public Form_HeartRateMonitor(Component component)
        {
            this.component = component;
            InitializeComponent();
        }

        private void Form_HeartRateMonitor_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500; //设定定时器timer1间隔时间0.5s
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
            if (component.input_ports != null)
            {
                foreach (Input_port input_port in component.input_ports)
                {
                    if (input_port.Port_queue1.Count > 0) //若input端口内部队列有数据
                    {
                        Object data = input_port.Port_queue1.Dequeue();
                        if (data.GetType().Name != "HeartRateDataType") //若不是心率数据则不显示
                            return;

                        heartRate = (HeartRateDataType)data;
                    }
                    else
                    {
                        heartRate = null;
                    }
                }
            }

            Set_HeartRateMonitoringChart();               //设置心率监控图表
            Add_HeartRateDatas();                         //添加心率数据
            Series series = HeartRateChart.Series[0];     //设置点在心率监控图表首次出现位置
            HeartRateChart.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 20;

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
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 15;

            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 100;
            //设置X轴最大值
            chartarea.AxisX.Maximum = heartRateDatas.Count;
            //chartarea.AxisX.Maximum = hrVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 10;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 5;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            //设置Y轴单位名
            chartarea.AxisY.Title = "heart rate value (bpm)";

            //设置表头
            this.HeartRateChart.Titles.Clear();
            this.HeartRateChart.Titles.Add("Heart rate monitoring");
            this.HeartRateChart.Titles[0].Text = "Heart rate monitoring";
            this.HeartRateChart.Titles[0].ForeColor = Color.Blue;
            this.HeartRateChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
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
