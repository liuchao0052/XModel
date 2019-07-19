using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Netron.GraphLib;
using System.Collections;


namespace XModel
{
    public partial class Form_port : Form
    {
        Component component; //端口配置表单对应的组件

        //端口ID 计数
        int port_ID_count = 1;
        ////记录端口ID 数组
        //static ArrayList array_portID = new ArrayList();

        //int k = 0;
        public Form_port(Component component)
        {
            this.component = component;
            //Console.WriteLine(this.component.GetType());
            InitializeComponent();
        }
        //加载端口配置表单中端口参数表格数据
        private void Form_port_Load(object sender, EventArgs e)
　　　　{
            ////设置表格listView1相关参数
            //表格是否显示网格线
            listView1.GridLines = true;
            //是否选中整行
            listView1.FullRowSelect = true;
            //设置显示方式
            listView1.View = View.Details;
            //是否自动显示滚动条
            listView1.Scrollable = true;
            //是否可以选择多行
            listView1.MultiSelect = false;
            //添加表头（列）
            listView1.Columns.Add("ID", "ID");
            listView1.Columns.Add("Director", "Director");
            listView1.Columns.Add("Type", "Type");
            //-1 根据内容设置宽度  -2 根据标题设置宽度
            //listView1.Columns["ID"].Width = -1;//根据内容设置宽度
            listView1.Columns["ID"].Width = 60;
            listView1.Columns["Director"].Width = -2;//根据标题设置宽度
            listView1.Columns["Type"].Width = -2;

            //若组件存在端口，则在表格listView1中添加相应端口属性值
            if (component.inout_ports != null)
            {
                //MessageBox.Show(component.ports.Length + "");
                for (int i = 0; i < component.inout_ports.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    //添加第1列内容
                    item.SubItems[0].Text = component.inout_ports[i].Port_ID1;
                    //添加第2列内容
                    item.SubItems.Add(component.inout_ports[i].Port_director1);
                    //添加第3列内容
                    item.SubItems.Add(component.inout_ports[i].Port_type1);
                    //添加该行
                    listView1.Items.Add(item);
                }
            }//if (component.inout_ports != null)

            if (component.input_ports != null)
            {
                //MessageBox.Show(component.ports.Length + "");
                for (int i = 0; i < component.input_ports.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    //添加第1列内容
                    item.SubItems[0].Text = component.input_ports[i].Port_ID1;
                    //添加第2列内容
                    item.SubItems.Add(component.input_ports[i].Port_director1);
                    //添加第3列内容
                    item.SubItems.Add(component.input_ports[i].Port_type1);
                    //添加该行
                    listView1.Items.Add(item);
                }
            }//if (component.input_ports != null)

            if (component.output_ports != null)
            {
                //MessageBox.Show(component.ports.Length + "");
                for (int i = 0; i < component.output_ports.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    //添加第1列内容
                    item.SubItems[0].Text = component.output_ports[i].Port_ID1;
                    //添加第2列内容
                    item.SubItems.Add(component.output_ports[i].Port_director1);
                    //添加第3列内容
                    item.SubItems.Add(component.output_ports[i].Port_type1);
                    //添加该行
                    listView1.Items.Add(item);
                }
            }//if (component.input_ports != null)

        }//Form_port_Load
　　　　
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
      
