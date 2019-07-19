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

namespace XModel.BasicLibrary
{
    //体温组件
    public class Temperature : Component
    {
        private TemperatureDataType temperatureData; //体温数据
        int delay = 100;  //时延

        Byte temperatureValue = 36; //体温值


        public TemperatureDataType TemperatureData
        {
            get { return temperatureData; }
            set { temperatureData = value; }
        }
        //private Queue<double> TempDataQueue = new Queue<double>(1000); //体温数据队列


        public Temperature(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\Temperature.png");

            this.bmp = Resource1.Temperature;
            this.Text = "Temperature";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "Temperature";
        }

        /********************************************
        *  函数名称：run()
        *  功能：体温组件执行函数
        *  参数：x 表示体温数据获取方式的选择
        *  返回值：无
        * ******************************************/
        public void run(object x)
        {
            while (true)
            {
                if (Form1.stop)
                {
                    this.EmptyingQueue();
                    return;
                }
                if ((int)x == 1) //x=1,基于函数模拟生成体温数据
                {
                    GeneratingTemperatureData();
                   
                    ComponentDataTransfer(this);

                    //TempDataQueue.Enqueue(temperatureData); //体温数据入队 

                    ////------若组件的output端口不为空,且输出端口存在连接线------------------------//
                    ////------则1) 组件生成数据传输至output端口------------------------------------//
                    ////------则2) 组件output端口继续将数据传输至相连接的另一组件input/inout端口---//

                    //if (this.output_ports != null)
                    //{
                    //    foreach (Output_port output_port in this.output_ports) //遍历所有输出端口
                    //    {
                    //        //Console.WriteLine((output_port.PortConnector1.Connections==null)?true:false);

                    //        //若输出端口连接点存在连接线
                    //        if (output_port.PortConnector1.Connections.Count != 0)
                    //        {
                    //            //体温数据队列中数据出列，进入其相应的端口队列
                    //            double temp = TempDataQueue.Dequeue();

                    //            output_port.Port_queue1.Enqueue(temp);

                    //            //++++++++++++ Debug - 读取output端口队列中的数据 +++++++++++//
                    //            //Console.Write("output端口队列数据:");
                    //            //foreach (int[] arr in output_port.Port_queue1)
                    //            //{
                    //            //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                    //            //}
                    //            //Console.WriteLine("");
                    //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                    //            //遍历该output端口所有连接线
                    //            foreach (Connection connection in output_port.PortConnector1.Connections)
                    //            {
                    //                //记录连接线起点
                    //                Connector start_connector = connection.From;
                    //                //记录连接线终点
                    //                Connector end_connector = connection.To;

                    //                //获取连接线起点所附属的端口
                    //                Port start_port = (Port)start_connector.BelongsTo;
                    //                //获取连接线终点所附属的端口
                    //                Port end_port = (Port)end_connector.BelongsTo;
                    //                //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);

                    //                //output端口继续将数据传输至相连接的另一组件input/output端口
                    //                double temp2 = (double)start_port.Port_queue1.Dequeue();
                    //                end_port.Port_queue1.Enqueue(temp2);

                    //                //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                    //                //Console.Write("input/inout端口队列数据:");
                    //                //foreach (int[] arr in end_port.Port_queue1)
                    //                //{
                    //                //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                    //                //}
                    //                //Console.WriteLine("");
                    //                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                    //            }//foreach (Connection connection in output_port.PortConnector1.Connections)                         

                    //        } //if (output_port.PortConnector1.Connections != null)
                    //    } //foreach (Output_port output_port in output_ports)                 
                    //}//if(this.output_ports != null)

                    ////------若组件的inout端口不为空,且inout端口存在连接线--------------------------//
                    ////------则1) 组件生成数据传输至inout端口---------------------------------------//
                    ////------则2) 组件inout端口继续将数据传输至相连接的另一组件input/inout端口------//

                    //if (this.inout_ports != null) //若组件的输入输出端口不为空
                    //{
                    //    foreach (Inout_port inout_port in this.inout_ports) //遍历所有输入输出端口
                    //    {
                    //        //若输入输出端口连接点存在连接线
                    //        if (inout_port.PortConnector1.Connections.Count != 0)
                    //        {
                    //            //血压数据队列中数据出列，进入其相应的端口队列
                    //            double temp = TempDataQueue.Dequeue();
                                                            
                    //            inout_port.Port_queue1.Enqueue(temp);

                    //            //++++++++++++ Debug - 读取inout端口队列中的数据 +++++++++++//
                    //            //Console.Write("inout端口队列数据:");
                    //            //foreach (int[] arr in inout_port.Port_queue1)
                    //            //{
                    //            //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                    //            //}
                    //            //Console.WriteLine("");
                    //            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                    //            //遍历该inout端口所有连接线
                    //            foreach (Connection connection in inout_port.PortConnector1.Connections)
                    //            {
                    //                //记录连接线起点
                    //                Connector start_connector = connection.From;
                    //                //记录连接线终点
                    //                Connector end_connector = connection.To;

                    //                //获取连接线起点所附属的端口
                    //                Port start_port = (Port)start_connector.BelongsTo;
                    //                //获取连接线终点所附属的端口
                    //                Port end_port = (Port)end_connector.BelongsTo;
                    //                //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);

                    //                //output端口继续将数据传输至相连接的另一组件input/output端口
                    //                double temp2 = (double)start_port.Port_queue1.Dequeue();
                    //                end_port.Port_queue1.Enqueue(temp2);

                    //                //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                    //                //Console.Write("input/inout端口队列数据:");
                    //                //foreach (int[] arr in end_port.Port_queue1)
                    //                //{
                    //                //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                    //                //}
                    //                //Console.WriteLine("");
                    //                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                    //            }//foreach (Connection connection in output_port.PortConnector1.Connections)

                    //        } //if (inout_port.PortConnector1.Connections.Count != 0)
                    //    } //foreach (Inout_port inout_port in this.inout_ports)               
                    //}//if (this.inout_ports != null)

                }//if ((int)x == 1)

                if ((int)x == 2) //x=2,基于串口通信获取采集的体温数据
                {
                    CollectTemperatureData();
                   
                }
                if ((int)x == 3) //x=3,基于MIT-BIH的数据集获取体温数据
                {
                    Get_MIT_BIH_TemperatureData();
                    this.Component_send_queue.Enqueue(temperatureData); 
                }
            }// while (true)
        }// public void run(object x)

