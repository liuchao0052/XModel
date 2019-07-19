using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Netron.GraphLib;
using XModel.BasicLibrary;

namespace XModel.CMIoTLibrary
{
    //物联网网关组件
    public class IoTGateway : Component
    {
        //Component wirelessModule1;       //子组件-无线模块1组件
        //Component wirelessModule2;       //子组件-无线模块2组件
        //Component wirelessModule3;       //子组件-无线模块3组件

        WirelessModule wirelessModule1;    //子组件-无线模块1组件
        WirelessModule wirelessModule2;    //子组件-无线模块2组件
        WirelessModule wirelessModule3;    //子组件-无线模块3组件
        Component myBuffer1;               //子组件-缓冲区1组件
        Component myBuffer2;               //子组件-缓冲区2组件
        Component myBuffer3;               //子组件-缓冲区3组件
        Component myBuffer4;               //子组件-缓冲区4组件
        Component protocolConverter;       //子组件-协议转换器组件
        WiredModule wiredModule;           //子组件-有线模块组件       

        private UInt64 wirelessModule1_mac_address = 0x10010585FEAB1001; //无线模块1MAC地址 64bits
        private UInt64 wirelessModule2_mac_address = 0x10010585FEAB2001; //无线模块2MAC地址 64bits
        private UInt64 wirelessModule3_mac_address = 0x1001FEAB3001;     //无线模块3MAC地址 48bits
        private UInt32 wirelessModule3_access_address = 0x8569FAC7;      //无线模块3接入地址 32bits
        
        private UInt64 wiredModule_mac_address = 0x1001FEAB4001; //有线模块MAC地址 48bits

        private UInt64 dest_address = 0xF001FEABF001; //目标地址 48bits


        public WirelessModule WirelessModule1
        {
            get { return wirelessModule1; }
            set { wirelessModule1 = value; }
        }
        public WirelessModule WirelessModule2
        {
            get { return wirelessModule2; }
            set { wirelessModule2 = value; }
        }
        public WirelessModule WirelessModule3
        {
            get { return wirelessModule3; }
            set { wirelessModule3 = value; }
        }
        //public Component WirelessModule1
        //{
        //    get { return wirelessModule1; }
        //    set { wirelessModule1 = value; }
        //}
        //public Component WirelessModule2
        //{
        //    get { return wirelessModule2; }
        //    set { wirelessModule2 = value; }
        //}
        //public Component WirelessModule3
        //{
        //    get { return wirelessModule3; }
        //    set { wirelessModule3 = value; }
        //}
        public Component MyBuffer1
        {
            get { return myBuffer1; }
            set { myBuffer1 = value; }
        }
        public Component MyBuffer2
        {
            get { return myBuffer2; }
            set { myBuffer2 = value; }
        }
        public Component MyBuffer3
        {
            get { return myBuffer3; }
            set { myBuffer3 = value; }
        }
        public Component MyBuffer4
        {
            get { return myBuffer4; }
            set { myBuffer4 = value; }
        }
        public Component ProtocolConverter
        {
            get { return protocolConverter; }
            set { protocolConverter = value; }
        }
        public WiredModule WiredModule
        {
            get { return wiredModule; }
            set { wiredModule = value; }
        }

