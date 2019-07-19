using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Netron.GraphLib;
using Netron.GraphLib.UI;
using XModel.CMIoTLibrary;
using XModel.BasicLibrary;

namespace XModel
{
    public partial class InsideForm : Form1
    {
        Component component; //内部表单对应的组件

        /********************************************
         * 函数名称：InsideForm()
         * 功能：构造函数
         * 参数：component 内部表单对应的组件
         * 返回值：无
         * *****************************************/
        public InsideForm(Component component)
            : base()
        {
            this.component = component;
            InitializeComponent();
            if (this.component.GetType().Name == "Patient")
            {
                PatientInternalStructure();
            }
            else if (this.component.GetType().Name == "HeartRateSensorNode")
            {
                HRSNInternalStructure();
            }
            else if (this.component.GetType().Name == "TemperatureSensorNode")
            {
                TSNInternalStructure();
            }
            else if (this.component.GetType().Name == "BloodPressureSensorNode")
            {
                BPSNInternalStructure();
            }
            else if (this.component.GetType().Name == "IoTGateway")
            {
                IoTGInternalStructure();
            }
            else if (this.component.GetType().Name == "IPv6Router")
            {
                IPv6RInternalStructure();
            }
            else if (this.component.GetType().Name == "MedicalServer")
            {
                MSInternalStructure();
            }
        }


