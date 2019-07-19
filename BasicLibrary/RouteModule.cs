using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //路由模块组件
    public class RouteModule : Component
    {
        public RouteModule(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\RouteModule.png");

            this.bmp = Resource1.RouteModule;
            this.Text = "RouteModule";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "RouteModule";
        }

        /******************************************************************************
        *  函数名称：Routing
        *  功能：路由选择
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void Routing()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取缓冲区组件接收队列数据
                    data = this.Component_reveice_queue.Dequeue();
                    PDU_Network ipv6_packet = (PDU_Network)data;

                    //foreach (UInt16 I in ipv6_packet.dest_ipv6_address)
                    //    Console.WriteLine(string.Format("{0:X4}",I));

                    //目的IPv6地址 2001:da8:d818:0082::1234
                    UInt16[] dest_ipv6_address = { 0x0120, 0xa80d, 0x18d8, 0x8200,
                                                     0x0000, 0x0000, 0x0000, 0x3412}; 

                    bool isEqual = true;
                    for (Int16 i = 0; i < 8; i++)
                    {
                        if (ipv6_packet.dest_ipv6_address[i] != dest_ipv6_address[i])
                            isEqual = false;
                    }
                    if (isEqual)               
                    {
                        //进入组件发送队列
                        this.Component_send_queue.Enqueue(ipv6_packet);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("路由选择错误情况：" + e.Message);
            }
        }
    }
}
