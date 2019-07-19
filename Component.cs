using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Netron.GraphLib;
using System.Collections;
using Netron.GraphLib.UI;
//using Netron.GraphLib.Interfaces;


namespace XModel
{
    //组件基类
    public class Component : Shape
    {
        //TextBox m_tb = null;

        public String name; //组件名称
        public String ID; //组件ID
        public Bitmap bmp; //组件背景图片
        public GraphControl graphControl; //组件所在的画布
        public bool IsCompositeComponnet; //是否为复合组件

        public Form InsideForm;           //复合组件内部结构

        public Queue<Object> Component_send_queue; //组件内部发送队列
        public Queue<Object> Component_reveice_queue; //组件内部接收队列

        //连接点
        //private Connector m_leftConnector;
        //private Connector m_rightConnector;

        public Input_port[] input_ports;   //组件输入端口数组
        public Output_port[] output_ports; //组件输出端口数组
        public Inout_port[] inout_ports;   //组件输入输出端口数组

        public ArrayList array_portID; //组件端口ID数组

        //public MouseEventHandler OnMouseUp;
        //public MouseEventHandler OnMouseDown;

        //组件ID 计数
        public static int  component_ID = 1;

        private static object lockObject = new object();
       
        public Component()
        {
            this.IsCompositeComponnet = false; //默认不为复合组件
            this.Component_send_queue = new Queue<object>(2000);
            this.Component_reveice_queue = new Queue<object>(2000);
            this.array_portID = new ArrayList();
            this.Rectangle = new RectangleF(50, 50, 80, 50); //设置组件位置及大小

            //this.bmp = new Bitmap(@"..\..\..\picture\Default.png");

            //this.bmp.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.bmp = (Bitmap)Bitmap.FromFile(@"/Images/Default.png");

            this.bmp = Resource1.Default;

            //this.Location = new System.Drawing.Point(50, 50);
            //this.OnMouseDown += Component_OnMouseDown; 
            this.OnMouseUp += new MouseEventHandler(Component_OnMouseUp);
            this.OnMouseDown += new MouseEventHandler(Component_OnMouseDown);
        }

        /********************************************************************************
         * 函数名称：Component()
         * 功能：构造函数
         * 参数：graphControl 组件所在画布；input_ports 组件输入端口组数集合；
         *       output_ports 组件输出端口组数集合；inout_ports 组件输入输出端口组数集合；
         * 返回值：无
         * *******************************************************************************/
        public Component(GraphControl graphControl, Input_port[] input_ports,
            Output_port[] output_ports, Inout_port[] inout_ports)
        {
            this.IsCompositeComponnet = false; //默认不为复合组件
            this.input_ports = input_ports;
            this.output_ports = output_ports;
            this.inout_ports = inout_ports;

            this.Component_send_queue = new Queue<object>(2000);
            this.Component_reveice_queue = new Queue<object>(2000);

            this.graphControl = graphControl;
            this.array_portID = new ArrayList(); 
            this.Rectangle = new RectangleF(50, 50, 80, 50); //设置组件位置及大小

            //this.bmp = new Bitmap(@"..\..\..\picture\Default.png");


            this.bmp = Resource1.port1;

            //this.Location = new System.Drawing.Point(50, 50);
            //this.OnMouseDown += Component_OnMouseDown; 
            this.OnMouseUp += new MouseEventHandler(Component_OnMouseUp);
            this.OnMouseDown += new MouseEventHandler(Component_OnMouseDown);
        }

        /********************************************
        * 函数名称：Component()
        * 功能：构造函数
        * 参数：graphControl 组件所在画布；
        * 返回值：无
        * *******************************************/
        public Component(GraphControl graphControl)
        {
            this.graphControl = graphControl;
            this.array_portID = new ArrayList();
            this.Rectangle = new RectangleF(50, 50, 80, 50); //设置组件位置及大小

            //this.bmp = new Bitmap(@"..\..\..\picture\Default.png");
            this.bmp = Resource1.Default;

            //this.Location = new System.Drawing.Point(50, 50);
            //this.OnMouseDown += Component_OnMouseDown; 
            this.OnMouseUp += new MouseEventHandler(Component_OnMouseUp);
            this.OnMouseDown += new MouseEventHandler(Component_OnMouseDown);
        }
        
