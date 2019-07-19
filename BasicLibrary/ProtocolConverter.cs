using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Collections;

namespace XModel.BasicLibrary
{
    //协议转换器组件
    public class ProtocolConverter : Component
    {

        public Hashtable SCI_Mapping; //源地址上下文标识符映射表
        public Hashtable DCI_Mapping; //目的地址上下文标识符映射表
        public Hashtable CommPara_ConnID_Mapping; //通信参数-连接标识映射表
        public Hashtable NodeMacAddr_NodeIPv6Addr_Mapping; //节点MAC地址-节点IPv6地址映射表

        PDU_Network IPv6_packet;      //IPv6数据报
        PDU_Transport UDP_packet;     //UDP数据报

        public ProtocolConverter(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\ProtocolConverter.png");

            this.bmp = Resource1.ProtocolConverter;
            this.Text = "ProtocolConverter";
            this.Rectangle = new RectangleF(50, 50, 74, 66); //设置组件位置及大小
            this.name = "ProtocolConverter";
            ConstructSCIMappingTab();
            ConstructDCIMappingTab();
            CommPara_ConnID_MappingTab();
        }

       /******************************************************************************
        *  函数名称：ConstructSCIMappingTab()
        *  功能：建立源地址上下文标识符映射表
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void ConstructSCIMappingTab()
        {
            SCI_Mapping = new Hashtable();
            SCI_Mapping.Add(0x0, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9008 }); //低字节优先存储 为2001:0da8:d813:0890
            SCI_Mapping.Add(0x1, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9108 });
            SCI_Mapping.Add(0x2, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9208 });
            SCI_Mapping.Add(0x3, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9308 });
            SCI_Mapping.Add(0x4, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9408 });
            SCI_Mapping.Add(0x5, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9508 });
            SCI_Mapping.Add(0x6, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9608 });
            SCI_Mapping.Add(0x7, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9708 });
            SCI_Mapping.Add(0x8, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9808 });
            SCI_Mapping.Add(0x9, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x0999 });
            SCI_Mapping.Add(0xA, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9A08 });
            SCI_Mapping.Add(0xB, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9B08 });
            SCI_Mapping.Add(0xC, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9C08 });
            SCI_Mapping.Add(0xD, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9D08 });
            SCI_Mapping.Add(0xE, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9E08 });
            SCI_Mapping.Add(0xF, new UInt16[] { 0x0120, 0xa80d, 0x13d8, 0x9F08 });
        }

       /******************************************************************************
        *  函数名称：ConstructDCIMappingTab()
        *  功能：建立目的地址上下文标识符映射表
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void ConstructDCIMappingTab()
        {
            DCI_Mapping = new Hashtable();
            DCI_Mapping.Add(0x0, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8000 });
            DCI_Mapping.Add(0x1, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8100 });
            DCI_Mapping.Add(0x2, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8200 });
            DCI_Mapping.Add(0x3, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8300 });
            DCI_Mapping.Add(0x4, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8400 });
            DCI_Mapping.Add(0x5, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8500 });
            DCI_Mapping.Add(0x6, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8600 });
            DCI_Mapping.Add(0x7, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8700 });
            DCI_Mapping.Add(0x8, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8800 });
            DCI_Mapping.Add(0x9, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8900 });
            DCI_Mapping.Add(0xA, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8A00 });
            DCI_Mapping.Add(0xB, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8B00 });
            DCI_Mapping.Add(0xC, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8C00 });
            DCI_Mapping.Add(0xD, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8D00 });
            DCI_Mapping.Add(0xE, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8E00 });
            DCI_Mapping.Add(0xF, new UInt16[] { 0x0120, 0xa80d, 0x18d8, 0x8F00 });

        }
        
       /******************************************************************************
        *  函数名称：CommPara_ConnID_MappingTab()
        *  功能：建立通信参数-连接标识映射表
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void CommPara_ConnID_MappingTab()
        {
            CommPara_ConnID_Mapping = new Hashtable();

            //ConnID 1
            UInt64 ConnID1 = 0xF431CA185F74C6E6;
            //ConnID 2
            UInt64 ConnID2 = 0x73B6D1725035878D;
            

            //2001:0DA8:D813:08A1:1201:0585:FEAB:6001
            UInt16[] source_ipv6_addr1 = new UInt16[] { 0x0120, 0xA80D, 0x13D8, 0xA108, 0x0112, 0x8505, 0xABFE, 0x0160 };
            UInt16[] source_ipv6_addr2 = new UInt16[] { 0x0120, 0xA80D, 0x13D8, 0xA108, 0x0112, 0x8505, 0xABFE, 0x0170 };
            UInt16[] dest_ipv6_addr = new UInt16[] { 0x0120, 0xA80D, 0x18D8, 0x8200, 0x0000, 0x0000, 0x0000, 0x3412 };
            Byte next_header = 0x11;
            Byte hop_limit = 0xFF;
            UInt16 source_port1 = 0xF0BF;
            UInt16 source_port2 = 0xF0BE;
            UInt16 dest_port = 0xF0B0; 


            //Communicarion Patameter 1
            Communicarion_Patameter commPara1 = new Communicarion_Patameter();
            commPara1.source_ipv6_addr = source_ipv6_addr1;
            commPara1.dest_ipv6_addr = dest_ipv6_addr;
            commPara1.next_header = next_header;
            commPara1.hop_limit = hop_limit;
            commPara1.source_port = source_port1;
            commPara1.dest_port = dest_port;


            //Communicarion Patameter 2
            Communicarion_Patameter commPara2 = new Communicarion_Patameter();
            commPara2.source_ipv6_addr = source_ipv6_addr2;
            commPara2.dest_ipv6_addr = dest_ipv6_addr;
            commPara2.next_header = next_header;
            commPara2.hop_limit = hop_limit;
            commPara2.source_port = source_port2;
            commPara2.dest_port = dest_port;


            CommPara_ConnID_Mapping.Add(ConnID1, commPara1);
            CommPara_ConnID_Mapping.Add(ConnID2, commPara2);       
            

        }


       /******************************************************************************
        *  函数名称：ProtocolConversion()
        *  功能：执行协议转换功能
        *  参数：无
        *  返回值：无
        * ***************************************************************************/
        public void ProtocolConversion()
        {
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取协议转换器接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    switch((data.GetType().Name))
                    {
                        case "PDU_LoWPAN_IPHC": //若为6LoWPAN报文数据
                            
                            //执行6LoWPAN报文到IPv6报文的转换
                            this.IPv6_packet = ConvertBetween_LoWPAN_IPv6(data);

                            //IPv6报文进入组件发送队列
                            this.Component_send_queue.Enqueue(this.IPv6_packet);
                            break;
                        case "PDU_ConnID"://若为ConnID报文数据

                            //执行ConnID报文到IPv6报文的转换
                            this.IPv6_packet = ConvertBetween_ConnID_IPv6(data);

                            //IPv6报文进入组件发送队列
                            this.Component_send_queue.Enqueue(this.IPv6_packet);

                            break;

                    }
                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("协议转换器错误情况："+e.Message+" "+e.StackTrace);
            }
        
        
        }

