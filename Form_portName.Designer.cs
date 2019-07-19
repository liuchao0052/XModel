namespace XModel
{
    partial class Form_portName
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
            this.textBox_ComponnetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PortID = new System.Windows.Forms.TextBox();
            this.textBox_PortName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_ComponnetName
            // 
            this.textBox_ComponnetName.Location = new System.Drawing.Point(174, 30);
            this.textBox_ComponnetName.Name = "textBox_ComponnetName";
            this.textBox_ComponnetName.ReadOnly = true;
            this.textBox_ComponnetName.Size = new System.Drawing.Size(145, 21);
            this.textBox_ComponnetName.TabIndex = 0;
            if(this.port.Component!=null)
                this.textBox_ComponnetName.Text = this.port.Component.name;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Component Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port Name";
            // 
            // textBox_PortID
            // 
            this.textBox_PortID.Location = new System.Drawing.Point(174, 72);
            this.textBox_PortID.Name = "textBox_PortID";
            this.textBox_PortID.ReadOnly = true;
            this.textBox_PortID.Size = new System.Drawing.Size(145, 21);
            this.textBox_PortID.TabIndex = 0;
            this.textBox_PortID.Text = this.port.Port_ID1;
            // 
            // textBox_PortName
            // 
            this.textBox_PortName.Location = new System.Drawing.Point(174, 113);
            this.textBox_PortName.Name = "textBox_PortName";
            this.textBox_PortName.Size = new System.Drawing.Size(145, 21);
            this.textBox_PortName.TabIndex = 0;
            this.textBox_PortName.Text = this.port.Port_name1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portNameConfigutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 206);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PortName);
            this.Controls.Add(this.textBox_PortID);
            this.Controls.Add(this.textBox_ComponnetName);
            this.MaximizeBox = false;
            this.Name = "PortNameConfigure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Port Name Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ComponnetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PortID;
        private System.Windows.Forms.TextBox textBox_PortName;
        private System.Windows.Forms.Button button1;


    }
}