using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;

namespace XModel.BasicLibrary
{
    //802.11信道组件
    public class Channel802_11 : Component
    {
        public Channel802_11(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
            : base(graphControl, input_ports, output_ports, inout_ports)
        {
            //this.bmp = new Bitmap(@"..\..\..\picture\WirelessMedia.png");

            this.bmp = Resource1.WirelessMedia;
            this.Text = "802.11Channel";
            this.Rectangle = new RectangleF(50, 350, 74, 32); //设置组件位置及大小
            this.name = "802.11Channel";
        }
    }
}
