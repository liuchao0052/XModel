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

namespace XModel
{
    public partial class DisplayForm : Form
    {
        //public ManualResetEvent manualResetEvent; //通知线程事件

        private Component component; //显示控制器表单对应的组件

        //血压数据列表
        //public List<int[]> bloodPressureDatas = new List<int[]>();
        public List<BloodPressureDataType> bloodPressureDatas = new List<BloodPressureDataType>();

        //public int high;
        //public int low;
        //public int[] bloodPressure = null;
        public BloodPressureDataType bloodPressure = null;
        private static string[] BloodPressure_DataType = { "高压", "低压" };

        //体温数据列表
        //public List<double> temperatureDatas = new List<double>();
        public List<TemperatureDataType> temperatureDatas = new List<TemperatureDataType>();
        public TemperatureDataType temperature = null;
        //public double max_temp = 39.0; //最高体温
        //public double min_temp = 35.0; //最低体温

        //心率数据列表
        //public List<int> heartRateDatas = new List<int>();
        public List<HeartRateDataType> heartRateDatas = new List<HeartRateDataType>();
        public HeartRateDataType heartRate = null;
        //public int max_rate = 90; //最高心率
        //public int min_rate = 70; //最低心率

        //数据总量列表
        public List<int[]> dataVolumes = new List<int[]>();

        int bpVolume = 0; //血压数据量
        int tempVolume = 0;  //体温数据量
        int hrVolume = 0;  //心率数据量

        private static string[] dataVolumnsType = { "血压数据量", "体温数据量", "心率数据量" };

        public DisplayForm(Component component)
        {
            this.component = component;
            InitializeComponent();
        }
        //public DisplayForm(int[] datas)
        //{
        //    this.bloodPressure = datas;
        //    InitializeComponent();
        //}

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500; //设定定时器timer1间隔时间1s
            this.timer1.Start();

            timer2.Interval = 2000; //设定定时器timer2间隔时间2s
            this.timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.stop)
            {
                //MessageBox.Show("显示组件终止！");
                this.component.EmptyingQueue();
                this.timer1.Stop();
                return;
            }
            //if (Form1.pause)
            //{
            //    //MessageBox.Show("显示组件暂停！");
            //    //this.timer1.Stop();
            //    this.manualResetEvent = new ManualResetEvent(false);
            //    manualResetEvent.WaitOne();
            //}         

            //若显示控制器组件input端口数组不为空
            if(component.input_ports != null)
            {
                foreach (Input_port input_port in component.input_ports)
                {
                    try
                    {
                        if (input_port.Port_queue1.Count > 0) //若input端口内部队列有数据
                        {
                            switch (input_port.Port_name1)
                            {
                                case "BloodPressurePort":
                                    bloodPressure = (BloodPressureDataType)input_port.Port_queue1.Dequeue();
                                    break;
                                case "TemperaturePort":
                                    temperature = (TemperatureDataType)input_port.Port_queue1.Dequeue();
                                    break;
                                case "HeartRatePort":
                                    heartRate = (HeartRateDataType)input_port.Port_queue1.Dequeue();
                                    break;
                                default:
                                    Object temp = (Object)input_port.Port_queue1.Dequeue();

                                    if (temp.GetType().Name == "BloodPressureDataType")
                                    {
                                        bloodPressure = (BloodPressureDataType)temp;
                                    }
                                    else if (temp.GetType().Name == "TemperatureDataType")
                                    {
                                        temperature = (TemperatureDataType)temp;
                                    }
                                    else if (temp.GetType().Name == "HeartRateDataType")
                                    {
                                        heartRate = (HeartRateDataType)temp;
                                    }
                                    break;
                            }                              

                        }
                        else  //若input端口内部队列无数据
                        {
                            switch (input_port.Port_name1)
                            {
                                case "BloodPressurePort":
                                    bloodPressure = null;
                                    break;
                                case "TemperaturePort":
                                    temperature = null;
                                    break;
                                case "HeartRatePort":
                                    heartRate = null;
                                    break;
                                default:
                                    bloodPressure = null;
                                    temperature = null;
                                    heartRate = null;
                                    break;
                            }
                        }
                       


                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }

                   
                } // foreach (Input_port input_port in component.input_ports)
            } //if(component.input_ports != null)

