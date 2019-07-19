using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Threading;

namespace XModel.BasicLibrary
{
    //以太网信道组件
    public class ChannelEthernet : Component
    {
        private int Delay; //时延
        private double PacketLossRate = 0.001; //丢包率
        private int Range; //范围
        private int PropagationSpeed; //传播速度

        public ChannelEthernet(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WiredMedia.png");
            this.bmp = Resource1.WiredMedia;
            this.Text = "Ethernet Channel";
            this.Rectangle = new RectangleF(150, 150, 74, 25); //设置组件位置及大小
            this.name = "Ethernet Channel";
        }

        /********************************************
         * 函数名称：run()
         * 功能：Ethernet Channel组件执行函数
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
                //1、接收输入端口数据
                ComponentDataReceive(this);
                //2、执行Ethernet Channel组件功能
                EthernetFrameTransfer();
                //3、发送Ethernet Channel组件处理后的数据
                ComponentDataTransfer(this);
            }
        }

        /******************************************
         *  函数名称：EthernetFrameTransfer()
         *  功能：以太网数据帧传输
         *  参数：无
         *  返回值：无
         * ****************************************/
        public void EthernetFrameTransfer()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    data = this.Component_reveice_queue.Dequeue();

                    if (data.GetType().Name != "Frame_Ethernet") //若不是以太网数据帧
                    {
                        return; //返回，丢弃该数据帧
                    }

                    Random rand = new Random();
                    Delay = rand.Next(10, 100); //产生随机时延0.01s-0.1s
                    Thread.Sleep(Delay);

                    if (Math.Round(rand.NextDouble(), 4) > PacketLossRate)
                        this.Component_send_queue.Enqueue(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Channel Ethernet Error:" + e.Message + " " + e.StackTrace);
            }
        }


    }
}
