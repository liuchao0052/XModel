using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XModel
{
    public partial class Form_portName : Form
    {
        Port port; //端口名配置表单对应的端口
        public Form_portName(Port port)
        {
            this.port = port;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.port.Port_name1 = textBox_PortName.Text;
            this.port.Text = textBox_PortName.Text;
            this.Close();
        }
    }
}
