using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using Netron.GraphLib;
using XModel.BasicLibrary;

namespace XModel
{
    public partial class Form_monitor : Form
    {
        //private int delay=300; //时延
        MyMonitor mymonitor; //监控器窗口对应的组件
        int i = 0;
        int j = 0;
        public Form_monitor(MyMonitor mymonitor)
        {
            this.mymonitor = mymonitor;
            InitializeComponent();
            Thread monitor_run = new Thread(new ParameterizedThreadStart(MonitorDatas)); //带1个参数传递的线程创建
            monitor_run.Start(mymonitor);
        }
        /********************************************
         *  函数名称：MonitorDatas()
         *  功能：数据监控，监控组件数据
         *  参数：monitor 表示对应的监控器组件
         *  返回值：无
         * ******************************************/
        private void MonitorDatas(Object monitor)
        {
            CheckForIllegalCrossThreadCalls = false; //去掉线程间操作无效检查
            MyMonitor mymonitor = (MyMonitor)monitor;
            while (true)
            {
                if (Form1.stop)
                {
                    this.mymonitor.EmptyingQueue();
                    return;
                }
                try
                {   //接收数据
                    mymonitor.ComponentDataReceive(mymonitor);
                    if (mymonitor.Component_reveice_queue.Count > 0)
                    {
                        Object data = mymonitor.Component_reveice_queue.Dequeue();

                        //if (data.GetType().Name == "Int32[]")
                        //{
                        //    MonitorInt32Array(data);
                        //}
                        //Console.WriteLine(data.GetType());
                        //Console.WriteLine(data.GetType().GetGenericArguments()[0].Name);

                        switch (data.GetType().Name)
                        {
                            case "BloodPressureDataType":
                                MonitorBloodPressureData(data);
                                break;             

                            case "TemperatureDataType":
                                MonitorTemperatureData(data);
                                break;

                            case "HeartRateDataType":
                                MonitorHeartRateData(data);
                                break;

                            case "List`1": //若为列表数据类型

                                //若列表元素为BloodPressureDataType
                                if (data.GetType().GetGenericArguments()[0].Name == "BloodPressureDataType")
                                {
                                    MonitorListBloodPressureData(data);
                                }                              
                                else if (data.GetType().GetGenericArguments()[0].Name == "TemperatureDataType")
                                {
                                    MonitorListTemperatureData(data);
                                }
                                else if (data.GetType().GetGenericArguments()[0].Name == "HeartRateDataType")
                                {
                                    MonitorListHeartRateData(data);
                                }

                                break;
                            

                            case "PDU_LoWPAN_IPHC":
                                Monitor_PDU_LoWPAN_IPHC(data);
                                break;

                            case "PDU_ConnID":
                                Monitor_PDU_ConnID(data);
                                break;

                            case "PDU_Network":
                                Monitor_PDU_Network(data);
                                break;

                            case "Frame_802_15_4":
                                Monitor_Frame_802_15_4(data);
                                break;

                            case "Frame_802_15_1":
                                Monitor_Frame_802_15_1(data);
                                break;
                            case "Frame_Ethernet":
                                Monitor_Frame_Ethernet(data);
                                break;
                        }

                    }

                    //Thread.Sleep(delay);

                }
                catch (Exception e){
                    Console.WriteLine("Form monitor错误情况:"+e.Message +" " +e.StackTrace);
                }
               
            }            
        }





