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
    public partial class Form_componentName : Form
    {
        Component component; //组件名配置表单对应的组件
        public Form_componentName(Component component)
        {
            this.component = component;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.component.name = textBox_ComponentName.Text;
            this.component.Text = textBox_ComponentName.Text;
            this.Close();
        }
    }
}