        /*********************************************
         * 函数名称：InitEntity()
         * 功能：改写Shape的InitEntity方法
         * 参数：无
         * 返回值：无
         * *******************************************/
        protected override void InitEntity()
        {
            base.InitEntity();
            this.name = "Default Component";
            this.Text = this.name;
            this.ID = "C" + (component_ID++);
            
            Pen = new Pen(Color.FromArgb(167, 58, 95));
            ShapeColor = Color.FromArgb(255, 253, 205);
     
            //设定大小不可更改
            this.IsResizable = false;
                        
            Font = new Font("Calibri", 10);
           
           
            //1、Connector构造函数的第1个参数是Shape对象，代表的Connector对象依附的图形对象;
            //2、第2个参数是Connector的名字,可以用SequenceShape.Connectors[“Left”]来访问到m_leftConnector;
            //3、第3个参数表示是否允许Connector有多个连接

            ////创建连接点,名称“Left”
            //m_leftConnector = new Connector(this, "Left", true);
            //Connectors.Add(m_leftConnector);

            ////创建连接点,名称“Right”
            //m_rightConnector = new Connector(this, "Right", true);
            //Connectors.Add(m_rightConnector);

        }//protected override void InitEntity()

        /***********************************************
         * 函数名称：Paint()
         * 功能：改写Shape的Paint方法，进行具体的画图
         * 参数：g
         * 返回值：无
         * *********************************************/
        //
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            //g.FillRectangle(new SolidBrush(ShapeColor), Rectangle);
            //g.DrawRectangle(Pen, System.Drawing.Rectangle.Round(Rectangle));
            //bmp = new Bitmap(@"..\..\..\picture\Default.png");

            //绘制组件背景图片
            g.DrawImage(
                 bmp,
                 this.Rectangle);

            //添加组件名称
            if (!string.IsNullOrEmpty(Text))
            {
                //文字在矩形框上方
                g.DrawString(Text, this.Font, this.TextBrush,
                    System.Drawing.RectangleF.FromLTRB(
                    Rectangle.Location.X,
                    Rectangle.Location.Y - 20,
                    Rectangle.Location.X + Rectangle.Width + 100,
                    Rectangle.Location.Y));

                //文字在矩形框内
                //g.DrawString(Text, this.Font, this.TextBrush,
                //    System.Drawing.RectangleF.Inflate(Rectangle, -2, -4));

                //文字在矩形框下方
                //g.DrawString(Text, this.Font, this.TextBrush,
                //    System.Drawing.RectangleF.FromLTRB(
                //    Rectangle.Location.X, 
                //    Rectangle.Location.Y+Rectangle.Height,
                //    Rectangle.Location.X+Rectangle.Width+50,
                //    Rectangle.Location.Y+Rectangle.Height+50));
            
            }
        }// public override void Paint(Graphics g)

        /*********************************************
         * 函数名称：Component_OnMouseDown()
         * 功能：鼠标按下事件，设定组件可移动条件
         * 参数：sender；e
         * 返回值：无
         * *******************************************/
        public void Component_OnMouseDown(object sender, MouseEventArgs e)
        {
            //1、若组件存在inout端口且存在inout端口未被选中，则组件不可移动
            if (this.inout_ports != null)
            {
                if (this.inout_ports[0].IsSelected == false)
                {
                    this.CanMove = false;
                    return;
                }
            }
            //2、若组件存在input端口且存在input端口未被选中，则组件不可移动
            if (this.input_ports != null)
            {
                if (this.input_ports[0].IsSelected == false)
                {
                    this.CanMove = false;
                    return;
                }
            }
            //3、若组件存在output端口且存在output端口未被选中，则组件不可移动
            if (this.output_ports != null)
            {
                if (this.output_ports[0].IsSelected == false)
                {
                    this.CanMove = false;
                    return;
                }
            }
            //4、当组件所拥有的所有端口都被选中时，组件可移动
            this.CanMove = true;
        }

