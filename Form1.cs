using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using XModel.BasicLibrary;
using Netron.GraphLib;
using Netron.GraphLib.UI;
using System.Threading;
using XModel.CMIoTLibrary;

namespace XModel
{
  
    public partial class Form1 : Form
    {
      
        //组件列表
        private List<Component> list_components = null;

        //端口连接线列表,形式为：{[起始端口1，终点端口1]，[起始端口2，终点端口2], ..。}
        private List<Port[]> list_Connection = new List<Port[]>();

        //public ManualResetEvent manualResetEvent; //通知线程事件
        //public static bool pause = false; //线程暂停
        public static bool stop = false;  //线程停止
     

        //================================================//
        //===============基本组件库中组件=================//
        //================================================//
        BloodPressure bloodPressure = null;             //B01 血压组件
        Temperature temperature = null;                 //B02 体温组件
        HeartRate heartRate = null;                     //B03 心率组件
        BloodPressureSensor bloodPressureSensor = null; //B04 血压传感器组件
        TemperatureSensor temperatureSensor = null;     //B05 体温传感器组件
        HeartRateSensor heartRateSensor = null;         //B06 心率传感器组件
        DisplayController displayController = null;     //B07 显示控制器组件
        AudioController audioController = null;         //B08 音频控制器组件
        ElectricMachineryController electricMachineryController = null; //B09 电机控制器组件
        MicroProcessor microProcessor = null;           //B10 运算器 微处理器组件
        ProtocolConverter protocolConverter = null;     //B11 协议转换器组件
        DataProcessor dataProcessor = null;             //B12 数据处理器组件
        DataAnalyzer dataAnalyzer = null;               //B13 数据分析器组件
        WiredModule wiredModule = null;                 //B14 有线通信模块组件
        WirelessModule wirelessModule = null;           //B15 无线通信模块组件
        WiredMedia wiredMedia = null;                   //B16 有线媒介组件
        WirelessMedia wirelessMedia = null;             //B17 无线媒介组件
        Register register = null;                       //B18 寄存器组件
        RAM ram = null;                                 //B19 存储器RAM组件
        ROM rom = null;                                 //B20 存储器ROM组件
        DataMemory dataMemory = null;                   //B21 数据存储器组件
        MyBuffer buffer = null;                         //B22 缓冲区组件
        RouteModule routeModule = null;                 //B23 路由模块组件
        MyMonitor monitor = null;                       //B24 监控器组件
        BloodPressureMonitor bpMonitor = null;          //B25 血压监控器组件
        TemperatureMonitor tempMonitor = null;          //B26 体温监控器组件
        HeartRateMonitor hrMonitor = null;              //B27 心率监控器组件
        
        //===================================================//
        //=============== CMIoT组件库中组件 =================//
        //===================================================//
        Patient patient = null;                         //C01 患者组件
        BloodPressureSensorNode BPSN = null;            //C02 血压传感节点组件
        TemperatureSensorNode TSN = null;               //C03 体温传感节点组件
        HeartRateSensorNode HRSN = null;                //C04 心率传感节点组件
        IoTGateway IoTG = null;                         //C05 物联网网关组件
        Channel802_11 channel_802_11 = null;            //C06 802.11信道组件
        Channel802_15_1 channel802_15_1 = null;         //C07 802.15.1信道组件
        Channel802_15_4 channel802_15_4 = null;         //C08 802.15.4信道组件
        ChannelEthernet channel_ethernet = null;        //C09 802.3信道组件
        IPv6Router ipv6Router = null;                   //C10 IPv6路由器组件
        MedicalServer MS = null;                        //C11 医疗服务器组件


