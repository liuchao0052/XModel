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
    //802.15.4信道组件
    public class Channel802_15_4: Component
    {
        private int Delay; //时延
        private double PacketLossRate = 0.01; //丢包率
        private int Range; //范围
        private int PropagationSpeed; //传播速度

        //bool isTransfer;  //判断是否传输数据帧
     
        public Channel802_15_4(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WirelessMedia.png");

            this.bmp = Resource1.WirelessMedia;
            this.Text = "802.15.4Channel";
            this.Rectangle = new RectangleF(50, 250, 74, 32); //设置组件位置及大小
            this.name = "802.15.4Channel";
        }

        /********************************************
         * 函数名称：run()
         * 功能：802.15.4Channel组件执行函数
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
                //2、执行802.15.4Channel组件功能
                FrameTransfer();
                //3、发送802.15.4Channel组件处理后的数据
                ComponentDataTransfer(this);
            }
        }

        /******************************************
         *  函数名称：FrameTransfer()
         *  功能：802.15.4数据帧网络传输
         *  参数：无
         *  返回值：无
         * ****************************************/
        public void FrameTransfer()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    data = this.Component_reveice_queue.Dequeue();

       
                    if (data.GetType().Name != "Frame_802_15_4") //若不是802.15.4数据帧
                    {
                        return; //返回，丢弃该数据帧
                    }

                    Random rand = new Random();
                    Delay = rand.Next(10, 500); //产生随机时延0.01s-0.5s
                    Thread.Sleep(Delay);

                    if(Math.Round(rand.NextDouble(), 3) > PacketLossRate)
                        this.Component_send_queue.Enqueue(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Channel802.15.4 Error:"+e.Message+" "+e.StackTrace);
            }
        }



    }
}
