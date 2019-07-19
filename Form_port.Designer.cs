namespace XModel
{
    partial class Form_port
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_commit = new System.Windows.Forms.Button();
            this.checkBox_input = new System.Windows.Forms.CheckBox();
            this.checkBox_output = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ID1 = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ID2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button_delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComponentName = new System.Windows.Forms.Label();
            this.ComponentID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_commit
            // 
            this.button_commit.Location = new System.Drawing.Point(130, 150);
            this.button_commit.Name = "button_commit";
            this.button_commit.Size = new System.Drawing.Size(63, 23);
            this.button_commit.TabIndex = 6;
            this.button_commit.Text = "Submit";
            this.button_commit.UseVisualStyleBackColor = true;
            this.button_commit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_commit_MouseClick);
            // 
            // checkBox_input
            // 
            this.checkBox_input.AutoSize = true;
            this.checkBox_input.Location = new System.Drawing.Point(8, 71);
            this.checkBox_input.Name = "checkBox_input";
            this.checkBox_input.Size = new System.Drawing.Size(54, 16);
            this.checkBox_input.TabIndex = 0;
            this.checkBox_input.Text = "Input";
            this.checkBox_input.UseVisualStyleBackColor = true;
            this.checkBox_input.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox_output
            // 
            this.checkBox_output.AutoSize = true;
            this.checkBox_output.Location = new System.Drawing.Point(8, 89);
            this.checkBox_output.Name = "checkBox_output";
            this.checkBox_output.Size = new System.Drawing.Size(60, 16);
            this.checkBox_output.TabIndex = 1;
            this.checkBox_output.Text = "Output";
            this.checkBox_output.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port ID";
            // 
            // textBox_ID1
            // 
            this.textBox_ID1.Location = new System.Drawing.Point(8, 26);
            this.textBox_ID1.Name = "textBox_ID1";
            this.textBox_ID1.ReadOnly = true;
            this.textBox_ID1.Size = new System.Drawing.Size(54, 21);
            this.textBox_ID1.TabIndex = 2;
            this.textBox_ID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ID1.Text = component.ID + "_P";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(130, 64);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(63, 23);
            this.button_add.TabIndex = 5;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_add_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Type";
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "bit",
            "int",
            "int[]",
            "float",
            "double",
            "char",
            "string",
            "boolean"});
            this.comboBox_type.Location = new System.Drawing.Point(8, 129);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(79, 20);
            this.comboBox_type.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ID2);
            this.groupBox1.Controls.Add(this.comboBox_type);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_ID1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox_output);
            this.groupBox1.Controls.Add(this.checkBox_input);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 157);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBox_ID2
            // 
            this.textBox_ID2.Location = new System.Drawing.Point(61, 26);
            this.textBox_ID2.Name = "textBox_ID2";
            this.textBox_ID2.Size = new System.Drawing.Size(28, 21);
            this.textBox_ID2.TabIndex = 4;
            this.textBox_ID2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port Director";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(209, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 150);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(130, 107);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(63, 23);
            this.button_delete.TabIndex = 8;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_delete_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(73, -73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 67);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.ComponentName);
            this.groupBox3.Controls.Add(this.ComponentID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 37);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(224, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Component Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(108, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 2;
            // 
            // ComponentName
            // 
            this.ComponentName.AutoSize = true;
            this.ComponentName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComponentName.Location = new System.Drawing.Point(340, 17);
            this.ComponentName.Name = "ComponentName";
            this.ComponentName.Size = new System.Drawing.Size(0, 12);
            this.ComponentName.TabIndex = 2;
            this.ComponentName.Text = component.name;
            // 
            // ComponentID
            // 
            this.ComponentID.AutoSize = true;
            this.ComponentID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComponentID.Location = new System.Drawing.Point(108, 17);
            this.ComponentID.Name = "ComponentID";
            this.ComponentID.Size = new System.Drawing.Size(0, 12);
            this.ComponentID.TabIndex = 2;
            this.ComponentID.Text = component.ID;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Component ID:";
            // 
            // Form_port
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 206);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_commit);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form_port";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ports Configure";
            this.Load += new System.EventHandler(this.Form_port_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_commit;
        private System.Windows.Forms.CheckBox checkBox_input;
        private System.Windows.Forms.CheckBox checkBox_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ID1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ID2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ComponentName;
        private System.Windows.Forms.Label ComponentID;

    }
}