        public IoTGateway(GraphControl graphControl)
            : base(graphControl)
        {
            this.IsCompositeComponnet = true; //IoTGateway为复合组件
            //this.bmp = new Bitmap(@"..\..\..\picture\IoTGateway.png");

            this.bmp = Resource1.IoTGateway;
            this.Text = "IoTGateway";
            this.Rectangle = new RectangleF(250, 200, 99, 105); //设置组件位置及大小
            this.name = "IoTGateway";
            
            //创建IoTGateway组件端口并显示
            this.input_ports = new Input_port[3];   //组件input端口数组
            this.output_ports = new Output_port[1]; //组件output端口数组
            this.input_ports[0] = new Input_port((this.ID + "_P1"), this.name + "Port", "input", "string", this);
            this.input_ports[1] = new Input_port((this.ID + "_P2"), this.name + "Port", "input", "string", this);
            this.input_ports[2] = new Input_port((this.ID + "_P3"), this.name + "Port", "input", "string", this);
            this.output_ports[0] = new Output_port((this.ID + "_P4"), this.name + "Port", "output", "string", this);

            int input_port_LocationX = (int)(this.Location.X);
            int input_ports_LocationY1 = (int)(this.Location.Y + 1 * (this.Height / (3 + 1)) - input_ports[0].Height / 2);
            int input_ports_LocationY2 = (int)(this.Location.Y + 2 * (this.Height / (3 + 1)) - input_ports[1].Height / 2);
            int input_ports_LocationY3 = (int)(this.Location.Y + 3 * (this.Height / (3 + 1)) - input_ports[2].Height / 2);

            int output_port_LocationX = (int)(this.Location.X + this.Width - 2);
            int output_ports_LocationY = (int)(this.Location.Y + 1 * (this.Height / (1 + 1)) - output_ports[0].Height / 2);

            input_ports[0].Rectangle = new RectangleF(input_port_LocationX, input_ports_LocationY1, 15, 15);
            input_ports[1].Rectangle = new RectangleF(input_port_LocationX, input_ports_LocationY2, 15, 15);
            input_ports[2].Rectangle = new RectangleF(input_port_LocationX, input_ports_LocationY3, 15, 15);
            output_ports[0].Rectangle = new RectangleF(output_port_LocationX, output_ports_LocationY, 15, 15);

            this.graphControl.AddShape(input_ports[0], new Point(input_port_LocationX, input_ports_LocationY1));
            this.graphControl.AddShape(input_ports[1], new Point(input_port_LocationX, input_ports_LocationY2));
            this.graphControl.AddShape(input_ports[2], new Point(input_port_LocationX, input_ports_LocationY3));
            this.graphControl.AddShape(output_ports[0], new Point(output_port_LocationX, output_ports_LocationY));


            //创建无线模块1组件
            this.wirelessModule1 = new WirelessModule(null, null, null, null);
            this.wirelessModule1.Mac_address = wirelessModule1_mac_address;

            //创建无线模块1组件端口
            this.wirelessModule1.input_ports = new Input_port[1];
            this.wirelessModule1.input_ports[0] = new Input_port(this.wirelessModule1.ID + "_P1",
                this.wirelessModule1.name + "Port", "input", "string", this.wirelessModule1);
            this.wirelessModule1.output_ports = new Output_port[1];
            this.wirelessModule1.output_ports[0] = new Output_port(this.wirelessModule1.ID + "_P2",
                this.wirelessModule1.name + "Port", "output", "string", this.wirelessModule1);

            //创建无线模块2组件
            this.wirelessModule2 = new WirelessModule(null, null, null, null);
            this.wirelessModule2.Mac_address = wirelessModule2_mac_address;

            //创建无线模块2组件端口
            this.wirelessModule2.input_ports = new Input_port[1];
            this.wirelessModule2.input_ports[0] = new Input_port(this.wirelessModule2.ID + "_P1",
                this.wirelessModule2.name + "Port", "input", "string", this.wirelessModule2);
            this.wirelessModule2.output_ports = new Output_port[1];
            this.wirelessModule2.output_ports[0] = new Output_port(this.wirelessModule2.ID + "_P2",
                this.wirelessModule2.name + "Port", "output", "string", this.wirelessModule2);

            //创建无线模块3组件
            this.wirelessModule3 = new WirelessModule(null, null, null, null);
            this.wirelessModule3.Mac_address = wirelessModule3_mac_address;
            this.WirelessModule3.Access_address = wirelessModule3_access_address;

            //创建无线模块3组件端口
            this.wirelessModule3.input_ports = new Input_port[1];
            this.wirelessModule3.input_ports[0] = new Input_port(this.wirelessModule3.ID + "_P1",
                this.wirelessModule3.name + "Port", "input", "string", this.wirelessModule3);
            this.wirelessModule3.output_ports = new Output_port[1];
            this.wirelessModule3.output_ports[0] = new Output_port(this.wirelessModule3.ID + "_P2",
                this.wirelessModule3.name + "Port", "output", "string", this.wirelessModule3);

            //创建缓冲区1组件
            this.myBuffer1 = new MyBuffer(null, null, null, null);
            //创建缓冲区1组件端口
            this.myBuffer1.input_ports = new Input_port[1];
            this.myBuffer1.input_ports[0] = new Input_port(this.myBuffer1.ID + "_P1",
                this.myBuffer1.name + "Port", "input", "string", this.myBuffer1);
            this.myBuffer1.output_ports = new Output_port[1];
            this.myBuffer1.output_ports[0] = new Output_port(this.myBuffer1.ID + "_P2",
                this.myBuffer1.name + "Port", "output", "string", this.myBuffer1);

            //创建缓冲区2组件
            this.myBuffer2 = new MyBuffer(null, null, null, null);
            //创建缓冲区2组件端口
            this.myBuffer2.input_ports = new Input_port[1];
            this.myBuffer2.input_ports[0] = new Input_port(this.myBuffer2.ID + "_P1",
                this.myBuffer2.name + "Port", "input", "string", this.myBuffer2);
            this.myBuffer2.output_ports = new Output_port[1];
            this.myBuffer2.output_ports[0] = new Output_port(this.myBuffer2.ID + "_P2",
                this.myBuffer2.name + "Port", "output", "string", this.myBuffer2);

            //创建缓冲区3组件
            this.myBuffer3 = new MyBuffer(null, null, null, null);
            //创建缓冲区2组件端口
            this.myBuffer3.input_ports = new Input_port[1];
            this.myBuffer3.input_ports[0] = new Input_port(this.myBuffer3.ID + "_P1",
                this.myBuffer3.name + "Port", "input", "string", this.myBuffer3);
            this.myBuffer3.output_ports = new Output_port[1];
            this.myBuffer3.output_ports[0] = new Output_port(this.myBuffer3.ID + "_P2",
                this.myBuffer3.name + "Port", "output", "string", this.myBuffer3);

            //创建缓冲区4组件
            this.myBuffer4 = new MyBuffer(null, null, null, null);
            //创建缓冲区4组件端口
            this.myBuffer4.input_ports = new Input_port[1];
            this.myBuffer4.input_ports[0] = new Input_port(this.myBuffer4.ID + "_P1",
                this.myBuffer4.name + "Port", "input", "string", this.myBuffer4);
            this.myBuffer4.output_ports = new Output_port[1];
            this.myBuffer4.output_ports[0] = new Output_port(this.myBuffer4.ID + "_P2",
                this.myBuffer4.name + "Port", "output", "string", this.myBuffer4);

            //创建协议转换器组件
            this.protocolConverter = new ProtocolConverter(null, null, null, null);
            //创建协议转换器组件端口
            this.protocolConverter.input_ports = new Input_port[3];
            this.protocolConverter.input_ports[0] = new Input_port(this.protocolConverter.ID + "_P1",
                this.protocolConverter.name + "Port", "input", "string", this.protocolConverter);
            this.protocolConverter.input_ports[1] = new Input_port(this.protocolConverter.ID + "_P2",
                this.protocolConverter.name + "Port", "input", "string", this.protocolConverter);
            this.protocolConverter.input_ports[2] = new Input_port(this.protocolConverter.ID + "_P3",
                this.protocolConverter.name + "Port", "input", "string", this.protocolConverter);

            this.protocolConverter.output_ports = new Output_port[1];
            this.protocolConverter.output_ports[0] = new Output_port(this.protocolConverter.ID + "_P4",
                this.protocolConverter.name + "Port", "output", "string", this.protocolConverter);

            //创建有线模块组件
            this.wiredModule = new WiredModule(null, null, null, null);
            this.wiredModule.Mac_address = wiredModule_mac_address;

            //创建有线模块组件端口
            this.wiredModule.input_ports = new Input_port[1];
            this.wiredModule.input_ports[0] = new Input_port(this.wiredModule.ID + "_P1",
                this.wiredModule.name + "Port", "input", "string", this.wiredModule);
            this.wiredModule.output_ports = new Output_port[1];
            this.wiredModule.output_ports[0] = new Output_port(this.wiredModule.ID + "_P2",
                this.wiredModule.name + "Port", "output", "string", this.wiredModule);

            //-------------------------------------------------------------//
            //--------建立内部组件端口到IoTGateway组件端口的连线-----------//
            //-------------------------------------------------------------//

            //1、建立IoTGateway组件input端口到无线模块1组件input端口的连线
            Connection connection1 = new Connection();
            connection1.From = this.input_ports[0].PortConnector1;
            connection1.To = this.wirelessModule1.input_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.input_ports[0].PortConnector1.Connections.Add(connection1);

            //2、建立IoTGateway组件input端口到无线模块2组件input端口的连线
            Connection connection2 = new Connection();
            connection2.From = this.input_ports[1].PortConnector1;
            connection2.To = this.wirelessModule2.input_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.input_ports[1].PortConnector1.Connections.Add(connection2);

            //3、建立IoTGateway组件input端口到无线模块3组件input端口的连线
            Connection connection3 = new Connection();
            connection3.From = this.input_ports[2].PortConnector1;
            connection3.To = this.wirelessModule3.input_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.input_ports[2].PortConnector1.Connections.Add(connection3);

            //12、建立有线模块组件output端口到IoTGateway组件output端口的连线
            Connection connection12 = new Connection();
            connection12.From = this.wiredModule.output_ports[0].PortConnector1;
            connection12.To = this.output_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.wiredModule.output_ports[0].PortConnector1.Connections.Add(connection12);

            //-------------------------------------------------------------------------//

            ////4、建立无线模块1组件output端口到缓冲区1组件input端口的连线
            //Connection connection4 = new Connection();
            //connection4.From = this.wirelessModule1.output_ports[0].PortConnector1;
            //connection4.To = this.myBuffer1.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.wirelessModule1.output_ports[0].PortConnector1.Connections.Add(connection4);

            ////5、建立无线模块2组件output端口到缓冲区2组件input端口的连线
            //Connection connection5 = new Connection();
            //connection5.From = this.wirelessModule2.output_ports[0].PortConnector1;
            //connection5.To = this.myBuffer2.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.wirelessModule2.output_ports[0].PortConnector1.Connections.Add(connection5);

            ////6、建立无线模块3组件output端口到缓冲区3组件input端口的连线
            //Connection connection6 = new Connection();
            //connection6.From = this.wirelessModule3.output_ports[0].PortConnector1;
            //connection6.To = this.myBuffer3.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.wirelessModule3.output_ports[0].PortConnector1.Connections.Add(connection6);

            ////7、建立缓冲区1组件output端口到协议转换模块组件input端口1的连线
            //Connection connection7 = new Connection();
            //connection7.From = this.myBuffer1.output_ports[0].PortConnector1;
            //connection7.To = this.protocolConverter.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer1.output_ports[0].PortConnector1.Connections.Add(connection7);

            ////8、建立缓冲区2组件output端口到协议转换模块组件input端口2的连线
            //Connection connection8 = new Connection();
            //connection8.From = this.myBuffer2.output_ports[0].PortConnector1;
            //connection8.To = this.protocolConverter.input_ports[1].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer2.output_ports[0].PortConnector1.Connections.Add(connection8);

            ////9、建立缓冲区3组件output端口到协议转换模块组件input端口3的连线
            //Connection connection9 = new Connection();
            //connection9.From = this.myBuffer3.output_ports[0].PortConnector1;
            //connection9.To = this.protocolConverter.input_ports[2].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer3.output_ports[0].PortConnector1.Connections.Add(connection9);

            ////10、建立协议转换模块组件output端口到缓冲区4组件input端口的连线
            //Connection connection10 = new Connection();
            //connection10.From = this.protocolConverter.output_ports[0].PortConnector1;
            //connection10.To = this.myBuffer4.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.protocolConverter.output_ports[0].PortConnector1.Connections.Add(connection10);

            ////11、建立缓冲区4组件output端口到有线模块组件input端口的连线
            //Connection connection11 = new Connection();
            //connection11.From = this.myBuffer4.output_ports[0].PortConnector1;
            //connection11.To = this.wiredModule.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer4.output_ports[0].PortConnector1.Connections.Add(connection11);

            this.InsideForm = new InsideForm(this); //构建内部结构显示表单

        }