            //Random rd = new Random();
            //++++++++ Debug 显示组件内部生成血压数据++++++++//
            //high = rd.Next(110, 140);
            //low = rd.Next(50, 90);
            //bloodPressure = new int[] { high, low };   
            //+++++++++++++++++++++++++++++++++++++++++++++++//                          
            Set_BloodPressureMonitoringChart(); //设置血压监控图表
            Add_BloodPressureDatas();
            Series series = chart1.Series[0]; //设置点在血压监控图表首次出现位置
            chart1.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 10;
 
 
            //++++++++ Debug 显示组件内部生成血压数据+++++++++++++++++++++++++++++++++++++++++//
            //temperature = Math.Round((rd.NextDouble() * (max_temp - min_temp) + min_temp), 1);
            //Console.WriteLine("temp=" + temperature);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//               
            Set_TemperatureMonitoringChart(); //设置体温监控图表
            Add_TemperatureDatas();
            Series series2 = chart2.Series[0];  //设置点在体温监控图表首次出现位置
            chart2.ChartAreas[0].AxisX.ScaleView.Position = series2.Points.Count - 10;

            //++++++++ Debug 显示组件内部生成心率数据++++++++//
            //Random rd = new Random();
            //hartRate = rd.Next(min_rate, max_rate);
            //+++++++++++++++++++++++++++++++++++++++++++++++//         
            Set_HeartRateMonitoringChart();//设置心率监控图表
            Add_HeartRateDatas();
            Series series3 = chart3.Series[0]; //设置点在心率监控图表首次出现位置
            chart3.ChartAreas[0].AxisX.ScaleView.Position = series3.Points.Count - 10;
           