        /********************************************
         * 函数名称：PatientInternalStructure()
         * 功能：Patient组件内部结构设计
         * 参数：无
         * 返回值：无
         * *****************************************/
        private void PatientInternalStructure() 
        {
            Patient patient = (Patient)(this.component);

            //创建Patient组件内部显示端口
            Output_port output_port0 = new Output_port((patient.ID + "_P1"), patient.BloodPressureComponent.name + "Port", "output", "int[]", patient);
            Output_port output_port1 = new Output_port((patient.ID + "_P2"), patient.TemperatureComponent.name + "Port", "output", "double", patient);
            Output_port output_port2 = new Output_port((patient.ID + "_P3"), patient.TemperatureComponent.name + "Port", "output", "int", patient);

            //Output_port output_port1 = patient.output_ports[0];
            //Output_port output_port1 = patient.output_ports[1];
            //Output_port output_port2 = patient.output_ports[2];
            //this.output_ports[0] = new Output_port((this.ID + "_P1"), this.BloodPressureComponent.name + "Port", "output", "int[]", this);
            //this.output_ports[1] = new Output_port((this.ID + "_P2"), this.TemperatureComponent.name + "Port", "output", "double", this);
            //this.output_ports[2] = new Output_port((this.ID + "_P3"), this.HeartRateComponent.name + "Port", "output", "int", this);
            
            //添加Patient组件的三个输出端口
            this.GraphControl.AddShape(output_port0, new PointF(this.GraphControl.Width - 300, 118));
            this.GraphControl.AddShape(output_port1, new PointF(this.GraphControl.Width - 300, 218));
            this.GraphControl.AddShape(output_port2, new PointF(this.GraphControl.Width - 300, 318));            

            //显示血压组件
            //patient.BloodPressureComponent = new BloodPressure(this.GraphControl,null,null,null);
            //patient.BloodPressureComponent.graphControl = this.GraphControl;
            PointF BPCLocation = new PointF(100, 100); //血压组件初始显示位置 
            this.GraphControl.AddShape(patient.BloodPressureComponent, BPCLocation);

            //patient.BloodPressureComponent.output_ports = new Output_port[1]; //创建血压组件的一个输出端口
            //patient.BloodPressureComponent.output_ports[0] = new Output_port((patient.BloodPressureComponent.ID + "_P1"), "output", "int[]", patient.BloodPressureComponent);
            int BPC_output_port_LocationX = (int)(BPCLocation.X + patient.BloodPressureComponent.Width - 2);
            int BPC_output_port_LocationY = (int)(BPCLocation.Y + 1 * (patient.BloodPressureComponent.Height / (1 + 1)) - patient.BloodPressureComponent.output_ports[0].Height / 2);
            patient.BloodPressureComponent.output_ports[0].Rectangle = new RectangleF(BPC_output_port_LocationX, BPC_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(patient.BloodPressureComponent.output_ports[0], new Point(BPC_output_port_LocationX, BPC_output_port_LocationY));

            //显示体温组件
            //patient.TemperatureComponent = new Temperature(this.GraphControl, null, null, null);
            PointF TCLocation = new PointF(100, 200); //体温组件初始显示位置 
            this.GraphControl.AddShape(patient.TemperatureComponent, new PointF(100, 200));

            //patient.TemperatureComponent.output_ports = new Output_port[1]; //创建体温组件的一个输出端口
            //patient.TemperatureComponent.output_ports[0] = new Output_port((patient.TemperatureComponent.ID + "_P1"), "output", "double", patient.TemperatureComponent);
            int TC_output_port_LocationX = (int)(TCLocation.X + patient.TemperatureComponent.Width - 2);
            int TC_output_port_LocationY = (int)(TCLocation.Y + 1 * (patient.TemperatureComponent.Height / (1 + 1)) - patient.TemperatureComponent.output_ports[0].Height / 2);
            patient.TemperatureComponent.output_ports[0].Rectangle = new RectangleF(TC_output_port_LocationX, TC_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(patient.TemperatureComponent.output_ports[0], new Point(TC_output_port_LocationX, TC_output_port_LocationY));

            //显示心率组件
            //patient.HeartRateComponent = new HeartRate(this.GraphControl, null, null, null);
            PointF HRCLocation = new PointF(100, 300); //体温组件初始显示位置 
            this.GraphControl.AddShape(patient.HeartRateComponent, new PointF(100, 300));

            //patient.HeartRateComponent.output_ports = new Output_port[1]; //创建心率组件的一个输出端口
            //patient.HeartRateComponent.output_ports[0] = new Output_port((patient.HeartRateComponent.ID + "_P1"), "output", "int", patient.HeartRateComponent);
            int HRC_output_port_LocationX = (int)(HRCLocation.X + patient.HeartRateComponent.Width - 2);
            int HRC_output_port_LocationY = (int)(HRCLocation.Y + 1 * (patient.HeartRateComponent.Height / (1 + 1)) - patient.HeartRateComponent.output_ports[0].Height / 2);
            patient.HeartRateComponent.output_ports[0].Rectangle = new RectangleF(HRC_output_port_LocationX, HRC_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(patient.HeartRateComponent.output_ports[0], new Point(HRC_output_port_LocationX, HRC_output_port_LocationY));

            ////添加内部组件端口到Patient组件端口的连线
            //Connection connection1 = new Connection();
            //connection1.From = patient.BloodPressureComponent.output_ports[0].PortConnector1;
            ////connection1.To = patient.output_ports[0].PortConnector1;
            //connection1.To = patient.output_ports[0].PortConnector1;
            //++++++++++++++++ Debug ++++++++++++++++++++++++++++++++++++++++++//
            //Console.WriteLine("connection.From " + connection.From.Location);
            //Console.WriteLine("connection.To " + connection.To.Location);
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

            //将连线显示在graphControl画布上
            //this.GraphControl.AddConnection(connection1.From, output_port0.PortConnector1);
            this.GraphControl.AddConnection(patient.BloodPressureComponent.output_ports[0].PortConnector1, output_port0.PortConnector1);

            //Connection connection2 = new Connection();
            //connection2.From = patient.TemperatureComponent.output_ports[0].PortConnector1;
            //connection2.To = patient.output_ports[1].PortConnector1;
            //this.GraphControl.AddConnection(connection2.From, output_port1.PortConnector1);
            this.GraphControl.AddConnection(patient.TemperatureComponent.output_ports[0].PortConnector1, output_port1.PortConnector1);

            //Connection connection3 = new Connection();
            //connection3.From = patient.HeartRateComponent.output_ports[0].PortConnector1;
            //connection3.To = patient.output_ports[2].PortConnector1;
            //this.GraphControl.AddConnection(connection3.From, output_port2.PortConnector1);
            this.GraphControl.AddConnection(patient.HeartRateComponent.output_ports[0].PortConnector1, output_port2.PortConnector1);
        }

        /********************************************
         * 函数名称：HRSNInternalStructure()
         * 功能：HeartRateSensorNode组件内部结构设计
         * 参数：无
         * 返回值：无
         * *****************************************/
        private void HRSNInternalStructure()
        {
            HeartRateSensorNode HRSN = (HeartRateSensorNode)(this.component);

            //创建HeartRateSensorNode组件内部显示端口
            Input_port input_port = new Input_port((HRSN.ID + "_P1"), HRSN.name + "Port", "input", "int", HRSN);
            Output_port output_port = new Output_port((HRSN.ID + "_P2"), HRSN.name + "Port", "output", "string", HRSN);

            //显示HeartRateSensorNode组件的input端口和output端口
            this.GraphControl.AddShape(input_port, new PointF(this.GraphControl.Width - 620, 100));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 20, 100));

            //显示心率传感器组件
            PointF HRSLocation = new PointF(90, 100); //心率传感器组件初始显示位置 
            this.GraphControl.AddShape(HRSN.HeartRateSensor, HRSLocation);      
            
            //显示心率传感器组件端口
            int HRSN_input_port_LocationX = (int)(HRSLocation.X);
            int HRSN_input_port_LocationY = (int)(HRSLocation.Y + 1 * (HRSN.HeartRateSensor.Height / (1 + 1)) - HRSN.HeartRateSensor.input_ports[0].Height / 2);
            int HRSN_output_port_LocationX = (int)(HRSLocation.X + HRSN.HeartRateSensor.Width - 2);
            int HRSN_output_port_LocationY = (int)(HRSLocation.Y + 1 * (HRSN.HeartRateSensor.Height / (1 + 1)) - HRSN.HeartRateSensor.output_ports[0].Height / 2);
            
            HRSN.HeartRateSensor.input_ports[0].Rectangle = new RectangleF(HRSN_input_port_LocationX, HRSN_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.HeartRateSensor.input_ports[0], new Point(HRSN_input_port_LocationX, HRSN_input_port_LocationY));
            HRSN.HeartRateSensor.output_ports[0].Rectangle = new RectangleF(HRSN_output_port_LocationX, HRSN_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.HeartRateSensor.output_ports[0], new Point(HRSN_output_port_LocationX, HRSN_output_port_LocationY));

            //显示微处理器组件
            PointF MPLocation = new PointF(220, 100); //微处理器组件初始显示位置 
            this.GraphControl.AddShape(HRSN.MicroProcessor, MPLocation);
           
            //显示微处理器组件端口
            int MP_input_port_LocationX = (int)(MPLocation.X);
            int MP_input_port_LocationY = (int)(MPLocation.Y + 1 * (HRSN.MicroProcessor.Height / (1 + 1)) - HRSN.MicroProcessor.input_ports[0].Height / 2);
            int MP_output_port_LocationX = (int)(MPLocation.X + HRSN.MicroProcessor.Width - 2);
            int MP_output_port_LocationY = (int)(MPLocation.Y + 1 * (HRSN.MicroProcessor.Height / (1 + 1)) - HRSN.MicroProcessor.output_ports[0].Height / 2);
           
            HRSN.MicroProcessor.input_ports[0].Rectangle = new RectangleF(MP_input_port_LocationX, MP_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.MicroProcessor.input_ports[0], new Point(MP_input_port_LocationX, MP_input_port_LocationY));
            HRSN.MicroProcessor.output_ports[0].Rectangle = new RectangleF(MP_output_port_LocationX, MP_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.MicroProcessor.output_ports[0], new Point(MP_output_port_LocationX, MP_output_port_LocationY));

            //显示缓冲区组件
            PointF MBLocation = new PointF(350, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(HRSN.MyBuffer, MBLocation);

            //显示缓冲区组件端口
            int MB_input_port_LocationX = (int)(MBLocation.X);
            int MB_input_port_LocationY = (int)(MBLocation.Y + 1 * (HRSN.MyBuffer.Height / (1 + 1)) - HRSN.MyBuffer.input_ports[0].Height / 2);
            int MB_output_port_LocationX = (int)(MBLocation.X + HRSN.MyBuffer.Width - 2);
            int MB_output_port_LocationY = (int)(MBLocation.Y + 1 * (HRSN.MyBuffer.Height / (1 + 1)) - HRSN.MyBuffer.output_ports[0].Height / 2);

            HRSN.MyBuffer.input_ports[0].Rectangle = new RectangleF(MB_input_port_LocationX, MB_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.MyBuffer.input_ports[0], new Point(MB_input_port_LocationX, MB_input_port_LocationY));
            HRSN.MyBuffer.output_ports[0].Rectangle = new RectangleF(MB_output_port_LocationX, MB_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.MyBuffer.output_ports[0], new Point(MB_output_port_LocationX, MB_output_port_LocationY));

            //显示无线模块组件
            PointF WMLocation = new PointF(480, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(HRSN.WirelessModule, WMLocation);

            //显示无线模块组件端口
            int WM_input_port_LocationX = (int)(WMLocation.X);
            int WM_input_port_LocationY = (int)(WMLocation.Y + 1 * (HRSN.WirelessModule.Height / (1 + 1)) - HRSN.WirelessModule.input_ports[0].Height / 2);
            int WM_output_port_LocationX = (int)(WMLocation.X + HRSN.WirelessModule.Width - 2);
            int WM_output_port_LocationY = (int)(WMLocation.Y + 1 * (HRSN.WirelessModule.Height / (1 + 1)) - HRSN.WirelessModule.output_ports[0].Height / 2);

            HRSN.WirelessModule.input_ports[0].Rectangle = new RectangleF(WM_input_port_LocationX, WM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.WirelessModule.input_ports[0], new Point(WM_input_port_LocationX, WM_input_port_LocationY));
            HRSN.WirelessModule.output_ports[0].Rectangle = new RectangleF(WM_output_port_LocationX, WM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(HRSN.WirelessModule.output_ports[0], new Point(WM_output_port_LocationX, WM_output_port_LocationY));

            //显示HeartRateSensorNode组件内部连接线
            this.GraphControl.AddConnection(input_port.PortConnector1, HRSN.HeartRateSensor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(HRSN.WirelessModule.output_ports[0].PortConnector1, output_port.PortConnector1);
   
            this.GraphControl.AddConnection(HRSN.HeartRateSensor.output_ports[0].PortConnector1, HRSN.MicroProcessor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(HRSN.MicroProcessor.output_ports[0].PortConnector1, HRSN.MyBuffer.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(HRSN.MyBuffer.output_ports[0].PortConnector1, HRSN.WirelessModule.input_ports[0].PortConnector1);
        }

        /********************************************
        * 函数名称：TSNInternalStructure()
        * 功能：TemperatureSensorNode组件内部结构设计
        * 参数：无
        * 返回值：无
        * *****************************************/
        private void TSNInternalStructure()
        {
            TemperatureSensorNode TSN = (TemperatureSensorNode)(this.component);

            //创建TemperatureSensorNode组件内部显示端口
            Input_port input_port = new Input_port((TSN.ID + "_P1"), TSN.name + "Port", "input", "double", TSN);
            Output_port output_port = new Output_port((TSN.ID + "_P2"), TSN.name + "Port", "output", "string", TSN);

            //显示TemperatureSensorNode组件的input端口和output端口
            this.GraphControl.AddShape(input_port, new PointF(this.GraphControl.Width - 620, 100));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 20, 100));

            //显示体温传感器组件
            PointF TSLocation = new PointF(90, 100); //体温传感器组件初始显示位置 
            this.GraphControl.AddShape(TSN.TemperatureSensor, TSLocation);

            //显示体温传感器组件端口
            int TS_input_port_LocationX = (int)(TSLocation.X);
            int TS_input_port_LocationY = (int)(TSLocation.Y + 1 * (TSN.TemperatureSensor.Height / (1 + 1)) - TSN.TemperatureSensor.input_ports[0].Height / 2);
            int TS_output_port_LocationX = (int)(TSLocation.X + TSN.TemperatureSensor.Width - 2);
            int TS_output_port_LocationY = (int)(TSLocation.Y + 1 * (TSN.TemperatureSensor.Height / (1 + 1)) - TSN.TemperatureSensor.output_ports[0].Height / 2);

            TSN.TemperatureSensor.input_ports[0].Rectangle = new RectangleF(TS_input_port_LocationX, TS_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.TemperatureSensor.input_ports[0], new Point(TS_input_port_LocationX, TS_input_port_LocationY));
            TSN.TemperatureSensor.output_ports[0].Rectangle = new RectangleF(TS_output_port_LocationX, TS_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.TemperatureSensor.output_ports[0], new Point(TS_output_port_LocationX, TS_output_port_LocationY));

            //显示微处理器组件
            PointF MPLocation = new PointF(220, 100); //微处理器组件初始显示位置 
            this.GraphControl.AddShape(TSN.MicroProcessor, MPLocation);

            //显示微处理器组件端口
            int MP_input_port_LocationX = (int)(MPLocation.X);
            int MP_input_port_LocationY = (int)(MPLocation.Y + 1 * (TSN.MicroProcessor.Height / (1 + 1)) - TSN.MicroProcessor.input_ports[0].Height / 2);
            int MP_output_port_LocationX = (int)(MPLocation.X + TSN.MicroProcessor.Width - 2);
            int MP_output_port_LocationY = (int)(MPLocation.Y + 1 * (TSN.MicroProcessor.Height / (1 + 1)) - TSN.MicroProcessor.output_ports[0].Height / 2);

            TSN.MicroProcessor.input_ports[0].Rectangle = new RectangleF(MP_input_port_LocationX, MP_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.MicroProcessor.input_ports[0], new Point(MP_input_port_LocationX, MP_input_port_LocationY));
            TSN.MicroProcessor.output_ports[0].Rectangle = new RectangleF(MP_output_port_LocationX, MP_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.MicroProcessor.output_ports[0], new Point(MP_output_port_LocationX, MP_output_port_LocationY));

            //显示缓冲区组件
            PointF MBLocation = new PointF(350, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(TSN.MyBuffer, MBLocation);

            //显示缓冲区组件端口
            int MB_input_port_LocationX = (int)(MBLocation.X);
            int MB_input_port_LocationY = (int)(MBLocation.Y + 1 * (TSN.MyBuffer.Height / (1 + 1)) - TSN.MyBuffer.input_ports[0].Height / 2);
            int MB_output_port_LocationX = (int)(MBLocation.X + TSN.MyBuffer.Width - 2);
            int MB_output_port_LocationY = (int)(MBLocation.Y + 1 * (TSN.MyBuffer.Height / (1 + 1)) - TSN.MyBuffer.output_ports[0].Height / 2);

            TSN.MyBuffer.input_ports[0].Rectangle = new RectangleF(MB_input_port_LocationX, MB_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.MyBuffer.input_ports[0], new Point(MB_input_port_LocationX, MB_input_port_LocationY));
            TSN.MyBuffer.output_ports[0].Rectangle = new RectangleF(MB_output_port_LocationX, MB_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.MyBuffer.output_ports[0], new Point(MB_output_port_LocationX, MB_output_port_LocationY));

            //显示无线模块组件
            PointF WMLocation = new PointF(480, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(TSN.WirelessModule, WMLocation);

            //显示无线模块组件端口
            int WM_input_port_LocationX = (int)(WMLocation.X);
            int WM_input_port_LocationY = (int)(WMLocation.Y + 1 * (TSN.WirelessModule.Height / (1 + 1)) - TSN.WirelessModule.input_ports[0].Height / 2);
            int WM_output_port_LocationX = (int)(WMLocation.X + TSN.WirelessModule.Width - 2);
            int WM_output_port_LocationY = (int)(WMLocation.Y + 1 * (TSN.WirelessModule.Height / (1 + 1)) - TSN.WirelessModule.output_ports[0].Height / 2);

            TSN.WirelessModule.input_ports[0].Rectangle = new RectangleF(WM_input_port_LocationX, WM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.WirelessModule.input_ports[0], new Point(WM_input_port_LocationX, WM_input_port_LocationY));
            TSN.WirelessModule.output_ports[0].Rectangle = new RectangleF(WM_output_port_LocationX, WM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(TSN.WirelessModule.output_ports[0], new Point(WM_output_port_LocationX, WM_output_port_LocationY));

            //显示TemperatureSensorNode组件内部连接线
            this.GraphControl.AddConnection(input_port.PortConnector1, TSN.TemperatureSensor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(TSN.TemperatureSensor.output_ports[0].PortConnector1, TSN.MicroProcessor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(TSN.MicroProcessor.output_ports[0].PortConnector1, TSN.MyBuffer.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(TSN.MyBuffer.output_ports[0].PortConnector1, TSN.WirelessModule.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(TSN.WirelessModule.output_ports[0].PortConnector1, output_port.PortConnector1);
        }

        /********************************************
        * 函数名称：BPSNInternalStructure()
        * 功能：BloodPressureSensorNode组件内部结构设计
        * 参数：无
        * 返回值：无
        * *****************************************/
        private void BPSNInternalStructure()
        {
            BloodPressureSensorNode BPSN = (BloodPressureSensorNode)(this.component);

            //创建BloodPressureSensorNode组件内部显示端口
            Input_port input_port = new Input_port((BPSN.ID + "_P1"), BPSN.name + "Port", "input", "int[]", BPSN);
            Output_port output_port = new Output_port((BPSN.ID + "_P2"), BPSN.name + "Port", "output", "string", BPSN);

            //显示BloodPressureSensorNode组件的input端口和output端口
            this.GraphControl.AddShape(input_port, new PointF(this.GraphControl.Width - 620, 100));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 20, 100));

            //显示血压传感器组件
            PointF BPSLocation = new PointF(90, 100); //血压传感器组件初始显示位置 
            this.GraphControl.AddShape(BPSN.BloodPressureSensor, BPSLocation);

            //显示血压传感器组件端口
            int BPS_input_port_LocationX = (int)(BPSLocation.X);
            int BPS_input_port_LocationY = (int)(BPSLocation.Y + 1 * (BPSN.BloodPressureSensor.Height / (1 + 1)) - BPSN.BloodPressureSensor.input_ports[0].Height / 2);
            int BPS_output_port_LocationX = (int)(BPSLocation.X + BPSN.BloodPressureSensor.Width - 2);
            int BPS_output_port_LocationY = (int)(BPSLocation.Y + 1 * (BPSN.BloodPressureSensor.Height / (1 + 1)) - BPSN.BloodPressureSensor.output_ports[0].Height / 2);

            BPSN.BloodPressureSensor.input_ports[0].Rectangle = new RectangleF(BPS_input_port_LocationX, BPS_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.BloodPressureSensor.input_ports[0], new Point(BPS_input_port_LocationX, BPS_input_port_LocationY));
            BPSN.BloodPressureSensor.output_ports[0].Rectangle = new RectangleF(BPS_output_port_LocationX, BPS_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.BloodPressureSensor.output_ports[0], new Point(BPS_output_port_LocationX, BPS_output_port_LocationY));

            //显示微处理器组件
            PointF MPLocation = new PointF(220, 100); //微处理器组件初始显示位置 
            this.GraphControl.AddShape(BPSN.MicroProcessor, MPLocation);

            //显示微处理器组件端口
            int MP_input_port_LocationX = (int)(MPLocation.X);
            int MP_input_port_LocationY = (int)(MPLocation.Y + 1 * (BPSN.MicroProcessor.Height / (1 + 1)) - BPSN.MicroProcessor.input_ports[0].Height / 2);
            int MP_output_port_LocationX = (int)(MPLocation.X + BPSN.MicroProcessor.Width - 2);
            int MP_output_port_LocationY = (int)(MPLocation.Y + 1 * (BPSN.MicroProcessor.Height / (1 + 1)) - BPSN.MicroProcessor.output_ports[0].Height / 2);

            BPSN.MicroProcessor.input_ports[0].Rectangle = new RectangleF(MP_input_port_LocationX, MP_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.MicroProcessor.input_ports[0], new Point(MP_input_port_LocationX, MP_input_port_LocationY));
            BPSN.MicroProcessor.output_ports[0].Rectangle = new RectangleF(MP_output_port_LocationX, MP_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.MicroProcessor.output_ports[0], new Point(MP_output_port_LocationX, MP_output_port_LocationY));

            //显示缓冲区组件
            PointF MBLocation = new PointF(350, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(BPSN.MyBuffer, MBLocation);

            //显示缓冲区组件端口
            int MB_input_port_LocationX = (int)(MBLocation.X);
            int MB_input_port_LocationY = (int)(MBLocation.Y + 1 * (BPSN.MyBuffer.Height / (1 + 1)) - BPSN.MyBuffer.input_ports[0].Height / 2);
            int MB_output_port_LocationX = (int)(MBLocation.X + BPSN.MyBuffer.Width - 2);
            int MB_output_port_LocationY = (int)(MBLocation.Y + 1 * (BPSN.MyBuffer.Height / (1 + 1)) - BPSN.MyBuffer.output_ports[0].Height / 2);

            BPSN.MyBuffer.input_ports[0].Rectangle = new RectangleF(MB_input_port_LocationX, MB_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.MyBuffer.input_ports[0], new Point(MB_input_port_LocationX, MB_input_port_LocationY));
            BPSN.MyBuffer.output_ports[0].Rectangle = new RectangleF(MB_output_port_LocationX, MB_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.MyBuffer.output_ports[0], new Point(MB_output_port_LocationX, MB_output_port_LocationY));

            //显示无线模块组件
            PointF WMLocation = new PointF(480, 100); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(BPSN.WirelessModule, WMLocation);

            //显示无线模块组件端口
            int WM_input_port_LocationX = (int)(WMLocation.X);
            int WM_input_port_LocationY = (int)(WMLocation.Y + 1 * (BPSN.WirelessModule.Height / (1 + 1)) - BPSN.WirelessModule.input_ports[0].Height / 2);
            int WM_output_port_LocationX = (int)(WMLocation.X + BPSN.WirelessModule.Width - 2);
            int WM_output_port_LocationY = (int)(WMLocation.Y + 1 * (BPSN.WirelessModule.Height / (1 + 1)) - BPSN.WirelessModule.output_ports[0].Height / 2);

            BPSN.WirelessModule.input_ports[0].Rectangle = new RectangleF(WM_input_port_LocationX, WM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.WirelessModule.input_ports[0], new Point(WM_input_port_LocationX, WM_input_port_LocationY));
            BPSN.WirelessModule.output_ports[0].Rectangle = new RectangleF(WM_output_port_LocationX, WM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(BPSN.WirelessModule.output_ports[0], new Point(WM_output_port_LocationX, WM_output_port_LocationY));

        
            //显示BloodPressureSensorNode组件内部连接线
            this.GraphControl.AddConnection(input_port.PortConnector1, BPSN.BloodPressureSensor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(BPSN.WirelessModule.output_ports[0].PortConnector1, output_port.PortConnector1);


            //避免因连线重复输出两遍，改变连线方向
            //逆序
            //this.GraphControl.AddConnection(BPSN.MicroProcessor.input_ports[0].PortConnector1, BPSN.BloodPressureSensor.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(BPSN.MyBuffer.input_ports[0].PortConnector1, BPSN.MicroProcessor.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(BPSN.WirelessModule.input_ports[0].PortConnector1, BPSN.MyBuffer.output_ports[0].PortConnector1);


            //正序
            this.GraphControl.AddConnection(BPSN.BloodPressureSensor.output_ports[0].PortConnector1, BPSN.MicroProcessor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(BPSN.MicroProcessor.output_ports[0].PortConnector1, BPSN.MyBuffer.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(BPSN.MyBuffer.output_ports[0].PortConnector1, BPSN.WirelessModule.input_ports[0].PortConnector1);

        
    
        }
    
        /********************************************
        * 函数名称：IoTGInternalStructure()
        * 功能：IoTGateway组件内部结构设计
        * 参数：无
        * 返回值：无
        * *****************************************/
        private void IoTGInternalStructure()
        {
            IoTGateway IoTG = (IoTGateway)(this.component);

            //创建IoTGateway组件内部显示端口
            Input_port input_port1 = new Input_port((IoTG.ID + "_P1"), IoTG.name + "Port", "input", "string", IoTG);
            Input_port input_port2 = new Input_port((IoTG.ID + "_P2"), IoTG.name + "Port", "input", "string", IoTG);
            Input_port input_port3 = new Input_port((IoTG.ID + "_P3"), IoTG.name + "Port", "input", "string", IoTG);
            Output_port output_port = new Output_port((IoTG.ID + "_P4"), IoTG.name + "Port", "output", "string", IoTG);

            //显示IoTGateway组件的input端口和output端口
            this.GraphControl.AddShape(input_port1, new PointF(15, 90));
            this.GraphControl.AddShape(input_port2, new PointF(15, 195));
            this.GraphControl.AddShape(input_port3, new PointF(15, 300));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 20, 195));

            //显示无线模块1组件
            PointF WM1Location = new PointF(65, 75); //无线模块1组件初始显示位置 
            this.GraphControl.AddShape(IoTG.WirelessModule1, WM1Location);

            //显示无线模块1组件端口
            int WM1_input_port_LocationX = (int)(WM1Location.X);
            int WM1_input_port_LocationY = (int)(WM1Location.Y + 1 * (IoTG.WirelessModule1.Height / (1 + 1)) - IoTG.WirelessModule1.input_ports[0].Height / 2);
            int WM1_output_port_LocationX = (int)(WM1Location.X + IoTG.WirelessModule1.Width - 2);
            int WM1_output_port_LocationY = (int)(WM1Location.Y + 1 * (IoTG.WirelessModule1.Height / (1 + 1)) - IoTG.WirelessModule1.output_ports[0].Height / 2);

            IoTG.WirelessModule1.input_ports[0].Rectangle = new RectangleF(WM1_input_port_LocationX, WM1_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule1.input_ports[0], new Point(WM1_input_port_LocationX, WM1_input_port_LocationY));
            IoTG.WirelessModule1.output_ports[0].Rectangle = new RectangleF(WM1_output_port_LocationX, WM1_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule1.output_ports[0], new Point(WM1_output_port_LocationX, WM1_output_port_LocationY));

            //显示无线模块2组件
            PointF WM2Location = new PointF(65, 180); //无线模块2组件初始显示位置 
            this.GraphControl.AddShape(IoTG.WirelessModule2, WM2Location);

            //显示无线模块2组件端口
            int WM2_input_port_LocationX = (int)(WM2Location.X);
            int WM2_input_port_LocationY = (int)(WM2Location.Y + 1 * (IoTG.WirelessModule2.Height / (1 + 1)) - IoTG.WirelessModule2.input_ports[0].Height / 2);
            int WM2_output_port_LocationX = (int)(WM2Location.X + IoTG.WirelessModule2.Width - 2);
            int WM2_output_port_LocationY = (int)(WM2Location.Y + 1 * (IoTG.WirelessModule2.Height / (1 + 1)) - IoTG.WirelessModule2.output_ports[0].Height / 2);

            IoTG.WirelessModule2.input_ports[0].Rectangle = new RectangleF(WM2_input_port_LocationX, WM2_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule2.input_ports[0], new Point(WM2_input_port_LocationX, WM2_input_port_LocationY));
            IoTG.WirelessModule2.output_ports[0].Rectangle = new RectangleF(WM2_output_port_LocationX, WM2_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule2.output_ports[0], new Point(WM2_output_port_LocationX, WM2_output_port_LocationY));

            //显示无线模块3组件
            PointF WM3Location = new PointF(65, 285); //无线模块3组件初始显示位置 
            this.GraphControl.AddShape(IoTG.WirelessModule3, WM3Location);

            //显示无线模块3组件端口
            int WM3_input_port_LocationX = (int)(WM3Location.X);
            int WM3_input_port_LocationY = (int)(WM3Location.Y + 1 * (IoTG.WirelessModule3.Height / (1 + 1)) - IoTG.WirelessModule3.input_ports[0].Height / 2);
            int WM3_output_port_LocationX = (int)(WM3Location.X + IoTG.WirelessModule3.Width - 2);
            int WM3_output_port_LocationY = (int)(WM3Location.Y + 1 * (IoTG.WirelessModule3.Height / (1 + 1)) - IoTG.WirelessModule3.output_ports[0].Height / 2);

            IoTG.WirelessModule3.input_ports[0].Rectangle = new RectangleF(WM3_input_port_LocationX, WM3_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule3.input_ports[0], new Point(WM3_input_port_LocationX, WM3_input_port_LocationY));
            IoTG.WirelessModule3.output_ports[0].Rectangle = new RectangleF(WM3_output_port_LocationX, WM3_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WirelessModule3.output_ports[0], new Point(WM3_output_port_LocationX, WM3_output_port_LocationY));

            //显示缓冲队列1组件
            PointF MB1Location = new PointF(185, 75); //缓冲队列1组件初始显示位置 
            this.GraphControl.AddShape(IoTG.MyBuffer1, MB1Location);

            //显示缓冲队列1组件端口
            int MB1_input_port_LocationX = (int)(MB1Location.X);
            int MB1_input_port_LocationY = (int)(MB1Location.Y + 1 * (IoTG.MyBuffer1.Height / (1 + 1)) - IoTG.MyBuffer1.input_ports[0].Height / 2);
            int MB1_output_port_LocationX = (int)(MB1Location.X + IoTG.MyBuffer1.Width - 2);
            int MB1_output_port_LocationY = (int)(MB1Location.Y + 1 * (IoTG.MyBuffer1.Height / (1 + 1)) - IoTG.MyBuffer1.output_ports[0].Height / 2);

            IoTG.MyBuffer1.input_ports[0].Rectangle = new RectangleF(MB1_input_port_LocationX, MB1_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer1.input_ports[0], new Point(MB1_input_port_LocationX, MB1_input_port_LocationY));
            IoTG.MyBuffer1.output_ports[0].Rectangle = new RectangleF(MB1_output_port_LocationX, MB1_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer1.output_ports[0], new Point(MB1_output_port_LocationX, MB1_output_port_LocationY));

            //显示缓冲队列2组件
            PointF MB2Location = new PointF(185, 180); //缓冲队列2组件初始显示位置 
            this.GraphControl.AddShape(IoTG.MyBuffer2, MB2Location);

            //显示缓冲队列2组件端口
            int MB2_input_port_LocationX = (int)(MB2Location.X);
            int MB2_input_port_LocationY = (int)(MB2Location.Y + 1 * (IoTG.MyBuffer2.Height / (1 + 1)) - IoTG.MyBuffer2.input_ports[0].Height / 2);
            int MB2_output_port_LocationX = (int)(MB2Location.X + IoTG.MyBuffer2.Width - 2);
            int MB2_output_port_LocationY = (int)(MB2Location.Y + 1 * (IoTG.MyBuffer2.Height / (1 + 1)) - IoTG.MyBuffer2.output_ports[0].Height / 2);

            IoTG.MyBuffer2.input_ports[0].Rectangle = new RectangleF(MB2_input_port_LocationX, MB2_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer2.input_ports[0], new Point(MB2_input_port_LocationX, MB2_input_port_LocationY));
            IoTG.MyBuffer2.output_ports[0].Rectangle = new RectangleF(MB2_output_port_LocationX, MB2_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer2.output_ports[0], new Point(MB2_output_port_LocationX, MB2_output_port_LocationY));

            //显示缓冲队列3组件
            PointF MB3Location = new PointF(185, 285); //缓冲队列3组件初始显示位置 
            this.GraphControl.AddShape(IoTG.MyBuffer3, MB3Location);

            //显示缓冲队列3组件端口
            int MB3_input_port_LocationX = (int)(MB3Location.X);
            int MB3_input_port_LocationY = (int)(MB3Location.Y + 1 * (IoTG.MyBuffer3.Height / (1 + 1)) - IoTG.MyBuffer3.input_ports[0].Height / 2);
            int MB3_output_port_LocationX = (int)(MB3Location.X + IoTG.MyBuffer3.Width - 2);
            int MB3_output_port_LocationY = (int)(MB3Location.Y + 1 * (IoTG.MyBuffer3.Height / (1 + 1)) - IoTG.MyBuffer3.output_ports[0].Height / 2);

            IoTG.MyBuffer3.input_ports[0].Rectangle = new RectangleF(MB3_input_port_LocationX, MB3_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer3.input_ports[0], new Point(MB3_input_port_LocationX, MB3_input_port_LocationY));
            IoTG.MyBuffer3.output_ports[0].Rectangle = new RectangleF(MB3_output_port_LocationX, MB3_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer3.output_ports[0], new Point(MB3_output_port_LocationX, MB3_output_port_LocationY));

            //显示协议转换模块组件
            PointF PCLocation = new PointF(305, 170); //协议转换模块组件初始显示位置 
            this.GraphControl.AddShape(IoTG.ProtocolConverter, PCLocation);

            //显示协议转换模块组件端口
            int PC_input_port_LocationX = (int)(PCLocation.X);
            int PC_input_port_LocationY1 = (int)(PCLocation.Y + 1 * (IoTG.ProtocolConverter.Height / (3 + 1)) - IoTG.ProtocolConverter.input_ports[0].Height / 2);
            int PC_input_port_LocationY2 = (int)(PCLocation.Y + 2 * (IoTG.ProtocolConverter.Height / (3 + 1)) - IoTG.ProtocolConverter.input_ports[0].Height / 2);
            int PC_input_port_LocationY3 = (int)(PCLocation.Y + 3 * (IoTG.ProtocolConverter.Height / (3 + 1)) - IoTG.ProtocolConverter.input_ports[0].Height / 2);
            int PC_output_port_LocationX = (int)(PCLocation.X + IoTG.ProtocolConverter.Width - 2);
            int PC_output_port_LocationY = (int)(PCLocation.Y + 1 * (IoTG.ProtocolConverter.Height / (1 + 1)) - IoTG.ProtocolConverter.output_ports[0].Height / 2);

            IoTG.ProtocolConverter.input_ports[0].Rectangle = new RectangleF(PC_input_port_LocationX, PC_input_port_LocationY1, 15, 15);
            this.GraphControl.AddShape(IoTG.ProtocolConverter.input_ports[0], new Point(PC_input_port_LocationX, PC_input_port_LocationY1));

            IoTG.ProtocolConverter.input_ports[1].Rectangle = new RectangleF(PC_input_port_LocationX, PC_input_port_LocationY2, 15, 15);
            this.GraphControl.AddShape(IoTG.ProtocolConverter.input_ports[1], new Point(PC_input_port_LocationX, PC_input_port_LocationY2));

            IoTG.ProtocolConverter.input_ports[2].Rectangle = new RectangleF(PC_input_port_LocationX, PC_input_port_LocationY3, 15, 15);
            this.GraphControl.AddShape(IoTG.ProtocolConverter.input_ports[2], new Point(PC_input_port_LocationX, PC_input_port_LocationY3));

            IoTG.ProtocolConverter.output_ports[0].Rectangle = new RectangleF(PC_output_port_LocationX, PC_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.ProtocolConverter.output_ports[0], new Point(PC_output_port_LocationX, PC_output_port_LocationY));

            //显示缓冲队列4组件
            PointF MB4Location = new PointF(415, 180); //缓冲队列4组件初始显示位置 
            this.GraphControl.AddShape(IoTG.MyBuffer4, MB4Location);

            //显示缓冲队列4组件端口
            int MB4_input_port_LocationX = (int)(MB4Location.X);
            int MB4_input_port_LocationY = (int)(MB4Location.Y + 1 * (IoTG.MyBuffer4.Height / (1 + 1)) - IoTG.MyBuffer4.input_ports[0].Height / 2);
            int MB4_output_port_LocationX = (int)(MB4Location.X + IoTG.MyBuffer4.Width - 2);
            int MB4_output_port_LocationY = (int)(MB4Location.Y + 1 * (IoTG.MyBuffer4.Height / (1 + 1)) - IoTG.MyBuffer4.output_ports[0].Height / 2);

            IoTG.MyBuffer4.input_ports[0].Rectangle = new RectangleF(MB4_input_port_LocationX, MB4_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer4.input_ports[0], new Point(MB4_input_port_LocationX, MB4_input_port_LocationY));
            IoTG.MyBuffer4.output_ports[0].Rectangle = new RectangleF(MB4_output_port_LocationX, MB4_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.MyBuffer4.output_ports[0], new Point(MB4_output_port_LocationX, MB4_output_port_LocationY));

            //显示有线模块组件
            PointF WiredMLocation = new PointF(525, 180); //有线模块组件初始显示位置 
            this.GraphControl.AddShape(IoTG.WiredModule, WiredMLocation);

            //显示有线模块组件端口
            int WiredM_input_port_LocationX = (int)(WiredMLocation.X);
            int WiredM_input_port_LocationY = (int)(WiredMLocation.Y + 1 * (IoTG.WiredModule.Height / (1 + 1)) - IoTG.WiredModule.input_ports[0].Height / 2);
            int WiredM_output_port_LocationX = (int)(WiredMLocation.X + IoTG.WiredModule.Width - 2);
            int WiredM_output_port_LocationY = (int)(WiredMLocation.Y + 1 * (IoTG.WiredModule.Height / (1 + 1)) - IoTG.WiredModule.output_ports[0].Height / 2);

            IoTG.WiredModule.input_ports[0].Rectangle = new RectangleF(WiredM_input_port_LocationX, WiredM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WiredModule.input_ports[0], new Point(WiredM_input_port_LocationX, WiredM_input_port_LocationY));
            IoTG.WiredModule.output_ports[0].Rectangle = new RectangleF(WiredM_output_port_LocationX, WiredM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IoTG.WiredModule.output_ports[0], new Point(WiredM_output_port_LocationX, WiredM_output_port_LocationY));

            //显示IoTGateway组件内部连接线
            this.GraphControl.AddConnection(input_port1.PortConnector1, IoTG.WirelessModule1.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(input_port2.PortConnector1, IoTG.WirelessModule2.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(input_port3.PortConnector1, IoTG.WirelessModule3.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.WiredModule.output_ports[0].PortConnector1, output_port.PortConnector1);


            //避免因连线重复输出两遍，改变连线方向
            //逆序
            //this.GraphControl.AddConnection(IoTG.MyBuffer1.input_ports[0].PortConnector1,IoTG.WirelessModule1.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.MyBuffer2.input_ports[0].PortConnector1,IoTG.WirelessModule2.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.MyBuffer3.input_ports[0].PortConnector1,IoTG.WirelessModule3.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.ProtocolConverter.input_ports[0].PortConnector1,IoTG.MyBuffer1.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.ProtocolConverter.input_ports[1].PortConnector1,IoTG.MyBuffer2.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.ProtocolConverter.input_ports[2].PortConnector1,IoTG.MyBuffer3.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.MyBuffer4.input_ports[0].PortConnector1,IoTG.ProtocolConverter.output_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(IoTG.WiredModule.input_ports[0].PortConnector1,IoTG.MyBuffer4.output_ports[0].PortConnector1);

            //正序
            this.GraphControl.AddConnection(IoTG.WirelessModule1.output_ports[0].PortConnector1, IoTG.MyBuffer1.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.WirelessModule2.output_ports[0].PortConnector1, IoTG.MyBuffer2.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.WirelessModule3.output_ports[0].PortConnector1, IoTG.MyBuffer3.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.MyBuffer1.output_ports[0].PortConnector1, IoTG.ProtocolConverter.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.MyBuffer2.output_ports[0].PortConnector1, IoTG.ProtocolConverter.input_ports[1].PortConnector1);
            this.GraphControl.AddConnection(IoTG.MyBuffer3.output_ports[0].PortConnector1, IoTG.ProtocolConverter.input_ports[2].PortConnector1);
            this.GraphControl.AddConnection(IoTG.ProtocolConverter.output_ports[0].PortConnector1, IoTG.MyBuffer4.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IoTG.MyBuffer4.output_ports[0].PortConnector1, IoTG.WiredModule.input_ports[0].PortConnector1);
        }
        
        /********************************************
        * 函数名称：IPv6RInternalStructure()
        * 功能：IPv6Router组件内部结构设计
        * 参数：无
        * 返回值：无
        * *****************************************/
        private void IPv6RInternalStructure()
        {
            IPv6Router IPv6R = (IPv6Router)(this.component);

            //创建IPv6Router组件内部显示端口
            Input_port input_port = new Input_port((IPv6R.ID + "_P1"), IPv6R.name + "Port", "input", "string", IPv6R);
            Output_port output_port = new Output_port((IPv6R.ID + "_P2"), IPv6R.name + "Port", "output", "string", IPv6R);

            //显示IPv6Router组件的input端口和output端口
            this.GraphControl.AddShape(input_port, new PointF(20, 100));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 20, 100));

            //显示有线模块1组件
            PointF WM1Location = new PointF(70, 85); //有线模块1组件初始显示位置 
            this.GraphControl.AddShape(IPv6R.WiredModule1, WM1Location);

            //显示有线模块1组件端口
            int WM1_input_port_LocationX = (int)(WM1Location.X);
            int WM1_input_port_LocationY = (int)(WM1Location.Y + 1 * (IPv6R.WiredModule1.Height / (1 + 1)) - IPv6R.WiredModule1.input_ports[0].Height / 2);
            int WM1_output_port_LocationX = (int)(WM1Location.X + IPv6R.WiredModule1.Width - 2);
            int WM1_output_port_LocationY = (int)(WM1Location.Y + 1 * (IPv6R.WiredModule1.Height / (1 + 1)) - IPv6R.WiredModule1.output_ports[0].Height / 2);

            IPv6R.WiredModule1.input_ports[0].Rectangle = new RectangleF(WM1_input_port_LocationX, WM1_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.WiredModule1.input_ports[0], new Point(WM1_input_port_LocationX, WM1_input_port_LocationY));
            IPv6R.WiredModule1.output_ports[0].Rectangle = new RectangleF(WM1_output_port_LocationX, WM1_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.WiredModule1.output_ports[0], new Point(WM1_output_port_LocationX, WM1_output_port_LocationY));

            //显示缓冲区1组件
            PointF MB1Location = new PointF(190, 85); //缓冲区1组件初始显示位置 
            this.GraphControl.AddShape(IPv6R.MyBuffer1, MB1Location);

            //显示缓冲区1组件端口
            int WB1_input_port_LocationX = (int)(MB1Location.X);
            int WB1_input_port_LocationY = (int)(MB1Location.Y + 1 * (IPv6R.MyBuffer1.Height / (1 + 1)) - IPv6R.MyBuffer1.input_ports[0].Height / 2);
            int WB1_output_port_LocationX = (int)(MB1Location.X + IPv6R.MyBuffer1.Width - 2);
            int WB1_output_port_LocationY = (int)(MB1Location.Y + 1 * (IPv6R.MyBuffer1.Height / (1 + 1)) - IPv6R.MyBuffer1.output_ports[0].Height / 2);

            IPv6R.MyBuffer1.input_ports[0].Rectangle = new RectangleF(WB1_input_port_LocationX, WB1_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.MyBuffer1.input_ports[0], new Point(WB1_input_port_LocationX, WB1_input_port_LocationY));
            IPv6R.MyBuffer1.output_ports[0].Rectangle = new RectangleF(WB1_output_port_LocationX, WB1_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.MyBuffer1.output_ports[0], new Point(WB1_output_port_LocationX, WB1_output_port_LocationY));

            //显示路由模块组件
            PointF RMLocation = new PointF(290, 150); //路由模块组件初始显示位置 
            this.GraphControl.AddShape(IPv6R.RouteModule, RMLocation);

            //显示路由模块组件端口
            int RM_input_port_LocationX = (int)(RMLocation.X);
            int RM_input_port_LocationY = (int)(RMLocation.Y + 1 * (IPv6R.RouteModule.Height / (1 + 1)) - IPv6R.RouteModule.input_ports[0].Height / 2);
            int RM_output_port_LocationX = (int)(RMLocation.X + IPv6R.RouteModule.Width - 2);
            int RM_output_port_LocationY = (int)(RMLocation.Y + 1 * (IPv6R.RouteModule.Height / (1 + 1)) - IPv6R.RouteModule.output_ports[0].Height / 2);

            IPv6R.RouteModule.input_ports[0].Rectangle = new RectangleF(RM_input_port_LocationX, RM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.RouteModule.input_ports[0], new Point(RM_input_port_LocationX, RM_input_port_LocationY));
            IPv6R.RouteModule.output_ports[0].Rectangle = new RectangleF(RM_output_port_LocationX, RM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.RouteModule.output_ports[0], new Point(RM_output_port_LocationX, RM_output_port_LocationY));

            //显示缓冲区2组件
            PointF MB2Location = new PointF(390, 85); //缓冲区2组件初始显示位置 
            this.GraphControl.AddShape(IPv6R.MyBuffer2, MB2Location);

            //显示缓冲区2组件端口
            int WB2_input_port_LocationX = (int)(MB2Location.X);
            int WB2_input_port_LocationY = (int)(MB2Location.Y + 1 * (IPv6R.MyBuffer2.Height / (1 + 1)) - IPv6R.MyBuffer2.input_ports[0].Height / 2);
            int WB2_output_port_LocationX = (int)(MB2Location.X + IPv6R.MyBuffer2.Width - 2);
            int WB2_output_port_LocationY = (int)(MB2Location.Y + 1 * (IPv6R.MyBuffer2.Height / (1 + 1)) - IPv6R.MyBuffer2.output_ports[0].Height / 2);

            IPv6R.MyBuffer2.input_ports[0].Rectangle = new RectangleF(WB2_input_port_LocationX, WB2_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.MyBuffer2.input_ports[0], new Point(WB2_input_port_LocationX, WB2_input_port_LocationY));
            IPv6R.MyBuffer2.output_ports[0].Rectangle = new RectangleF(WB2_output_port_LocationX, WB2_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.MyBuffer2.output_ports[0], new Point(WB2_output_port_LocationX, WB2_output_port_LocationY));

            //显示有线模块2组件
            PointF WM2Location = new PointF(510, 85); //有线模块1组件初始显示位置 
            this.GraphControl.AddShape(IPv6R.WiredModule2, WM2Location);

            //显示有线模块2组件端口
            int WM2_input_port_LocationX = (int)(WM2Location.X);
            int WM2_input_port_LocationY = (int)(WM2Location.Y + 1 * (IPv6R.WiredModule2.Height / (1 + 1)) - IPv6R.WiredModule2.input_ports[0].Height / 2);
            int WM2_output_port_LocationX = (int)(WM2Location.X + IPv6R.WiredModule2.Width - 2);
            int WM2_output_port_LocationY = (int)(WM2Location.Y + 1 * (IPv6R.WiredModule2.Height / (1 + 1)) - IPv6R.WiredModule2.output_ports[0].Height / 2);

            IPv6R.WiredModule2.input_ports[0].Rectangle = new RectangleF(WM2_input_port_LocationX, WM2_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.WiredModule2.input_ports[0], new Point(WM2_input_port_LocationX, WM2_input_port_LocationY));
            IPv6R.WiredModule2.output_ports[0].Rectangle = new RectangleF(WM2_output_port_LocationX, WM2_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(IPv6R.WiredModule2.output_ports[0], new Point(WM2_output_port_LocationX, WM2_output_port_LocationY));

            //显示IPv6Router组件内部连接线
            this.GraphControl.AddConnection(input_port.PortConnector1, IPv6R.WiredModule1.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IPv6R.WiredModule1.output_ports[0].PortConnector1, IPv6R.MyBuffer1.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IPv6R.MyBuffer1.output_ports[0].PortConnector1, IPv6R.RouteModule.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IPv6R.RouteModule.output_ports[0].PortConnector1, IPv6R.MyBuffer2.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IPv6R.MyBuffer2.output_ports[0].PortConnector1, IPv6R.WiredModule2.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(IPv6R.WiredModule2.output_ports[0].PortConnector1, output_port.PortConnector1);
        }            
    
        /********************************************
        * 函数名称：MSInternalStructure()
        * 功能：MedicalServer组件内部结构设计
        * 参数：无
        * 返回值：无
        * *****************************************/
        private void MSInternalStructure()
        {
            MedicalServer MS = (MedicalServer)(this.component);

            //创建MedicalServer组件内部显示端口
            Input_port input_port = new Input_port((MS.ID + "_P1"), MS.name + "Port", "input", "string", MS);
            Output_port output_port = new Output_port((MS.ID + "_P2"), MS.name + "Port", "output", "string", MS);


            //显示MedicalServer组件的端口
            this.GraphControl.AddShape(input_port, new PointF(15, 100));
            this.GraphControl.AddShape(output_port, new PointF(this.GraphControl.Width - 30, 110));

            //显示有线模块组件
            PointF WMLocation = new PointF(60, 85); //有线模块组件初始显示位置 
            this.GraphControl.AddShape(MS.WiredModule, WMLocation);

            //显示有线模块组件端口
            int WM_input_port_LocationX = (int)(WMLocation.X);
            int WM_input_port_LocationY = (int)(WMLocation.Y + 1 * (MS.WiredModule.Height / (1 + 1)) - MS.WiredModule.input_ports[0].Height / 2);
            int WM_output_port_LocationX = (int)(WMLocation.X + MS.WiredModule.Width - 2);
            int WM_output_port_LocationY = (int)(WMLocation.Y + 1 * (MS.WiredModule.Height / (1 + 1)) - MS.WiredModule.output_ports[0].Height / 2);

            MS.WiredModule.input_ports[0].Rectangle = new RectangleF(WM_input_port_LocationX, WM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.WiredModule.input_ports[0], new Point(WM_input_port_LocationX, WM_input_port_LocationY));
            MS.WiredModule.output_ports[0].Rectangle = new RectangleF(WM_output_port_LocationX, WM_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.WiredModule.output_ports[0], new Point(WM_output_port_LocationX, WM_output_port_LocationY));

            //显示缓冲区组件
            PointF MBLocation = new PointF(180, 85); //缓冲区组件初始显示位置 
            this.GraphControl.AddShape(MS.MyBuffer, MBLocation);

            //显示缓冲区组件端口
            int WB_input_port_LocationX = (int)(MBLocation.X);
            int WB_input_port_LocationY = (int)(MBLocation.Y + 1 * (MS.MyBuffer.Height / (1 + 1)) - MS.MyBuffer.input_ports[0].Height / 2);
            int WB_output_port_LocationX = (int)(MBLocation.X + MS.MyBuffer.Width - 2);
            int WB_output_port_LocationY = (int)(MBLocation.Y + 1 * (MS.MyBuffer.Height / (1 + 1)) - MS.MyBuffer.output_ports[0].Height / 2);

            MS.MyBuffer.input_ports[0].Rectangle = new RectangleF(WB_input_port_LocationX, WB_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.MyBuffer.input_ports[0], new Point(WB_input_port_LocationX, WB_input_port_LocationY));
            MS.MyBuffer.output_ports[0].Rectangle = new RectangleF(WB_output_port_LocationX, WB_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.MyBuffer.output_ports[0], new Point(WB_output_port_LocationX, WB_output_port_LocationY));

            //显示数据处理模块组件
            PointF DPLocation = new PointF(300, 85); //数据处理模块组件初始显示位置 
            this.GraphControl.AddShape(MS.DataProcessor, DPLocation);

            //显示数据处理组件端口
            int DP_input_port_LocationX = (int)(DPLocation.X);
            int DP_input_port_LocationY = (int)(DPLocation.Y + 1 * (MS.DataProcessor.Height / (1 + 1)) - MS.DataProcessor.input_ports[0].Height / 2);
            int DP_output_port_LocationX = (int)(DPLocation.X + MS.DataProcessor.Width - 2);
            int DP_output_port_LocationY = (int)(DPLocation.Y + 1 * (MS.DataProcessor.Height / (1 + 1)) - MS.DataProcessor.output_ports[0].Height / 2);

            MS.DataProcessor.input_ports[0].Rectangle = new RectangleF(DP_input_port_LocationX, DP_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.DataProcessor.input_ports[0], new Point(DP_input_port_LocationX, DP_input_port_LocationY));
            MS.DataProcessor.output_ports[0].Rectangle = new RectangleF(DP_output_port_LocationX, DP_output_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.DataProcessor.output_ports[0], new Point(DP_output_port_LocationX, DP_output_port_LocationY));

            //显示数据分析模块组件
            PointF DALocation = new PointF(420, 80); //数据处理模块组件初始显示位置 
            this.GraphControl.AddShape(MS.DataAnalyzer, DALocation);

            //显示数据分析模块组件端口
            int DA_input_port_LocationX = (int)(DALocation.X);
            int DA_input_port_LocationY = (int)(DALocation.Y + 1 * (MS.DataAnalyzer.Height / (1 + 1)) - MS.DataAnalyzer.input_ports[0].Height / 2);
            int DA_output_port_LocationX = (int)(DALocation.X + MS.DataAnalyzer.Width - 2);
            int DA_output_port_LocationY1 = (int)(DALocation.Y + 1 * (MS.DataAnalyzer.Height / (2 + 1)) - MS.DataAnalyzer.output_ports[0].Height / 2);
            int DA_output_port_LocationY2 = (int)(DALocation.Y + 2 * (MS.DataAnalyzer.Height / (2 + 1)) - MS.DataAnalyzer.output_ports[1].Height / 2);
            //int DA_output_port_LocationY3 = (int)(DALocation.Y + 3 * (MS.DataAnalyzer.Height / (3 + 1)) - MS.DataAnalyzer.output_ports[2].Height / 2);

            MS.DataAnalyzer.input_ports[0].Rectangle = new RectangleF(DA_input_port_LocationX, DA_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.DataAnalyzer.input_ports[0], new Point(DA_input_port_LocationX, DA_input_port_LocationY));
            MS.DataAnalyzer.output_ports[0].Rectangle = new RectangleF(DA_output_port_LocationX, DA_output_port_LocationY1, 15, 15);
            this.GraphControl.AddShape(MS.DataAnalyzer.output_ports[0], new Point(DA_output_port_LocationX, DA_output_port_LocationY1));

            MS.DataAnalyzer.output_ports[1].Rectangle = new RectangleF(DA_output_port_LocationX, DA_output_port_LocationY2, 15, 15);
            this.GraphControl.AddShape(MS.DataAnalyzer.output_ports[1], new Point(DA_output_port_LocationX, DA_output_port_LocationY2));

            //MS.DataAnalyzer.output_ports[2].Rectangle = new RectangleF(DA_output_port_LocationX, DA_output_port_LocationY3, 15, 15);
            //this.GraphControl.AddShape(MS.DataAnalyzer.output_ports[2], new Point(DA_output_port_LocationX, DA_output_port_LocationY3));


            //显示数据存储模块组件
            PointF DMLocation = new PointF(540, 50); //数据处理模块组件初始显示位置 
            this.GraphControl.AddShape(MS.DataMemory, DMLocation);

            //显示数据存储模块组件端口
            int DM_input_port_LocationX = (int)(DMLocation.X);
            int DM_input_port_LocationY = (int)(DMLocation.Y + 1 * (MS.DataMemory.Height / (1 + 1)) - MS.DataMemory.input_ports[0].Height / 2);
            //int DM_output_port_LocationX = (int)(DMLocation.X + MS.DataMemory.Width - 2);
            //int DM_output_port_LocationY = (int)(DMLocation.Y + 1 * (MS.DataMemory.Height / (1 + 1)) - MS.DataMemory.output_ports[0].Height / 2);

            MS.DataMemory.input_ports[0].Rectangle = new RectangleF(DM_input_port_LocationX, DM_input_port_LocationY, 15, 15);
            this.GraphControl.AddShape(MS.DataMemory.input_ports[0], new Point(DM_input_port_LocationX, DM_input_port_LocationY));
            //MS.DataMemory.output_ports[0].Rectangle = new RectangleF(DM_output_port_LocationX, DM_output_port_LocationY, 15, 15);
            //this.GraphControl.AddShape(MS.DataMemory.output_ports[0], new Point(DM_output_port_LocationX, DM_output_port_LocationY));



            ////显示显示控制器模块组件
            //PointF DCLocation = new PointF(540, 150); //显示控制器模块组件初始显示位置 
            //this.GraphControl.AddShape(MS.DisplayController, DCLocation);

            ////显示显示控制器模块组件端口
            //int DC_input_port_LocationX = (int)(DCLocation.X);
            //int DC_input_port_LocationY = (int)(DCLocation.Y + 1 * (MS.DisplayController.Height / (1 + 1)) - MS.DisplayController.input_ports[0].Height / 2);
            ////int DC_output_port_LocationX = (int)(DCLocation.X + MS.DisplayController.Width - 2);
            ////int DC_output_port_LocationY = (int)(DCLocation.Y + 1 * (MS.DisplayController.Height / (1 + 1)) - MS.DisplayController.output_ports[0].Height / 2);

            //MS.DisplayController.input_ports[0].Rectangle = new RectangleF(DC_input_port_LocationX, DC_input_port_LocationY, 15, 15);
            //this.GraphControl.AddShape(MS.DisplayController.input_ports[0], new Point(DC_input_port_LocationX, DC_input_port_LocationY));
            ////MS.DisplayController.output_ports[0].Rectangle = new RectangleF(DC_output_port_LocationX, DC_output_port_LocationY, 15, 15);
            ////this.GraphControl.AddShape(MS.DisplayController.output_ports[0], new Point(DC_output_port_LocationX, DC_output_port_LocationY));

            ////显示音频控制器模块组件
            //PointF ACLocation = new PointF(540, 225); //音频控制器模块组件初始显示位置 
            //this.GraphControl.AddShape(MS.AudioController, ACLocation);

            ////显示音频控制器模块组件端口
            //int AC_input_port_LocationX = (int)(ACLocation.X);
            //int AC_input_port_LocationY = (int)(ACLocation.Y + 1 * (MS.AudioController.Height / (1 + 1)) - MS.AudioController.input_ports[0].Height / 2);
            ////int AC_output_port_LocationX = (int)(ACLocation.X + MS.AudioController.Width - 2);
            ////int AC_output_port_LocationY = (int)(ACLocation.Y + 1 * (MS.AudioController.Height / (1 + 1)) - MS.AudioController.output_ports[0].Height / 2);

            //MS.AudioController.input_ports[0].Rectangle = new RectangleF(AC_input_port_LocationX, AC_input_port_LocationY, 15, 15);
            //this.GraphControl.AddShape(MS.AudioController.input_ports[0], new Point(AC_input_port_LocationX, AC_input_port_LocationY));
            ////MS.AudioController.output_ports[0].Rectangle = new RectangleF(AC_output_port_LocationX, AC_output_port_LocationY, 15, 15);
            ////this.GraphControl.AddShape(MS.AudioController.output_ports[0], new Point(AC_output_port_LocationX, AC_output_port_LocationY));

            //显示MedicalServer组件内部连接线
            this.GraphControl.AddConnection(input_port.PortConnector1, MS.WiredModule.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(MS.WiredModule.output_ports[0].PortConnector1, MS.MyBuffer.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(MS.MyBuffer.output_ports[0].PortConnector1, MS.DataProcessor.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(MS.DataProcessor.output_ports[0].PortConnector1, MS.DataAnalyzer.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(MS.DataAnalyzer.output_ports[0].PortConnector1, MS.DataMemory.input_ports[0].PortConnector1);
            this.GraphControl.AddConnection(MS.DataAnalyzer.output_ports[1].PortConnector1, output_port.PortConnector1);
            //this.GraphControl.AddConnection(MS.DataAnalyzer.output_ports[1].PortConnector1, MS.DisplayController.input_ports[0].PortConnector1);
            //this.GraphControl.AddConnection(MS.DataAnalyzer.output_ports[2].PortConnector1, MS.AudioController.input_ports[0].PortConnector1);
        }  
    
    }
}
