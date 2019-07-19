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
    public class Inout_port : Port
    {
        //private Component component; //端口所属的组件
        public Inout_port():base()
        {
            this.Port_director1 = "inout"; //端口方向 
            //this.BackgroundImage1 = new Bitmap(@"..\..\..\picture\port2.png");

            this.BackgroundImage1 = Resource1.port2;
            
            this.Rectangle = new RectangleF(100, 100, 12, 8);
        }

        public Inout_port(String port_ID, String port_name,String port_director, String port_type, Component component)
            : base(port_ID, port_name,port_director, port_type, component)
        {
            //this.component = component;
            //this.Port_director1 = "inout"; //端口方向 
            //this.BackgroundImage1 = new Bitmap(@"..\..\..\picture\port2.png");

            this.BackgroundImage1 = Resource1.port2;
            this.Rectangle = new RectangleF(100, 100, 12, 8);
          
            //this.Port_ID1 = port_ID;
            //this.Port_director1 = port_director;
            //this.Port_type1 = port_type;
        }
        //public Component BelongTo()
        //{
        //    return this.component;
        //}
        //public override bool IsSelected
        //{
        //    set
        //    {
        //        //the base keeps the value
        //        base.IsSelected = value;
        //    }
        //    //get
        //    //{
        //    //    //return base.IsSelected;
        //    //}
        //}
       
    }//public class Port : Shape
}
