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
    //血压传感节点组件
    public class BloodPressureSensorNode : Component
    {
        Component bloodPressureSensor;  //子组件-血压传感器组件
        Component microProcessor;       //子组件-微处理器组件
        Component myBuffer;             //子组件-缓冲区组件
        WirelessModule wirelessModule;  //子组件-无线模块

        private UInt64 wirelessModule_mac_address = 0x10010585FEAB5001; //无线模块MAC地址
        private UInt64 dest_address = 0x10010585FEAB1001; //目标地址

        //Component wirelessModule;     //子组件-无线模块

        string x = "6LoWPAN";           //报文封装格式为6LoWPAN报文
        string y = "frame802154";       //帧封装格式为802.15.4帧

        //private int delay = 300;        //时延

        public Component BloodPressureSensor
        {
            get { return bloodPressureSensor; }
            set { bloodPressureSensor = value; }
        }  
        public Component MicroProcessor
        {
            get { return microProcessor; }
            set { microProcessor = value; }
        }
        public Component MyBuffer
        {
            get { return myBuffer; }
            set { myBuffer = value; }
        }
        //public Component WirelessModule
        //{
        //    get { return wirelessModule; }
        //    set { wirelessModule = value; }
        //}
        public WirelessModule WirelessModule
        {
            get { return wirelessModule; }
            set { wirelessModule = value; }
        }

        public BloodPressureSensorNode(GraphControl graphControl)
            : base(graphControl)
        {
            this.IsCompositeComponnet = true; //BloodPressureSensorNode为复合组件

            //this.bmp = new Bitmap(@"..\..\..\picture\BloodPressureSensorNode.png");

            this.bmp = Resource1.BloodPressureSensorNode;
            this.Text = "BloodPressureSensorNode";
            this.Rectangle = new RectangleF(200, 200, 87, 54); //设置组件位置及大小
            this.name = "BloodPressureSensorNode";

            //创建BloodPressureSensorNode组件端口并显示
            this.input_ports = new Input_port[1];   //组件input端口数组
            this.output_ports = new Output_port[1]; //组件output端口数组
            this.input_ports[0] = new Input_port((this.ID + "_P1"), this.name + "Port", "input", "int[]", this);
            this.output_ports[0] = new Output_port((this.ID + "_P2"), this.name + "Port", "output", "String", this);

            int input_port_LocationX = (int)(this.Location.X);
            int input_ports_LocationY = (int)(this.Location.Y + 1 * (this.Height / (1 + 1)) - input_ports[0].Height / 2);

            int output_port_LocationX = (int)(this.Location.X + this.Width - 2);
            int output_ports_LocationY = (int)(this.Location.Y + 1 * (this.Height / (1 + 1)) - output_ports[0].Height / 2);

            input_ports[0].Rectangle = new RectangleF(input_port_LocationX, input_ports_LocationY, 15, 15);
            output_ports[0].Rectangle = new RectangleF(output_port_LocationX, output_ports_LocationY, 15, 15);

            this.graphControl.AddShape(input_ports[0], new Point(input_port_LocationX, input_ports_LocationY));
            this.graphControl.AddShape(output_ports[0], new Point(output_port_LocationX, output_ports_LocationY));

            //创建BloodPressureSensor组件
            this.BloodPressureSensor = new BloodPressureSensor(null, null, null, null);
            //创建BloodPressureSensor组件端口
            this.BloodPressureSensor.input_ports = new Input_port[1];
            this.BloodPressureSensor.input_ports[0] = new Input_port(this.BloodPressureSensor.ID + "_P1",
                this.BloodPressureSensor.name + "Port", "input", "int[]", this.BloodPressureSensor);
            this.BloodPressureSensor.output_ports = new Output_port[1];
            this.BloodPressureSensor.output_ports[0] = new Output_port(this.BloodPressureSensor.ID + "_P2",
                this.BloodPressureSensor.name + "Port", "output", "int[]", this.BloodPressureSensor);

            //创建MicroProcessor组件
            this.MicroProcessor = new MicroProcessor(null, null, null, null);
            //创建MicroProcessor组件端口
            this.MicroProcessor.input_ports = new Input_port[1];
            this.MicroProcessor.input_ports[0] = new Input_port(this.MicroProcessor.ID + "_P1",
                this.MicroProcessor.name + "Port", "input", "int", this.MicroProcessor);
            this.MicroProcessor.output_ports = new Output_port[1];
            this.MicroProcessor.output_ports[0] = new Output_port(this.MicroProcessor.ID + "_P2",
                this.MicroProcessor.name + "Port", "output", "string", this.MicroProcessor);

            //创建MyBuffer组件
            this.MyBuffer = new MyBuffer(null, null, null, null);
            //创建MyBuffer组件端口
            this.MyBuffer.input_ports = new Input_port[1];
            this.MyBuffer.input_ports[0] = new Input_port(this.MyBuffer.ID + "_P1",
                this.MyBuffer.name + "Port", "input", "string", this.MyBuffer);
            this.MyBuffer.output_ports = new Output_port[1];
            this.MyBuffer.output_ports[0] = new Output_port(this.MyBuffer.ID + "_P2",
                this.MyBuffer.name + "Port", "output", "string", this.MyBuffer);


            //创建WirelessModule组件
            this.WirelessModule = new WirelessModule(null, null, null, null);
            this.WirelessModule.Mac_address = wirelessModule_mac_address; //血压传感节点MAC地址
            
            //创建WirelessModule组件端口
            this.WirelessModule.input_ports = new Input_port[1];
            this.WirelessModule.input_ports[0] = new Input_port(this.WirelessModule.ID + "_P1",
                this.WirelessModule.name + "Port", "input", "string", this.WirelessModule);
            this.WirelessModule.output_ports = new Output_port[1];
            this.WirelessModule.output_ports[0] = new Output_port(this.WirelessModule.ID + "_P2",
                this.WirelessModule.name + "Port", "output", "string", this.WirelessModule);

            //------------------------------------------------------------------------//
            //--------建立内部组件端口到BloodPressureSensorNode组件端口的连线-----------//
            //------------------------------------------------------------------------//

            //1、建立BloodPressureSensorNode组件input端口到BloodPressureSensor组件的连线
            Connection connection1 = new Connection();
            connection1.From = this.input_ports[0].PortConnector1;
            connection1.To = this.BloodPressureSensor.input_ports[0].PortConnector1;
            //修改ConnectionCollection.cs第78行，获取Add方法
            //将连线添加到组件输出端口连接点
            this.input_ports[0].PortConnector1.Connections.Add(connection1);

            //2、建立WirelessModule组件到BloodPressureSensorNode组件output端口的连线
            Connection connection2 = new Connection();
            connection2.From = this.WirelessModule.output_ports[0].PortConnector1;
            connection2.To = this.output_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.WirelessModule.output_ports[0].PortConnector1.Connections.Add(connection2);

            //-----------------------------------------------------------------------------//

            ////3、建立BloodPressureSensor组件output到MicroProcessor组件input端口的连线
            //Connection connection3 = new Connection();
            //connection3.From = this.BloodPressureSensor.output_ports[0].PortConnector1;
            //connection3.To = this.MicroProcessor.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.BloodPressureSensor.output_ports[0].PortConnector1.Connections.Add(connection3);

            ////4、建立MicroProcessor组件output到MyBuffer组件input端口的连线
            //Connection connection4 = new Connection();
            //connection4.From = this.MicroProcessor.output_ports[0].PortConnector1;
            //connection4.To = this.MyBuffer.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.MicroProcessor.output_ports[0].PortConnector1.Connections.Add(connection4);

            ////5、建立MyBuffer组件output到WirelessModule组件input端口的连线
            //Connection connection5 = new Connection();
            //connection5.From = this.MyBuffer.output_ports[0].PortConnector1;
            //connection5.To = this.WirelessModule.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.MyBuffer.output_ports[0].PortConnector1.Connections.Add(connection5);


            this.InsideForm = new InsideForm(this); //构建内部结构显示表单


        }

        /********************************************
         * 函数名称：run()
         * 功能：血压传感节点组件执行函数
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

                //-------------------血压传感器节点input端口传输数据-------------------//
                //若input端口不为空
                if (this.input_ports != null)
                {
                    //foreach(Input_port input in this.input_ports){
                    PortDataTransfer(this.input_ports[0]); //input端口进行数据传输
                    //}
                }

                //--------------------血压传感器组件启动执行---------------------------//
                BloodPressureSensor bps = (BloodPressureSensor)(this.BloodPressureSensor);

                //step1、血压传感器组件接收数据
                bps.ComponentDataReceive(bps);

                //++++++++++++ Debug - 读取组件接收队列中的数据 +++++++++++//
                //Console.Write(bps.name + "组件接收队列内的数据（入队后）:");
                //Console.WriteLine("组件接收队列长度：" + bps.Component_reveice_queue.Count);
                //foreach (int[] arr in bps.Component_reveice_queue)
                //{
                //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                //}
                //Console.WriteLine("");
                //Console.WriteLine("=========================");
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                //step2、执行血压传感器功能，即采样数据,并将采样数据传至发送队列
                bps.CollectBloodPressureData();

                //++++++++++++ Debug - 读取组件发送队列中的数据 +++++++++++//
                //Console.Write(bps.name + "组件发送队列内的数据:");
                //foreach (int[] arr in bps.Component_send_queue)
                //{
                //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                //}
                //Console.WriteLine("");
                //Console.WriteLine("=========================");
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                //step3、血压传感器组件output端口传输数据
                bps.ComponentDataTransfer(bps); //传输采样血压数据

                //--------------------微处理器组件启动执行---------------------------//
                MicroProcessor mp = (MicroProcessor)this.microProcessor;
                //step1、微处理器组件接收数据
                mp.ComponentDataReceive(mp);

                //++++++++++++ Debug - 读取组件发送队列中的数据 +++++++++++//
                //Console.Write(mp.name + "组件接收队列内的数据:");
                //foreach (int[] arr in mp.Component_send_queue)
                //{
                //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                //}
                //Console.WriteLine("");
                //Console.WriteLine("=========================");
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                //step2、执行微处理器功能
                mp.MessageEncapsulation(x);

                //step3、微处理器组件output端口传输数据
                mp.ComponentDataTransfer(mp);


                //--------------------缓冲区组件启动执行---------------------------//
                MyBuffer buf = (MyBuffer)this.myBuffer;
                //step1、缓冲区组件接收数据
                buf.ComponentDataReceive(buf);
                //step2、执行缓冲区功能
                buf.MessageBuffering(y);
                //step3、缓冲区组件output端口传输数据
                buf.ComponentDataTransfer(buf);

                //------------------------无线模块--------------------------------//
                WirelessModule wm = (WirelessModule)this.wirelessModule;
                //step1、无线模块组件接收数据
                wm.ComponentDataReceive(wm);
                //step2、执行无线模块数据帧封装功能
                wm.FrameEncapsulation(y,dest_address);
                //step3、无线模块组件output端口传输数据
                wm.ComponentDataTransfer(wm);

                //-------------------血压传感器节点output端口传输数据-------------------//
                //若output端口不为空
                if (this.output_ports != null)
                {
                    foreach(Output_port output in this.output_ports){
                        PortDataTransfer(output); //output端口进行数据传输
                    }
                }

                //Thread.Sleep(delay);
            }

        }// public void run()

    }// public class Patient : Component
}
