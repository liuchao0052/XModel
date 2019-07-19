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
    public class Output_port : Port
    {
        //private Component component; //端口所属的组件
        public Output_port()
        {
            Port_director1 = "output"; //端口方向 
            //BackgroundImage1 = new Bitmap(@"..\..\..\picture\port1.png");

            this.BackgroundImage1 = Resource1.port1;
            
            this.Rectangle = new RectangleF(100, 100, 15, 15);
        }
        public Output_port(String port_ID, String port_name, String port_director, String port_type, Component component)
            : base(port_ID, port_name, port_director, port_type, component)
        {
            //this.component = component;
            //Port_director1 = "output"; //端口方向 
            //BackgroundImage1 = new Bitmap(@"..\..\..\picture\port1.png");
            //this.Rectangle = new RectangleF(100, 100, 15, 15);
            //this.Port_ID1 = port_ID;
            //this.Port_director1 = port_director;
            //this.Port_type1 = port_type;
        }

        protected override void InitEntity()
        {
            base.InitEntity();
            Pen = new Pen(Color.FromArgb(167, 58, 95));
            ShapeColor = Color.FromArgb(255, 253, 205);
            //this.Rectangle = new RectangleF(100, 100, 15, 15);

            //设定大小不可更改
            this.IsResizable = false;

            Text = this.Port_ID1;
            //MessageBox.Show(Text);
            //Font = new Font("宋体", 10);

            //鼠标点击响应
            //this.OnMouseDown += new MouseEventHandler(this.Component_OnMouseDown);
            //双击图标修改文字
            //OnMouseDown += SequenceShape_OnMouseDown;

            //创建连接点,名称“PortConnector”
            //Connector构造函数的第一个参数是Shape对象，代表的Connector对象依附的图形对象;
            //第二个参数是Connector的名字
            //第三个参数表示是否允许Connector有多个连接
            PortConnector1 = new Connector(this, "PortConnector", true);
            //将创建的连接点加入连接点集合
            Connectors.Add(PortConnector1);

        }//protected override void InitEntity()
        //public Component BelongTo()
        //{
        //    return this.component;
        //}
    } //public class Port : Shape
}