            //-----------数据量统计-----------//
            //Set_DataStatisticsChart();
            //Add_DataStatistics();
        }

        //private void get_display_data(Input_port input_port)
        //{
        //    //情况一、若input端口与其他组件output/inout端口相连且input内部队列不为空
        //    if (input_port.PortConnector1.Connections.Count > 0 && input_port.Port_queue1.Count > 0)
        //    {
        //        //----------------------------------------------------------//
        //        //------ Step1. 获取连接线起点端口所附属的组件 -------------//
        //        //----------------------------------------------------------//
        //        //输入端口默认最多只有一个连接线
        //        //记录连接线起点
        //        Connector start_connector = input_port.PortConnector1.Connections[0].From;
        //        //获取连接线起点所附属的端口
        //        Output_port start_port = (Output_port)start_connector.BelongsTo;

        //        //获取起点端口所附属的组件
        //        start_component = start_port.BelongTo();
        //        //Console.WriteLine("一、起点组件为：" + start_component.name);    

        //        //------------------------------------------------//
        //        //------ Step2. 判断起点组件类型 -----------------//
        //        //------------------------------------------------//
        //        //若起点端口名为BloodPressurePort
        //        //if (start_component.name == "BloodPressure" || (start_component.name == "Patient" && start_port.Port_name1=="BloodPressure"))
        //        if (start_port.Port_name1 == "BloodPressurePort")
        //        {
        //            //input端口内部队列数据出队并传给bloodPressure变量
        //            bloodPressure = (int[])input_port.Port_queue1.Dequeue();

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //        }

        //        //若起点端口名为TemperaturePort
        //        //if (start_component.name == "Temperature")
        //        else if (start_port.Port_name1 == "TemperaturePort")
        //        {
        //            //input端口内部队列数据出队并传给temperature变量
        //            temperature = (double)input_port.Port_queue1.Dequeue();

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //        }

        //        //若起点端口名为HeartRatePort
        //        else if (start_port.Port_name1 == "HeartRatePort")
        //        {
        //            //input端口内部队列数据出队并传给temperature变量
        //            heartRate = (int)input_port.Port_queue1.Dequeue();

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //        }
        //    }
        //    //情况二、若input端口与其他组件output/inout端口相连且input内部队列为空
        //    else if (input_port.PortConnector1.Connections.Count > 0 && input_port.Port_queue1.Count == 0)
        //    {
        //        //----------------------------------------------------------//
        //        //------ Step1. 获取连接线起点端口所附属的组件 -------------//
        //        //----------------------------------------------------------//
        //        //输入端口默认最多只有一个连接线
        //        //记录连接线起点
        //        Connector start_connector = input_port.PortConnector1.Connections[0].From;
        //        //获取连接线起点所附属的端口
        //        Output_port start_port = (Output_port)start_connector.BelongsTo;
        //        //获取起点端口所附属的组件
        //        start_component = start_port.BelongTo();
        //        //Console.WriteLine("二、起点组件为：" + start_component.name);

        //        //------------------------------------------------//
        //        //------ Step2. 判断起点组件类型 -----------------//
        //        //------------------------------------------------//
        //        //若起点端口名为BloodPressurePort
        //        //if (start_component.name == "BloodPressure")
        //        if (start_port.Port_name1 == "BloodPressurePort")
        //        {
        //            //input端口内部队列数据出队并传给bloodPressure变量
        //            bloodPressure = null;
        //        }
        //        //若起点端口名为TemperaturePort
        //        //if (start_component.name == "Temperature")
        //        else if (start_port.Port_name1 == "TemperaturePort")
        //        {
        //            //input端口内部队列数据出队并传给temperature变量
        //            temperature = 0;
        //        }
        //        //若起点端口名为HeartRatePort
        //        //if (start_component.name == "HeartRate")
        //        else if (start_port.Port_name1 == "HeartRatePort")
        //        {
        //            //input端口内部队列数据出队并传给temperature变量
        //            heartRate = 0;
        //        }
        //    }
        //    //情况三、若input端口未与其他组件output/inout端口相连且input内部队列内数据不为空
        //    else if (input_port.PortConnector1.Connections.Count == 0 && input_port.Port_queue1.Count > 0)
        //    {
        //        //Console.WriteLine("input内部队列数据不为空" + input_port.Port_queue1.Count + " " + input_port.Port_ID1);
        //        Object temp = input_port.Port_queue1.Dequeue();
        //        //Console.WriteLine("temp.GetType().ToString()=" + temp.GetType().Name);
        //        //若队列中数据类型为int[]类型，可判断为血压数据
        //        if (temp.GetType().Name == "Int32[]")
        //        {
        //            bloodPressure = (int[])temp;

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        //            //+++++++++++++ Debug +++++++++++++++++++//
        //            //Console.WriteLine("bloodPressure=" + bloodPressure[0] + "; " + bloodPressure[1]);
        //            ////若input内部队列最后一个数据出队
        //            //if (input_port.Port_queue1.Count == 0)
        //            //{
        //            //    bloodPressure = null;
        //            //}
        //            //+++++++++++++++++++++++++++++++++++++++//
        //        }
        //        //若队列中数据类型为double类型，可判断为体温数据
        //        else if (temp.GetType().Name == "Double")
        //        {
        //            temperature = (double)temp;

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //        }
        //        else
        //        {
        //            heartRate = (int)temp;

        //            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
        //            //Console.Write(input_port.Component.name + "组件" + input_port.Port_ID1 + "端口队列数据(出队后):");
        //            //foreach (Object arr in input_port.Port_queue1)
        //            //{
        //            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //            //    Console.Write(arr.GetType().Name + " ;");
        //            //}
        //            //Console.WriteLine("");
        //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //        }
        //    }
        //    //情况四、若input端口未与其他组件output/inout端口相连且input内部队列为空
        //    else
        //    {
        //        //Console.WriteLine("input内部队列数据为空" + input_port.Port_ID1);
        //        //bloodPressure = null;
        //        //temperature = 0;
        //        //hartRate = 0;
                
        //    }
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            ////++++++++ Debug 显示组件内部生成心率数据++++++++//
            ////Random rd = new Random();
            ////hartRate = rd.Next(min_rate, max_rate);
            ////+++++++++++++++++++++++++++++++++++++++++++++++//         
            //Set_HeartRateMonitoringChart();//设置心率监控图表
            //Add_HeartRateDatas();
            //Series series3 = chart3.Series[0]; //设置点在心率监控图表首次出现位置
            //chart3.ChartAreas[0].AxisX.ScaleView.Position = series3.Points.Count - 10;
        }
        
        //--------血压实时监控图表-----------//
        private void Set_BloodPressureMonitoringChart()
        {
            //定义图表区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("血压实时监控");
            this.chart1.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;         
            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;   

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            chartarea.AxisY.Minimum = 20;
            //设置Y轴最大值
            chartarea.AxisY.Maximum = 155;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = bloodPressureDatas.Count;
            //chartarea.AxisX.Maximum = bpVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            chartarea.AxisX.ScaleView.Size = 10;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 20;

            //设置X轴单位名
            chartarea.AxisX.Title = "时间(s)";
            //设置Y轴单位名
            chartarea.AxisY.Title = "血压(mmHg)";

            //设置表头
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("血压实时监控");
            this.chart1.Titles[0].Text = "血压实时监控";
            this.chart1.Titles[0].ForeColor = Color.Blue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.chart1.Series.Clear();

            for (int i = 0; i < 2; i++)
            {
                Series series = new Series(BloodPressure_DataType[i]);
                //设置样条图类型
                series.ChartType = SeriesChartType.Spline;
                //设置折线图类型
                //series.ChartType = SeriesChartType.Line;
                //设置绘制数据序列的区域
                series.ChartArea = "血压实时监控";
                //设置数据序列点颜色
                //series.Color = Color.Blue;
                series.BorderWidth = 2;
 
                //设置标记点边框和大小
                series.MarkerBorderWidth = 10;
                series.MarkerSize = 8;
                //设置标记点形状
                series.MarkerStyle = MarkerStyle.Diamond;
                series.ToolTip = BloodPressure_DataType[i] + "#VAL \r\n #AXISLABEL";
                              
                chart1.Series.Add(series);
            }
            
            //this.chart1.Series[0].YAxisType = AxisType.Primary;
            //this.chart1.Series[1].YAxisType = AxisType.Secondary;
        }

        //--------体温实时监控图表-----------//
        private void Set_TemperatureMonitoringChart()
        {
            //定义图表区域
            this.chart2.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("体温实时监控");
            this.chart2.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            chartarea.AxisY.Minimum = 34;
            //设置Y轴最大值
            chartarea.AxisY.Maximum = 40;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = bloodPressureDatas.Count;
            chartarea.AxisX.Maximum =tempVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 10;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 0.5;

            //设置X轴单位名
            chartarea.AxisX.Title = "时间(s)";
            //设置Y轴单位名
            chartarea.AxisY.Title = "体温(°C)";  

            //设置表头
            this.chart2.Titles.Clear();
            this.chart2.Titles.Add("体温实时监控");
            this.chart2.Titles[0].Text = "体温实时监控";
            this.chart2.Titles[0].ForeColor = Color.Blue;
            this.chart2.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.chart2.Series.Clear();

            Series series = new Series("体温");
            //设置样条图类型
            series.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series.ChartArea = "体温实时监控";
            //设置数据序列点颜色
            series.Color = Color.DarkOrchid;
            series.BorderWidth = 2;
            //设置标记点边框和大小
            series.MarkerBorderWidth = 10;
            series.MarkerSize = 8;
            //设置标记点形状
            series.MarkerStyle = MarkerStyle.Diamond;
            series.ToolTip = "体温" + "#VAL \r\n #AXISLABEL";
            chart2.Series.Add(series);
            
        }

        //--------心率实时监控图表-----------//
        private void Set_HeartRateMonitoringChart()
        {
            //定义图表区域
            this.chart3.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("心率实时监控");
            this.chart3.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            chartarea.AxisY.Minimum = 60;
            //设置Y轴最大值
            chartarea.AxisY.Maximum = 100;
            //设置X轴最大值
            //chartarea.AxisX.Maximum = bloodPressureDatas.Count;
            chartarea.AxisX.Maximum = hrVolume;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 10;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 3;

            //设置X轴单位名
            chartarea.AxisX.Title = "时间(min)";
            //设置Y轴单位名
            chartarea.AxisY.Title = "心率(bpm)";

            //设置表头
            this.chart3.Titles.Clear();
            this.chart3.Titles.Add("心率实时监控");
            this.chart3.Titles[0].Text = "心率实时监控";
            this.chart3.Titles[0].ForeColor = Color.Blue;
            this.chart3.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.chart3.Series.Clear();

            Series series = new Series("心率");
            //设置样条图类型
            series.ChartType = SeriesChartType.Spline;
            //设置折线图类型
            //series.ChartType = SeriesChartType.Line;
            //设置绘制数据序列的区域
            series.ChartArea = "心率实时监控";
            //设置数据序列点颜色
            series.Color = Color.Red;
            series.BorderWidth = 2;
            //设置标记点边框和大小
            series.MarkerBorderWidth = 10;
            series.MarkerSize = 8;
            //设置标记点形状
            series.MarkerStyle = MarkerStyle.Diamond;
            series.ToolTip = "心率" + "#VAL \r\n #AXISLABEL";
            chart3.Series.Add(series);

        }

        //--------数据统计图表-----------//
        private void Set_DataStatisticsChart()
        {
            //定义图表区域
            this.chart4.ChartAreas.Clear();
            ChartArea chartarea = new ChartArea("数据量统计");
            this.chart4.ChartAreas.Add(chartarea);
            //设置X轴网格线条颜色
            //chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartarea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //设置Y轴网格线条线条颜色
            chartarea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;

            //设置X轴滚动条是否可见
            chartarea.AxisX.ScrollBar.Enabled = false;
            //设置滚动条粗细
            chartarea.AxisX.ScrollBar.Size = 10;
            //设置滚动条在图表外部
            chartarea.AxisX.ScrollBar.IsPositionedInside = false;

            //设置Y轴最小值
            //chartarea.AxisY.Minimum = 40;
            
            //设置X轴最大值
            chartarea.AxisX.Maximum = dataVolumes.Count;

            //设置X轴视图缩放大小，指当前显示的是第几个  
            //chartarea.AxisX.ScaleView.Size = 10;

            //设置X轴间隔
            chartarea.AxisX.Interval = 1;
            //设置Y轴间隔
            chartarea.AxisY.Interval = 50;

            //设置X轴单位名
            chartarea.AxisX.Title = "时间(s)";
            //设置Y轴单位名
            chartarea.AxisY.Title = "数据量";

            //设置表头
            this.chart4.Titles.Clear();
            this.chart4.Titles.Add("数据量统计");
            this.chart4.Titles[0].Text = "数据量统计";
            this.chart4.Titles[0].ForeColor = Color.Blue;
            this.chart4.Titles[0].Font = new System.Drawing.Font("Microsoft Sans serif", 12f, FontStyle.Bold);
            //定义存储和显示点的容器
            this.chart4.Series.Clear();

            for (int i = 0; i < 3; i++)
            {
                Series series = new Series(dataVolumnsType[i]);
                //设置柱形图类型
                series.ChartType = SeriesChartType.Column;
                //设置样条图类型
                //series.ChartType = SeriesChartType.Spline;
                //设置折线图类型
                //series.ChartType = SeriesChartType.Line;
                //设置绘制数据序列的区域
                series.ChartArea = "数据量统计";
                //设置数据序列点颜色
                //series.Color = Color.DarkSlateBlue;
                series.BorderWidth = 2;
                //设置标记点边框和大小
                //series.MarkerBorderWidth = 10;
                //series.MarkerSize = 8;
                //设置标记点形状
                //series.MarkerStyle = MarkerStyle.Circle;
                series.ToolTip = dataVolumnsType[i] + "#VAL \r\n #AXISLABEL";
                chart4.Series.Add(series);
            }

        }

        //--------血压数据导入图表-------------------------//
        //入口参数:                                        //
        //高压:  High                                      //
        //低压:  Low                                       //
        public void Add_BloodPressureDatas()
        {
            //Console.WriteLine("血压数据计数："+bloodPressureDatas.Count);
            //当血压数据不为空
            if (bloodPressure != null)
            {
                //向血压数据列表中添加数据
                bloodPressureDatas.Add(bloodPressure);
                bpVolume++;
                foreach (BloodPressureDataType array in bloodPressureDatas)
                {
                    //Console.WriteLine(array[0] + "  " + array[1]);
                    //Console.WriteLine(array[1]);
                    this.chart1.Series[0].Points.AddY(array.HighBP);
                    this.chart1.Series[1].Points.AddY(array.LowBP);
                }   
            }
            else
            {
                BloodPressureDataType bp = new BloodPressureDataType();
                bp.HighBP = 0;
                bp.LowBP = 0;
                bloodPressureDatas.Add(bp);
                foreach (BloodPressureDataType array in bloodPressureDatas)
                {
                    //Console.WriteLine(array.HighBP + " ," + array.LowBP);
                    this.chart1.Series[0].Points.AddY(array.HighBP);
                    this.chart1.Series[1].Points.AddY(array.LowBP);
                }
            } 
            ////若血压数据为空，图表显示时添加数据0
            //else 
            //{                
            //    int[] temp = new int[] { 0, 0 };
            //    bloodPressureDatas.Add(temp);
            //    foreach (int[] array in bloodPressureDatas)
            //    {
            //        //Console.WriteLine(array[0] + "  " + array[1]);
            //        //Console.WriteLine(array[1]);
            //        this.chart1.Series[0].Points.AddY(array[0]);
            //        this.chart1.Series[1].Points.AddY(array[1]);
            //    }   
            //} 
            //this.timer1.Stop();
        }

        //--------体温数据导入图表-------------------------//
        public void Add_TemperatureDatas()
        {
            //Console.WriteLine(temperature);
            if (temperature != null)
            {
                //向体温数据列表中添加数据
                temperatureDatas.Add(temperature);
                tempVolume++;

                foreach (TemperatureDataType temp in temperatureDatas)
                {
                    String str = temp.TemperatureInteger + "." + temp.TemperatureDecimal;
                   
                    this.chart2.Series[0].Points.AddY( System.Convert.ToDouble(str) );
                }
            }
            else
            {
                TemperatureDataType temp = new TemperatureDataType();
                temp.TemperatureInteger = 0;
                temp.TemperatureDecimal = 0;
                String str = temp.TemperatureInteger + "." + temp.TemperatureDecimal;
                temperatureDatas.Add(temp);
                foreach (TemperatureDataType t in temperatureDatas)
                {

                    this.chart2.Series[0].Points.AddY(System.Convert.ToDouble(str));
                }
            }
            //this.timer1.Stop();
        }

        //--------心率数据导入图表-------------------------//
        public void Add_HeartRateDatas()
        {
            if (heartRate != null)
            {
                //向心率数据列表中添加数据
                heartRateDatas.Add(heartRate);
                hrVolume++;
                foreach (HeartRateDataType hr in heartRateDatas)
                {
                    this.chart3.Series[0].Points.AddY(hr.HeartRate);
                }
            }
            else
            {
                HeartRateDataType hr = new HeartRateDataType();
                hr.HeartRate = 0;
                heartRateDatas.Add(hr);
                foreach (HeartRateDataType h in heartRateDatas)
                {
                    this.chart3.Series[0].Points.AddY(h.HeartRate);
                }
            }
            //this.timer1.Stop();
        }

        //--------数据量导入图表-------------------------//
        public void Add_DataStatistics()
        {
            //int bpVolume =  bloodPressureDatas.Count; //血压数据量
            //int tempVolume = temperatureDatas.Count;  //体温数据量
            //int hrVolume = heartRateDatas.Count;  //心率数据量
            //foreach (int[] data in bloodPressureDatas)
            //{
            //    if (data == new int[] { 0, 0 })
            //    {
            //        bpVolume--;
            //    }
            //}
            //foreach (double data in temperatureDatas)
            //{
            //    if (data == 0)
            //    {
            //        tempVolume--;
            //    }
            //}
            //foreach (int data in heartRateDatas)
            //{
            //    if (data == 0)
            //    {
            //        hrVolume--;
            //    }
            //}
            int[] count = new int[] { bpVolume, tempVolume, hrVolume };
            dataVolumes.Add(count); 
            foreach (int[] array in dataVolumes)  
            {
                this.chart4.Series[0].Points.AddY(array[0]);
                this.chart4.Series[1].Points.AddY(array[1]);
                this.chart4.Series[2].Points.AddY(array[2]);
            }
           
        }
    }
}
