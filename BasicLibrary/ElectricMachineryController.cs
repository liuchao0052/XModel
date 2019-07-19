using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //电机控制器组件
    public class ElectricMachineryController : Component
    {
        public ElectricMachineryController(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\ElectricMachineryController.png");

            this.bmp = Resource1.ElectricMachineryController;
            this.Text = "ElectricMachineryController";
            this.Rectangle = new RectangleF(50, 50, 70, 45); //设置组件位置及大小
            this.name = "ElectricMachineryController";
        }
    }
}
