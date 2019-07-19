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
    //医疗服务器组件
    public class MedicalServer : Component
    {
        //Component wiredModule;        //有线模块组件
        WiredModule wiredModule;      //有线模块组件
        Component myBuffer;           //缓冲区组件
        DataProcessor dataProcessor;  //数据处理模块组件          
        Component dataAnalyzer;       //数据分析模块组件
        Component dataMemory;         //数据存储模块组件
        //Component displayController;  //显示控制器模块组件
        //Component audioController;    //音频控制器模块组件

        private UInt64 wiredModule_mac_address = 0xFF01FEABFF01; //有线模块MAC地址 48bits

        //服务器IPv6地址 2001:da8:d818:0082::1234
        private UInt16[] Server_IPv6_address = { 0x0120, 0xa80d, 0x18d8, 0x8200, 
                                            0x000, 0x0000, 0x0000, 0x3412 }; 

        //public Component WiredModule
        //{
        //    get { return wiredModule; }
        //    set { wiredModule = value; }
        //}
        public WiredModule WiredModule
        {
            get { return wiredModule; }
            set { wiredModule = value; }
        }
        public Component MyBuffer
        {
            get { return myBuffer; }
            set { myBuffer = value; }
        }
        //public Component DataProcessor
        //{
        //    get { return dataProcessor; }
        //    set { dataProcessor = value; }
        //}
        public DataProcessor DataProcessor
        {
            get { return dataProcessor; }
            set { dataProcessor = value; }
        }
        public Component DataAnalyzer
        {
            get { return dataAnalyzer; }
            set { dataAnalyzer = value; }
        }
        public Component DataMemory
        {
            get { return dataMemory; }
            set { dataMemory = value; }
        }

        //public Component DisplayController
        //{
        //    get { return displayController; }
        //    set { displayController = value; }
        //}
        //public Component AudioController
        //{
        //    get { return audioController; }
        //    set { audioController = value; }
        //}


        public MedicalServer(GraphControl graphControl)
            : base(graphControl)
        {
            this.IsCompositeComponnet = true; //MedicalServer为复合组件
            //this.bmp = new Bitmap(@"..\..\..\picture\MedicalServer.png");

            this.bmp = Resource1.MedicalServer;
            this.Text = "MedicalServer";
            this.Rectangle = new RectangleF(400, 300, 84, 56); //设置组件位置及大小
            this.name = "MedicalServer";

            //创建MedicalServer组件端口并显示
            this.input_ports = new Input_port[1];   //组件input端口数组
            this.output_ports = new Output_port[1]; //组件output端口数组
            this.input_ports[0] = new Input_port((this.ID + "_P1"), this.name + "Port", "input", "String", this);
            this.output_ports[0] = new Output_port((this.ID + "_P2"), this.name + "Port", "output", "String", this);

            int input_port_LocationX = (int)(this.Location.X);
            int input_ports_LocationY = (int)(this.Location.Y + 1 * (this.Height / (1 + 1)) - input_ports[0].Height / 2);

            int output_port_LocationX = (int)(this.Location.X + this.Width - 2);
            int output_ports_LocationY = (int)(this.Location.Y + 1 * (this.Height / (1 + 1)) - output_ports[0].Height / 2);

            input_ports[0].Rectangle = new RectangleF(input_port_LocationX, input_ports_LocationY, 15, 15);
            output_ports[0].Rectangle = new RectangleF(output_port_LocationX, output_ports_LocationY, 15, 15);

            this.graphControl.AddShape(input_ports[0], new Point(input_port_LocationX, input_ports_LocationY));
            this.graphControl.AddShape(output_ports[0], new Point(output_port_LocationX, output_ports_LocationY));

            
            //创建WiredModule组件
            this.wiredModule = new WiredModule(null, null, null, null);
            this.wiredModule.Mac_address = wiredModule_mac_address;

            //创建WiredModule组件端口
            this.wiredModule.input_ports = new Input_port[1];
            this.wiredModule.input_ports[0] = new Input_port(this.wiredModule.ID + "_P1",
                this.wiredModule.name + "Port", "input", "string", this.wiredModule);
            this.wiredModule.output_ports = new Output_port[1];
            this.wiredModule.output_ports[0] = new Output_port(this.wiredModule.ID + "_P2",
                this.wiredModule.name + "Port", "output", "string", this.wiredModule);

            //创建MyBuffer组件
            this.myBuffer = new MyBuffer(null, null, null, null);
            //创建MyBuffer组件端口
            this.myBuffer.input_ports = new Input_port[1];
            this.myBuffer.input_ports[0] = new Input_port(this.myBuffer.ID + "_P1",
                this.myBuffer.name + "Port", "input", "string", this.myBuffer);
            this.myBuffer.output_ports = new Output_port[1];
            this.myBuffer.output_ports[0] = new Output_port(this.myBuffer.ID + "_P2",
                this.myBuffer.name + "Port", "output", "string", this.myBuffer);

            //创建DataProcessor组件
            this.dataProcessor = new DataProcessor(null, null, null, null);
            this.dataProcessor.IPv6_address1 = Server_IPv6_address;


            //创建DataProcessor组件端口
            this.dataProcessor.input_ports = new Input_port[1];
            this.dataProcessor.input_ports[0] = new Input_port(this.dataProcessor.ID + "_P1",
                this.dataProcessor.name + "Port", "input", "string", this.dataProcessor);
            this.dataProcessor.output_ports = new Output_port[1];
            this.dataProcessor.output_ports[0] = new Output_port(this.dataProcessor.ID + "_P2",
                this.dataProcessor.name + "Port", "output", "string", this.dataProcessor);

            //创建DataAnalyzer组件
            this.dataAnalyzer = new DataAnalyzer(null, null, null, null);
            //创建DataAnalyzer组件端口
            this.dataAnalyzer.input_ports = new Input_port[1];
            this.dataAnalyzer.input_ports[0] = new Input_port(this.dataAnalyzer.ID + "_P1",
                this.dataAnalyzer.name + "Port", "input", "string", this.dataAnalyzer);
            //this.dataAnalyzer.output_ports = new Output_port[3];
            this.dataAnalyzer.output_ports = new Output_port[2];
            this.dataAnalyzer.output_ports[0] = new Output_port(this.dataAnalyzer.ID + "_P2",
                this.dataAnalyzer.name + "Port", "output", "string", this.dataAnalyzer);
            this.dataAnalyzer.output_ports[1] = new Output_port(this.dataAnalyzer.ID + "_P3",
                this.dataAnalyzer.name + "Port", "output", "string", this.dataAnalyzer);
            //this.dataAnalyzer.output_ports[2] = new Output_port(this.dataAnalyzer.ID + "_P4",
            //     this.dataAnalyzer.name + "Port", "output", "string", this.dataAnalyzer);

            //创建DataMemory组件
            this.dataMemory = new DataMemory(null, null, null, null);
            //创建DataMemory组件端口
            this.dataMemory.input_ports = new Input_port[1];
            this.dataMemory.input_ports[0] = new Input_port(this.dataMemory.ID + "_P1",
                this.dataMemory.name + "Port", "input", "string", this.dataMemory);
            //this.dataMemory.output_ports = new Output_port[1];
            //this.dataMemory.output_ports[0] = new Output_port(this.dataMemory.ID + "_P2",
            //    this.dataMemory.name + "Port", "output", "string", this.dataMemory);

            ////创建DisplayController组件
            //this.displayController = new DisplayController(null, null, null, null);
            ////创建DisplayController组件端口
            //this.displayController.input_ports = new Input_port[1];
            //this.displayController.input_ports[0] = new Input_port(this.displayController.ID + "_P1",
            //    this.displayController.name + "Port", "input", "string", this.displayController);
            ////this.displayController.output_ports = new Output_port[1];
            ////this.displayController.output_ports[0] = new Output_port(this.displayController.ID + "_P2",
            ////    this.displayController.name + "Port", "output", "string", this.displayController);

            ////创建AudioController组件
            //this.audioController = new AudioController(null, null, null, null);
            ////创建AudioController组件端口
            //this.audioController.input_ports = new Input_port[1];
            //this.audioController.input_ports[0] = new Input_port(this.audioController.ID + "_P1",
            //    this.audioController.name + "Port", "input", "string", this.audioController);
            ////this.audioController.output_ports = new Output_port[1];
            ////this.audioController.output_ports[0] = new Output_port(this.audioController.ID + "_P2",
            ////    this.audioController.name + "Port", "output", "string", this.audioController);

            //--------------------------------------------------------------//
            //--------建立内部组件端口到MedicalServer组件端口的连线---------//
            //--------------------------------------------------------------//

            //1、建立MedicalServer组件input端口到WiredModule组件input端口的连线
            Connection connection1 = new Connection();
            connection1.From = this.input_ports[0].PortConnector1;
            connection1.To = this.wiredModule.input_ports[0].PortConnector1;
            //修改ConnectionCollection.cs第78行，获取Add方法
            //将连线添加到组件输出端口连接点
            this.input_ports[0].PortConnector1.Connections.Add(connection1);

            //2、建立DataAnalyzer组件output1端口到MedicalServer组件output端口的连线
            Connection connection2 = new Connection();
            connection2.From = this.DataAnalyzer.output_ports[1].PortConnector1;
            connection2.To = this.output_ports[0].PortConnector1;

            //将连线添加到组件输出端口连接点
            this.DataAnalyzer.output_ports[1].PortConnector1.Connections.Add(connection2);

            //-------------------------------------------------------------------//
            ////2、建立WiredModule组件output端口到Mybuffer组件input端口的连线
            //Connection connection2 = new Connection();
            //connection2.From = this.wiredModule.output_ports[0].PortConnector1;
            //connection2.To = this.myBuffer.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.wiredModule.output_ports[0].PortConnector1.Connections.Add(connection2);

            ////3、建立Mybuffer组件output端口到DataProcessor组件input端口的连线
            //Connection connection3 = new Connection();
            //connection3.From = this.myBuffer.output_ports[0].PortConnector1;
            //connection3.To = this.dataProcessor.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer.output_ports[0].PortConnector1.Connections.Add(connection3);

            ////4、建立DataProcessor组件output端口到DataAnalyzer组件input端口的连线
            //Connection connection4 = new Connection();
            //connection4.From = this.dataProcessor.output_ports[0].PortConnector1;
            //connection4.To = this.dataAnalyzer.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.dataProcessor.output_ports[0].PortConnector1.Connections.Add(connection4);

            ////5、建立DataAnalyzer组件output端口到DataMemory组件input端口的连线
            //Connection connection5 = new Connection();
            //connection5.From = this.dataAnalyzer.output_ports[0].PortConnector1;
            //connection5.To = this.dataMemory.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.dataAnalyzer.output_ports[0].PortConnector1.Connections.Add(connection5);

            ////6、建立DataAnalyzer组件output端口到DisplayController组件input端口的连线
            //Connection connection6 = new Connection();
            //connection6.From = this.dataAnalyzer.output_ports[1].PortConnector1;
            //connection6.To = this.displayController.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.dataAnalyzer.output_ports[1].PortConnector1.Connections.Add(connection6);

            ////7、建立DataAnalyzer组件output端口到AudioController组件input端口的连线
            //Connection connection7 = new Connection();
            //connection7.From = this.dataAnalyzer.output_ports[2].PortConnector1;
            //connection7.To = this.audioController.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.dataAnalyzer.output_ports[2].PortConnector1.Connections.Add(connection7);

            this.InsideForm = new InsideForm(this); //构建内部结构显示表单     

        }

        /********************************************
         * 函数名称：run()
         * 功能：医疗服务器组件执行函数
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

                //-------------------医疗服务器input端口传输数据----------------//
                //若input端口不为空
                if (this.input_ports != null)
                {
                    foreach (Input_port input in this.input_ports)
                    {
                        PortDataTransfer(input); //input端口进行数据传输
                    }
                }

                //-------------------有线模块组件启动执行-------------------//
                WiredModule wiredM = (WiredModule)this.wiredModule;
                //step1、有线模块组件接收数据
                wiredM.ComponentDataReceive(wiredM);
                //step2、执行有线模块数据帧解封装功能
                wiredM.EthernetFrameDecapsulation();
                //step3、有线模块组件output端口传输数据
                wiredM.ComponentDataTransfer(wiredM);

                //--------------------缓冲区组件启动执行--------------------//
                MyBuffer buf = (MyBuffer)this.myBuffer;
                //step1、缓冲区组件接收数据
                buf.ComponentDataReceive(buf);
                //step2、执行缓冲区功能
                buf.MessageBuffering(null);
                //step3、缓冲区1组件output端口传输数据
                buf.ComponentDataTransfer(buf);

                //---------------网络数据处理模块组件启动执行--------------//
                DataProcessor dp = (DataProcessor)this.dataProcessor;
                //step1、网络数据处理模块接收数据
                dp.ComponentDataReceive(dp);
                //step2、执行网络数据处理模块功能
                dp.NetworkDataProcessing();
                //step3、网络数据处理模块output端口传输数据
                dp.ComponentDataTransfer(dp);

                //----------------信息分析控制模块启动执行------------------//
                DataAnalyzer da = (DataAnalyzer)this.dataAnalyzer;
                //step1、信息分析控制模块接收数据
                da.ComponentDataReceive(da);
                //step2、执行信息分析控制模块功能
                da.DataAnalysis();
                //step3、信息分析控制模块output端口传输数据
                da.ComponentDataTransfer(da);

                //----------------医疗服务器output端口传输数据--------------//
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
