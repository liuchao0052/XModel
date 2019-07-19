using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Collections;
using System.Windows.Forms;

namespace XModel.BasicLibrary
{
    //显示控制器组件
    public class DisplayController : Component
    {
        public DisplayController(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\DisplayController.png");

            this.bmp = Resource1.DisplayController;

            this.Text = "DisplayController";
            this.Rectangle = new RectangleF(50, 50, 70, 55); //设置组件位置及大小
            this.name = "DisplayController";
        }
        /********************************************
         *  函数名称：run()
         *  功能：显示控制器组件执行函数
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void run()
        {
            //Display();
            MedicalDataMonitoring();
        }

       /********************************************
        *  函数名称：Display()
        *  功能：创建数据显示窗口，动态显示数据信息
        *  参数：this 表示显示窗口对应的组件
        *  返回值：无
        * ******************************************/

        public void Display()
        {
            Form fm = new DisplayForm(this);
            fm.Show();
        }

       /********************************************
        *  函数名称：MedicalDataMonitoring()
        *  功能：健康医疗数据实时监控
        *  参数：this 表示显示窗口对应的组件
        *  返回值：无
        * ******************************************/
        public void MedicalDataMonitoring()
        {
            try
            {
                Form fm = new Form_MedicalDataMonitor(this);
                fm.Show();
            }

            catch (Exception e)
            {
                Console.WriteLine("MedicalDataMonitoring错误情况：" + e.Message + " " + e.StackTrace);
            }

        }


    }
}