        //“添加端口”按钮
        private void button_add_MouseClick(object sender, MouseEventArgs e)
        {
            //设置标记变量
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            //创建一个表格记录对象
            ListViewItem item = new ListViewItem();
            item.SubItems.Clear();
            
            //(1) 添加第1列内容，即端口ID
            if (string.IsNullOrEmpty(textBox_ID2.Text)) //若textBox_ID2为空，提示用户需填写端口ID
            {   
                MessageBox.Show("请添加端口ID");
                flag1 = false;
                return;
            }
            else //若textBox不为空，则将表格记录对象第一列设置为此端口ID
            {
                item.SubItems[0].Text = textBox_ID1.Text + textBox_ID2.Text;
                flag1 = true;
            }
            
            //(2) 添加第2列内容，即端口方向
            //若checkBox_input、checkBox_output均未选择，提示用户需选择端口方向
            if (checkBox_input.CheckState == CheckState.Unchecked &&
               checkBox_output.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("请选择端口方向");
                flag2 = false;
                return;
            }
            //若仅选择checkBox_input，则将表格记录对象第二列设置为“input”
            else if(checkBox_input.CheckState == CheckState.Checked &&
                checkBox_output.CheckState == CheckState.Unchecked)
            {
                item.SubItems.Add("input");
                flag2 = true;
            }
            //若仅选择checkBox_output，则将表格记录对象第二列设置为“output”
            else if (checkBox_input.CheckState == CheckState.Unchecked &&
              checkBox_output.CheckState == CheckState.Checked)
            {
                item.SubItems.Add("output");
                flag2 = true;
            }
            //若同时选择checkBox_input、checkBox_output，则将表格记录对象第二列设置为“inout”
            else
            {
                item.SubItems.Add("inout");
                flag2 = true;
            }                
          
            //(3) 添加第3列内容，即端口类型
            //若comboBox_type值为空，提示用户选择端口类型
            if (string.IsNullOrEmpty(comboBox_type.Text))
            {
                MessageBox.Show("请选择端口类型");
                flag3 = false;
                return;
            }
            else //否则将所选端口类型设置为表格记录对象第三列内容
            {
                item.SubItems.Add(comboBox_type.Text);
                flag3 = true;
            }

            //如果列表不包含port_ID，则返回-1
            if (component.array_portID.IndexOf(component.ID + "_P" + textBox_ID2.Text) != -1) //存在相同port_ID
            {
                //Console.WriteLine("端口ID=" + component.ID + "_P" + port_ID_count);
                MessageBox.Show("存在相同端口ID,请重新输入！");
                flag4 = false;
                return;
            }
            else
                flag4 = true;

            //当且仅当端口号、端口方向、端口类型均设置后，在表格中添加该对象
            if (flag1 == true && flag2 == true && flag3 == true && flag4 == true)
            {
                listView1.Items.Add(item);
                //端口ID由组件ID+P+port_ID_count组成，即component.ID+"_P"+port_ID_count
                //array_portID.Add(component.ID + "_P" + port_ID_count);
                component.array_portID.Add(item.SubItems[0].Text);

                textBox_ID1.Text = component.ID + "_P" ;
                textBox_ID2.Text = (++port_ID_count) + "";
                Console.WriteLine("port_ID_count=" + port_ID_count);
            }                
            flag1 = false; 
            flag2 = false;
            flag3 = false;
            flag4 = false;
        }

        //“删除端口”按钮
        private void button_delete_MouseClick(object sender, MouseEventArgs e)
        {
            int index = 0;
            //判断listview有选中项
            if (this.listView1.SelectedItems.Count > 0)
            {
                //取当前选中项的index
                index = this.listView1.SelectedItems[0].Index;
               
                //Console.WriteLine(listView1.Items[index].SubItems[0].Text);
                //端口ID列表中删除该ID
                component.array_portID.Remove(listView1.Items[index].SubItems[0].Text);
                
                //Console.WriteLine("剩余元素：");
                //foreach (String s in component.array_portID)
                //{
                //    Console.WriteLine(s);
                //}

                //依据index值删除对应表项
                listView1.Items[index].Remove();                   
            }
        }// private void button_delete_MouseClick

