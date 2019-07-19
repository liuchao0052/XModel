using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{

    //数据分析器组件
    public class DataAnalyzer : Component
    {

        bool isValid = true;  //分析数据是否合法

        public DataAnalyzer(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\DataAnalyzer.png");

            this.bmp = Resource1.DataAnalyzer;

            this.Text = "DataAnalyzer";
            this.Rectangle = new RectangleF(50, 50, 70, 56); //设置组件位置及大小
            this.name = "DataAnalyzer";
        }

       /***************************************************************************
        *  函数名称：DataAnalysis
        *  功能：数据分析
        *  参数：无
        *  返回值：无
        * *************************************************************************/
        public void DataAnalysis()
        {
            //int uncompressed_field_byte_num = 0; //非压缩字段字节数            
            try
            {
                Object data = null;
                if (this.Component_reveice_queue.Count > 0)
                {
                    //读取信息分析控制模块组件接收队列数据
                    data = this.Component_reveice_queue.Dequeue();

                    switch (data.GetType().GetGenericArguments()[0].Name)
                    {
                        case "BloodPressureDataType":
                            AnalyticalBloodPressureData(data); //分析血压数据
                            break;
                        case "TemperatureDataType":
                            AnalyticalTemperatureData(data);   //分析体温数据
                            break;
                        case "HeartRateDataType":
                            AnalyticalHeartRateData(data);     //分析心率数据
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DataAnalysis错误情况：" + e.Message);
            }

        }


       /******************************************************************************
        *  函数名称：AnalyticalHeartRateData
        *  功能：分析心率数据
        *  参数：data 所要分析的数据
        *  返回值：无
        * ***************************************************************************/
        private void AnalyticalHeartRateData(Object data)
        {
            List<HeartRateDataType> HRDataList = (List<HeartRateDataType>)data;

            isValid = true;
            foreach (HeartRateDataType hrData in HRDataList)
            {

                if (hrData.HeartRate < 60 || hrData.HeartRate > 180) //若心率数据低于0或高于200，判断为异常数据，丢弃
                    isValid = false;

                if (isValid)//正常数据进入信息分析模块组件发送队列
                    this.Component_send_queue.Enqueue(hrData);

                isValid = true;
            }
        }


       /******************************************************************************
        *  函数名称：AnalyticalTemperatureData
        *  功能：分析体温数据
        *  参数：data 所要分析的数据
        *  返回值：无
        * ***************************************************************************/
        private void AnalyticalTemperatureData(Object data)
        {
            List<TemperatureDataType> TempDataList = (List<TemperatureDataType>)data;

            isValid = true;
            foreach (TemperatureDataType tempData in TempDataList)
            {
                if (tempData.TemperatureInteger < 32 || tempData.TemperatureInteger > 43) //若体温数据低于30或高于45，判断为异常数据，丢弃
                    isValid = false;

                if (isValid)//正常数据进入信息分析模块组件发送队列
                    this.Component_send_queue.Enqueue(tempData);

                isValid = true;
            }
        }


       /******************************************************************************
        *  函数名称：AnalyticalBloodPressureData
        *  功能：分析血压数据
        *  参数：data 所要分析的数据
        *  返回值：无
        * ***************************************************************************/
        private void AnalyticalBloodPressureData(Object data)
        {
            List<BloodPressureDataType> BPDataList = (List<BloodPressureDataType>)data;
            
            isValid = true;
            foreach (BloodPressureDataType bpData in BPDataList)
            {
                if (bpData.HighBP < 70 || bpData.HighBP > 200) //若高压低于60或高于200，判断为异常数据，丢弃
                    isValid = false;
                if (bpData.LowBP < 50 || bpData.LowBP > 150) //若低压低于20或高于150，判断为异常数据，丢弃
                    isValid = false;

                if (isValid) //正常数据进入信息分析模块组件发送队列
                    this.Component_send_queue.Enqueue(bpData);

                isValid = true;
            }
        }




    }
}