        /********************************************
        *  函数名称：GeneratingTemperatureData()
        *  功能：基于函数模拟生成体温数据
        *  参数：无
        *  返回值：无
        * ******************************************/
        public void GeneratingTemperatureData()
        {

            temperatureData = new TemperatureDataType();


            //Byte[] bytes = new Byte[5];
            //for (int i = 0; i < 5; i++)
            //{
            //    bytes[i] = (Byte)(35 + i);
            //}

            temperatureData.TemperatureInteger = temperatureValue;

            Random rand = new Random();
            //temperatureData.Temperature = Math.Round((rand.NextDouble() * (max_temp - min_temp) + min_temp), 1);
         
            if (rand.Next() % 2 == 0 && rand.Next() % 3 == 0)
            {
                temperatureData.TemperatureInteger = (Byte)(temperatureValue + (Byte)rand.Next(-1, 1));
            }                

            temperatureData.TemperatureDecimal = (Byte)rand.Next(1, 9);

            this.Component_send_queue.Enqueue(temperatureData);//体温数据进入组件发送队列
            Thread.Sleep(delay);
        }

        /********************************************
         *  函数名称：CollectTemperatureData()
         *  功能：基于串口通信获取采集的体温数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void CollectTemperatureData()
        {
            //后续扩展...
          
        }

        /********************************************
         *  函数名称：Get_MIT_BIH_BloodTemperatureeData()
         *  功能：基于MIT-BIH的数据集获取体温数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void Get_MIT_BIH_TemperatureData()
        {
            //后续扩展...
          
        }
    }//public class Temperature : Component
}