        /********************************************
         * 函数名称：run()
         * 功能：物联网网关组件执行函数
         * 参数：无
         * 返回值：无
         * *****************************************/
        public void run()
        {
            while (true)
            {
                if (Form1.stop)
                {
                    this.EmptyingQueue();
                    return;
                }

                //-------------------IoT网关input端口传输数据----------------//
                //若input端口不为空
                if (this.input_ports != null)
                {
                    foreach(Input_port input in this.input_ports){
                        PortDataTransfer(input); //input端口进行数据传输
                    }
                }

                //-------------------无线模块1组件启动执行-------------------//
                WirelessModule wm1 = (WirelessModule)this.wirelessModule1;

                //step1、无线模块1组件接收数据
                wm1.ComponentDataReceive(wm1);
                //step2、执行无线模块1数据帧解封装功能
                wm1.FrameDecapsulation();
                //step3、无线模块1组件output端口传输数据
                wm1.ComponentDataTransfer(wm1);

                //-------------------无线模块2组件启动执行-------------------//
                WirelessModule wm2 = (WirelessModule)this.wirelessModule2;
                //step1、无线模块2组件接收数据
                wm2.ComponentDataReceive(wm2);
                //step2、执行无线模块2数据帧解封装功能
                wm2.FrameDecapsulation();
                //step3、无线模块2组件output端口传输数据
                wm2.ComponentDataTransfer(wm2);

                //-------------------无线模块3组件启动执行-------------------//
                WirelessModule wm3 = (WirelessModule)this.wirelessModule3;
                //step1、无线模块2组件接收数据
                wm3.ComponentDataReceive(wm3);
                //step2、执行无线模块2数据帧解封装功能
                wm3.FrameDecapsulation();
                //step3、无线模块2组件output端口传输数据
                wm3.ComponentDataTransfer(wm3);

                //-------------------缓冲区1组件启动执行-------------------//
                MyBuffer buf1 = (MyBuffer)this.myBuffer1;
                //step1、缓冲区1组件接收数据
                buf1.ComponentDataReceive(buf1);
                //step2、执行缓冲区功能
                buf1.MessageBuffering("frame802154");
                //step3、缓冲区1组件output端口传输数据
                buf1.ComponentDataTransfer(buf1);

                //-------------------缓冲区2组件启动执行-------------------//
                MyBuffer buf2 = (MyBuffer)this.myBuffer2;
                //step1、缓冲区2组件接收数据
                buf2.ComponentDataReceive(buf2);
                //step2、执行缓冲区2功能
                buf2.MessageBuffering("frame802154");
                //step3、缓冲区2组件output端口传输数据
                buf2.ComponentDataTransfer(buf2);

                //-------------------缓冲区3组件启动执行-------------------//
                MyBuffer buf3 = (MyBuffer)this.myBuffer3;
                //step1、缓冲区3组件接收数据
                buf3.ComponentDataReceive(buf3);
                //step2、执行缓冲区3功能
                buf3.MessageBuffering("frame802151");
                //step3、缓冲区3组件output端口传输数据
                buf3.ComponentDataTransfer(buf3);
                
                //----------------网络协议转换模块启动执行-----------------//
                ProtocolConverter pc = (ProtocolConverter)this.protocolConverter;
                //step1、网络协议转换模块接收数据
                pc.ComponentDataReceive(pc);
                //step2、执行网络协议转换模块功能
                pc.ProtocolConversion();
                //step3、网络协议转换模块output端口传输数据
                pc.ComponentDataTransfer(pc);

                //-------------------缓冲区4组件启动执行-------------------//
                MyBuffer buf4 = (MyBuffer)this.myBuffer4;
                //step1、缓冲区3组件接收数据
                buf4.ComponentDataReceive(buf4);
                //step2、执行缓冲区3功能
                buf4.MessageBuffering(null);
                //step3、缓冲区3组件output端口传输数据
                buf4.ComponentDataTransfer(buf4);

                //-------------------有线模块组件启动执行-------------------//
                WiredModule wiredM = (WiredModule)wiredModule;
                //step1、有线模块组件接收数据
                wiredM.ComponentDataReceive(wiredM);
                //step2、执行有线模块组件功能
                wiredM.EthernetFrameEncapsulation(dest_address);
                //step3、有线模块组件output端口传输数据
                wiredM.ComponentDataTransfer(wiredM);

                //----------------IoT网关output端口传输数据--------------//
                //若output端口不为空
                if (this.output_ports != null)
                {
                    foreach (Output_port output in this.output_ports)
                    {
                        PortDataTransfer(output); //output端口进行数据传输
                    }
                }
            }
        }// public void run()

    }
}
