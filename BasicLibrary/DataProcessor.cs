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
    //数据处理器组件
    public class DataProcessor : Component
    {
        public Hashtable NodeIID_NetPrefix_Mapping = new Hashtable();  //“节点标识-网络前缀”映射表

        private UInt16[] IPv6_address;  //模块IPv6地址

        bool isReceive;  //判断是否接受报文

        List<Byte[]> LoWPAN_data = new List<byte[]>();       //6LoWPAN数据
        List<Byte[]> ConnID_data = new List<byte[]>();       //ConnID数据
        List<Byte[]> BLE_data = new List<byte[]>();          //BLE数据
        List<Byte[]> ZigBee_data = new List<byte[]>();       //ZigBee数据
        List<Byte[]> WirelessHART_data = new List<byte[]>(); //WirelessHART数据
        //... ...


        List<BloodPressureDataType> BloodPressure_data = new List<BloodPressureDataType>();  //血压数据
        List<TemperatureDataType> Temperature_data = new List<TemperatureDataType>();        //体温数据
        List<HeartRateDataType> HeartRate_data = new List<HeartRateDataType>();              //心率数据
        //... ...


        private static object lockObject = new object();

        public UInt16[] IPv6_address1
        {
            get { return IPv6_address; }
            set { IPv6_address = value; }
        }

        public DataProcessor(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\DataProcessor.png");

            this.bmp = Resource1.DataProcessor;
            this.Text = "DataProcessor";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "DataProcessor";
        }

       /***************************************************************************
        *  函数名称：NetworkDataProcessing
        *  功能：进行网络数据处理
        *  参数：无
        *  返回值：无
        * *************************************************************************/
        public void NetworkDataProcessing()
        {
            //int uncompressed_field_byte_num = 0; //非压缩字段字节数            
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取网络数据处理模块组件接收队列数据
                    data = this.Component_reveice_queue.Dequeue();
                    PDU_Network IPv6_packet = (PDU_Network)data;

                    //检查目的地址是否为服务器IPv6地址
                    isReceive = true;             
                    for (Int16 i = 0; i < 8; i++)
                    {
                        if (IPv6_packet.dest_ipv6_address[i] != IPv6_address[i])
                            isReceive = false; //丢弃该IPv6报文
                    }

                    if (isReceive)
                        NetworkPacketProcess(IPv6_packet); //进行网络报文处理                 

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("MessageBuffering错误情况：" + e.Message);
            }
        }

       /***************************************************************************
        *  函数名称：NetworkPacketProcess
        *  功能：进行网络报文处理
        *        依据源IPv6地址接口标识获得节点标识，填充“节点标识-网络前缀”映射表
        *        依据源IPv6地址网络前缀判断通信技术类型
        *        依据源端口号判断数据类型
        *  参数：无
        *  返回值：无
        * *************************************************************************/
        private void NetworkPacketProcess(PDU_Network IPv6_packet)
        {
            //获取源IPv6地址
            UInt16[] source_IPv6_addr = IPv6_packet.source_ipv6_address;
            UInt16[] IPv6_Prefix = new UInt16[4];  //网络前缀
            UInt16[] IPv6_IID = new UInt16[4];     //接口标识
            bool[] Category = new bool[4];         //子网类别
            bool[] Tech_ID = new bool[4];          //通信技术类型


            for (Int16 i = 0; i < 4; i++)
            {
                IPv6_Prefix[i] = source_IPv6_addr[i];
            }
            int j = 0;
            for (Int16 i = 4; i < 8; i++)
            {
                IPv6_IID[j++] = source_IPv6_addr[i];
            }

            //填充“节点标识-网络前缀”映射表
            NodeIID_NetPrefix_Mapping.Add(IPv6_IID, IPv6_Prefix);

            //获取网络前缀第四字段
            Byte[] temp_arr = BitConverter.GetBytes(IPv6_Prefix[3]);
            BitArray temp_bitarr = new BitArray(temp_arr); //同一字节低位优先

            //网络前缀中，第四字段5、6、7、8位为子网类别，对应存储位为4、3、2、1

            j = 0;
            for (Int16 i = 3; i >= 0; i--)
            {
                Category[j++] = temp_bitarr[i];
            }


            //若子网类别为0x8;0x9;0xA;0xB;则可判断为源节点来自物联子网
            if ((Category[0] && !Category[1] && !Category[2] && !Category[3]) ||
                (Category[0] && !Category[1] && !Category[2] && Category[3]) ||
                (Category[0] && !Category[1] && Category[2] && !Category[3]) ||
                (Category[0] && !Category[1] && Category[2] && Category[3]))
            {
                //获取通信技术类型
                //网络前缀中，第四字段9、10、11、12位为子网类别，对应存储位为15、14、13、12
                j = 0;
                for (Int16 i = 15; i >= 12; i--)
                {
                    Tech_ID[j++] = temp_bitarr[i];

                }

                //Console.WriteLine("----------------------------------------------------------------");
                //Console.Write(Tech_ID[0] + " "+Tech_ID[1] + " "+Tech_ID[2] + " "+Tech_ID[3] + " ");

                //若Tech ID为0x9，则采用6LoWPAN技术
                if (Tech_ID[0] && !Tech_ID[1] && !Tech_ID[2] && Tech_ID[3])
                {
                    LoWPAN_data = IPv6_packet.pdu_transport.application_data;
                    //Console.WriteLine("LoWPAN_data长度=" + LoWPAN_data.Count);


                    switch (IPv6_packet.pdu_transport.source_port)
                    {
                        case 0xF0BF:  //若采用6LoWPAN技术的报文源端口号为0xF0BF,则为血压数据

                            BloodPressure_data.Clear(); //血压数据列表变量清空

                            for (int i = 0; i < LoWPAN_data.Count - 1; i = i + 2)
                            {
                                BloodPressureDataType bpData = new BloodPressureDataType();

                                bpData.HighBP = BitConverter.ToInt16(LoWPAN_data[i], 0);
                                bpData.LowBP = BitConverter.ToInt16(LoWPAN_data[i + 1], 0);

                                BloodPressure_data.Add(bpData);

                            }
                            //Console.WriteLine("BloodPressure_data长度=" + BloodPressure_data.Count);

                            //lock (lockObject)
                            //{
                            //血压数据进入网络数据处理组件发送队列
                            this.Component_send_queue.Enqueue(BloodPressure_data);
                            //}
                            break;

                        //可扩展... ... 
                    }
                }

                //若Tech ID为0xA，则采用ConnID技术
                else if (Tech_ID[0] && !Tech_ID[1] && Tech_ID[2] && !Tech_ID[3])
                {
                    ConnID_data = IPv6_packet.pdu_transport.application_data;

                    //Console.WriteLine(IPv6_packet.pdu_transport.source_port + " ");

                    switch (IPv6_packet.pdu_transport.source_port)
                    {
                        case 0xF0BF: //若采用ConnID技术且报文源端口号为0xF0BF,则为体温数据

                            Temperature_data.Clear();  //体温数据列表变量清空
                            for (int i = 0; i < ConnID_data.Count - 1; i = i + 2)
                            {
                                TemperatureDataType tempData = new TemperatureDataType();

                                tempData.TemperatureInteger = ConnID_data[i][0];
                                tempData.TemperatureDecimal = ConnID_data[i + 1][0];

                                Temperature_data.Add(tempData);

                            }

                            this.Component_send_queue.Enqueue(Temperature_data);


                            break;

                        case 0xF0BE: //若采用ConnID技术且报文源端口号为0xF0BE,则为心率数据


                            HeartRate_data.Clear();  //心率数据列表变量清空
                            for (int i = 0; i < ConnID_data.Count - 1; i = i + 1)
                            {
                                HeartRateDataType hrData = new HeartRateDataType();

                                hrData.HeartRate = BitConverter.ToInt16(ConnID_data[i], 0);

                                HeartRate_data.Add(hrData);

                            }

                            this.Component_send_queue.Enqueue(HeartRate_data);
                            break;
                    }
                }
            }
        }





    }
}