        //“提交”按钮
        private void button_commit_MouseClick(object sender, MouseEventArgs e)
        {
            
            //若端口参数表格无表项，则直接关闭端口配置表单窗口，并退出函数
            if (listView1.Items.Count == 0)
            {
                this.Close();
                return;
            }

            //若组件端口不为空，则先删除组件端口，后面依据表格内容重新创建端口
            if (component.inout_ports != null)
            {
                for (int i = 0; i < component.inout_ports.Length; i++)               
                    //component.graphControl.RemoveShape(component.inout_ports[i]);
                    component.graphControl.Shapes.Remove(component.inout_ports[i]);
                component.inout_ports = null;
                //component.graphControl.Refresh();
                //foreach (Inout_port inout_port in component.inout_ports)
                //    component.graphControl.RemoveShape(inout_port);
            }
            if (component.input_ports != null)
            {
                
                for (int i = 0; i < component.input_ports.Length; i++)
                    //component.graphControl.RemoveShape(component.input_ports[i]);
                    component.graphControl.Shapes.Remove(component.input_ports[i]);
                component.input_ports = null;
            }
            if (component.output_ports != null)
            {
                for (int i = 0; i < component.output_ports.Length; i++)
                    //component.graphControl.RemoveShape(component.output_ports[i]);
                    component.graphControl.Shapes.Remove(component.output_ports[i]);
                component.output_ports = null;
            } 

            //创建端口数组对象，数组长度对应端口参数表格行数
            //Port[] ports = new Port[listView1.Items.Count];

            int input_num = 0; //记录Input_port端口数量
            int output_num = 0; //记录Output_port端口数量
            int inout_num = 0; //记录Inout_port端口数量

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewItem item = listView1.Items[i];

                //若端口方向为input
                if(item.SubItems[1].Text=="input"){                    
                    input_num++;
                }
                //若端口方向为output
                else if(item.SubItems[1].Text=="output"){
                    output_num++;
                }
                //若端口方向为inout
                else if(item.SubItems[1].Text=="inout"){              
                    inout_num++;
                }//for (int i = 0; i < listView1.Items.Count; i++)        
            }

            int j = 0; int n1 = 1;
            int k = 0; int n2 = 1;
            int l = 0; int n3 = 1;

            Inout_port[] inout_ports = null;
            Input_port[] input_ports = null;
            Output_port[] output_ports = null;

            if(inout_num > 0)
                inout_ports = new Inout_port[inout_num];
            if (input_num > 0)
                input_ports = new Input_port[input_num];
            if (output_num > 0)
                output_ports = new Output_port[output_num];

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewItem item = listView1.Items[i];

                //若为inout类型
                if (item.SubItems[1].Text=="inout")
                {             
                    //创建Inout端口对象
                    //inout_ports[j] = new Inout_port();
                    //inout_ports[j].Port_ID1 = item.SubItems[0].Text;
                    //inout_ports[j].Port_type1 = item.SubItems[2].Text;
                    inout_ports[j] = new Inout_port(item.SubItems[0].Text, this.component.name+"Port", item.SubItems[1].Text, item.SubItems[2].Text, this.component);

                    //计算组件当前inout端口位置以及大小
                    int inout_ports_LocationX = (int)(component.Location.X + n1 * (component.Width / (inout_num + 1)) - inout_ports[j].Width / 2);
                    //int inout_ports_LocationY = (int)(component.Location.Y + component.Height - inout_ports[j].Height / 2);
                    int inout_ports_LocationY = (int)(component.Location.Y + component.Height - inout_ports[j].Height / 3);

                    //component.inout_ports[j].Rectangle = new RectangleF(inout_ports_LocationX, inout_ports_LocationY, 12, 8);
                    inout_ports[j].Rectangle = new RectangleF(inout_ports_LocationX, inout_ports_LocationY, 12, 8);
     
                    //component.graphControl.AddShape(component.inout_ports[j], new Point(inout_ports_LocationX, inout_ports_LocationY));
                    component.graphControl.AddShape(inout_ports[j], new Point(inout_ports_LocationX, inout_ports_LocationY));
                    n1++;
                    j++;                   
                }// if (item.SubItems[1].Text=="inout")