       /******************************************************************************
        *  函数名称：ConvertBetween_LoWPAN_IPv6()
        *  功能：实现6LoWPAN协议到IPv6协议的转换
        *  参数：data表示6LoWPAN报文；
        *  返回值：IPv6_packet 返回IPv6报文
        * ***************************************************************************/

        private PDU_Network ConvertBetween_LoWPAN_IPv6(Object data)
        {
            PDU_LoWPAN_IPHC pdu_lowpan = (PDU_LoWPAN_IPHC)data;

            Byte dispatch = pdu_lowpan.dispatch;            //获取6LoWPAN报文分派值
            Byte iphc_header = pdu_lowpan.iphc_header;      //获取6LoWPAN报文IPHC报头
            Byte context_id = pdu_lowpan.context_identifier;//获取6LoWPAN报文上下文标识符
            List<Byte[]> unzip_field = pdu_lowpan.IP_uncompressed_field; //获取6LoWPAN报文IP域非压缩字段
            Byte nhc_header = pdu_lowpan.nhc_header;        //获取6LoWPAN报文NHC报头
            List<Byte[]> nh_field = pdu_lowpan.NH_field;    //获取6LoWPAN报文下一个首部域字段
            List<Byte[]> app_data = pdu_lowpan.application_data; //获取6LoWPAN报文应用层数据

            IPv6_packet = new PDU_Network();    //构造IPv6数据报
            UDP_packet = new PDU_Transport(); //构造UDP数据报

            //================ IPv6 版本号 =====================//
            IPv6_packet.version = 0x6; //版本号4bit

            //依据IPHC报头执行转换
            Byte[] dispatch_arr = { dispatch };
            BitArray arr = new BitArray(dispatch_arr);

            bool[] TF = new bool[2]; //通信类型&流标签
            TF[0] = arr[arr.Count - 4];
            TF[1] = arr[arr.Count - 5];
            String TF_value = "";
            if (!TF[0] && !TF[1])
                TF_value = "00";     //2bitECN+6bitDSCP+4bitPAD+20bit流标签
            else if (!TF[0] && TF[1])
                TF_value = "01";     //2bitECN+2bitPAD+20bit流标签
            else if (TF[0] && !TF[1])
                TF_value = "10";     //2bitECN+6bitDSCP
            else
                TF_value = "11";     //通信类型&流标签全部压缩
            switch (TF_value)
            {
                case "00":
                    break;
                case "01":
                    break;
                case "10":
                    break;
                case "11":
                    //================ IPv6 通信类型&流标签 =====================//
                    IPv6_packet.traffic_class = 0x00; //通信类型8bit
                    IPv6_packet.flow_label = 0x0000; //流标签20bit
                    IPv6_packet.flow_label2 = 0x0;
                    break;
            }

            bool NH = arr[arr.Count - 6];  //下一报头
            switch (NH)
            {
                case false: //不压缩 (包含于非压缩字段)
                    break;
                case true:  //用LoWPAN_NHC压缩
                    //读取NHC Header字段各比特位值
                    Byte[] nhc_header_arr = { nhc_header };
                    BitArray arr2 = new BitArray(nhc_header_arr);
                    if (arr2[arr2.Count - 1] && arr2[arr2.Count - 2] && arr2[arr2.Count - 3] &&
                        arr2[arr2.Count - 4] && !arr2[arr2.Count - 5])  //若NHC Header前5位为11110，则下一首部为UDP报头
                    {
                        //================== IPv6 下一个首部=============================//
                        IPv6_packet.next_header = 0x11;  //下一首部11H，表示UDP报文 

                        switch (arr2[arr2.Count - 6]) //第6为C位表示UDP校验和是否压缩
                        {
                            //============================ UDP 校验和 =====================================//
                            case false:    //UDP校验和不压缩
                                UDP_packet.udp_checksum = BitConverter.ToUInt16(nh_field.ElementAt(1), 0);
                                break;
                            case true:     //UDP校验和压缩
                                UDP_packet.udp_checksum = 0x0000;
                                break;
                        }

                        //第7、8位为P位，表示源端口和目的端口是否压缩
                        if (!arr2[arr2.Count - 7] && !arr2[arr2.Count - 8]) { }     //00,源端口、目的端口都不压缩
                        else if (!arr2[arr2.Count - 7] && arr2[arr2.Count - 8]) { } //01,源端口不压缩，目的端口前8位为0xF0，被省略
                        else if (arr2[arr2.Count - 7] && !arr2[arr2.Count - 8]) { } //10,目的端口不压缩，源端口前8位为0xF0，被省略
                        else  //11,源端口、目的端口前12位均为0XF0B，被省略
                        {
                            BitArray arr1 = new BitArray(nh_field.ElementAt(0));
                            bool[] zip_ports = new bool[8];
                            zip_ports[0] = arr1[arr1.Count - 1];
                            zip_ports[1] = arr1[arr1.Count - 2];
                            zip_ports[2] = arr1[arr1.Count - 3];
                            zip_ports[3] = arr1[arr1.Count - 4];
                            zip_ports[4] = arr1[arr1.Count - 5];
                            zip_ports[5] = arr1[arr1.Count - 6];
                            zip_ports[6] = arr1[arr1.Count - 7];
                            zip_ports[7] = arr1[arr1.Count - 8];
                            //================================ UDP 端口号 ==============================//
                            //源端口
                            if (!zip_ports[0] && !zip_ports[1] && !zip_ports[2] && !zip_ports[3])     //0000
                                UDP_packet.source_port = 0xF0B0 + 0x0;
                            else if (!zip_ports[0] && !zip_ports[1] && !zip_ports[2] && zip_ports[3]) //0001
                                UDP_packet.source_port = 0xF0B0 + 0x1;
                            else if (!zip_ports[0] && !zip_ports[1] && zip_ports[2] && !zip_ports[3]) //0010
                                UDP_packet.source_port = 0xF0B0 + 0x2;
                            else if (!zip_ports[0] && !zip_ports[1] && zip_ports[2] && zip_ports[3])  //0011
                                UDP_packet.source_port = 0xF0B0 + 0x3;
                            else if (!zip_ports[0] && zip_ports[1] && !zip_ports[2] && !zip_ports[3]) //0100
                                UDP_packet.source_port = 0xF0B0 + 0x4;
                            else if (!zip_ports[0] && zip_ports[1] && !zip_ports[2] && zip_ports[3])  //0101
                                UDP_packet.source_port = 0xF0B0 + 0x5;
                            else if (!zip_ports[0] && zip_ports[1] && zip_ports[2] && !zip_ports[3])  //0110
                                UDP_packet.source_port = 0xF0B0 + 0x6;
                            else if (!zip_ports[0] && zip_ports[1] && zip_ports[2] && zip_ports[3])   //0111
                                UDP_packet.source_port = 0xF0B0 + 0x7;
                            else if (zip_ports[0] && !zip_ports[1] && !zip_ports[2] && !zip_ports[3]) //1000
                                UDP_packet.source_port = 0xF0B0 + 0x8;
                            else if (zip_ports[0] && !zip_ports[1] && !zip_ports[2] && zip_ports[3])  //1001
                                UDP_packet.source_port = 0xF0B0 + 0x9;
                            else if (zip_ports[0] && !zip_ports[1] && zip_ports[2] && !zip_ports[3])  //1010
                                UDP_packet.source_port = 0xF0B0 + 0xA;
                            else if (zip_ports[0] && !zip_ports[1] && zip_ports[2] && zip_ports[3])   //1011
                                UDP_packet.source_port = 0xF0B0 + 0xB;
                            else if (zip_ports[0] && zip_ports[1] && !zip_ports[2] && !zip_ports[3])  //1100
                                UDP_packet.source_port = 0xF0B0 + 0xC;
                            else if (zip_ports[0] && zip_ports[1] && !zip_ports[2] && zip_ports[3])   //1101
                                UDP_packet.source_port = 0xF0B0 + 0xD;
                            else if (zip_ports[0] && zip_ports[1] && zip_ports[2] && !zip_ports[3])   //1110
                                UDP_packet.source_port = 0xF0B0 + 0xE;
                            else                                                                      //1111
                                UDP_packet.source_port = 0xF0B0 + 0xF;

                            //目的端口
                            if (!zip_ports[4] && !zip_ports[5] && !zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x0;
                            else if (!zip_ports[4] && !zip_ports[5] && !zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x1;
                            else if (!zip_ports[4] && !zip_ports[5] && zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x2;
                            else if (!zip_ports[4] && !zip_ports[5] && zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x3;
                            else if (!zip_ports[4] && zip_ports[5] && !zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x4;
                            else if (!zip_ports[4] && zip_ports[5] && !zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x5;
                            else if (!zip_ports[4] && zip_ports[5] && zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x6;
                            else if (!zip_ports[4] && zip_ports[5] && zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x7;
                            else if (zip_ports[4] && !zip_ports[5] && !zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x8;
                            else if (zip_ports[4] && !zip_ports[5] && !zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0x9;
                            else if (zip_ports[4] && !zip_ports[5] && zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0xA;
                            else if (zip_ports[4] && !zip_ports[5] && zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0xB;
                            else if (zip_ports[4] && zip_ports[5] && !zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0xC;
                            else if (zip_ports[4] && zip_ports[5] && !zip_ports[6] && zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0xD;
                            else if (zip_ports[4] && zip_ports[5] && zip_ports[6] && !zip_ports[7])
                                UDP_packet.dest_port = 0xF0B0 + 0xE;
                            else
                                UDP_packet.dest_port = 0xF0B0 + 0xF;

                        }// else  //11,源端口、目的端口前12位均为0XF0B，被省略

                    }
                    break;
            }//switch (NH)


            bool[] HLIM = new bool[2]; //跳数限制
            HLIM[0] = arr[arr.Count - 7];
            HLIM[1] = arr[arr.Count - 8];
            String HLIM_value = "";
            if (!HLIM[0] && !HLIM[1])
                HLIM_value = "00";     //跳数限制不压缩
            else if (!HLIM[0] && HLIM[1])
                HLIM_value = "01";     //跳数限制为1
            else if (HLIM[0] && !HLIM[1])
                HLIM_value = "10";     //跳数限制为64
            else
                HLIM_value = "11";     //跳数限制为255
            switch (HLIM_value)
            {
                //========================= IPv6  跳数限制======================//
                case "00":
                    IPv6_packet.hop_limit = unzip_field.ElementAt(0)[0]; //非压缩字段1为未压缩的跳数限制字段，1字节
                    break;
                case "01":
                    IPv6_packet.hop_limit = 0x01;
                    break;
                case "10":
                    IPv6_packet.hop_limit = 0x40;
                    break;
                case "11":
                    IPv6_packet.hop_limit = 0xFF;
                    break;
            }

            Byte[] iphc_header_arr = { iphc_header };
            BitArray iphc_header_bitarr = new BitArray(iphc_header_arr);

            Byte[] context_id_arr = { context_id };
            BitArray context_id_bitarr = new BitArray(context_id_arr);

            bool CID = iphc_header_bitarr[iphc_header_bitarr.Count - 1]; //上下文标识扩展

            UInt16[] source_IPv6_addr_prefix = null; //定义源IPv6地址前缀
            UInt16[] dest_IPv6_addr_prefix = null;   //定义目的IPv6地址前缀
            switch (CID)
            {
                case false:  //使用默认上下文 0x0
                    source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x0]; //获取源IPv6地址前缀
                    dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x0];   //获取目的IPv6地址前缀
                    break;
                case true:   //使用指定上下文
                    bool[] SCI = new bool[4];  //源地址上下文标识符
                    bool[] DCI = new bool[4];  //目的地址上下文标识符

                    SCI[0] = context_id_bitarr[context_id_bitarr.Count - 1];
                    SCI[1] = context_id_bitarr[context_id_bitarr.Count - 2];
                    SCI[2] = context_id_bitarr[context_id_bitarr.Count - 3];
                    SCI[3] = context_id_bitarr[context_id_bitarr.Count - 4];

                    DCI[0] = context_id_bitarr[context_id_bitarr.Count - 5];
                    DCI[1] = context_id_bitarr[context_id_bitarr.Count - 6];
                    DCI[2] = context_id_bitarr[context_id_bitarr.Count - 7];
                    DCI[3] = context_id_bitarr[context_id_bitarr.Count - 8];

                    if (!SCI[0] && !SCI[1] && !SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x0];
                    else if (!SCI[0] && !SCI[1] && !SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x1];
                    else if (!SCI[0] && !SCI[1] && SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x2];
                    else if (!SCI[0] && !SCI[1] && SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x3];
                    else if (!SCI[0] && SCI[1] && !SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x4];
                    else if (!SCI[0] && SCI[1] && !SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x5];
                    else if (!SCI[0] && SCI[1] && SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x6];
                    else if (!SCI[0] && SCI[1] && SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x7];
                    else if (SCI[0] && !SCI[1] && !SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x8];
                    else if (SCI[0] && !SCI[1] && !SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0x9];
                    else if (SCI[0] && !SCI[1] && SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xA];
                    else if (SCI[0] && !SCI[1] && SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xB];
                    else if (SCI[0] && SCI[1] && !SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xC];
                    else if (SCI[0] && SCI[1] && !SCI[2] && SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xD];
                    else if (SCI[0] && SCI[1] && SCI[2] && !SCI[3])
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xE];
                    else
                        source_IPv6_addr_prefix = (UInt16[])SCI_Mapping[0xF];

                    if (!DCI[0] && !DCI[1] && !DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x0];
                    else if (!DCI[0] && !DCI[1] && !DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x1];
                    else if (!DCI[0] && !DCI[1] && DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x2];
                    else if (!DCI[0] && !DCI[1] && DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x3];
                    else if (!DCI[0] && DCI[1] && !DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x4];
                    else if (!DCI[0] && DCI[1] && !DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x5];
                    else if (!DCI[0] && DCI[1] && DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x6];
                    else if (!DCI[0] && DCI[1] && DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x7];
                    else if (DCI[0] && !DCI[1] && !DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x8];
                    else if (DCI[0] && !DCI[1] && !DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0x9];
                    else if (DCI[0] && !DCI[1] && DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xA];
                    else if (DCI[0] && !DCI[1] && DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xB];
                    else if (DCI[0] && DCI[1] && !DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xC];
                    else if (DCI[0] && DCI[1] && !DCI[2] && DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xD];
                    else if (DCI[0] && DCI[1] && DCI[2] && !DCI[3])
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xE];
                    else
                        dest_IPv6_addr_prefix = (UInt16[])DCI_Mapping[0xF];

                    break;
            }// switch (CID)

            bool SAC = iphc_header_bitarr[iphc_header_bitarr.Count - 2]; //源地址压缩状态
            bool[] SAM = new bool[2];    //源地址模式
            SAM[0] = iphc_header_bitarr[iphc_header_bitarr.Count - 3];
            SAM[1] = iphc_header_bitarr[iphc_header_bitarr.Count - 4];

            bool M = iphc_header_bitarr[iphc_header_bitarr.Count - 5];   //组播压缩

            bool DAC = iphc_header_bitarr[iphc_header_bitarr.Count - 6]; //目的地址压缩状态
            bool[] DAM = new bool[2];    //目的地址模式
            DAM[0] = iphc_header_bitarr[iphc_header_bitarr.Count - 7];
            DAM[1] = iphc_header_bitarr[iphc_header_bitarr.Count - 8];

            UInt16[] source_IPv6_addr_IID = null; //定义源IPv6地址IID
            UInt16[] dest_IPv6_addr_IID = null;   //定义目的IPv6地址IID

            switch (SAC)
            {
                case false:   //无状态压缩
                    break;
                case true:    //有状态压缩
                    if (!SAM[0] && !SAM[1]) { }   //保留
                    else if (!SAM[0] && SAM[1])  //64bit IID串联发送，前64bit由上下文计算得出
                    {
                        Byte[] temp1 = { unzip_field.ElementAt(1)[0], unzip_field.ElementAt(1)[1] };
                        Byte[] temp2 = { unzip_field.ElementAt(1)[2], unzip_field.ElementAt(1)[3] };
                        Byte[] temp3 = { unzip_field.ElementAt(1)[4], unzip_field.ElementAt(1)[5] };
                        Byte[] temp4 = { unzip_field.ElementAt(1)[6], unzip_field.ElementAt(1)[7] };

                        source_IPv6_addr_IID = new UInt16[4];
                        source_IPv6_addr_IID[0] = BitConverter.ToUInt16(temp1, 0); //两个Byte类型转UInt16
                        source_IPv6_addr_IID[1] = BitConverter.ToUInt16(temp2, 0);
                        source_IPv6_addr_IID[2] = BitConverter.ToUInt16(temp3, 0);
                        source_IPv6_addr_IID[3] = BitConverter.ToUInt16(temp4, 0);

                    }
                    else if (SAM[0] && !SAM[1]) { } //16bit 短地址串联发送，前112bit由上下文计算得出
                    else { }      //0bit，全部由上下文计算得出
                    break;
            }

            switch (DAC)
            {
                case false:   //无状态压缩
                    break;
                case true:    //有状态压缩
                    if (!DAM[0] && !DAM[1]) { }   //保留
                    else if (!DAM[0] && DAM[1])  //64bit IID串联发送，前64bit由上下文计算得出
                    {

                        Byte[] temp1 = { unzip_field.ElementAt(2)[0], unzip_field.ElementAt(2)[1] };
                        Byte[] temp2 = { unzip_field.ElementAt(2)[2], unzip_field.ElementAt(2)[3] };
                        Byte[] temp3 = { unzip_field.ElementAt(2)[4], unzip_field.ElementAt(2)[5] };
                        Byte[] temp4 = { unzip_field.ElementAt(2)[6], unzip_field.ElementAt(2)[7] };

                        dest_IPv6_addr_IID = new UInt16[4];
                        dest_IPv6_addr_IID[0] = BitConverter.ToUInt16(temp1, 0); //两个Byte类型转UInt16
                        dest_IPv6_addr_IID[1] = BitConverter.ToUInt16(temp2, 0);
                        dest_IPv6_addr_IID[2] = BitConverter.ToUInt16(temp3, 0);
                        dest_IPv6_addr_IID[3] = BitConverter.ToUInt16(temp4, 0);

                    }
                    else if (DAM[0] && !DAM[1]) { } //16bit 短地址串联发送，前112bit由上下文计算得出
                    else { }      //0bit，全部由上下文计算得出
                    break;
            }

            //================================= IPv6 源地址、目的地址======================================//
            //计算源IPv6地址
            IPv6_packet.source_ipv6_address = new UInt16[source_IPv6_addr_prefix.Length + source_IPv6_addr_IID.Length];
            source_IPv6_addr_prefix.CopyTo(IPv6_packet.source_ipv6_address, 0);
            source_IPv6_addr_IID.CopyTo(IPv6_packet.source_ipv6_address, source_IPv6_addr_prefix.Length);

            //计算目的IPv6地址
            IPv6_packet.dest_ipv6_address = new UInt16[dest_IPv6_addr_prefix.Length + dest_IPv6_addr_IID.Length];
            dest_IPv6_addr_prefix.CopyTo(IPv6_packet.dest_ipv6_address, 0);
            dest_IPv6_addr_IID.CopyTo(IPv6_packet.dest_ipv6_address, dest_IPv6_addr_prefix.Length);

            UInt16 app_data_len=0x0000; //应用层数据字节数
            foreach(Byte[] B in app_data){
                foreach (Byte b in B)
                {
                    app_data_len++;
                }
            }

            //================== UDP长度 =====================//
            UDP_packet.udp_length = (UInt16)(0x0008 + app_data_len); //UDP长度为UDP报头+UDP数据长度

            //================ IPv6有效载荷长度 ===============//
            IPv6_packet.payload_length = UDP_packet.udp_length;

            //================== UDP数据 ======================//
            UDP_packet.application_data = app_data;

            //================ IPv6上层PDU ====================//
            IPv6_packet.pdu_transport = UDP_packet;

            return IPv6_packet;
        } 

       
       /******************************************************************************
        *  函数名称：ConvertBetween_ConnID_IPv6()
        *  功能：实现ConnID协议到IPv6协议的转换
        *  参数：data表示ConnID报文；
        *  返回值：IPv6_packet 返回IPv6报文
        * ***************************************************************************/

        private PDU_Network ConvertBetween_ConnID_IPv6(Object data)
        {
            PDU_ConnID pdu_connid = (PDU_ConnID)data;
            
            IPv6_packet = new PDU_Network();    //构造IPv6数据报
            UDP_packet = new PDU_Transport();   //构造UDP数据报

            UInt64 connid = pdu_connid.connid;    //获取ConnID报文连接标识ConnID
            List<Byte[]> app_data = pdu_connid.application_data; //获取ConnID报文应用层数据

            Communicarion_Patameter commPata = (Communicarion_Patameter)CommPara_ConnID_Mapping[connid];

            IPv6_packet.version = 0x6;        //版本号4bit
            IPv6_packet.traffic_class = 0x00; //通信类型8bit
            IPv6_packet.flow_label = 0x0000;  //流标签20bit
            IPv6_packet.flow_label2 = 0x0;


            IPv6_packet.next_header = commPata.next_header;   //下一首部8bit
            IPv6_packet.hop_limit = commPata.hop_limit;       //跳数限制8bit
            IPv6_packet.source_ipv6_address = commPata.source_ipv6_addr;    //源IPv6地址
            IPv6_packet.dest_ipv6_address = commPata.dest_ipv6_addr;        //目的IPv6地址

            UDP_packet.source_port = commPata.source_port;  //源端口号
            UDP_packet.dest_port = commPata.dest_port;      //目的端口号
            UDP_packet.udp_checksum = 0x0000;

            UInt16 app_data_len = 0x0000; //应用层数据字节数
            foreach (Byte[] B in app_data)
            {
                foreach (Byte b in B)
                {
                    app_data_len++;
                }
            }

            //================== UDP长度 =====================//
            UDP_packet.udp_length = (UInt16)(0x0008 + app_data_len); //UDP长度为UDP报头+UDP数据长度
           
            //================ IPv6有效载荷长度 ===============//
            IPv6_packet.payload_length = UDP_packet.udp_length;

            //================== UDP数据 ======================//
            UDP_packet.application_data = app_data;

            //================ IPv6上层PDU ====================//
            IPv6_packet.pdu_transport = UDP_packet;

            return IPv6_packet;


        }




    }
}
