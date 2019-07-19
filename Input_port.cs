using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Netron.GraphLib;

namespace XModel
{
    //端口类
    public class Input_port : Port
    {
        //private Component component; //端口所属的组件
        //public Input_port()
        //{
        //    Port_director1="input"; //端口方向 
        //    BackgroundImage1 = new Bitmap(@"..\..\..\picture\port1.png");
        //    this.Rectangle = new RectangleF(100, 100, 15, 15);
        //}

        public Input_port(String port_ID, String port_name, String port_director, String port_type, Component component)
            : base(port_ID, port_name, port_director, port_type, component)
        {
            //this.component = component;
            //Port_director1 = "input"; //端口方向 
            //BackgroundImage1 = new Bitmap(@"..\..\..\picture\port1.png");
            //this.Rectangle = new RectangleF(100, 100, 15, 15);
            //this.Port_ID1 = port_ID;
            //this.Port_director1 = port_director;
            //this.Port_type1 = port_type;
        }

        //重写Shape的ConnectionPoint方法,返回Connector的具体坐标
        public override PointF ConnectionPoint(Connector c)
        {
            if (c == PortConnector1)
            {
                //返回端口连接点坐标
                return new PointF(Rectangle.Left+5 , Rectangle.Top + Rectangle.Height / 2-1);
            }
            return new PointF(0, 0);
        }// public override PointF ConnectionPoint(Connector c)
        //public Component BelongTo()
        //{
        //    return this.component;
        //}

    } //public class Port : Shape
}
