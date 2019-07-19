using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //微处理器组件
    public class MicroProcessor : Component
    {
        
        public MicroProcessor(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\MicroProcessor.png");

            this.bmp = Resource1.MicroProcessor;
            this.Text = "MicroProcessor";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "MicroProcessor";
        }
       
        /********************************************
        * 函数名称：run()
        * 功能：微处理器组件执行函数
        * 参数：无
        * 返回值：无
        * *****************************************/
        public void run(Object x)
        {
            while (true)
            {
                if (Form1.stop)
                {
                    this.EmptyingQueue();
                    return;
                }
              
                //if ((string)x == "6LoWPAN")
                //{
                //    //1、接收输入端口数据
                //    ComponentDataReceive(this);
                //    //2、执行微处理器功能
                //    MessageEncapsulation("6LoWPAN");
                //    //3、发送微处理器处理后的数据
                //    ComponentDataTransfer(this);
                //}
          
                //else if ((string)x == "ConnID")
                //{
                //    //1、接收输入端口数据
                //    ComponentDataReceive(this);
                //    //2、执行微处理器功能
                //    MessageEncapsulation("ConnID");
                //    //3、发送微处理器处理后的数据
                //    ComponentDataTransfer(this);
                //}
            }
        }
        /******************************************************************************
         *  函数名称：MessageEncapsulation()
         *  功能：报文封装
         *  参数：x 表示模拟传输协议
         *        x="6LoWPAN" 表示构建6LoWPAN协议数据单元 ，x="ConnID"表示构建基于ConnID
         *        方式协议数据单元
         *  返回值：无
         * ***************************************************************************/
        public void MessageEncapsulation(string x)
        {
            try
            {
                Object temp = null;

                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取微处理器组件接收队列数据
                    temp = this.Component_reveice_queue.Dequeue();

                    //将该数据作为应用层数据，同时转换为字节表示形式
                    List<Byte[]> app_data = new List<Byte[]>();  //应用层数据列表
                    //if (temp.GetType().Name == "Int32[]")

                    switch (temp.GetType().Name)
                    {
                        case  "BloodPressureDataType":

                             BloodPressureDataType bpData = (BloodPressureDataType)temp;
                             Byte[] bytes0 = BitConverter.GetBytes(bpData.HighBP);
                             Byte[] bytes1 = BitConverter.GetBytes(bpData.LowBP);
                             app_data.Add(bytes0);
                             app_data.Add(bytes1);
                             break;

                        case "TemperatureDataType":

                             TemperatureDataType tempData = (TemperatureDataType)temp;
                             //Byte[] bytes2 = BitConverter.GetBytes(tempData.TemperatureInteger);
                             //Byte[] bytes3 = BitConverter.GetBytes(tempData.TemperatureDecimal);
                             app_data.Add(new Byte[]{ tempData.TemperatureInteger });
                             app_data.Add(new Byte[]{ tempData.TemperatureDecimal });

                             break;

                        case "HeartRateDataType":

                             HeartRateDataType hrData = (HeartRateDataType)temp;
                             Byte[] bytes4 = BitConverter.GetBytes(hrData.HeartRate);
                             app_data.Add(bytes4);
                             break;
                    }


                    switch (x)
                    {
                        case "6LoWPAN":   //6LoWPAN协议数据单元

                            //构建6LoWPAN PDU
                            PDU_LoWPAN_IPHC pdu_lowpan_iphc = new PDU_LoWPAN_IPHC();
                            pdu_lowpan_iphc.dispatch = 0x7C; //0111 1100
                            pdu_lowpan_iphc.iphc_header = 0xD5; //1101 0101
                            pdu_lowpan_iphc.context_identifier = 0x12; //0001 0010
                            pdu_lowpan_iphc.IP_uncompressed_field = new List<Byte[]>();

                            //非压缩字段1，跳数限制255
                            Byte[] hop_limit = new Byte[] { 0xFF };
                            pdu_lowpan_iphc.IP_uncompressed_field.Add(hop_limit);
                            //非压缩字段2，源地址1201_0585_FEAB_5001H
                            Byte[] source_addr = new Byte[] { 0x12, 0x01, 0x05, 0x85, 0xFE, 0xAB, 0x50, 0x01 };
                            pdu_lowpan_iphc.IP_uncompressed_field.Add(source_addr);
                            //非压缩字段3，目的地址0000_0000_0000_1234H
                            Byte[] dest_addr = new Byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x12, 0x34 };
                            pdu_lowpan_iphc.IP_uncompressed_field.Add(dest_addr);


                            //根据IPHC报头NH=1，可判断下一报头采用LoWPAN_NHC压缩
                            pdu_lowpan_iphc.nhc_header = 0xF3;  //1111 0011
                            pdu_lowpan_iphc.NH_field = new List<Byte[]>();

                            //根据nhc_header最后两位，确定端口号采用最短压缩形式，即源端口号和目的端口号所占存储均为4bit,默认前12bit为0xF0B
                            Byte[] port = new Byte[] { 0xF0 }; //即源端口号为0xF0BF，目的端口号为0xF0B0;
                            pdu_lowpan_iphc.NH_field.Add(port);
                            //UDP校验和0
                            Byte[] checksum = new Byte[] { 0x00, 0x0F };
                            pdu_lowpan_iphc.NH_field.Add(checksum);

                            //添加应用层数据
                            //foreach (Byte[] data in app_data)
                            //{
                            //    pdu_lowpan_iphc.application_data.Add(data);
                            //}
                            pdu_lowpan_iphc.application_data = app_data;

                            //6LoWPAN PDU进入组件发送队列
                            this.Component_send_queue.Enqueue(pdu_lowpan_iphc);

                            //foreach (PDU_LoWPAN_IPHC p in Component_send_queue)
                            //{
                            //    Console.WriteLine(p + "////");
                            //}
                            break;

                        case "ConnID": //ConnID协议数据单元

                            //构建ConnID PDU
                            PDU_ConnID pdu_connid = new PDU_ConnID();
                            pdu_connid.message_identifier = 0xFF; //FF表示Data消息类型
                            //Byte[] connid = new Byte[] { 0xF4, 0x31, 0xCA, 0x18, 0x5F, 0x74, 0xC6, 0xE6 }; //f431ca185f74c6e6                                                      
                            //pdu_connid.connid = new List<byte[]>();
                            //pdu_connid.connid.Add(connid);

                            pdu_connid.connid = 0xF431CA185F74C6E6; 

                            //添加应用层数据
                            //foreach (Byte[] data in app_data)
                            //{
                            //    pdu_connid.application_data.Add(data);
                            //}
                            pdu_connid.application_data = app_data;

                            //ConnID PDU进入组件发送队列
                            this.Component_send_queue.Enqueue(pdu_connid);
                            break;

                        case "ConnID_2": //ConnID协议数据单元

                            //构建ConnID PDU
                            PDU_ConnID pdu_connid_2 = new PDU_ConnID();
                            pdu_connid_2.message_identifier = 0xFF; //FF表示Data消息类型
                            //Byte[] connid_2 = new Byte[] { 0x73, 0xB6, 0xD1, 0x72, 0x50, 0x35, 0x87, 0x8d }; //73b6d1725035878d
                            //pdu_connid_2.connid = new List<byte[]>();
                            //pdu_connid_2.connid.Add(connid_2);

                            pdu_connid_2.connid = 0x73B6D1725035878D; 



                            //添加应用层数据
                            //foreach (Byte[] data in app_data)
                            //{
                            //    pdu_connid.application_data.Add(data);
                            //}
                            pdu_connid_2.application_data = app_data;

                            //ConnID PDU进入组件发送队列
                            this.Component_send_queue.Enqueue(pdu_connid_2);
                            break;

                    }                   


                }              
            }
            catch (Exception e)
            {
                Console.WriteLine("MP错误情况："+e.Message+e.StackTrace);
            }
        }
    }
}