        public List<Component> List_components
        {
            get { return list_components; }
            set { list_components = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /***************************************************************************
         *  函数名称：treeView1_NodeMouseDoubleClick()
         *  功能：组件库列表表项鼠标双击事件,在graphControl绘图控制区创建相应组件
         *  参数：sender;e
         *  返回值：无
         * *************************************************************************/
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            if (treeView1.SelectedNode.Level > 1)
            {
                string name;         
                //int tabIndex = 0; //第一个选项卡
                name = e.Node.Name.ToString();
                switch (name)
                {
                    //================================================================//
                    //======================创建基本组件==============================//
                    //================================================================//
                    //B01 人体血压
                    case "BloodPressure":                        
                        bloodPressure = new BloodPressure(this.graphControl,null,null,null);
                        graphControl.AddShape(bloodPressure, bloodPressure.Location);
                        break;

                    //B02 人体体温
                    case "Temperature":
                        temperature = new Temperature(this.graphControl, null, null, null);
                        graphControl.AddShape(temperature, new PointF(temperature.Location.X, temperature.Location.Y + 80));
                        break;

                    //B03 人体心率
                    case "HeartRate":
                        heartRate = new HeartRate(this.graphControl, null, null, null);
                        graphControl.AddShape(heartRate, new PointF(heartRate.Location.X, heartRate.Location.Y + 160));
                        break;

                    //B04 血压传感器
                    case "BloodPressureSensor":
                        bloodPressureSensor = new BloodPressureSensor(this.graphControl, null, null, null);
                        graphControl.AddShape(bloodPressureSensor, new PointF(bloodPressureSensor.Location.X + 110, bloodPressureSensor.Location.Y));
                        break;

                    //B05 体温传感器
                    case "TemperatureSensor":
                        temperatureSensor = new TemperatureSensor(this.graphControl, null, null, null);
                        graphControl.AddShape(temperatureSensor, new PointF(temperatureSensor.Location.X + 110, temperatureSensor.Location.Y + 80));
                        break;

                    //B06 心率传感器
                    case "HeartRateSensor":
                        heartRateSensor = new HeartRateSensor(this.graphControl, null, null, null);
                        graphControl.AddShape(heartRateSensor, new PointF(heartRateSensor.Location.X + 110, heartRateSensor.Location.Y + 160));
                        break;

                    //B07 显示控制器
                    case "DisplayController":
                        displayController = new DisplayController(this.graphControl, null, null, null);
                        graphControl.AddShape(displayController, new PointF(displayController.Location.X + 220, displayController.Location.Y));
                        break;

                    //B08 音频控制器
                    case "AudioController":
                        audioController = new AudioController(this.graphControl, null, null, null);
                        graphControl.AddShape(audioController, new PointF(audioController.Location.X + 220, audioController.Location.Y+80));
                        break;

                    //B09 电机控制器
                    case "ElectricMachineryController":
                        electricMachineryController = new ElectricMachineryController(this.graphControl, null, null, null);
                        graphControl.AddShape(electricMachineryController, new PointF(electricMachineryController.Location.X + 220, electricMachineryController.Location.Y + 160));
                        break;

                    //B10 运算器 微处理器
                    case "MicroProcessor":
                        microProcessor = new MicroProcessor(this.graphControl, null, null, null);
                        graphControl.AddShape(microProcessor, new PointF(microProcessor.Location.X + 330, microProcessor.Location.Y));
                        break;

                    //B11 协议转换器
                    case "ProtocolConverter":
                        protocolConverter = new ProtocolConverter(this.graphControl, null, null, null);
                        graphControl.AddShape(protocolConverter, new PointF(protocolConverter.Location.X + 330, protocolConverter.Location.Y+70));
                        break;

                    //B12 数据处理器
                    case "DataProcessor":
                        dataProcessor = new DataProcessor(this.graphControl, null, null, null);
                        graphControl.AddShape(dataProcessor, new PointF(dataProcessor.Location.X + 330, dataProcessor.Location.Y + 160));
                        break;

                    //B13 数据分析器
                    case "DataAnalyzer":
                        dataAnalyzer = new DataAnalyzer(this.graphControl, null, null, null);
                        graphControl.AddShape(dataAnalyzer, new PointF(dataAnalyzer.Location.X + 330, dataAnalyzer.Location.Y + 240));
                        break;

                    //B14 有线通信模块
                    case "WiredModule":
                        wiredModule = new WiredModule(this.graphControl, null, null, null);
                        graphControl.AddShape(wiredModule, new PointF(wiredModule.Location.X + 440, wiredModule.Location.Y));
                        break;

                    //B15 无线通信模块
                    case "WirelessModule":
                        wirelessModule = new WirelessModule(this.graphControl, null, null, null);
                        graphControl.AddShape(wirelessModule, new PointF(wirelessModule.Location.X + 440, wirelessModule.Location.Y+80));
                        break;

                    //B16 有线媒介
                    case "WiredMedia":
                        wiredMedia = new WiredMedia(this.graphControl, null, null, null);
                        graphControl.AddShape(wiredMedia, new PointF(wiredMedia.Location.X + 440, wiredMedia.Location.Y+160));
                        break;

                    //B17 无线媒介
                    case "WirelessMedia":
                        wirelessMedia = new WirelessMedia(this.graphControl, null, null, null);
                        graphControl.AddShape(wirelessMedia, new PointF(wirelessMedia.Location.X + 440, wirelessMedia.Location.Y+240));
                        break;

                    //18 寄存器
                    case "Register":
                        register = new Register(this.graphControl, null, null, null);
                        graphControl.AddShape(register, new PointF(register.Location.X + 550, register.Location.Y));
                        break;

                    //B19 存储器RAM
                    case "RAM":
                        ram = new RAM(this.graphControl, null, null, null);
                        graphControl.AddShape(ram, new PointF(ram.Location.X + 550, ram.Location.Y+80));
                        break;

                    //B20 存储器ROM
                    case "ROM":
                        rom = new ROM(this.graphControl, null, null, null);
                        graphControl.AddShape(rom, new PointF(rom.Location.X + 550, rom.Location.Y + 160));
                        break;

                    //B21 数据存储器
                    case "DataMemory":
                        dataMemory = new DataMemory(this.graphControl, null, null, null);
                        graphControl.AddShape(dataMemory, new PointF(dataMemory.Location.X + 550, dataMemory.Location.Y + 240));
                        break;

                    //B22 缓冲区
                    case "Buffer":
                        buffer = new MyBuffer(this.graphControl, null, null, null);
                        graphControl.AddShape(buffer, new PointF(buffer.Location.X + 550, buffer.Location.Y + 320));
                        break;

                    //B23 路由模块
                    case "RouteModule":
                        routeModule = new RouteModule(this.graphControl, null, null, null);
                        graphControl.AddShape(routeModule, new PointF(routeModule.Location.X + 330, routeModule.Location.Y + 320));
                        break;

                    //B24 监控器
                    case "Monitor":
                        monitor = new MyMonitor(this.graphControl, null, null, null);
                        graphControl.AddShape(monitor, new PointF(monitor.Location.X + 220, monitor.Location.Y + 240));
                        break;

                    //B25 血压监控器
                    case "BloodPressureMonitor":
                        bpMonitor = new BloodPressureMonitor(this.graphControl, null, null, null);
                        graphControl.AddShape(bpMonitor, new PointF(bpMonitor.Location.X + 220, bpMonitor.Location.Y + 280));
                        break;

                    //B26 体温监控器
                    case "TemperatureMonitor":
                        tempMonitor = new TemperatureMonitor(this.graphControl, null, null, null);
                        graphControl.AddShape(tempMonitor, new PointF(tempMonitor.Location.X + 220, tempMonitor.Location.Y + 320));
                        break;

                    //B27 心率监控器
                    case "HeartRateMonitor":
                        hrMonitor = new HeartRateMonitor(this.graphControl, null, null, null);
                        graphControl.AddShape(hrMonitor, new PointF(hrMonitor.Location.X + 220, hrMonitor.Location.Y + 360));
                        break;

                    //====================================================================//
                    //======================CMIoT组件库中组件=============================//
                    //====================================================================//
                    //C01 患者组件
                    case "Patient":
                        patient = new Patient(this.graphControl);
                        graphControl.AddShape(patient, patient.Location);
                        break;
                    //C02 血压传感节点
                    case "BloodPressureSensorNode":
                        BPSN = new BloodPressureSensorNode(this.graphControl);
                        //BPSN_InsideForm = new InsideForm(BPSN); //构建内部结构
                        graphControl.AddShape(BPSN, BPSN.Location);
                        break;
                    //C03 体温传感节点
                    case "TemperatureSensorNode":
                        TSN = new TemperatureSensorNode(this.graphControl);
                        graphControl.AddShape(TSN, TSN.Location);
                        break;
                    //C04 心率传感节点
                    case "HeartRateSensorNode":
                        HRSN = new HeartRateSensorNode(this.graphControl);
                        graphControl.AddShape(HRSN, HRSN.Location);
                        break;
                    //C05 物联网网关
                    case "IoTGateway":
                        IoTG = new IoTGateway(this.graphControl);
                        graphControl.AddShape(IoTG, IoTG.Location);
                        break;
                    //C06 802.11信道组件
                    case "802.11Channel":
                        channel_802_11 = new Channel802_11(this.graphControl,null,null,null);
                        graphControl.AddShape(channel_802_11, channel_802_11.Location);
                        break;
                    //C07 802.15.1信道组件
                    case "802.15.1Channel":
                        channel802_15_1 = new Channel802_15_1(this.graphControl, null, null, null);
                        graphControl.AddShape(channel802_15_1, channel802_15_1.Location);
                        break;
                    //C08 802.15.4信道组件
                    case "802.15.4Channel":
                        channel802_15_4 = new Channel802_15_4(this.graphControl, null, null, null);
                        graphControl.AddShape(channel802_15_4, channel802_15_4.Location);
                        break;
                    //C09 Ethernet信道组件
                    case "EthernetChannel":
                        channel_ethernet = new ChannelEthernet(this.graphControl, null, null, null);
                        graphControl.AddShape(channel_ethernet, channel_ethernet.Location);
                        break;
                    //C10 IPv6路由器组件
                    case "IPv6Router":
                        ipv6Router = new IPv6Router(this.graphControl);
                        graphControl.AddShape(ipv6Router, ipv6Router.Location);
                        break;
                    //C11 医疗服务器组件
                    case "MedicalServer":
                        MS = new MedicalServer(this.graphControl);
                        graphControl.AddShape(MS, MS.Location);
                        break;
                }
            }// if (treeView1.SelectedNode.Level > 1)
        }//treeView1_NodeMouseDoubleClick


       /***********************************************
        *  函数名称：Run_Click()
        *  功能：运行按钮单击事件，执行所构建的模型
        *  参数：sender;e
        *  返回值：无
        * **********************************************/
        public void Run_Click(object sender, EventArgs e)
        {
            //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
            //Console.WriteLine(graphControl.Controls.GetType());
            //Console.WriteLine(graphControl.NodesCount);
            //Console.WriteLine(graphControl.Shapes.Count);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
            stop = false;
            //pause = false;

            //创建组件列表
            list_components = new List<Component>();
                 
            //遍历graphControl画布中所有的控件
            foreach (Shape shape in graphControl.Shapes)
            {
                //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                //Console.WriteLine("控件名称：" + shape.GetType().Name + " " + 
                //    "控件基类名称：" + shape.GetType().BaseType.Name);
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                //若控件的基类为组件Component
                if (shape.GetType().BaseType.Name == "Component")
                {
                    Component component = (Component)shape;
                   
                    //将该组件添加至组件列表
                    list_components.Add(component);

                    //记录组件output/input端口所有连接线并添加至连接线列表
                    RecordConnections(component);

                    //根据组件类型启动执行各组件
                    ComponentsStartRun(component);
                }//if (shape.GetType().BaseType.Name == "Component")     

            }//foreach (Shape shape in graphControl.Shapes)     
       
        }//private void Run_Click(object sender, EventArgs e)

       /***********************************************
        *  函数名称：ComponentsStartRun()
        *  功能：依据组件类型启动执行相应的组件
        *  参数：component 相应启动执行的组件
        *  返回值：无
        * **********************************************/
        private void ComponentsStartRun(Component component)
        {
            // 若组件为B01:血压组件
            if (component.GetType().Name == "BloodPressure")
            {
                bloodPressure = (BloodPressure)component;
                int x = 1; //设定血压数据获取方式

                //创建生成血压数据的线程
                //Thread GeneratingBPData_thread = new Thread(bloodPressure.GeneratingBloodPressureData); //不带参数创建Thread 
                //GeneratingBPData_thread.Start(); //启动线程

                Thread bp_thread = new Thread(new ParameterizedThreadStart(bloodPressure.run)); //带1个参数传递的线程创建
                bp_thread.Start(x);
            }

            // 若组件为B02:体温组件
            else if (component.GetType().Name == "Temperature")
            {
                temperature = (Temperature)component;
                int x = 1; //设定体温数据获取方式

                //创建生成体温数据的线程
                Thread temp_thread = new Thread(new ParameterizedThreadStart(temperature.run)); //带1个参数传递的线程创建
                temp_thread.Start(x);
            }

            // 若组件为B03:心率组件
            else if (component.GetType().Name == "HeartRate")
            {
                heartRate = (HeartRate)component;
                int x = 1; //设定心率数据获取方式

                //创建生成心率数据的线程
                Thread hr_thread = new Thread(new ParameterizedThreadStart(heartRate.run)); //带1个参数传递的线程创建
                hr_thread.Start(x);
            }

            // 若组件为B04:血压传感器组件
            else if (component.GetType().Name == "BloodPressureSensor")
            {
                bloodPressureSensor = (BloodPressureSensor)component;
                
                //创建血压传感器执行的线程
                Thread bps_thread = new Thread(bloodPressureSensor.run); 
                bps_thread.Start();
            }

            // 若组件为B07:显示控制器组件
            else if (component.GetType().Name == "DisplayController")
            {
                displayController = (DisplayController)component;
                displayController.run();
            }
            
            //若组件为B10:微处理器组件
            else if (component.GetType().Name == "MicroProcessor")
            {
                microProcessor = (MicroProcessor)component;
                //int x = 1; //设定封装为6LoWPAN报文格式
                string x = "6LoWPAN"; //设定封装为6LoWPAN报文格式
                //创建微处理器执行的线程
                Thread mp_thread = new Thread(new ParameterizedThreadStart(microProcessor.run));
                mp_thread.Start(x);
            }

            // 若组件为B24:监控器器组件
            else if (component.GetType().Name == "MyMonitor")
            {
                MyMonitor myMonitor = (MyMonitor)component;
                myMonitor.run();
            }

            //若组件为B25:血压监控器
            else if (component.GetType().Name == "BloodPressureMonitor")
            {
                BloodPressureMonitor bpMonitor = (BloodPressureMonitor)component;
                bpMonitor.run();
            }

            //若组件为B26:体温监控器
            else if (component.GetType().Name == "TemperatureMonitor")
            {
                TemperatureMonitor tempMonitor = (TemperatureMonitor)component;
                tempMonitor.run();
            }

            //B27 心率监控器
            else if (component.GetType().Name == "HeartRateMonitor")
            {
                HeartRateMonitor hrMonitor = (HeartRateMonitor)component;
                hrMonitor.run();
            }

            // 若组件为C01:患者组件
            else if (component.GetType().Name == "Patient")
            {
                patient = (Patient)component;

                //创建患者组件执行的线程
                Thread patient_thread = new Thread(patient.run); //不带参数创建Thread 

                patient_thread.Start(); //启动线程

                //+++++++++++++++++++ Debug +++++++++++++++++++++++++++++++++//
                //foreach (int[] arr in patient.output_ports[0].Port_queue1)
                //{
                //    Console.WriteLine("血压数据：" + arr[0] + " " + arr[1]);
                //}
                //foreach (double arr in patient.output_ports[1].Port_queue1)
                //{
                //    Console.WriteLine("体温数据：" + arr);
                //}
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
            }

            //若组件为C02:血压传感节点组件
            else if (component.GetType().Name == "BloodPressureSensorNode")
            {
                BPSN = (BloodPressureSensorNode)component;
            
                //创建血压传感节点组件的线程
                Thread bpsn_thread = new Thread(BPSN.run); //不带参数创建Thread 
                bpsn_thread.Start(); //启动线程
            }

            //若组件为C03:体温传感节点组件
            else if (component.GetType().Name == "TemperatureSensorNode")
            {
                TSN = (TemperatureSensorNode)component;

                //创建体温传感节点组件的线程
                Thread tsn_thread = new Thread(TSN.run); //不带参数创建Thread 
                tsn_thread.Start(); //启动线程
            }

            //若组件为C04:心率传感节点组件
            else if (component.GetType().Name == "HeartRateSensorNode")
            {
                HRSN = (HeartRateSensorNode)component;

                //创建心率传感节点组件的线程
                Thread hrsn_thread = new Thread(HRSN.run); //不带参数创建Thread 
                hrsn_thread.Start(); //启动线程
            }

            //若为C05:物联网网关组件
            else if (component.GetType().Name == "IoTGateway")
            {
                IoTG = (IoTGateway)component;
                //创建物联网网关组件执行的线程
                Thread gateway_thread = new Thread(IoTG.run);
                gateway_thread.Start();
            }

            //若为C07:802.15.1Channel组件
            else if (component.GetType().Name == "Channel802_15_1")
            {
                channel802_15_1 = (Channel802_15_1)component;
                //创建802.15.1Channel组件执行的线程
                Thread channel_802151_thread = new Thread(channel802_15_1.run);
                channel_802151_thread.Start();
            }

            //若为C08:802.15.4Channel组件
            else if (component.GetType().Name == "Channel802_15_4")
            {
                channel802_15_4 = (Channel802_15_4)component;
                //创建802.15.4Channel组件执行的线程
                Thread channel_802154_thread = new Thread(channel802_15_4.run);
                channel_802154_thread.Start();
            }

            //若为C09:Ethernet信道组件
            else if (component.GetType().Name == "ChannelEthernet")
            {
                channel_ethernet = (ChannelEthernet)component;
                //创建EthernetChannel组件执行的线程
                Thread channel_ethernet_thread = new Thread(channel_ethernet.run);
                channel_ethernet_thread.Start();
            }

            //若为C10:IPv6路由器组件
            else if (component.GetType().Name == "IPv6Router")
            {
                ipv6Router = (IPv6Router)component;
                //创建IPv6Router组件执行的线程
                Thread ipv6_router_thread = new Thread(ipv6Router.run);
                ipv6_router_thread.Start();
            }

            //若为C11:医疗服务器组件
            else if (component.GetType().Name == "MedicalServer")
            {
                MS = (MedicalServer)component;
                //创建MedicalServer组件执行线程
                Thread ms_thread = new Thread(MS.run);
                ms_thread.Start();
            }

        }

       /***********************************************
        *  函数名称：RecordConnections()
        *  功能：记录组件所有连接线
        *  参数：component
        *  返回值：list_Connection 记录连接线的列表
        * **********************************************/
        private void RecordConnections(Component component)
        {            
            //1.若组件的output端口不为空
            if (component.output_ports != null)
            {
                //Console.WriteLine(commponent .name+"的输出端口不为空");
                //遍历组件所有输出端口
                foreach (Output_port output_port in component.output_ports)
                {
                    //Console.WriteLine("form1里："+((output_port.PortConnector1.Connections == null) ? true : false));
                    //Console.WriteLine("输出端口连接点的端口=" + output_port.PortConnector1.BelongsTo);

                    //若输出端口连接点存在连接线
                    if (output_port.PortConnector1.Connections.Count > 0)
                    {
                        //遍历该输出端口所有连接线
                        foreach (Connection connection in output_port.PortConnector1.Connections)
                        {
                            //记录连接线起点
                            Connector start_connector = connection.From;
                            //记录连接线终点
                            Connector end_connector = connection.To;

                            //获取连接线起点所附属的端口
                            Port start_port = (Port)start_connector.BelongsTo;
                            //获取连接线终点所附属的端口
                            Port end_port = (Port)end_connector.BelongsTo;
                            //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);

                            Port[] port_array = new Port[] { start_port, end_port };

                            //将起始端口终点端口对加入连接线列表
                            list_Connection.Add(port_array);

                            ////获取连接线对应的连接点数组
                            //PointF[] points = connection.GetConnectionPoints();
                            //for (int i = 0; i < points.Length;i++ )
                            //    Console.WriteLine("连接点"+i+"坐标：" + points[i]);              

                        }//foreach (Connection connection in output_port.PortConnector1.Connections)
                    }//if (output_port.PortConnector1.Connections.Count > 0)  
                }//foreach(Output_port output_port in commponent.output_ports )
            }// if (commponent.output_ports != null)

            //2.若组件的inout端口不为空
            if (component.inout_ports != null)
            {
                //遍历组件所有输入输出端口
                foreach (Inout_port inout_port in component.inout_ports)
                {
                    //若输入输出端口连接点存在连接线
                    if (inout_port.PortConnector1.Connections.Count > 0)
                    {
                        //遍历该输入输出端口所有连接线
                        foreach (Connection connection in inout_port.PortConnector1.Connections)
                        {
                            //记录连接线起点
                            Connector start_connector = connection.From;
                            //记录连接线终点
                            Connector end_connector = connection.To;

                            //获取连接线起点所附属的端口
                            Port start_port = (Port)start_connector.BelongsTo;
                            //获取连接线终点所附属的端口
                            Port end_port = (Port)end_connector.BelongsTo;
                            //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);

                            Port[] port_array = new Port[] { start_port, end_port };

                            //将起始端口终点端口对加入连接线列表
                            list_Connection.Add(port_array);
                        }
                    }// if (inout_port.PortConnector1.Connections.Count > 0)
                }//foreach (Inout_port output_port in commponent.output_ports)
            }// if (commponent.inout_ports != null)
     
           ////----------------------------------------------------//
           ////------遍历连接线列表中记录，即所有端口对------------//
           ////----------------------------------------------------//
           //foreach(Port[] port_array in list_Connection)
           //{
           //    //+++++++++++++++++++ Debug - 读取端口对应的组件 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
           //    //int loc = port_array[0].Port_ID1.IndexOf("_");
           //    //String start_component_name = port_array[0].Port_ID1.Substring(0, loc);
           //    //int loc2 = port_array[1].Port_ID1.IndexOf("_");
           //    //String end_component_name = port_array[1].Port_ID1.Substring(0, loc2);
           //    //Console.WriteLine("对应组件名（起始）=" + start_component_name + ";对应组件名（终点）=" + end_component_name);
           //    //Console.WriteLine("连接线端口对=<" + port_array[0].Port_ID1 + ";" + port_array[1].Port_ID1+">");
           //    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
             
           //    //+++++++++++++++++++ Debug - 多参数函数创建线程 ++++++++++++++++++++++++++//
           //    ////若起始端口内部队列中存在数据，则传递给终点端口的内部队列
           //    //if (port_array[0].Port_queue1.Count >0)
           //    //{
           //    //    Transfer trans = new Transfer();
           //    //    trans.p1 = port_array[0];
           //    //    trans.p2 = port_array[1];
           //    //    Thread t = new Thread(new ThreadStart(trans.TransferDataBetweenPorts));
           //    //    t.Start();
           //    //}
           //    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
           //}//foreach(Port[] port_array in list_Connection)                        
        }


       /***********************************************
        *  函数名称：Stop_Click()
        *  功能：终止按钮单击事件，终止模型的执行
        *  参数：sender;e
        *  返回值：无
        * **********************************************/
        private void Stop_Click(object sender, EventArgs e)
        {
            stop = true;
        }
        /***********************************************
         *  函数名称：Pause_Click()
         *  功能：暂停按钮单击事件，终止模型的执行
         *  参数：sender;e
         *  返回值：无
         * **********************************************/
        private void Pause_Click(object sender, EventArgs e)
        {
            //pause = true;
        }
        /***********************************************
         *  函数名称：Pause_Click()
         *  功能：暂停按钮单击事件，终止模型的执行
         *  参数：sender;e
         *  返回值：无
         * **********************************************/
        private void Continue_Click(object sender, EventArgs e)
        {
            //pause = false;
            //manualResetEvent.Set();
        }//private List<Port[]> RecordConnections(Component component)
     
    }//public partial class Form1 : Form


    //+++++++++++++++++++ Debug - 多参数函数创建线程 ++++++++++++++++++++++++++//
    //public class Transfer
    //{
    //    public Port p1;
    //    public Port p2;

    //    public void TransferDataBetweenPorts()
    //    {
    //        while (this.p1.Port_queue1.Count > 0)
    //        {
    //            this.p2.Port_queue1.Enqueue(this.p1.Port_queue1.Dequeue());
    //            Thread.Sleep(500);
    //            Console.Write("起点端口内部队列数据:");
    //            foreach (int[] arr in p1.Port_queue1)
    //            {
    //                Console.Write("[" + arr[0] + "," + arr[1] + " ];");
    //            }
    //            Console.WriteLine("");

    //            Console.Write("终点端口内部队列数据:");
    //            foreach (int[] arr in p2.Port_queue1)
    //            {
    //                Console.Write("[" + arr[0] + "," + arr[1] + " ];");
    //            }
    //            Console.WriteLine("");   
    //        }      
    //    }
    //}
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

}
