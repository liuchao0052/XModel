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
    //IPv6路由器组件
    public class IPv6Router : Component
    {
        //Component wiredModule1;   //有线模块1组件
        //Component wiredModule2;   //有线模块2组件    

        WiredModule wiredModule1;   //有线模块1组件
        WiredModule wiredModule2;   //有线模块2组件     
        Component myBuffer1;        //缓冲区1组件
        Component myBuffer2;        //缓冲区2组件     
        Component routeModule;      //路由模块组件

        private UInt64 wiredModule1_mac_address = 0xF001FEABF001; //有线模块1MAC地址 48bits
        private UInt64 wiredModule2_mac_address = 0xF002FEABF002; //有线模块2MAC地址 48bits

        private UInt64 dest_address = 0xFF01FEABFF01; //目标地址，服务器MAC地址 48bits

        public WiredModule WiredModule1
        {
            get { return wiredModule1; }
            set { wiredModule1 = value; }
        }
        public WiredModule WiredModule2
        {
            get { return wiredModule2; }
            set { wiredModule2 = value; }
        }

        //public Component WiredModule1
        //{
        //    get { return wiredModule1; }
        //    set { wiredModule1 = value; }
        //}
        //public Component WiredModule2
        //{
        //    get { return wiredModule2; }
        //    set { wiredModule2 = value; }
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
        public Component RouteModule
        {
            get { return routeModule; }
            set { routeModule = value; }
        }

        public IPv6Router(GraphControl graphControl)
            : base(graphControl)
        {
            this.IsCompositeComponnet = true; //IPv6Router为复合组件
            //this.bmp = new Bitmap(@"..\..\..\picture\IPv6Router.png");

            this.bmp = Resource1.IPv6Router;
            this.Text = "IPv6Router";
            this.Rectangle = new RectangleF(400, 200, 84, 55); //设置组件位置及大小
            this.name = "IPv6Router";

            //创建IPv6Router组件端口并显示
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

            //创建有线模块1组件
            this.wiredModule1 = new WiredModule(null, null, null, null);
            this.wiredModule1.Mac_address = wiredModule1_mac_address;

            //创建有线模块1组件端口
            this.wiredModule1.input_ports = new Input_port[1];
            this.wiredModule1.input_ports[0] = new Input_port(this.wiredModule1.ID + "_P1",
                this.wiredModule1.name + "Port", "input", "string", this.wiredModule1);
            this.wiredModule1.output_ports = new Output_port[1];
            this.wiredModule1.output_ports[0] = new Output_port(this.wiredModule1.ID + "_P2",
                this.wiredModule1.name + "Port", "output", "string", this.wiredModule1);

            //创建有线模块2组件
            this.wiredModule2 = new WiredModule(null, null, null, null);
            this.wiredModule2.Mac_address = wiredModule2_mac_address;

            //创建有线模块2组件端口
            this.wiredModule2.input_ports = new Input_port[1];
            this.wiredModule2.input_ports[0] = new Input_port(this.wiredModule2.ID + "_P1",
                this.wiredModule2.name + "Port", "input", "string", this.wiredModule2);
            this.wiredModule2.output_ports = new Output_port[1];
            this.wiredModule2.output_ports[0] = new Output_port(this.wiredModule2.ID + "_P2",
                this.wiredModule2.name + "Port", "output", "string", this.wiredModule2);

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

            //创建路由模块组件
            this.routeModule = new RouteModule(null, null, null, null);
            //创建路由模块组件端口
            this.routeModule.input_ports = new Input_port[1];
            this.routeModule.input_ports[0] = new Input_port(this.routeModule.ID + "_P1",
                this.routeModule.name + "Port", "input", "string", this.routeModule);
            this.routeModule.output_ports = new Output_port[1];
            this.routeModule.output_ports[0] = new Output_port(this.routeModule.ID + "_P2",
                this.routeModule.name + "Port", "output", "string", this.routeModule);

            //-------------------------------------------------------------//
            //--------建立内部组件端口到IPv6Router组件端口的连线-----------//
            //-------------------------------------------------------------//

            //1、建立IPv6Router组件input端口到WiredModule1组件input端口的连线
            Connection connection1 = new Connection();
            connection1.From = this.input_ports[0].PortConnector1;
            connection1.To = this.wiredModule1.input_ports[0].PortConnector1;
            //修改ConnectionCollection.cs第78行，获取Add方法
            //将连线添加到组件输出端口连接点
            this.input_ports[0].PortConnector1.Connections.Add(connection1);

            //6、建立WiredModule2组件output端口到IPv6Router组件output端口的连线
            Connection connection6 = new Connection();
            connection6.From = this.wiredModule2.output_ports[0].PortConnector1;
            connection6.To = this.output_ports[0].PortConnector1;
            //将连线添加到组件输出端口连接点
            this.wiredModule2.output_ports[0].PortConnector1.Connections.Add(connection6);

            //-------------------------------------------------------------------------//

            ////2、建立WiredModule1组件output端口到MyBuffer1组件input端口的连线
            //Connection connection2 = new Connection();
            //connection2.From = this.wiredModule1.output_ports[0].PortConnector1;
            //connection2.To = this.myBuffer1.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.wiredModule1.output_ports[0].PortConnector1.Connections.Add(connection2);

            ////3、建立MyBuffer1组件output端口到RouteModule组件input端口的连线
            //Connection connection3 = new Connection();
            //connection3.From = this.myBuffer1.output_ports[0].PortConnector1;
            //connection3.To = this.routeModule.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer1.output_ports[0].PortConnector1.Connections.Add(connection3);

            ////4、建立RouteModule组件output端口到MyBuffer2组件input端口的连线
            //Connection connection4 = new Connection();
            //connection4.From = this.routeModule.output_ports[0].PortConnector1;
            //connection4.To = this.myBuffer2.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.routeModule.output_ports[0].PortConnector1.Connections.Add(connection4);

            ////5、建立MyBuffer2组件output端口到WiredModule2组件input端口的连线
            //Connection connection5 = new Connection();
            //connection5.From = this.myBuffer2.output_ports[0].PortConnector1;
            //connection5.To = this.wiredModule2.input_ports[0].PortConnector1;
            ////将连线添加到组件输出端口连接点
            //this.myBuffer2.output_ports[0].PortConnector1.Connections.Add(connection5);

            this.InsideForm = new InsideForm(this); //构建内部结构显示表单     

        }

        /********************************************
         * 函数名称：run()
         * 功能：IPv6路由器组件执行函数
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

                //-------------------IPv6路由器input端口传输数据----------------//
                //若input端口不为空
                if (this.input_ports != null)
                {
                    foreach (Input_port input in this.input_ports)
                    {
                        PortDataTransfer(input); //input端口进行数据传输
                    }
                }

                //-------------------有线模块1组件启动执行-------------------//
                WiredModule wiredM1 = (WiredModule)this.wiredModule1;
                //step1、有线模块1组件接收数据
                wiredM1.ComponentDataReceive(wiredM1);
                //step2、执行有线模块1数据帧解封装功能
                wiredM1.EthernetFrameDecapsulation();
                //step3、有线模块1组件output端口传输数据
                wiredM1.ComponentDataTransfer(wiredM1);

                //-------------------缓冲区1组件启动执行-------------------//
                MyBuffer buf1 = (MyBuffer)this.myBuffer1;
                //step1、缓冲区1组件接收数据
                buf1.ComponentDataReceive(buf1);
                //step2、执行缓冲区功能
                buf1.MessageBuffering(null);
                //step3、缓冲区1组件output端口传输数据
                buf1.ComponentDataTransfer(buf1);

                //-------------------路由模块组件启动执行-------------------//
                RouteModule rm = (RouteModule)this.routeModule;
                //step1、路由模块组件接收数据
                rm.ComponentDataReceive(rm);
                //step2、执行路由模块功能
                rm.Routing();
                //step3、路由模块组件output端口传输数据
                rm.ComponentDataTransfer(rm);

                //-------------------缓冲区2组件启动执行-------------------//
                MyBuffer buf2 = (MyBuffer)this.myBuffer2;
                //step1、缓冲区2组件接收数据
                buf2.ComponentDataReceive(buf2);
                //step2、执行缓冲区功能
                buf2.MessageBuffering(null);
                //step3、缓冲区2组件output端口传输数据
                buf2.ComponentDataTransfer(buf2);

                //-------------------有线模块2组件启动执行-------------------//
                WiredModule wiredM2 = (WiredModule)this.wiredModule2;
                //step1、有线模块2组件接收数据
                wiredM2.ComponentDataReceive(wiredM2);
                //step2、执行有线模块2数据帧封装功能
                wiredM2.EthernetFrameEncapsulation(dest_address);
                //step3、有线模块2组件output端口传输数据
                wiredM2.ComponentDataTransfer(wiredM2);


                //----------------IPv6路由器output端口传输数据--------------//
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

    }// public class Patient : Component
}
