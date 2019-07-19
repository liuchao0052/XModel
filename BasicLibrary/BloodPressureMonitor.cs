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
    //血压监控器组件
    public class BloodPressureMonitor : Component
    {
        public BloodPressureMonitor(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\BloodPressureMonitor.png");

            this.bmp = Resource1.BloodPressureMonitor;

            this.Text = "BloodPressureMonitor";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "BloodPressureMonitor";
        }
        /********************************************
         *  函数名称：run()
         *  功能：血压监控器组件执行函数
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void run()
        {
            Monitor();
        }

       /********************************************
        *  函数名称：Monitor
        *  功能：显示血压数据
        *  参数：this 表示显示窗口对应的组件
        *  返回值：无
        * ******************************************/

        public void Monitor()
        {
            Form fm = new Form_BloodPressureMonitor(this);
            fm.Show();
        }


    }
}
