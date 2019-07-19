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
    public partial class Form_BloodPressureMonitor : Form
    {
        private Component component; //监控器表单对应的组件

        //血压数据列表
        public List<BloodPressureDataType> bloodPressureDatas = new List<BloodPressureDataType>();
        public BloodPressureDataType bloodPressure = null;
        private static string[] BloodPressure_DataType = { "HighPressure", "LowPressure" };

        public Form_BloodPressureMonitor(Component component)
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
                          if (data.GetType().Name != "BloodPressureDataType") //若不是血压数据则不显示
                              return;
                          bloodPressure = (BloodPressureDataType)data;
                      }
                      else
                      {
                          bloodPressure = null;
                      }
                  }
              }
              Set_BloodPressureMonitoringChart();        //设置血压监控图表
              Add_BloodPressureDatas();                  //添加血压数据
              Series series = BloodPressureChart.Series[0];   //设置点在血压监控图表首次出现位置
              BloodPressureChart.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 20;
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
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 20;

            chartarea.AxisY.IsStartedFromZero = false;

            //设置Y轴最大值
            //chartarea.AxisY.Maximum = 155;
            //设置X轴最大值
            chartarea.AxisX.Maximum = bloodPressureDatas.Count;
            //chartarea.AxisX.Maximum = bpVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 20;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 5;

            //设置X轴单位名
            chartarea.AxisX.Title = "sequence number";
            //设置Y轴单位名
            chartarea.AxisY.Title = "pressure value (mmHg)";

            //设置表头
            this.BloodPressureChart.Titles.Clear();
            this.BloodPressureChart.Titles.Add("Blood pressure monitoring");
            this.BloodPressureChart.Titles[0].Text = "Blood pressure monitoring";
            this.BloodPressureChart.Titles[0].ForeColor = Color.Blue;
            this.BloodPressureChart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
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
            series.MarkerBorderWidth = 7;
            series.MarkerSize = 7;
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
            series2.MarkerBorderWidth = 7;
            series2.MarkerSize = 7;
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



 







    }
}
