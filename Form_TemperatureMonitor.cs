﻿using System;
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
    public partial class Form_TemperatureMonitor : Form
    {
        private Component component; //监控器表单对应的组件

        //体温数据列表
        public List<TemperatureDataType> temperatureDatas = new List<TemperatureDataType>();
        public TemperatureDataType temperature = null;
        private static string[] Temperature_DataType = { "Temperature" };

        public Form_TemperatureMonitor(Component component)
        {
            this.component = component;
            InitializeComponent();

        }

        private void Form_BloodPressureMonitor_Load(object sender, EventArgs e)
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
                         if (data.GetType().Name != "TemperatureDataType") //若不是体温数据则不显示
                             return;
                         temperature = (TemperatureDataType)data;
                     }
                     else
                     {
                         temperature = null;
                     }
                 }
             }

             Set_TemperatureMonitoringChart();          //设置体温监控图表
             Add_TemperatureDatas();                    //添加体温数据
             Series series = TemperatureChart.Series[0];   //设置点在体温监控图表首次出现位置
             TemperatureChart.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 20;

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
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 24;
            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 155;
            //设置X轴最大值
            chartarea.AxisX.Maximum = temperatureDatas.Count;
            //chartarea.AxisX.Maximum = bpVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 20;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 0.2;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            //设置Y轴单位名
            chartarea.AxisY.Title = "temperature value(°C)";

            //设置表头
            this.TemperatureChart.Titles.Clear();
            this.TemperatureChart.Titles.Add("Temperature monitoring");
            this.TemperatureChart.Titles[0].Text = "Temperature monitoring";
            this.TemperatureChart.Titles[0].ForeColor = Color.Blue;
            this.TemperatureChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
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



 



    }
}