                //若为input类型
                if (item.SubItems[1].Text == "input")
                {
                    //创建Input端口对象
                    //input_ports[k] = new Input_port();
                    //input_ports[k].Port_ID1 = item.SubItems[0].Text;
                    //input_ports[k].Port_type1 = item.SubItems[2].Text;
                    input_ports[k] = new Input_port(item.SubItems[0].Text, this.component.name+"Port", item.SubItems[1].Text, item.SubItems[2].Text,this.component);
                    
                    //+++++++++++++++ Debug 输出input端口所附属的组件+++++++++++++++++++++++++++++++++++++++++++//
                    //Console.WriteLine(input_ports[k].Port_ID1 + "所属的组件为：" + input_ports[k].BelongTo());
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
                    
                    //计算组件当前input端口位置以及大小
                    //int input_ports_LocationX = (int)(component.Location.X - input_ports[k].Width / 2);
                    int input_ports_LocationX = (int)(component.Location.X);
                    int input_ports_LocationY = (int)(component.Location.Y + n2 * (component.Height / (input_num + 1)) - input_ports[k].Height / 2);

                    //component.inout_ports[j].Rectangle = new RectangleF(inout_ports_LocationX, inout_ports_LocationY, 12, 8);
                    input_ports[k].Rectangle = new RectangleF(input_ports_LocationX, input_ports_LocationY, 15, 15);

                    //component.graphControl.AddShape(component.inout_ports[j], new Point(inout_ports_LocationX, inout_ports_LocationY));
                    component.graphControl.AddShape(input_ports[k], new Point(input_ports_LocationX, input_ports_LocationY));
                    n2++;
                    k++;
                }//if (item.SubItems[1].Text == "input")

                //若为output类型
                if (item.SubItems[1].Text == "output")
                {
                    //创建Output端口对象
                    //output_ports[l] = new Output_port();
                    //output_ports[l].Port_ID1 = item.SubItems[0].Text;
                    //output_ports[l].Port_type1 = item.SubItems[2].Text;
                    output_ports[l] = new Output_port(item.SubItems[0].Text, this.component.name+"Port", item.SubItems[1].Text, item.SubItems[2].Text,this.component);

                    //计算组件当前output端口位置以及大小
                    //int output_ports_LocationX = (int)(component.Location.X + component.Width - output_ports[l].Width / 2);
                    int output_ports_LocationX = (int)(component.Location.X + component.Width-2);
                    int output_ports_LocationY = (int)(component.Location.Y + n3 * (component.Height / (output_num + 1)) - output_ports[l].Height / 2);

                    //component.inout_ports[j].Rectangle = new RectangleF(inout_ports_LocationX, inout_ports_LocationY, 12, 8);
                    output_ports[l].Rectangle = new RectangleF(output_ports_LocationX, output_ports_LocationY, 15, 15);

                    component.graphControl.AddShape(output_ports[l], new Point(output_ports_LocationX, output_ports_LocationY));
                    n3++;
                    l++;
                }//if (item.SubItems[1].Text == "output")
            }// for (int i = 0; i < listView1.Items.Count; i++)

            //将inout端口与组件进行绑定
            component.inout_ports = inout_ports;
            //Debug
            //foreach(Inout_port inout in component.inout_ports){
            //     Console.WriteLine(inout.Port_ID1+" "+inout.Location);
            //}

            //将input端口与组件进行绑定
            component.input_ports = input_ports;
            //将output端口与组件进行绑定
            component.output_ports = output_ports;

            ////若组件为血压组件，则所有端口名设置为BloodPressureOutputPort
            //if (component.name == "BloodPressure")
            //{
            //    if (component.inout_ports != null)
            //    {
            //        foreach (Inout_port inout_port in component.inout_ports)
            //        {
            //            inout_port.Port_name1 = "BloodPressureOutputPort";
            //        }
            //    }
            //    if (component.input_ports != null)
            //    {
            //        foreach (Input_port input_port in component.inout_ports)
            //        {
            //            input_port.Port_name1 = "BloodPressureOutputPort";
            //        }
            //    }                
            //}

            this.Close();
        }//button_commit_MouseClick
    }//public partial class Form_port
}
