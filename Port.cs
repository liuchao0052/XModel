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
    public class Port : Shape
    {
        private Component component;      //端口所属的组件
        private String Port_ID;           //端口ID 
        private String Port_name;         //端口名称
        private String Port_director;     //端口方向
        private String Port_type;         //端口类型      
        private Bitmap BackgroundImage;   //端口默认背景图片  
        //public RectangleF Rectangle;    //端口位置及大小
        //public Point location;          //端口位置
        private Connector PortConnector;  //端口连接点
        private Queue<Object> Port_queue; //端口内部队列

        public Component Component
        {
            get { return component; }
            set { component = value; }
        }
        public Component BelongTo()
        {
            return this.component;
        }
        public String Port_ID1
        {
            get { return Port_ID; }
            set { Port_ID = value; }
        }
        public String Port_name1
        {
            get { return Port_name; }
            set { Port_name = value; }
        }
        public String Port_director1
        {
            get { return Port_director; }
            set { Port_director = value; }
        }
        public String Port_type1
        {
            get { return Port_type; }
            set { Port_type = value; }
        }
        public Bitmap BackgroundImage1
        {
            get { return BackgroundImage; }
            set { BackgroundImage = value; }
        }
        public Connector PortConnector1
        {
            get { return PortConnector; }
            set { PortConnector = value; }
        }
        public Queue<Object> Port_queue1
        {
            get { return Port_queue; }
            set { Port_queue = value; }
        }
        public Port()
        {

        }
        public Port(String port_ID,String port_name, String port_director, String port_type, Component component)
        {
            
            //this.BackgroundImage = new Bitmap(@"..\..\..\picture\port1.png");

            this.BackgroundImage1 = Resource1.port1;

            this.Rectangle = new RectangleF(100, 100, 15, 15);
            this.Port_queue = new Queue<object>(2000);
            this.Port_ID1 = port_ID;
            this.Port_director1 = port_director;
            this.Port_type1 = port_type;
            this.Port_name1 = port_name;
            this.component = component;
            this.Component.array_portID.Add(port_ID); //向组件端口ID列表添加端口ID
            
            //this.OnMouseMove += new MouseEventHandler(Port_OnMouseMove);
            //this.Rectangle = new RectangleF(100, 100, 15, 15);        
            //this.OnMouseDown += new MouseEventHandler(Port_OnMouseDown);
        }

        //private void Port_OnMouseDown(object sender, MouseEventArgs e)
        //{
        //    this.IsSelected
        //}

        //改写Shape的InitEntity方法
        //初始化对象的矩形坐标，设定画边框的画笔Pen和Shape的背景颜色ShapeColor
        protected override void InitEntity()
        {
            base.InitEntity();
            Pen = new Pen(Color.FromArgb(167, 58, 95));
            ShapeColor = Color.FromArgb(255, 253, 205);
            //this.Rectangle = new RectangleF(100, 100, 15, 15);

            //设定大小不可更改
            this.IsResizable = false;

            Text = this.Port_ID;
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
            PortConnector = new Connector(this, "PortConnector", true);
            //将创建的连接点加入连接点集合
            Connectors.Add(PortConnector);
           
        }

        //重写ShapeMenu()方法，在GraphControl第1456行调用
        public override MenuItem[] ShapeMenu()
        {
            ////菜单选项——“端口名配置”
            //创建“端口名配置”选项
            MenuItem portName = new System.Windows.Forms.MenuItem();
            portName.Name = "Port Name";
            //ports.Size = new System.Drawing.Size(180, 22);
            portName.Text = "Port Name";
            portName.Click += new EventHandler(this.portNameMenuItem_Click);
            return new System.Windows.Forms.MenuItem[] {
                   portName};
        }//public override MenuItem[] ShapeMenu()

        //private void Port_OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    this.IsSelected = false; //不允许端口移动
        //    throw new NotImplementedException();
        //}//protected override void InitEntity()
        
        //改写Shape的Paint方法，进行具体的画图
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            //g.FillRectangle(new SolidBrush(ShapeColor), Rectangle);
            //g.DrawRectangle(Pen, System.Drawing.Rectangle.Round(Rectangle));
            //Bitmap bmp = new Bitmap(@"..\..\..\picture\port1.png");
            //int width = bmp.Width;
            //int height = bmp.Height;
            g.DrawImage(
                 this.BackgroundImage,
                 this.Rectangle);

            ////添加文字
            //if (!string.IsNullOrEmpty(Text))
            //    g.DrawString(Text, this.Font, this.TextBrush,
            //        System.Drawing.RectangleF.Inflate(Rectangle, -2, -4));
        }// public override void Paint(Graphics g)

        //重写Shape的ConnectionPoint方法,返回Connector的具体坐标
        public override PointF ConnectionPoint(Connector c)
        {
            if (c == PortConnector)
            {
                //返回端口连接点坐标
                return new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);
            }
            return new PointF(0, 0);
        }// public override PointF ConnectionPoint(Connector c)

        //public Component BelongTo()
        //{
        //    return this.component;
        //}

        //“端口名配置”选项点击事件
        public void portNameMenuItem_Click(object sender, EventArgs e)
        {
            //端口配置表单
            Form portNameForm = new Form_portName(this);
            portNameForm.Show();
        }//portsToolStripMenuItem_Click

    } //public class Port : Shape
}
