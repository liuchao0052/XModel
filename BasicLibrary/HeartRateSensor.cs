using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //心率传感器组件
    public class HeartRateSensor : Component
    {
        private HeartRateDataType sampled_hr_data; //采样心率数据

        //private int period = 1000;     //采样周期
        private int frequency = 1;      //采样频率
        private int i = 0;              //计数
        private int noise;              //噪音数据
        private int noise_low = -50;    //噪音数据下界
        private int noise_high = 150;   //噪音数据上界


        public HeartRateSensor(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\HeartRateSensor.png");

            this.bmp = Resource1.HeartRateSensor;
            this.Text = "HeartRateSensor";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "HeartRateSensor";
        }


       /********************************************
        * 函数名称：run()
        * 功能：心率传感器组件执行函数
        * 参数：无
        * 返回值：无
        * *****************************************/
        public void run()
        {
            while (true)
            {
                if (Form1.stop)
                {
                    this.EmptyingQueue();
                    return;
                }
                //1、接收输入端口数据
                ComponentDataReceive(this);
                //2、执行体温传感器功能
                CollectHeartRateData();
                //3、发送体温传感器处理后的数据
                ComponentDataTransfer(this);
            }
        }

       /**********************************************
        *  函数名称：GeneratingNoiseData()
        *  功能：随机噪音数据生成函数
        *  参数：low 噪音数据下界；high 噪音数据上界
        *  返回值：噪音数据
        * *********************************************/
        public int GeneratingNoiseData(int low, int high)
        {
            Random rand = new Random();
            bool b = (rand.Next() % 2 == 0 && rand.Next() % 3 == 0 && rand.Next() % 5 == 0);
            if (b)
            {
                return rand.Next(low, high);
            }
            else
                return 0;
        }

        /****************************************************************
        *  函数名称：CollectHeartRateData()
        *  功能：体温传感器采样数据，采样周期period,同时添加随机噪音数据
        *  参数：无
        *  返回值：无
        * **************************************************************/
        public void CollectHeartRateData()
        {
            //int[] temp = new int[2];
            HeartRateDataType temp = null;

            sampled_hr_data = new HeartRateDataType();

            //生成噪音数据
            noise = this.GeneratingNoiseData(noise_low, noise_high);
            //Console.WriteLine("Component_reveice_queue.Count2=" + this.Component_reveice_queue.Count);
            try
            {
                //若组件接收队列不为空
                if (this.Component_reveice_queue.Count > 0)
                {
                    //temp = (int[])this.Component_reveice_queue.Dequeue();
                    temp = (HeartRateDataType)this.Component_reveice_queue.Dequeue();

                    //Console.WriteLine("Component_reveice_queue.Count3=" + this.Component_reveice_queue.Count);
                    i++;
                    if (i == frequency)
                    {
                        //采样数据添加噪音数据
                        sampled_hr_data.HeartRate = (Int16)(temp.HeartRate + noise);
                    
                        //样本数据进入组件发送队列
                        this.Component_send_queue.Enqueue(sampled_hr_data);
                        //Console.WriteLine("Component_send_queue.Count=" + this.Component_send_queue.Count);
                        i = 0;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("HRS错误情况" + e.Message + e.StackTrace);
            }

            //Thread.Sleep(period); //采样周期
        }




    }
}
