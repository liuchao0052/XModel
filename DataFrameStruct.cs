using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModel
{
    class DataFrameStruct
    {
       
    }
    class Frame_802_15_4                 //IEEE 802.15.4协议帧结构
    {
        public UInt16 frame_control;     //帧控制,2Byte
        public Byte sequence_number;     //序列号,1Byte
        public UInt16 dest_panid;        //目标PANID,2Byte
        public UInt64 dest_addr;         //目标地址,8Byte
        public UInt16 source_panid;      //源PANID,2Byte
        public UInt64 source_addr;       //源地址,8Byte
        //==================//
        //6LoWPAN协议数据单元  
        public PDU_LoWPAN_IPHC pdu_lowpan_iphc = null; //6LoWPAN协议数据单元,最大127-23 = 104Byte
        //ConnID协议数据单元
        public PDU_ConnID pdu_connid = null;           //ConnID协议数据单元,最大127-23 = 104byte

        public Frame_802_15_4()   
        {

        }
    }

    class Frame_802_15_1                 //IEEE 802.15.1协议帧结构
    {
        public UInt32 access_addr;       //接入地址,4Byte
        public Byte notice_header;       //通告首部,1Byte
        public Byte payload_length;      //负载长度,1Byte
        public UInt64 dev_addr;          //设备地址,6Byte
        //==================//
        public PDU_ConnID pdu_connid = null;    //ConnID协议数据单元,最大43-12 = 31Byte

        public Frame_802_15_1()
        {

        }
    }

    class Frame_802_11                   //IEEE 802.11协议帧结构
    {
        public UInt16 frame_contor;      //帧控制,2Byte
        public UInt16 duration;          //持续时间,2Byte
        public UInt64 addr1;             //地址1,目的地址,6Byte
        public UInt64 addr2;             //地址2,源地址地址,6Byte
        public UInt64 addr3;             //地址3,接收端地址,6Byte
        public UInt32 sequence;          //序列号,2Byte
        public UInt64 addr4;             //地址4,传送段地址,6Byte
        //==================//
        public UInt64 snap_header;       //子网络访问协议SNAP,6Byte
        public UInt32 type;              //类型,2Byte
        //==================//
        public PDU_Network pdu_network=null;  //网络层协议数据单元,最大2334-30 = 2304-8 = 2296Byte
          
        public Frame_802_11()
        {

        }
    }

    class Frame_Ethernet                      //以太网帧结构
    {
        public UInt64 dest_mac_addr;          //目的MAC地址,6Byte
        public UInt64 source_mac_addr;        //源MAC地址,6Byte
        public UInt16 type;                   //类型,2Byte
        public PDU_Network pdu_network=null;  //网络层协议数据单元,最大1514-14 = 1500Byte
     
        public Frame_Ethernet()
        {

        }
    }

    class PDU_LoWPAN_IPHC                          //6LoWPAN协议数据单元
    {
        public Byte dispatch;                      //分派值,1Byte,前3bit为011，后5bit作为IPHC报头部分
        public Byte iphc_header;                   //IPHC报头,1Byte
        public Byte context_identifier;            //上下文标识符，1Byte,其中前4bit为SCI、后4bit为DCI
        public List<Byte[]> IP_uncompressed_field; //IP域非压缩字段
        public Byte nhc_header;                    //NHC报头，1Byte
        public List<Byte[]> NH_field;              //下一个首部域字段
        public List<Byte[]> application_data;      //应用层数据

        public PDU_LoWPAN_IPHC()
        {

        }

        public PDU_LoWPAN_IPHC(Byte dispatch, Byte iphc_header, Byte context_identifier,
            List<Byte[]> IP_uncompressed_field, Byte nhc_header,List<Byte[]> NH_field,
            List<Byte[]> application_data)
        {
            this.dispatch = dispatch;
            this.iphc_header = iphc_header;
            this.context_identifier = context_identifier;
            this.IP_uncompressed_field = IP_uncompressed_field;
            this.nhc_header = nhc_header;
            this.NH_field = NH_field;
            this.application_data = application_data;
        }

    }

    class PDU_ConnID                            //ConnID协议数据单元
    {
        public Byte message_identifier;         //消息标识符,1Byte
        public UInt64 connid;                   //连接标识符，8Byte
        public List<Byte[]> application_data;   //应用层数据

        public PDU_ConnID()
        {

        }

        public PDU_ConnID(Byte message_identifier, UInt64 connid, List<Byte[]> application_data)
        {
            this.message_identifier = message_identifier;
            this.connid = connid;
            this.application_data = application_data;
        }

    }

    class PDU_Network                             //网络层协议数据单元
    {
        public Byte version;                      //版本号,4bit
        public Byte traffic_class;                //通信类型,1Byte
        public UInt16 flow_label;                 //流标签,20bit 
        public Byte flow_label2;
        public UInt16 payload_length;             //有效载荷长度,2Byte
        public Byte next_header;                  //下一个首部,1Byte
        public Byte hop_limit;                    //跳数限制,1Byte
        public UInt16[] source_ipv6_address;      //源IPv6地址,16Byte
        public UInt16[] dest_ipv6_address;        //目的IPv6地址,16Byte
        public PDU_Transport pdu_transport;       //传输层协议数据单元
        
    }
    class PDU_Transport                         //传输层协议数据单元
    {
        public UInt16 source_port;              //源端口号,2Byte
        public UInt16 dest_port;                //目的端口号,2Byte
        public UInt16 udp_length;               //UDP长度,2Byte
        public UInt16 udp_checksum;             //UDP校验和,2Byte
        public List<Byte[]> application_data;   //应用层数据
    }


    class Communicarion_Patameter               //通信参数
    {
        public UInt16[] source_ipv6_addr;
        public UInt16[] dest_ipv6_addr;
        public Byte next_header;
        public Byte hop_limit;
        public UInt16 source_port;
        public UInt16 dest_port;
    }


}



    //int a = 53;
    //byte[] list = BitConverter.GetBytes(a);
    //BitArray arr = new BitArray(list);
    //bool bit = arr[0];//取第一位，用bool类型表示


    //Byte[] bytes = { 0xF4 };
    //BitArray arr = new BitArray(bytes);//存储方式 低位优先

    //for (int i = arr.Count-1; i >=0; i--)
    //{
    //    Console.Write("{0, -3} ", arr[i]);
    //    //Console.Write(arr[i]+" ");
    //}