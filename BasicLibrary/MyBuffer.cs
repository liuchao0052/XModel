using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{    
    //缓冲区组件
    public class MyBuffer : Component
    {
        public Queue<Object> Buffer_queue;          //缓冲队列
        public int total_app_data_byte_num = 0;     //应用层数据总字节数

        public MyBuffer(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\Buffer.png");

            this.bmp = Resource1.Buffer;
            this.Text = "Buffer";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "Buffer";
            this.Buffer_queue = new Queue<object>(2000);
        }

        /******************************************************************************
         *  函数名称：MessageBuffering()
         *  功能：报文缓冲
         *  参数：frameFormat 表示帧格式
         *  返回值：无
         * ***************************************************************************/
        public void MessageBuffering(string frameFormat)
        {
            //int uncompressed_field_byte_num = 0; //非压缩字段字节数            
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取缓冲区组件接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    if (data.GetType().Name == "PDU_LoWPAN_IPHC") //若为6LoWPAN报文数据
                    {
                        LoWPAN_Packet_Buffering(data);
                    }

                    else if (data.GetType().Name == "PDU_ConnID") //若为ConnID报文数据
                    {

                        switch (frameFormat)
                        {
                            case "frame802154":
                                ConnID_802154_Packet_Buffering(data);
                                break;
                            case "frame802151":
                                ConnID_802151_Packet_Buffering(data);
                                break;

                        }                       
                    }

                    else if (data.GetType().Name == "PDU_Network") //若为IPv6报文数据
                    {
                        IPv6_Packet_Buffering(data);
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("MyBuffer错误情况："+e.Message);
            }
        }


       /******************************************************************************
        *  函数名称：IPv6_Packet_Buffering()
        *  功能：执行IPv6报文缓冲
        *  参数：data表示所收到的IPv6报文
        *  返回值：无
        * ***************************************************************************/
        private void IPv6_Packet_Buffering(object data)
        {
            PDU_Network pdu_ipv6 = (PDU_Network)data;

            //IPv6报文进入缓冲队列
            this.Buffer_queue.Enqueue(pdu_ipv6);
            //缓冲队列数据出队
            PDU_Network IPv6_Packet = (PDU_Network)this.Buffer_queue.Dequeue();

            //IPv6报文进入组件发送队列
            this.Component_send_queue.Enqueue(IPv6_Packet);
        }


       /******************************************************************************
        *  函数名称：LoWPAN_Packet_Buffering()
        *  功能：执行6LoWPAN报文缓冲
        *  参数：data表示所收到的6LoWPAN报文
        *  返回值：无
        * ***************************************************************************/
        private void LoWPAN_Packet_Buffering(Object data)
        {
            PDU_LoWPAN_IPHC pdu_lowpan_iphc = (PDU_LoWPAN_IPHC)data;
            //foreach (Byte[] B in pdu_lowpan_iphc.uncompressed_field)
            //{
            //    foreach (Byte b in B)
            //    {
            //        uncompressed_field_byte_num++;
            //    }
            //}
            //Console.WriteLine("非压缩字段字节数=" + uncompressed_field_byte_num);

            int app_data_byte_num = 0; //应用层数据字节数
            //记录当前数据报应用层数据量
            foreach (Byte[] B in pdu_lowpan_iphc.application_data)
            {
                foreach (Byte b in B)
                {
                    app_data_byte_num++;
                }
            }
            //Console.WriteLine("应用层数据字节数=" + app_data_byte_num);

            //当应用层总数据量+当前数据报应用层数据量<81字节时
            if (total_app_data_byte_num + app_data_byte_num < 81)
            {
                total_app_data_byte_num += app_data_byte_num;

                //Console.WriteLine("应用层数据总量=" + total_app_data_byte_num);

                //当前报文应用层数据进入6LoWPAN数据缓冲队列
                this.Buffer_queue.Enqueue(pdu_lowpan_iphc.application_data);
            }

            else //当应用层数据总量达到81字节时
            {
                List<Byte[]> app_data = new List<byte[]>();

                while (this.Buffer_queue.Count > 0)
                {
                    //缓冲队列内数据全部出队
                    foreach (Byte[] B in (List<Byte[]>)this.Buffer_queue.Dequeue())
                    {
                        app_data.Add(B);
                    }
                }

                //将应用层数据重新封装成6LoWPAN数据包
                PDU_LoWPAN_IPHC pdu_lowpan_iphc2 = new PDU_LoWPAN_IPHC(pdu_lowpan_iphc.dispatch,
                    pdu_lowpan_iphc.iphc_header, pdu_lowpan_iphc.context_identifier, pdu_lowpan_iphc.IP_uncompressed_field,
                    pdu_lowpan_iphc.nhc_header, pdu_lowpan_iphc.NH_field, app_data);

                //重新封装的数据包进入缓冲区组件发送队列
                this.Component_send_queue.Enqueue(pdu_lowpan_iphc2);


                //当前报文应用层数据进入缓冲区队列
                this.Buffer_queue.Enqueue(pdu_lowpan_iphc.application_data);
                app_data_byte_num = 0;
                //统计当前数据报应用层数据量
                foreach (Byte[] B in pdu_lowpan_iphc.application_data)
                {
                    foreach (Byte b in B)
                    {
                        app_data_byte_num++;
                    }
                }
                total_app_data_byte_num = app_data_byte_num; //重新设定应用层数据总量

                //pdu_lowpan_iphc.application_data = app_data;
            }
        }

        /******************************************************************************
        *  函数名称：ConnID_802154_Packet_Buffering()
        *  功能：执行ConnID报文缓冲,帧格式为802.15.4
        *  参数：data表示所收到的ConnID报文
        *  返回值：无
        * ***************************************************************************/
        private void ConnID_802154_Packet_Buffering(Object data)
        {
            PDU_ConnID pdu_connid = (PDU_ConnID)data;
            //foreach (Byte[] B in pdu_lowpan_iphc.uncompressed_field)
            //{
            //    foreach (Byte b in B)
            //    {
            //        uncompressed_field_byte_num++;
            //    }
            //}
            //Console.WriteLine("非压缩字段字节数=" + uncompressed_field_byte_num);

            int app_data_byte_num = 0; //应用层数据字节数
            //记录当前数据报应用层数据量
            foreach (Byte[] B in pdu_connid.application_data)
            {
                foreach (Byte b in B)
                {
                    app_data_byte_num++;
                }
            }
            //Console.WriteLine("应用层数据字节数=" + app_data_byte_num);

            //当应用层总数据量+当前数据报应用层数据量 <= 95 字节时
            if (total_app_data_byte_num + app_data_byte_num <= 95)
            {
                total_app_data_byte_num += app_data_byte_num;

                //Console.WriteLine("应用层数据总量=" + total_app_data_byte_num);

                //当前报文应用层数据进入数据缓冲队列
                this.Buffer_queue.Enqueue(pdu_connid.application_data);
            }

            else //当应用层数据总量达到95字节时
            {
                List<Byte[]> app_data = new List<byte[]>();

                while (this.Buffer_queue.Count > 0)
                {
                    //缓冲队列内数据全部出队
                    foreach (Byte[] B in (List<Byte[]>)this.Buffer_queue.Dequeue())
                    {
                        app_data.Add(B);
                    }
                }

                //将应用层数据重新封装成ConnID数据包
                PDU_ConnID pdu_connid2 = new PDU_ConnID(pdu_connid.message_identifier,
                   pdu_connid.connid, app_data);

                //重新封装的数据包进入缓冲区组件发送队列
                this.Component_send_queue.Enqueue(pdu_connid2);


                //当前报文应用层数据进入缓冲区队列
                this.Buffer_queue.Enqueue(pdu_connid.application_data);
                app_data_byte_num = 0;
                //统计当前数据报应用层数据量
                foreach (Byte[] B in pdu_connid.application_data)
                {
                    foreach (Byte b in B)
                    {
                        app_data_byte_num++;
                    }
                }
                total_app_data_byte_num = app_data_byte_num; //重新设定应用层数据总量

                //pdu_lowpan_iphc.application_data = app_data;
            }
        }

       /******************************************************************************
        *  函数名称：ConnID_802151_Packet_Buffering()
        *  功能：执行ConnID报文缓冲,帧格式为802.15.1
        *  参数：data表示所收到的ConnID报文
        *  返回值：无
        * ***************************************************************************/
        private void ConnID_802151_Packet_Buffering(Object data)
        {
            PDU_ConnID pdu_connid = (PDU_ConnID)data;
            //foreach (Byte[] B in pdu_lowpan_iphc.uncompressed_field)
            //{
            //    foreach (Byte b in B)
            //    {
            //        uncompressed_field_byte_num++;
            //    }
            //}
            //Console.WriteLine("非压缩字段字节数=" + uncompressed_field_byte_num);

            int app_data_byte_num = 0; //应用层数据字节数
            //记录当前数据报应用层数据量
            foreach (Byte[] B in pdu_connid.application_data)
            {
                foreach (Byte b in B)
                {
                    app_data_byte_num++;
                }
            }
            //Console.WriteLine("应用层数据字节数=" + app_data_byte_num);

            //当应用层总数据量+当前数据报应用层数据量 <= 22 字节时
            if (total_app_data_byte_num + app_data_byte_num <= 22)
            {
                total_app_data_byte_num += app_data_byte_num;

                //Console.WriteLine("应用层数据总量=" + total_app_data_byte_num);

                //当前报文应用层数据进入N数据缓冲队列
                this.Buffer_queue.Enqueue(pdu_connid.application_data);
            }

            else //当应用层数据总量达到22字节时
            {
                List<Byte[]> app_data = new List<byte[]>();

                while (this.Buffer_queue.Count > 0)
                {
                    //缓冲队列内数据全部出队
                    foreach (Byte[] B in (List<Byte[]>)this.Buffer_queue.Dequeue())
                    {
                        app_data.Add(B);
                    }
                }

                //将应用层数据重新封装成ConnID数据包
                PDU_ConnID pdu_connid2 = new PDU_ConnID(pdu_connid.message_identifier,
                   pdu_connid.connid, app_data);

                //重新封装的数据包进入缓冲区组件发送队列
                this.Component_send_queue.Enqueue(pdu_connid2);


                //当前报文应用层数据进入缓冲区队列
                this.Buffer_queue.Enqueue(pdu_connid.application_data);
                app_data_byte_num = 0;
                //统计当前数据报应用层数据量
                foreach (Byte[] B in pdu_connid.application_data)
                {
                    foreach (Byte b in B)
                    {
                        app_data_byte_num++;
                    }
                }
                total_app_data_byte_num = app_data_byte_num; //重新设定应用层数据总量

                //pdu_lowpan_iphc.application_data = app_data;
            }
        }



    }
}
