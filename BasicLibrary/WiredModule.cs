using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //有线模块组件
    public class WiredModule : Component
    {
        private UInt64 mac_address; //有线模块的MAC地址
        
        public UInt64 Mac_address
        {
            get { return mac_address; }
            set { mac_address = value; }
        }

        public WiredModule(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WiredModule.png");

            this.bmp = Resource1.WiredModule;
            this.Text = "WiredModule";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "WiredModule";
        }

       /******************************************************************************
        *  函数名称：EthernetFrameEncapsulation()
        *  功能：以太网数据帧封装
        *  参数：dest_addr表示目标地址
        *  返回值：无
        * ***************************************************************************/
        public void EthernetFrameEncapsulation(UInt64 dest_addr)
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取有线模块接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    //构建以太网帧
                    Frame_Ethernet frame_ethernet = new Frame_Ethernet();
                    frame_ethernet.dest_mac_addr = dest_addr;
                    frame_ethernet.source_mac_addr = mac_address;
                    frame_ethernet.type = 0x86DD;   //以太网帧类型0x86DD表示上层采用IPv6

                    frame_ethernet.pdu_network = (PDU_Network)data;

                    //以太网帧进入组件发送队列
                    this.Component_send_queue.Enqueue(frame_ethernet);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("以太网帧封装错误情况："+e.Message+" "+e.StackTrace);
            }
        }

       /******************************************************************************
        *  函数名称：EthernetFrameDecapsulation()
        *  功能：以太网数据帧解封装
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void EthernetFrameDecapsulation()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取有线模块接收队列数据
                    data = this.Component_reveice_queue.Dequeue();
                    Frame_Ethernet frame = (Frame_Ethernet)data;

                    //检查目的地址是否为本模块地址
                    if (frame.dest_mac_addr != mac_address) //若不是
                    {
                        return; //返回，丢弃该数据帧
                    }

                    //上层协议判断方式：依据帧类型字段判断
                    if (frame.type == 0x86DD)  //类型字段86DDH，表示IPv6报文
                    {
                        //解封装，获取IPv6 PDU,并进入有线模块组件发送队列
                        this.Component_send_queue.Enqueue(frame.pdu_network);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("以太网数据帧解封装错误情况：" + e.Message + " " + e.StackTrace);
            }
        }


    
    }
}
