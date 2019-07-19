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
    //监控器组件
    public class MyMonitor : Component
    {
        public MyMonitor(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\Monitor.png");

            this.bmp = Resource1.Monitor;
            this.Text = "Monitor";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "Monitor";
        }
        /********************************************
         *  函数名称：run()
         *  功能：监控器组件执行函数
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void run()
        {
            monitor(); //显示监视窗口
        }
        /********************************************
         *  函数名称：monitor()
         *  功能：监控函数，监控组件数据
         *  参数：无
         *  返回值：无
         * ******************************************/
        public void monitor()
        {
            Form fm = new Form_monitor(this);
            fm.Show();
        }
    }
}
