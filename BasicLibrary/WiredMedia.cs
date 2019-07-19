using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //有线媒介组件
    public class WiredMedia : Component
    {
        public WiredMedia(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WiredMedia.png");

            this.bmp = Resource1.WiredMedia;
            this.Text = "WiredMedia";
            this.Rectangle = new RectangleF(50, 50, 77, 25); //设置组件位置及大小
            this.name = "WiredMedia";
        }
    }
}
