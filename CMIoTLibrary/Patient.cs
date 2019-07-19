using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Netron.GraphLib.UI;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Netron.GraphLib;
using XModel.BasicLibrary;

namespace XModel.CMIoTLibrary
{
    //患者组件
    public class Patient : Component
    {
        Component bloodPressureComponent; //子组件-血压组件
        Component temperatureComponent;   //子组件-体温组件
        Component heartRateComponent;     //子组件-心率组件

        public Component BloodPressureComponent
        {
            get { return bloodPressureComponent; }
            set { bloodPressureComponent = value; }
        }
        public Component HeartRateComponent
        {
            get { return heartRateComponent; }
            set { heartRateComponent = value; }
        }
        public Component TemperatureComponent
        {
            get { return temperatureComponent; }
            set { temperatureComponent = value; }
        }

        public Patient(GraphControl graphControl)
            : base(graphControl)
        {
            this.IsCompositeComponnet = true; //Patient为复合组件
            //this.bmp = new Bitmap(@"..\..\..\picture\Patient.png");

            this.bmp = Resource1.Patient;
            this.Text = "Patient";
            this.Rectangle = new RectangleF(50, 300, 65, 83); //设置组件位置及大小
            this.name = "Patient";

            //创建血压组件
            this.bloodPressureComponent = new BloodPressure(null, null, null, null);
            this.BloodPressureComponent.output_ports = new Output_port[1]; //创建血压组件的一个输出端口
            this.BloodPressureComponent.output_ports[0] = new Output_port(this.BloodPressureComponent.ID + "_P1",
                this.BloodPressureComponent.name + "Port", "output", "int[]", this.BloodPressureComponent);

            //创建体温组件
            this.TemperatureComponent = new Temperature(null, null, null, null);
            this.TemperatureComponent.output_ports = new Output_port[1]; //创建体温组件的一个输出端口
            this.TemperatureComponent.output_ports[0] = new Output_port(this.TemperatureComponent.ID + "_P1",
                this.TemperatureComponent.name + "Port", "output", "double", this.TemperatureComponent);

            //创建心率组件
            this.HeartRateComponent = new HeartRate(null, null, null, null);
            this.HeartRateComponent.output_ports = new Output_port[1]; //创建心率组件的一个输出端口
            this.HeartRateComponent.output_ports[0] = new Output_port(this.HeartRateComponent.ID + "_P1",
                this.HeartRateComponent.name + "Port", "output", "int", this.HeartRateComponent);

            //创建Patient组件端口
            //list_bloodPressureDatas = new List<int[]>();
            this.output_ports = new Output_port[3]; //组件输出端口数组
            this.output_ports[0] = new Output_port((this.ID + "_P1"), this.BloodPressureComponent.name+"Port", "output", "int[]", this);
            this.output_ports[1] = new Output_port((this.ID + "_P2"), this.TemperatureComponent.name+"Port", "output", "double", this);
            this.output_ports[2] = new Output_port((this.ID + "_P3"), this.HeartRateComponent.name+"Port", "output", "int", this);

            int output_ports_LocationX = (int)(this.Location.X + this.Width - 2);
            int output_ports_LocationY1 = (int)(this.Location.Y + 1 * (this.Height / (3 + 1)) - output_ports[0].Height / 2);
            int output_ports_LocationY2 = (int)(this.Location.Y + 2 * (this.Height / (3 + 1)) - output_ports[1].Height / 2);
            int output_ports_LocationY3 = (int)(this.Location.Y + 3 * (this.Height / (3 + 1)) - output_ports[2].Height / 2);

            output_ports[0].Rectangle = new RectangleF(output_ports_LocationX, output_ports_LocationY1, 15, 15);
            output_ports[1].Rectangle = new RectangleF(output_ports_LocationX, output_ports_LocationY2, 15, 15);
            output_ports[2].Rectangle = new RectangleF(output_ports_LocationX, output_ports_LocationY3, 15, 15);

            this.graphControl.AddShape(output_ports[0], new Point(output_ports_LocationX, output_ports_LocationY1));
            this.graphControl.AddShape(output_ports[1], new Point(output_ports_LocationX, output_ports_LocationY2));
            this.graphControl.AddShape(output_ports[2], new Point(output_ports_LocationX, output_ports_LocationY3));



            //----------------------------------------------------------//
            //--------建立内部组件端口到Patient组件端口的连线-----------//
            //----------------------------------------------------------//
            //1、建立血压组件到Patient组件端口的连线
            Connection connection1 = new Connection();
            connection1.From = this.BloodPressureComponent.output_ports[0].PortConnector1;
            connection1.To = this.output_ports[0].PortConnector1;
            //修改ConnectionCollection.cs第78行，获取Add方法
            //将连线添加到血压组件输出端口连接点
            this.BloodPressureComponent.output_ports[0].PortConnector1.Connections.Add(connection1);

            //2、建立体温组件到Patient组件端口的连线
            Connection connection2 = new Connection();
            connection2.From = this.TemperatureComponent.output_ports[0].PortConnector1;
            connection2.To = this.output_ports[1].PortConnector1;
            //将连线添加到体温组件输出端口连接点
            this.TemperatureComponent.output_ports[0].PortConnector1.Connections.Add(connection2);

            //3、建立心率组件到Patient组件端口的连线
            Connection connection3 = new Connection();
            connection3.From = this.HeartRateComponent.output_ports[0].PortConnector1;
            connection3.To = this.output_ports[2].PortConnector1;
            //将连线添加到心率组件输出端口连接点
            this.HeartRateComponent.output_ports[0].PortConnector1.Connections.Add(connection3);



            this.InsideForm = new InsideForm(this); //构建内部结构显示表单

        }

      
        /********************************************
         * 函数名称：run()
         * 功能：患者组件执行函数
         * 参数：无
         * 返回值：无
         * *****************************************/
        public void run()
        {
            while (true)
            {
                if (Form1.stop)
                {
                    this.EmptyingQueue();
                    return;
                }
                
                BloodPressure bp = (BloodPressure)(this.bloodPressureComponent);
                ////启动血压组件执行线程
                //Thread bp_thread = new Thread(new ParameterizedThreadStart(bp.run)); //带1个参数传递的线程创建
                //bp_thread.Start(1);
                bp.GeneratingBloodPressureData(); //生成血压数据
                //bp.Component_send_queue.Enqueue(bp.BloodPressureData);
                bp.ComponentDataTransfer(bp);     //传输血压数据
                PortDataTransfer(this.output_ports[0]);  //患者组件output端口继续将数据传输至另一组件input端口

                Temperature temp = (Temperature)(this.temperatureComponent);
                ////启动体温组件执行线程
                //Thread temp_thread = new Thread(new ParameterizedThreadStart(temp.run)); //带1个参数传递的线程创建
                //temp_thread.Start(1);
                temp.GeneratingTemperatureData(); //生成体温数据
                //temp.Component_send_queue.Enqueue(temp.TemperatureData);
                temp.ComponentDataTransfer(temp); //传输体温数据
                PortDataTransfer(this.output_ports[1]); //患者组件output端口继续将数据传输至另一组件input端口

                HeartRate hr = (HeartRate)(this.heartRateComponent);
                ////启动心率组件执行线程
                //Thread hr_thread = new Thread(new ParameterizedThreadStart(hr.run)); //带1个参数传递的线程创建
                //hr_thread.Start(1);
                hr.GeneratingHartRateData(); //生成心率数据
                //hr.Component_send_queue.Enqueue(hr.HeartRateData);
                hr.ComponentDataTransfer(hr); //传输心率数据
                PortDataTransfer(this.output_ports[2]); //患者组件output端口继续将数据传输至另一组件input端口

            }

        }// public void run()

    }// public class Patient : Component
}
