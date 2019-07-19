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
    //无线模块组件
    public class WirelessModule : Component
    {
        private UInt64 mac_address; //无线模块的MAC地址
        private Byte i = 0; //序列号值

        private UInt32 access_address; //接入地址

        public UInt32 Access_address
        {
            get { return access_address; }
            set { access_address = value; }
        }

        public UInt64 Mac_address
        {
            get { return mac_address; }
            set { mac_address = value; }
        }
        public WirelessModule()
        {

        }

        public WirelessModule(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WirelessModule.png");

            this.bmp = Resource1.WirelessModule;
            this.Text = "WirelessModule";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "WirelessModule";
     
        }

        /******************************************************************************
         *  函数名称：FrameEncapsulation()
         *  功能：数据帧封装
         *  参数：x表示数据帧封装格式 
         *        x="frame802154":封装为802.15.4数据帧；
         *        x="frame805151":封装为802.15.1数据帧；
         *        x="frame80211":封装为802.11数据帧
         *        dest_addr表示目标地址
         *  返回值：无
         * ***************************************************************************/
        public void FrameEncapsulation(string x,UInt64 dest_addr)
        {
            Byte temp = 0;
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取无线模块接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    if (data.GetType().Name == "PDU_LoWPAN_IPHC") //若为6LoWPAN报文数据
                    {
                        //添加802.15.4帧首部 
                        Frame_802_15_4 frame_802_15_4 = new Frame_802_15_4();
                        frame_802_15_4.frame_control = 0x2033;           //帧控制位 0010 0000 0011 0011
                        if (i < 255)
                            temp = i++;
                        else
                        {
                            i = 0;
                            temp = 0;
                        }                            
                        frame_802_15_4.sequence_number = temp;         //序列号
                        frame_802_15_4.dest_panid = 0x2019;            //目标PANID 0010 0000 0001 1001
                        //frame_802_15_4.dest_addr = 0x10010585FEAB1001;//目标地址
                        frame_802_15_4.dest_addr = dest_addr;          //目标地址
                        frame_802_15_4.source_panid = 0x2019;          //源PANID 
                        //frame_802_15_4.source_addr = 0x10010585FEAB5001;//源地址
                        frame_802_15_4.source_addr = mac_address;      //源地址
                        //添加6LoWPAN PDU
                        frame_802_15_4.pdu_lowpan_iphc = new PDU_LoWPAN_IPHC();
                        frame_802_15_4.pdu_lowpan_iphc = (PDU_LoWPAN_IPHC)data; //6LoWPAN PDU
                        
                        //802.15.4帧进入组件发送队列
                        this.Component_send_queue.Enqueue(frame_802_15_4);

                    }
                    else if (data.GetType().Name == "PDU_ConnID")
                    {
                        switch (x)
                        {
                            case "frame802154": //添加802.15.4帧首部
                                Frame_802_15_4 frame_802_15_4 = new Frame_802_15_4();
                                frame_802_15_4.frame_control = 0x2033;           //帧控制位 0010 0000 0011 0011
                                if (i < 255)
                                    temp = i++;
                                else
                                {
                                    i = 0;
                                    temp = 0;
                                }
                                frame_802_15_4.sequence_number = temp;         //序列号
                                frame_802_15_4.dest_panid = 0x2019;            //目标PANID 0010 0000 0001 1001
                                frame_802_15_4.dest_addr = dest_addr;          //目标地址
                                frame_802_15_4.source_panid = 0x2019;          //源PANID 
                                frame_802_15_4.source_addr = mac_address;      //源地址

                                //添加ConnID PDU
                                frame_802_15_4.pdu_connid = new PDU_ConnID();
                                frame_802_15_4.pdu_connid = (PDU_ConnID)data; //ConnID PDU

                                //802.15.4帧进入组件发送队列
                                this.Component_send_queue.Enqueue(frame_802_15_4);

                                break;

                            case "frame802151": //添加802.15.1帧首部
                                Frame_802_15_1 frame_802_15_1 = new Frame_802_15_1();
                                //802.15.1广播接入地址0x8E89BED6
                                //802.15.1数据接入地址0x8569FAC7
                                frame_802_15_1.access_addr = (UInt32)dest_addr;  //接入地址
                                frame_802_15_1.notice_header = 0xFB;      //通告首部
                                frame_802_15_1.dev_addr = mac_address;    //设备地址
                          

                                //添加ConnID PDU
                                frame_802_15_1.pdu_connid = new PDU_ConnID();
                                frame_802_15_1.pdu_connid = (PDU_ConnID)data; //ConnID PDU

                                int len=0;
                                foreach(Byte[] B in frame_802_15_1.pdu_connid .application_data)
                                {
                                    foreach(Byte b in B)
                                        len++;
                                }
                                
                                frame_802_15_1.payload_length = (Byte)(len + 9); //9：ConnID + message identify

                                //802.15.1帧进入组件发送队列
                                this.Component_send_queue.Enqueue(frame_802_15_1);

                                break;

                            case "frame80211":
                                break;
                        }
                   
                      
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("wireless module错误情况："+e.Message+" "+e.StackTrace);
            }
        }

       /******************************************************************************
        *  函数名称：FrameDecapsulation()
        *  功能：数据帧解封装
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void FrameDecapsulation()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取无线模块接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    switch(data.GetType().Name)
                    {
                        case "Frame_802_15_4": //若为802.15.4数据帧

                            Frame_802_15_4 frame = (Frame_802_15_4)data;
                            //检查目的地址是否为本模块地址
                            if (frame.dest_addr != mac_address) //若不是
                            {
                                return; //返回，丢弃该数据帧
                            }

                            //上层PDU判断方式1：读取第24字节前3bit值，若为011则是6LoWPAN PDU，若为111则为ConnID PDU
                            //上层PDU判断方式2：若pdu_lowpan_iphc变量不为空,则为6LoWPAN PDU，若pdu_connid不为空，
                            //则为ConnID PDU

                            //采用判断方式2
                            if (frame.pdu_lowpan_iphc != null)
                            {
                                //解封装，获取6LoWPAN PDU,并进入无线模块组件发送队列
                                this.Component_send_queue.Enqueue(frame.pdu_lowpan_iphc);
                            }
                            else if (frame.pdu_connid != null)
                            {
                                //解封装，获取ConnID PDU,并进入无线模块组件发送队列
                                this.Component_send_queue.Enqueue(frame.pdu_connid);
                            }
                            break;

                        case "Frame_802_15_1":  //若为802.15.1数据帧

                            Frame_802_15_1 frame802151 = (Frame_802_15_1)data;
                            //检查接入地址是否一致
                            if (frame802151.access_addr != access_address) //若不是
                            {
                                return; //返回，丢弃该数据帧
                            }

                            //解封装，获取ConnID PDU,并进入无线模块组件发送队列
                            this.Component_send_queue.Enqueue(frame802151.pdu_connid);
                            
                            break;
                    }
                              



                }
            }
            catch (Exception e)
            {
                Console.WriteLine("wireless module2错误情况："+e.Message+" "+e.StackTrace);
            }
        }

    
    }
}