        /*********************************************
         * 函数名称：Component_OnMouseUp()
         * 功能：鼠标抬起事件，选中组件所有端口
         * 参数：sender；e
         * 返回值：无
         * *******************************************/
        public void Component_OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.inout_ports != null)
                {
                    foreach (Inout_port inout_port in this.inout_ports)
                    {
                        inout_port.IsSelected = true;
                        //Console.WriteLine(inout_port.Location + "");
                        Console.WriteLine(inout_port.Port_ID1 + "" + inout_port.Location + " " + inout_port.Rectangle);
                        if (inout_port.IsSelected)
                        {
                            Console.WriteLine("afterselect:" + inout_port.Port_ID1 + "" + inout_port.Location);
                        }
                    }
                }//if (this.inout_ports != null)

                if (this.input_ports != null)
                {
                    foreach (Input_port input_port in this.input_ports)
                    {
                        input_port.IsSelected = true;
                    }
                }//if (this.input_ports != null)

                if (this.output_ports != null)
                {
                    foreach (Output_port output_port in this.output_ports)
                    {
                        output_port.IsSelected = true;
                    }
                }//if (this.input_ports != null)
            }// if (e.Button == MouseButtons.Left )      
        }//public void Component_OnMouseUp

        /**********************************************************************************
        * 函数名称：ShapeMenu()
        * 功能：重写ShapeMenu()方法，添加组件右击弹出菜单选项。在GraphControl第1456行调用。
        * 参数：无
        * 返回值：无
        * *********************************************************************************/
        //
        public override MenuItem[] ShapeMenu()
        {
            //----------------“端口”选项-------------------//
            //创建“端口”选项
            MenuItem ports = new System.Windows.Forms.MenuItem();
            ports.Name = "ports";
            //ports.Size = new System.Drawing.Size(180, 22);
            ports.Text = "Ports";
            //“端口”选项点击事件
            ports.Click += new EventHandler(this.portsMenuItem_Click);

            //--------------“打开组件”选项-----------------//
            //创建“打开组件”选项
            MenuItem openComponent = new System.Windows.Forms.MenuItem();
            openComponent.Name = "openComponents";
            //openComponent.Size = new System.Drawing.Size(180, 22);
            openComponent.Text = "Open Component";            
            openComponent.Click += new EventHandler(this.openComponentMenuItem_Click);

            //--------------“删除组件”选项-----------------//
            //创建“删除组件”选项
            MenuItem deleteComponent = new System.Windows.Forms.MenuItem();
            deleteComponent.Name = "deleteComponent";
            //deleteComponent.Size = new System.Drawing.Size(180, 22);
            deleteComponent.Text = "Delete";
            deleteComponent.Click += new EventHandler(this.deleteComponentMenuItem_Click);

            //--------------“组件名”选项-----------------//
            //创建“组件名”选项
            MenuItem componentName = new System.Windows.Forms.MenuItem();
            componentName.Name = "Component Name";
            //openComponent.Size = new System.Drawing.Size(180, 22);
            componentName.Text = "Component Name";
            componentName.Click += new EventHandler(this.componentNameMenuItem_Click);

            return new System.Windows.Forms.MenuItem[] {
                    ports,(new MenuItem("-")),componentName,(new MenuItem("-")),
                    openComponent,(new MenuItem("-")),deleteComponent };
        }

       

        /**********************************************
         * 函数名称：portsMenuItem_Click()
         * 功能：“端口”选项点击事件,弹出端口配置表单
         * 参数：sender；e
         * 返回值：无
         * ********************************************/
        public void portsMenuItem_Click(object sender, EventArgs e)
        {
            //端口配置表单
            Form fm = new Form_port(this);
            fm.Show();
        }//portsToolStripMenuItem_Click

        /**********************************************
         * 函数名称：componentNameMenuItem_Click()
         * 功能：“组件名”选项点击事件,弹出端口配置表单
         * 参数：sender；e
         * 返回值：无
         * ********************************************/
        private void componentNameMenuItem_Click(object sender, EventArgs e)
        {
            //组件名配置表单
            Form fm = new Form_componentName(this);
            fm.Show();
        }//public override MenuItem[] ShapeMenu()

        /**********************************************************
         * 函数名称：portsMenuItem_Click()
         * 功能：“打开组件”选项点击事件,显示复合组件内部结构窗口
         * 参数：sender；e
         * 返回值：无
         * ********************************************************/
        public void openComponentMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsCompositeComponnet) //若为原子组件
            {
                MessageBox.Show("该组件为原子组件！");
            }
            else
            {
                //复合组件内部结构表单
                //Form insideForm = new InsideForm(this);
                //insideForm.Show();

                if (!this.InsideForm.IsDisposed)
                    this.InsideForm.Show();
                //else
                //{
                //    Form insideForm = new InsideForm(this);
                //    insideForm.Show();
                //}
            }          
        }//openComponentMenuItem_Click

        /**********************************************************
         * 函数名称：deleteComponentMenuItem_Click()
         * 功能：“删除”选项点击事件
         * 参数：sender；e
         * 返回值：无
         * ********************************************************/
        private void deleteComponentMenuItem_Click(object sender, EventArgs e)
        {
            if(this.inout_ports!=null){
                foreach(Inout_port inout in this.inout_ports){
                    inout.Delete();
                }
            }
            if (this.input_ports != null)
            {
                foreach (Input_port input in this.input_ports)
                {
                    input.Delete();
                }
            }
            if (this.output_ports != null)
            {
                foreach (Output_port output in this.output_ports)
                {
                    output.Delete();
                }
            }

            this.Delete();
        }
        
        /**************************************************************************************************
         * 函数名称：ComponentDataTransfer()
         * 功能：组件数据传输函数,组件队列数据传输至output/inout端口，进而继续传输至另一组件input/inout端口
         *       或复合组件output端口
         * 参数：component 表示进行数据传输的组件；data 表示所传输的数据
         * 返回值：无
         * ************************************************************************************************/
        public void ComponentDataTransfer(Component component)
        {
            Thread.Sleep(10);
            ////若数据不为空
            //if(data != null)
            //    component.Component_send_queue.Enqueue(data); //数据进入组件发送队列

            //+++++++++++ Debug - 读取组件发送队列中的数据 +++++++++++//
            //Console.Write(component.name + "组件发送队列数据（入队后）:");
            //foreach (Object arr in component.Component_send_queue)
            //{
            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
            //    Console.Write(arr.GetType().Name + " ;");
            //}
            //Console.WriteLine("");
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

            //------ 若组件的output端口不为空，则1) 组件发送队列中的数据传输至所有output端口 -------//
            //------ 若output端口存在连接线，则2) 组件output端口继续将数据传输至相连接的另一 -------//
            //------ 组件input/inout端口或复合组件output端口 ---------------------------------------//
            try
            {
                if (component.output_ports != null)
                {
                    Object temp = null;
                    if (component.Component_send_queue.Count > 0) //若发送队列有数据
                    {
                        try
                        {
                            temp = this.Component_send_queue.Dequeue();  //数据发送队列中数据出列
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("4错误情况：" + e.Message+" "+e.StackTrace);
                        }
                        //++++++++++ Debug - 读取组件队列中的数据 ++++++++++++++//
                        //Console.Write(component.name + "组件发送队列数据（出队后）:");
                        //foreach (Object arr in this.Component_send_queue)
                        //{
                        //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                        //    Console.Write(arr.GetType().Name + " ;");
                        //}
                        //Console.WriteLine("");
                        //++++++++++++++++++++++++++++++++++++++++++++++++++++++//                    

                        foreach (Output_port output_port in this.output_ports) //遍历所有output端口
                        {
                            if (temp != null)
                                output_port.Port_queue1.Enqueue(temp); //组件出队的数据进入output端口队列

                            //++++++++++++ Debug - 读取output端口队列中的数据 +++++++++++//
                            //Console.Write(component.name + "组件" + output_port.Port_name1 + "output端口队列数据(入队后):");
                            //foreach (Object arr in output_port.Port_queue1)
                            //{
                            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                            //    Console.Write(arr.GetType().Name + " ;");
                            //}
                            //Console.WriteLine("");
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                            //Console.WriteLine((output_port.PortConnector1.Connections==null)?true:false);

                            //若output端口连接点存在连接线
                            if (output_port.PortConnector1.Connections.Count > 0)
                            {
                                Object temp2 = null;
                                if (output_port.Port_queue1.Count > 0) //且output端口队列有数据
                                {
                                    try
                                    {
                                        temp2 = output_port.Port_queue1.Dequeue(); //output端口内部队列数据出队
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("3错误情况："+e.Message);
                                    }

                                    //遍历该output端口所有连接线
                                    foreach (Connection connection in output_port.PortConnector1.Connections)
                                    {
                                        //记录连接线起点
                                        Connector start_connector = connection.From;
                                        //记录连接线终点
                                        Connector end_connector = connection.To;

                                        //获取连接线起点所附属的端口
                                        Port start_port = (Port)start_connector.BelongsTo;
                                        //获取连接线终点所附属的端口
                                        Port end_port = (Port)end_connector.BelongsTo;

                                        //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);
                                        //Console.WriteLine("队列长度"+end_port.Port_queue1.Count);

                                        //output端口继续将数据传输至相连接的另一组件端口
                                        //if (temp2 != null && end_port.Port_queue1 != null)
                                        if (temp2 != null)
                                            end_port.Port_queue1.Enqueue(temp2);

                                        //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                                        //Console.Write(end_port.Component.name + "组件" + end_port.Port_ID1 + "端口队列数据(入队后):");
                                        //foreach (Object arr in end_port.Port_queue1)
                                        //{
                                        //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                        //    Console.Write(arr.GetType().Name + " ;");
                                        //}
                                        //Console.WriteLine("");
                                        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                                    }//foreach (Connection connection in output_port.PortConnector1.Connections)          

                                }
                                //++++++++++++ Debug - 读取output端口队列中的数据 +++++++++++//
                                //Console.Write(component.name + "组件" + output_port.Port_name1 + "output端口队列数据(出队后):");
                                //foreach (Object arr in output_port.Port_queue1)
                                //{
                                //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                //    Console.Write(arr.GetType().Name + " ;");
                                //}
                                //Console.WriteLine("");
                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
                            } //if (output_port.PortConnector1.Connections != null)
                        } //foreach (Output_port output_port in output_ports)     
                    }// if (component.Component_send_queue.Count > 0) //若发送队列有数据                                        
                }//if(component.output_ports != null)

                //------ 若组件的inout端口不为空，则1) 组件发送队列中的数据传输至所有inout端口 -------//
                //------ 若inout端口存在连接线，则2) 组件inout端口继续将数据传输至相连接的另一 -------//
                //------ 组件input/inout端口或复合组件output端口 -------------------------------------//

                if (component.inout_ports != null) //若组件的inout端口不为空
                {
                    Object temp = null;
                    if (component.Component_send_queue.Count > 0) //若发送队列有数据
                    {
                        try
                        {
                            temp = this.Component_send_queue.Dequeue();  //数据发送队列中数据出列
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("1错误情况：" + e.Message);
                        }


                        foreach (Inout_port inout_port in component.inout_ports) //遍历所有inout端口
                        {
                            if (temp != null)
                                inout_port.Port_queue1.Enqueue(temp); //组件出队的数据进入相应的端口队列

                            //++++++++++++ Debug - 读取inout端口队列中的数据 +++++++++++//
                            //Console.Write(component.name + "组件" + inout_port.Port_name1 + "inout端口队列数据(入队后):");
                            //foreach (Object arr in inout_port.Port_queue1)
                            //{
                            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                            //    Console.Write(arr.GetType().Name + " ;");
                            //}
                            //Console.WriteLine("");
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                            //若inout端口连接点存在连接线
                            if (inout_port.PortConnector1.Connections.Count > 0)
                            {
                                Object temp2 = null;
                                if (inout_port.Port_queue1.Count > 0) //且inout端口队列不为空
                                {
                                    try
                                    {
                                        temp2 = inout_port.Port_queue1.Dequeue(); //inout端口内部队列数据出队
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("2错误情况："+e.Message);
                                    }

                                    //++++++++++++ Debug - 读取inout端口队列中的数据 +++++++++++//
                                    //Console.Write(component.name + "组件" + inout_port.Port_name1 + "inout端口队列数据(出队后):");
                                    //foreach (Object arr in inout_port.Port_queue1)
                                    //{
                                    //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                    //    Console.Write(arr.GetType().Name + " ;");
                                    //}
                                    //Console.WriteLine("");
                                    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                                    //遍历该inout端口所有连接线
                                    foreach (Connection connection in inout_port.PortConnector1.Connections)
                                    {
                                        //记录连接线起点
                                        Connector start_connector = connection.From;
                                        //记录连接线终点
                                        Connector end_connector = connection.To;

                                        //获取连接线起点所附属的端口
                                        Port start_port = (Port)start_connector.BelongsTo;
                                        //获取连接线终点所附属的端口
                                        Port end_port = (Port)end_connector.BelongsTo;
                                        //Console.WriteLine("连接线起始端口=" + start_port.Port_ID1 + "连接线终止端口=" + end_port.Port_ID1);

                                        //inout端口继续将数据传输至相连接的另一组件端口
                                        if (temp2 != null)
                                            end_port.Port_queue1.Enqueue(temp2);

                                        //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                                        //Console.Write("input/inout端口队列数据:");
                                        //foreach (int[] arr in end_port.Port_queue1)
                                        //{
                                        //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                        //}
                                        //Console.WriteLine("");
                                        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
                                    }//foreach (Connection connection in output_port.PortConnector1.Connections)
                                }//if (inout_port.Port_queue1.Count > 0) //且inout端口队列不为空
                            } //if (inout_port.PortConnector1.Connections.Count != 0)
                        } //foreach (Inout_port inout_port in this.inout_ports)       
                    } //if (component.Component_send_queue.Count > 0) //若发送队列有数据
                }//if (component.inout_ports != null)
            }
            catch (Exception e1)
            {
                Console.WriteLine("5错误情况：" + e1.Message+e1.StackTrace);
            }

        }// public void ComponentDataTransfer(Component component,Object data)

        /*********************************************************************************
         * 函数名称：PortDataTransfer()
         * 功能：端口数据传输函数，仅用于复合组件，若端口为output端口，output端口将数据传输
         *       至相连的另一组件input端口；若端口为input端口，input端口将组件传输至相连的
         *       内部组件input端口
         * 参数：port 表示进行数据传输的端口
         * 返回值：无
         * *******************************************************************************/
        public void PortDataTransfer(Port port)
        {
            try
            {
                Thread.Sleep(10);
                //若端口为output端口
                if (port.GetType().Name == "Output_port")
                {
                    Output_port output = (Output_port)port;
                    Object temp = null;
                    //若输出端口队列数据大于0且输出端口存在连线
                    if (output.Port_queue1.Count > 0 && output.PortConnector1.Connections.Count > 0)
                    {
                        try
                        {
                            temp = output.Port_queue1.Dequeue();

                            //++++++++++++ Debug - 读取output端口队列中的数据 +++++++++++//
                            //Console.Write(output.Component.name + "组件" + output.Port_ID1 + "端口队列数据(出队后):");
                            //foreach (Object arr in output.Port_queue1)
                            //{
                            //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                            //    Console.Write(arr.GetType().Name + " ;");
                            //}
                            //Console.WriteLine("");
                            ////Console.WriteLine("=========================");
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                            //遍历该output端口所有连接线
                            foreach (Connection connection in output.PortConnector1.Connections)
                            {
                                //记录连接线起点
                                Connector start_connector = connection.From;
                                //记录连接线终点
                                Connector end_connector = connection.To;

                                //获取连接线起点所附属的端口
                                Port start_port = (Port)start_connector.BelongsTo;
                                //获取连接线终点所附属的端口
                                Port end_port = (Port)end_connector.BelongsTo;
                                if (temp != null)
                                    end_port.Port_queue1.Enqueue(temp);

                                //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                                //Console.Write(end_port.Component.name + "组件" + end_port.Port_ID1 + "端口队列数据(入队后):");
                                //foreach (Object arr in end_port.Port_queue1)
                                //{
                                //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                //    Console.Write(arr.GetType().Name + " ;");
                                //}
                                //Console.WriteLine("");
                                //Console.WriteLine("=========================");
                                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
                            }
                        }catch (Exception e){
                            Console.WriteLine("6错误情况：" + e.Message);
                        }
                    
                    }
                }// if (port.GetType().Name == "Output_port")

                //若端口为input端口
                if (port.GetType().Name == "Input_port")
                {
                    Input_port input = (Input_port)port;
                    Object temp = null;
                    //Console.WriteLine("input.Port_queue1.Count=" + input.Port_queue1.Count + " input.PortConnector1.Connections.Count=" 
                    //    + input.PortConnector1.Connections.Count);
                    //若input端口队列数据大于0且input端口存在连线
                    if (input.Port_queue1.Count > 0 && input.PortConnector1.Connections.Count > 0)
                    {
                        temp = input.Port_queue1.Dequeue(); //input端口内部队列数据出列
                        //遍历该input端口所有连接线
                        foreach (Connection connection in input.PortConnector1.Connections)
                        {
                            //若连接线的起点为该input端口,且连接线终点为输入端口类型
                            if (connection.From.BelongsTo == input && connection.To.BelongsTo.GetType().Name == "Input_port")
                            {
                                try
                                {
                                    Input_port input_end = (Input_port)connection.To.BelongsTo;
                                    input_end.Port_queue1.Enqueue(temp);
                                    //++++++++++++ Debug - 读取input/inout端口队列中的数据 +++++++++++//
                                    //Console.Write(input_end.Component.name + "组件" + input_end.Port_ID1 + "端口队列数据(入队后):");
                                    //foreach (Object arr in input_end.Port_queue1)
                                    //{
                                    //    //Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                                    //    Console.Write(arr.GetType().Name + " ;");
                                    //}
                                    //Console.WriteLine("");
                                    //Console.WriteLine("=========================");
                                    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("7错误情况：" + e.Message);
                                }
                            }
                        }
                    }
                }// if (port.GetType().Name == "Input_port")

            }
            catch (Exception e1)
            {
                Console.WriteLine("8错误情况：" + e1.Message+e1.StackTrace);
            }
        }

        /*****************************************************
         * 函数名称：ComponentDataReceive()
         * 功能：组件数据接收函数,组件input端口数据传输至组件
         * 参数：component 表示进行数据接收的组件
         * 返回值：无
         * ***************************************************/
        public void ComponentDataReceive(Component component)
        {
            try
            {
                Thread.Sleep(10);
                //若组件输入端口不为空
                if (component.input_ports != null)
                {
                    //遍历组件中所有的input端口
                    foreach (Input_port input_port in component.input_ports)
                    {
                        Object temp = null;
                        //Console.WriteLine(input_port.Port_queue1.Count);
                        //若input端口内部队列有数据
                        if (input_port.Port_queue1!=null && input_port.Port_queue1.Count > 0)
                        {

                            //lock (lockObject)
                            //{
                                //input端口数据出队
                                temp = input_port.Port_queue1.Dequeue(); //Thread.Sleep(100);
                            //}
                       
                            if (temp != null)
                            {
                                //lock (lockObject)
                                //{
                                    //进入组件数据接收队列
                                    component.Component_reveice_queue.Enqueue(temp);
                                //}  
                            }
                         
                            //++++++++++++ Debug - 读取组件接收队列中的数据 +++++++++++//
                            //Console.Write(component.name + "组件接收队列内的数据（入队后）:");
                            //foreach (int[] arr in component.Component_reveice_queue)
                            //{
                            //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
                            //    //Console.Write(arr.GetType().Name + " ;");
                            //}
                            //Console.WriteLine("");
                            //Console.WriteLine("=========================");
                            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

                            //若该input端口与其他组件input端口相连，则将数据也传给该组件input端口
                            if (input_port.PortConnector1.Connections.Count > 0)
                            {
                                foreach (Connection connection in input_port.PortConnector1.Connections)
                                {
                                    //若连接线的起点为该input端口,且连接线终点为输入端口类型
                                    if (connection.From.BelongsTo == input_port && connection.To.BelongsTo.GetType().Name == "Input_port")
                                    {
                                        Input_port input_end = (Input_port)connection.To.BelongsTo;
                                        input_end.Port_queue1.Enqueue(temp);
                                    }
                                }
                            }
                        }//if (input_port.Port_queue1.Count > 0)
                    }//foreach (Input_port input_port in component.input_ports)
                }//if (component.inout_ports != null)
                //Thread.Sleep(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("9错误情况：" + e.Message+""+e.StackTrace);
            }
            
        }
        
        /*****************************************************
         * 函数名称：EmptyingQueue()
         * 功能：当模性停止执行，清空所有组件队列数据
         * 参数：component 表示进行数据接收的组件
         * 返回值：无
         * ***************************************************/
        public void EmptyingQueue()
        {
            try
            {
                if (this.Component_send_queue != null)
                    this.Component_send_queue.Clear();
                if (this.Component_reveice_queue != null)
                    this.Component_reveice_queue.Clear();
                if (this.inout_ports != null)
                {
                    foreach (Inout_port inout in this.inout_ports)
                    {
                        inout.Port_queue1.Clear();
                    }
                }
                if (this.input_ports != null)
                {
                    foreach (Input_port input in this.input_ports)
                    {
                        input.Port_queue1.Clear();
                    }
                }
                if (this.output_ports != null)
                {
                    foreach (Output_port output in this.output_ports)
                    {
                        output.Port_queue1.Clear();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("组件停止错误情况：" + e.Message + " " + e.StackTrace);
            }

        }


        /*****************************************************
         * 函数名称：ReceiveQueueDataDequeue()
         * 功能：组件接收队列数据出队
         * 参数：component 表示进行数据接收的组件
         * 返回值：无
         * ***************************************************/
        //public void ReceiveQueueDataDequeue(Object comp)
        //{
        //    Component component = (Component)comp;
        //    Console.Write("component.Component_reveice_queue.Count=" + component.Component_reveice_queue.Count);
        //    while (component.Component_reveice_queue.Count > 0)
        //    {
        //        component.Component_reveice_queue.Dequeue();

        //        //++++++++++++ Debug - 读取组件接收队列中的数据 +++++++++++//
        //        //Console.Write(component.name + "组件接收队列内的数据（出队后）:");
        //        //foreach (int[] arr in component.Component_reveice_queue)
        //        //{
        //        //    Console.Write("[" + arr[0] + "," + arr[1] + " ];");
        //        //}
        //        //Console.WriteLine("");
        //        ////Console.WriteLine("=========================");
        //        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        //        Thread.Sleep(300);
        //    }
        //}


    }//public class Component : Shape
}