       /********************************************
        *  函数名称：Monitor_Frame_Ethernet()
        *  功能：显示以太网帧数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void Monitor_Frame_Ethernet(object data)
        {
            Frame_Ethernet frame = (Frame_Ethernet)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText(
                    "[Dest Mac Addr=" + string.Format("{0:X12}", frame.dest_mac_addr) +
                    "],[Source Mac Addr=" + string.Format("{0:X12}", frame.source_mac_addr) +
                    "],[Type=" + string.Format("{0:X4}", frame.type) +
                    "],IPv6 Packet:");
                Monitor_PDU_Network(frame.pdu_network);
            }
        }


        /********************************************
         *  函数名称：Monitor_PDU_Network()
         *  功能：显示网络层IPv6报文数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void Monitor_PDU_Network(object data)
        {
            PDU_Network ipv6_packet = (PDU_Network)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText("{ [Version=" + ipv6_packet.version.ToString("X") + 
                    "],[Traffic Class=" + string.Format("{0:X2}", ipv6_packet.traffic_class) +
                    "],[Flow Label=" + string.Format("{0:X4}", ipv6_packet.flow_label) + ipv6_packet.flow_label2.ToString("X") +
                    "],[Payload Length=" + string.Format("{0:X4}", ipv6_packet.payload_length));
                //Byte[] payload_len_bytes = BitConverter.GetBytes(ipv6_packet.payload_length);
                //foreach (Byte b in payload_len_bytes)
                //{
                //    this.richTextBox1.AppendText(string.Format("{0:X2}", b));
                //}

                this.richTextBox1.AppendText("],[Next Header=" + string.Format("{0:X2}", ipv6_packet.next_header) + 
                    "],[Hop Limit=" +  string.Format("{0:X2}", ipv6_packet.hop_limit) +
                    "],[Source IPv6 Addr=");
                i = 0;
                foreach(UInt16 U in ipv6_packet.source_ipv6_address)
                {
                    Byte[] temp = BitConverter.GetBytes(U);
                    foreach(Byte b in temp)
                    {
                        this.richTextBox1.AppendText(string.Format("{0:X2}",b));
                    }

                    if (i < ipv6_packet.source_ipv6_address.Length-1)
                    {
                        i++;
                        this.richTextBox1.AppendText(":");
                    }
                }

                this.richTextBox1.AppendText("],[Dest IPv6 Addr=");
                i = 0;
                foreach (UInt16 U in ipv6_packet.dest_ipv6_address)
                {
                    Byte[] temp = BitConverter.GetBytes(U);
                    foreach (Byte b in temp)
                    {
                        this.richTextBox1.AppendText(string.Format("{0:X2}", b));
                    }
                  
                    if (i < ipv6_packet.dest_ipv6_address.Length - 1)
                    {
                        i++;
                        this.richTextBox1.AppendText(":");
                    }
                }

                this.richTextBox1.AppendText("],UDP Packet:[Source Port="+
                    string.Format("{0:X4}", ipv6_packet.pdu_transport.source_port) +
                    "],[Dest Port=" + string.Format("{0:X4}", ipv6_packet.pdu_transport.dest_port) +
                    "],[UDP Length=" + string.Format("{0:X4}", ipv6_packet.pdu_transport.udp_length));

                //Byte[] udp_length_bytes =  BitConverter.GetBytes(ipv6_packet.pdu_transport.udp_length);
                //foreach (Byte b in udp_length_bytes)
                //{
                //    this.richTextBox1.AppendText(string.Format("{0:X2}", b));
                //}                     


                this.richTextBox1.AppendText("],[UDP Checksum=");
                Byte[] udp_checksum_bytes = BitConverter.GetBytes(ipv6_packet.pdu_transport.udp_checksum);
                foreach (Byte b in udp_checksum_bytes)
                {
                    this.richTextBox1.AppendText(string.Format("{0:X2}", b));
                }


                this.richTextBox1.AppendText("],[App Data:(");
                List<Byte[]> app_data = ipv6_packet.pdu_transport.application_data; //应用层数据
                j = 0;
                foreach (Byte[] B in app_data)
                {
                    for (int k = B.Length - 1; k >= 0; k--)
                    {
                        this.richTextBox1.AppendText("" + string.Format("{0:X2}", B[k]));
                    }

                    //i = 0;
                    //foreach (Byte b in B)
                    //{
                    //    this.richTextBox1.AppendText("" + b.ToString("X"));
                    //    //this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    //    //if (i < B.Length - 1)
                    //    //{
                    //    //    i++;
                    //    //    this.richTextBox1.AppendText("_");
                    //    //}
                    //}
                    if (j < app_data.Count - 1)
                    {
                        j++;
                        this.richTextBox1.AppendText(",");
                    }
                }

                this.richTextBox1.AppendText(")] }\n");
                for (int k = 0; k < (this.richTextBox1.Width) / 6 - 5; k++)
                    this.richTextBox1.AppendText("-");
                this.richTextBox1.AppendText("\n");
            }
        }

        /********************************************
         *  函数名称：Monitor_Frame_802_15_4()
         *  功能：显示802.15.4帧数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void Monitor_Frame_802_15_4(object data)
        {
            Frame_802_15_4 frame = (Frame_802_15_4)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText("[Frame Control=" + frame.frame_control.ToString("X")+
                "],[Sequence Num=" + string.Format("{0:X2}", frame.sequence_number) + 
                "],[Dest PanID=" + frame.dest_panid.ToString("X") +
                "],[Dest Addr=" + string.Format("{0:X16}", frame.dest_addr) + 
                "],[Source PanID=" + frame.source_panid.ToString("X") +
                "],[Source Addr=" +  string.Format("{0:X16}", frame.source_addr) + "],");
               
               
                if(frame.pdu_lowpan_iphc != null)
                {
                    this.richTextBox1.AppendText("6LoWPAN PDU:");
                    Monitor_PDU_LoWPAN_IPHC(frame.pdu_lowpan_iphc);
                }
                   
                else if (frame.pdu_connid != null)
                {
                    this.richTextBox1.AppendText("ConnID PDU:");
                    Monitor_PDU_ConnID(frame.pdu_connid);
                }

            }
        }


        /********************************************
         *  函数名称：Monitor_Frame_802_15_1()
         *  功能：显示802.15.1帧数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void Monitor_Frame_802_15_1(object data)
        {
            Frame_802_15_1 frame = (Frame_802_15_1)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText(
                    "[Access Addr=" + string.Format("{0:X8}", frame.access_addr) +
                    "],[Notice Header=" + string.Format("{0:X2}", frame.notice_header) +
                    "],[Payload Length=" + string.Format("{0:X2}", frame.payload_length) +
                    "],[Device Addr=" + string.Format("{0:X12}", frame.dev_addr) +
                    "],ConnID PDU:");

           
                    Monitor_PDU_ConnID(frame.pdu_connid);
                

            }
        }


        /********************************************
         *  函数名称：Monitor_PDU_ConnID()
         *  功能：显示ConnID PDU数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void Monitor_PDU_ConnID(Object data)
        {
            PDU_ConnID pdu_connid = (PDU_ConnID)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText("{ [Message Identifier=" + string.Format("{0:X2}",pdu_connid.message_identifier) + 
                    "],[ConnID=" + string.Format("{0:X16}",pdu_connid.connid));
                //Byte[] bytes0 = pdu_connid.connid.ElementAt(0);
                //i = 0;
                //foreach (Byte b in bytes0)
                //{
                //    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                //    if (i < bytes0.Length - 1)
                //    {
                //        i++;
                //        this.richTextBox1.AppendText("_");
                //    }
                //}

                this.richTextBox1.AppendText("],[App Data:");
                //Byte[] bytes1 = pdu_connid.application_data.ElementAt(0); //应用层数据
                //foreach (Byte b in bytes1)
                //{
                //    this.richTextBox1.AppendText("" + b.ToString("X"));
                //}

                //this.richTextBox1.AppendText("] }\n");
                List<Byte[]> app_data = pdu_connid.application_data; //应用层数据
                j = 0;
                foreach (Byte[] B in app_data)
                {
                    for (int k = B.Length - 1; k >= 0; k--)
                    {
                        this.richTextBox1.AppendText("" + string.Format("{0:X2}", B[k]));
                    }

                    //i = 0;
                    //foreach (Byte b in B)
                    //{
                    //    this.richTextBox1.AppendText("" + b.ToString("X"));
                    //    //this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    //    //if (i < B.Length - 1)
                    //    //{
                    //    //    i++;
                    //    //    this.richTextBox1.AppendText("_");
                    //    //}
                    //}
                    if (j < app_data.Count - 1)
                    {
                        j++;
                        this.richTextBox1.AppendText(",");
                    }
                }
                this.richTextBox1.AppendText(")] }\n");
                for (int k = 0; k < (this.richTextBox1.Width) / 6 - 5; k++)
                    this.richTextBox1.AppendText("-");
                this.richTextBox1.AppendText("\n");
            } //if (this.richTextBox1.CanFocus)
        }


        /********************************************
         *  函数名称：Monitor_PDU_LoWPAN_IPHC()
         *  功能：显示6LoWPAN PDU数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void Monitor_PDU_LoWPAN_IPHC(Object data)
        {
            PDU_LoWPAN_IPHC pdu_lowpan_iphc = (PDU_LoWPAN_IPHC)data;
            if (this.richTextBox1.CanFocus)
            {
                this.richTextBox1.AppendText("{ [Dispatch=" + pdu_lowpan_iphc.dispatch.ToString("X") + "],[IPHC Header=" +
                    pdu_lowpan_iphc.iphc_header.ToString("X") + "],[Context Identifier=" + pdu_lowpan_iphc.context_identifier.ToString("X") +
                    "],[IP Uncompressed Field=(Hop Limit:");

                Byte[] bytes2 = pdu_lowpan_iphc.IP_uncompressed_field.ElementAt(0); //跳数限制
                foreach (Byte b in bytes2)
                {
                    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                }

                this.richTextBox1.AppendText("),(Source Addr:");
                Byte[] bytes0 = pdu_lowpan_iphc.IP_uncompressed_field.ElementAt(1); //源地址
                i = 1;
                foreach (Byte b in bytes0)
                {
                    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    if (i < bytes0.Length)
                    {
                        if (i % 2 == 0)
                        {
                            this.richTextBox1.AppendText("_");
                        }
                        i++;
                    }
                }

                this.richTextBox1.AppendText("),(Dest Addr:");
                Byte[] bytes1 = pdu_lowpan_iphc.IP_uncompressed_field.ElementAt(2); //目的地址
                i = 1;
                foreach (Byte b in bytes1)
                {
                    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    if (i < bytes1.Length)
                    {
                        if (i % 2 == 0)
                        {
                            this.richTextBox1.AppendText("_");
                        }
                        i++;
                    }
                }

                this.richTextBox1.AppendText(")],[NHC Header:" 
                    + string.Format("{0:X2}", pdu_lowpan_iphc.nhc_header));//下一个首部报头


                this.richTextBox1.AppendText("],[Next Header Field = (Port:");
                Byte[] bytes3 = pdu_lowpan_iphc.NH_field.ElementAt(0); //端口号
                foreach (Byte b in bytes3)
                {
                    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                }

                this.richTextBox1.AppendText("),(Checksum:");
                Byte[] bytes4 = pdu_lowpan_iphc.NH_field.ElementAt(1); //校验和
                i = 0;
                foreach (Byte b in bytes4)
                {
                    //this.richTextBox1.AppendText("" + b.ToString("X"));
                    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    if (i < bytes4.Length - 1)
                    {
                        i++;
                        this.richTextBox1.AppendText("_");
                    }

                }

                this.richTextBox1.AppendText(")],[App Data:(");
                List<Byte[]> app_data = pdu_lowpan_iphc.application_data; //应用层数据
                j = 0;
                foreach (Byte[] B in app_data)
                {
                    for (int k = B.Length-1; k >=0 ; k--)
                    {
                        this.richTextBox1.AppendText("" + string.Format("{0:X2}", B[k]));
                    }
                    //i = 0;
                    //foreach (Byte b in B)
                    //{
                    //    //this.richTextBox1.AppendText("" + b.ToString("X"));
                    //    this.richTextBox1.AppendText("" + string.Format("{0:X2}", b));
                    //    //    if (i < B.Length - 1)
                    //    //    {
                    //    //        i++;
                    //    //        this.richTextBox1.AppendText("_");
                    //    //    }
                    //}
                    if (j < app_data.Count - 1)
                    {
                        j++;
                        this.richTextBox1.AppendText(",");
                    }
                }
                this.richTextBox1.AppendText(")] }\n");
                for(int k=0;k<(this.richTextBox1.Width)/6-5;k++)
                    this.richTextBox1.AppendText("-");
                this.richTextBox1.AppendText("\n");
            }//if (this.richTextBox1.CanFocus)
        }

       /********************************************
        *  函数名称：MonitorMonitorHeartRateData()
        *  功能：显示HeartRateDataType类型数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void MonitorHeartRateData(Object data)
        {
            HeartRateDataType temp = (HeartRateDataType)data;
            if (this.richTextBox1.CanFocus)
                this.richTextBox1.AppendText("[" + temp.HeartRate + "] ");
        }
       /********************************************
        *  函数名称：MonitorTemperatureData()
        *  功能：显示体温类型数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void MonitorTemperatureData(Object data)
        {
            TemperatureDataType temp = (TemperatureDataType)data;
            if (this.richTextBox1.CanFocus)
                this.richTextBox1.AppendText("[" + temp.TemperatureInteger+"."+temp.TemperatureDecimal + "] ");
        }
       /********************************************
        *  函数名称：MonitorBloodPressureData()
        *  功能：显示血压类型数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void MonitorBloodPressureData(Object data)
        {
            //int[] temp = new int[2];
            //temp = (int[])data;

            BloodPressureDataType bpData = (BloodPressureDataType)data;

            //Console.WriteLine(temp[0] + ";" + temp[1]);
            if (this.richTextBox1.CanFocus)
                this.richTextBox1.AppendText("[" + bpData.HighBP + "," + bpData.LowBP + "] ");
        }

       /********************************************
        *  函数名称：MonitorListBloodPressureData()
        *  功能：显示血压列表数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void MonitorListBloodPressureData(object data)
        {
            List<BloodPressureDataType> BPDataList = (List<BloodPressureDataType>)data;

            if (this.richTextBox1.CanFocus)
            {
                foreach (BloodPressureDataType bpData in BPDataList)
                {
                    //Console.WriteLine("[" + bpData.HighBP + "," + bpData.LowBP + "] ");
                    this.richTextBox1.AppendText("[" + bpData.HighBP + "," + bpData.LowBP + "] ");
                }
            }
            
        }

        /********************************************
         *  函数名称：MonitorListTemperatureData()
         *  功能：显示体温列表数据
         *  参数：data 表示所要显示的数据
         *  返回值：无
         * ******************************************/
        private void MonitorListTemperatureData(object data)
        {
            List<TemperatureDataType> TempDataList = (List<TemperatureDataType>)data;

            if (this.richTextBox1.CanFocus)
            {
                foreach (TemperatureDataType tempData in TempDataList)
                {
                    //Console.WriteLine("[" + tempData.TemperatureInteger + "." + tempData.TemperatureDecimal + "] ");
                    this.richTextBox1.AppendText("[" + tempData.TemperatureInteger + "." + tempData.TemperatureDecimal + "] ");
                }
            }
        }

       /********************************************
        *  函数名称：MonitorListHeartRateData()
        *  功能：显示心率列表数据
        *  参数：data 表示所要显示的数据
        *  返回值：无
        * ******************************************/
        private void MonitorListHeartRateData(object data)
        {
            List<HeartRateDataType> HRDataList = (List<HeartRateDataType>)data;

            if (this.richTextBox1.CanFocus)
            {
                foreach (HeartRateDataType hrData in HRDataList)
                {
                    this.richTextBox1.AppendText("[" + hrData.HeartRate + "] ");
                }
            }
        }

 


    }
}
