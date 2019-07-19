using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Netron.GraphLib;

namespace XModel.BasicLibrary
{
    //血压组件
    public class BloodPressure : Component
    {
        //public List<int[]> list_bloodPressureDatas; //血压数据列表
        //public ManualResetEvent manualResetEvent; //通知线程事件

        //private int[] bloodPressureData; //血压数据
        private BloodPressureDataType bpData; //血压数据

        Int16 HighPressure = 120; //高压
        Int16 LowPressure = 80;  //低压

        public BloodPressureDataType BpData
        {
            get { return bpData; }
            set { bpData = value; }
        }

        private int delay = 100; //延时时间
        //private Queue<int[]> BPDataQueue = new Queue<int[]>(1000); //血压数据队列

        //private Queue<int[]> BPDataQueue1
        //{
        //    get { return BPDataQueue; }
        //    set { BPDataQueue = value; }
        //}

        //public int[] BloodPressureData
        //{
        //    get { return bloodPressureData; }
        //    set { bloodPressureData = value; }
        //}
        
        public BloodPressure(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\bloodpressure.png");

            this.bmp = Resource1.BloodPressure;

            this.Text = "BloodPressure";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "BloodPressure";
            //list_bloodPressureDatas = new List<int[]>();            
        }

        /********************************************
         * 函数名称：run()
         * 功能：血压组件执行函数
         * 参数：x 表示血压数据获取方式的选择
         * 返回值：无
         * *****************************************/
        public void run(object x)
        {
            while (true)
            {
                if (Form1.stop)
                {
                    //MessageBox.Show("血压组件终止！");
                    this.EmptyingQueue();
                    return;
                }
                //if (Form1.pause)
                //{
                //    //MessageBox.Show("血压组件暂停！");
                //    this.manualResetEvent = new ManualResetEvent(false);
                //    this.manualResetEvent.WaitOne();
                //}
                if ((int)x == 1) //x=1,基于函数模拟生成血压数据
                {
                    GeneratingBloodPressureData();
                   
                    //ComponentDataTransfer(this, bloodPressureData);
                    ComponentDataTransfer(this);
                }
                if ((int)x == 2) //x=2,基于串口通信获取采集的血压数据
                {
                    Get_serial_BloodPressureData();
                   
                }
                if ((int)x == 3) //x=3,基于MIT-BIH的数据集获取血压数据
                {
                    Get_MIT_BIH_BloodPressureData();
                }
            }// while (true)
        }// public void run(object x)


        /********************************************
         *  函数名称：GeneratingBloodPressureData()
         *  功能：基于函数模拟生成血压数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void GeneratingBloodPressureData()
        {

            bpData = new BloodPressureDataType(); 
         
            Random rand = new Random();

            if (rand.Next() % 2 == 0){
                bpData.HighBP = (Int16)(HighPressure + rand.Next(-15, 15));
                bpData.LowBP = (Int16)(LowPressure + rand.Next(-10, 10));
            }               
            else if (rand.Next() % 3 == 0 && rand.Next() % 4 == 0){
                bpData.HighBP = (Int16)(HighPressure + rand.Next(-20, 20));
                bpData.LowBP = (Int16)(LowPressure + rand.Next(-10, 10));
            }              
            else{
                bpData.HighBP = (Int16)(HighPressure + rand.Next(-5, 5));
                bpData.LowBP = (Int16)(LowPressure + rand.Next(-5, 5));
            }              

            this.Component_send_queue.Enqueue(bpData);//血压数据进行组件发送队列
            Thread.Sleep(delay);

        }

        /********************************************
         *  函数名称：Get_serial_BloodPressureData()
         *  功能：基于串口通信获取血压数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void Get_serial_BloodPressureData()
        {
            //可扩展...
           
        }

        /********************************************
         *  函数名称：Get_MIT_BIH_BloodPressureData()
         *  功能：基于MIT-BIH的数据集获取血压数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void Get_MIT_BIH_BloodPressureData()
        {
            //可扩展...
           
        }

    }// public class BloodPressure : Component
}
