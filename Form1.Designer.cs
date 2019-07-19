namespace XModel
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("BloodPressure", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Temperature", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("HeartRate", 3, 3);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Physical", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("BloodPressureSensor", 4, 4);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("TemperatureSensor", 5, 5);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("HeartRateSensor", 6, 6);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Sensing", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("DisplayController", 7, 7);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Monitor", 31, 31);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("BloodPressureMonitor", 32, 32);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("TemperatureMonitor", 33, 33);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("HeartRateMonitor", 34, 34);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("AudioController", 8, 8);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("ElectricMachineryController", 9, 9);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Controlling", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("MicroProcessor", 10, 10);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("ProtocolConverter", 11, 11);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("DataProcessor", 12, 12);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("DataAnalyzer", 13, 13);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("RouteModule", 30, 30);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Computing", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("WiredModule", 14, 14);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("WirelessModule", 15, 15);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Communication", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("WiredMedia", 16, 16);
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("WirelessMedia", 17, 17);
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Transfer", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Register", 18, 18);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("RAM", 19, 19);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("ROM", 20, 20);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("DataMemory", 21, 21);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Buffer", 22, 22);
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Storing", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("BasicLibrary", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode16,
            treeNode22,
            treeNode25,
            treeNode28,
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Patient", 23, 23);
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("User", new System.Windows.Forms.TreeNode[] {
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("BloodPressureSensorNode", 24, 24);
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("TemperatureSensorNode", 25, 25);
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("HeartRateSensorNode", 26, 26);
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("SensorNode", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("IoTGateway", 27, 27);
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Gateway", new System.Windows.Forms.TreeNode[] {
            treeNode42});
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("802.15.4 Channel", 17, 17);
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("802.15.1 Channel", 17, 17);
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("802.11 Channel", 17, 17);
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Ethernet Channel", 16, 16);
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Channel", new System.Windows.Forms.TreeNode[] {
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("IPv6Router", 28, 28);
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Router", new System.Windows.Forms.TreeNode[] {
            treeNode49});
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("MedicalServer", 29, 29);
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Server", new System.Windows.Forms.TreeNode[] {
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("CMIoTLibrary", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode41,
            treeNode43,
            treeNode48,
            treeNode50,
            treeNode52});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.fullSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.editPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.newInputPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOutputPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newInputoutputPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Copy = new System.Windows.Forms.ToolStripButton();
            this.Cut = new System.Windows.Forms.ToolStripButton();
            this.OpenContainer = new System.Windows.Forms.ToolStripButton();
            this.Run = new System.Windows.Forms.ToolStripButton();
            this.Pause = new System.Windows.Forms.ToolStripButton();
            this.Continue = new System.Windows.Forms.ToolStripButton();
            this.Stop = new System.Windows.Forms.ToolStripButton();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Library = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.directoryIcons = new System.Windows.Forms.ImageList(this.components);
            this.Tree = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.graphControl = new Netron.GraphLib.UI.GraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Library.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sToolStripMenuItem3,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(884, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.aToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(128, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.designViewToolStripMenuItem,
            this.xMLViewToolStripMenuItem,
            this.sToolStripMenuItem,
            this.fullSToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // designViewToolStripMenuItem
            // 
            this.designViewToolStripMenuItem.Name = "designViewToolStripMenuItem";
            this.designViewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.designViewToolStripMenuItem.Text = "Design View";
            // 
            // xMLViewToolStripMenuItem
            // 
            this.xMLViewToolStripMenuItem.Name = "xMLViewToolStripMenuItem";
            this.xMLViewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.xMLViewToolStripMenuItem.Text = "XML View";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(144, 6);
            // 
            // fullSToolStripMenuItem
            // 
            this.fullSToolStripMenuItem.Name = "fullSToolStripMenuItem";
            this.fullSToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.fullSToolStripMenuItem.Text = "Full Screen";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.sToolStripMenuItem1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pluseToolStripMenuItem,
            this.sToolStripMenuItem2,
            this.editPToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pluseToolStripMenuItem
            // 
            this.pluseToolStripMenuItem.Name = "pluseToolStripMenuItem";
            this.pluseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.pluseToolStripMenuItem.Text = "Paste";
            // 
            // sToolStripMenuItem2
            // 
            this.sToolStripMenuItem2.Name = "sToolStripMenuItem2";
            this.sToolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // editPToolStripMenuItem
            // 
            this.editPToolStripMenuItem.Name = "editPToolStripMenuItem";
            this.editPToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.editPToolStripMenuItem.Text = "Edit Preferences";
            // 
            // sToolStripMenuItem3
            // 
            this.sToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInputPortToolStripMenuItem,
            this.newOutputPortToolStripMenuItem,
            this.newInputoutputPortToolStripMenuItem});
            this.sToolStripMenuItem3.Name = "sToolStripMenuItem3";
            this.sToolStripMenuItem3.Size = new System.Drawing.Size(56, 21);
            this.sToolStripMenuItem3.Text = "Graph";
            // 
            // newInputPortToolStripMenuItem
            // 
            this.newInputPortToolStripMenuItem.Name = "newInputPortToolStripMenuItem";
            this.newInputPortToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.newInputPortToolStripMenuItem.Text = "New input port";
            // 
            // newOutputPortToolStripMenuItem
            // 
            this.newOutputPortToolStripMenuItem.Name = "newOutputPortToolStripMenuItem";
            this.newOutputPortToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.newOutputPortToolStripMenuItem.Text = "New output port";
            // 
            // newInputoutputPortToolStripMenuItem
            // 
            this.newInputoutputPortToolStripMenuItem.Name = "newInputoutputPortToolStripMenuItem";
            this.newInputoutputPortToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.newInputoutputPortToolStripMenuItem.Text = "New input/output port";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDebuggingToolStripMenuItem,
            this.runToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // startDebuggingToolStripMenuItem
            // 
            this.startDebuggingToolStripMenuItem.Name = "startDebuggingToolStripMenuItem";
            this.startDebuggingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.startDebuggingToolStripMenuItem.Text = "Start Debugging";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.Copy,
            this.Cut,
            this.OpenContainer,
            this.Run,
            this.Pause,
            this.Continue,
            this.Stop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Open
            // 
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(28, 28);
            this.Open.Text = "Open";
            // 
            // Save
            // 
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(28, 28);
            this.Save.Text = "Save";
            // 
            // Copy
            // 
            this.Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy.Image = ((System.Drawing.Image)(resources.GetObject("Copy.Image")));
            this.Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(28, 28);
            this.Copy.Text = "Copy";
            // 
            // Cut
            // 
            this.Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cut.Image = ((System.Drawing.Image)(resources.GetObject("Cut.Image")));
            this.Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(28, 28);
            this.Cut.Text = "Cut";
            // 
            // OpenContainer
            // 
            this.OpenContainer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenContainer.Image = ((System.Drawing.Image)(resources.GetObject("OpenContainer.Image")));
            this.OpenContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenContainer.Name = "OpenContainer";
            this.OpenContainer.Size = new System.Drawing.Size(28, 28);
            this.OpenContainer.Text = "Open the container";
            // 
            // Run
            // 
            this.Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Run.Image = ((System.Drawing.Image)(resources.GetObject("Run.Image")));
            this.Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(28, 28);
            this.Run.Text = "Run";
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Pause
            // 
            this.Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pause.Image = ((System.Drawing.Image)(resources.GetObject("Pause.Image")));
            this.Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(28, 28);
            this.Pause.Text = "Pause";
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Continue
            // 
            this.Continue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Continue.Image = ((System.Drawing.Image)(resources.GetObject("Continue.Image")));
            this.Continue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(28, 28);
            this.Continue.Text = "Continue";
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Stop
            // 
            this.Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Stop.Image = ((System.Drawing.Image)(resources.GetObject("Stop.Image")));
            this.Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(28, 28);
            this.Stop.Text = "Stop";
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(358, 222);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.Library);
            this.tabControl1.Controls.Add(this.Tree);
            this.tabControl1.Location = new System.Drawing.Point(8, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(219, 462);
            this.tabControl1.TabIndex = 3;
            // 
            // Library
            // 
            this.Library.BackColor = System.Drawing.SystemColors.Control;
            this.Library.Controls.Add(this.treeView1);
            this.Library.Location = new System.Drawing.Point(4, 22);
            this.Library.Name = "Library";
            this.Library.Padding = new System.Windows.Forms.Padding(3);
            this.Library.Size = new System.Drawing.Size(211, 436);
            this.Library.TabIndex = 0;
            this.Library.Text = "Library";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)), true);
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.directoryIcons;
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 22;
            this.treeView1.Location = new System.Drawing.Point(-4, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "BloodPressure";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "BloodPressure";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Temperature";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Text = "Temperature";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "HeartRate";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "HeartRate";
            treeNode4.Name = "Physical";
            treeNode4.Text = "Physical";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "BloodPressureSensor";
            treeNode5.SelectedImageIndex = 4;
            treeNode5.Text = "BloodPressureSensor";
            treeNode6.ImageIndex = 5;
            treeNode6.Name = "TemperatureSensor";
            treeNode6.SelectedImageIndex = 5;
            treeNode6.Text = "TemperatureSensor";
            treeNode7.ImageIndex = 6;
            treeNode7.Name = "HeartRateSensor";
            treeNode7.SelectedImageIndex = 6;
            treeNode7.Text = "HeartRateSensor";
            treeNode8.Name = "Sensing";
            treeNode8.Text = "Sensing";
            treeNode9.ImageIndex = 7;
            treeNode9.Name = "DisplayController";
            treeNode9.SelectedImageIndex = 7;
            treeNode9.Text = "DisplayController";
            treeNode10.ImageIndex = 31;
            treeNode10.Name = "Monitor";
            treeNode10.SelectedImageIndex = 31;
            treeNode10.Text = "Monitor";
            treeNode11.ImageIndex = 32;
            treeNode11.Name = "BloodPressureMonitor";
            treeNode11.SelectedImageIndex = 32;
            treeNode11.Text = "BloodPressureMonitor";
            treeNode12.ImageIndex = 33;
            treeNode12.Name = "TemperatureMonitor";
            treeNode12.SelectedImageIndex = 33;
            treeNode12.Text = "TemperatureMonitor";
            treeNode13.ImageIndex = 34;
            treeNode13.Name = "HeartRateMonitor";
            treeNode13.SelectedImageIndex = 34;
            treeNode13.Text = "HeartRateMonitor";
            treeNode14.ImageIndex = 8;
            treeNode14.Name = "AudioController";
            treeNode14.SelectedImageIndex = 8;
            treeNode14.Text = "AudioController";
            treeNode15.ImageIndex = 9;
            treeNode15.Name = "ElectricMachineryController";
            treeNode15.SelectedImageIndex = 9;
            treeNode15.Text = "ElectricMachineryController";
            treeNode16.Name = "Controlling";
            treeNode16.Text = "Controlling";
            treeNode17.ImageIndex = 10;
            treeNode17.Name = "MicroProcessor";
            treeNode17.SelectedImageIndex = 10;
            treeNode17.Text = "MicroProcessor";
            treeNode18.ImageIndex = 11;
            treeNode18.Name = "ProtocolConverter";
            treeNode18.SelectedImageIndex = 11;
            treeNode18.Text = "ProtocolConverter";
            treeNode19.ImageIndex = 12;
            treeNode19.Name = "DataProcessor";
            treeNode19.SelectedImageIndex = 12;
            treeNode19.Text = "DataProcessor";
            treeNode20.ImageIndex = 13;
            treeNode20.Name = "DataAnalyzer";
            treeNode20.SelectedImageIndex = 13;
            treeNode20.Text = "DataAnalyzer";
            treeNode21.ImageIndex = 30;
            treeNode21.Name = "RouteModule";
            treeNode21.SelectedImageIndex = 30;
            treeNode21.Text = "RouteModule";
            treeNode22.Name = "Computing";
            treeNode22.Text = "Computing";
            treeNode23.ImageIndex = 14;
            treeNode23.Name = "WiredModule";
            treeNode23.SelectedImageIndex = 14;
            treeNode23.Text = "WiredModule";
            treeNode24.ImageIndex = 15;
            treeNode24.Name = "WirelessModule";
            treeNode24.SelectedImageIndex = 15;
            treeNode24.Text = "WirelessModule";
            treeNode25.Name = "Communication";
            treeNode25.Text = "Communication";
            treeNode26.ImageIndex = 16;
            treeNode26.Name = "WiredMedia";
            treeNode26.SelectedImageIndex = 16;
            treeNode26.Text = "WiredMedia";
            treeNode27.ImageIndex = 17;
            treeNode27.Name = "WirelessMedia";
            treeNode27.SelectedImageIndex = 17;
            treeNode27.Text = "WirelessMedia";
            treeNode28.Name = "Transfer";
            treeNode28.Text = "Transfer";
            treeNode29.ImageIndex = 18;
            treeNode29.Name = "Register";
            treeNode29.SelectedImageIndex = 18;
            treeNode29.Text = "Register";
            treeNode30.ImageIndex = 19;
            treeNode30.Name = "RAM";
            treeNode30.SelectedImageIndex = 19;
            treeNode30.Text = "RAM";
            treeNode31.ImageIndex = 20;
            treeNode31.Name = "ROM";
            treeNode31.SelectedImageIndex = 20;
            treeNode31.Text = "ROM";
            treeNode32.ImageIndex = 21;
            treeNode32.Name = "DataMemory";
            treeNode32.SelectedImageIndex = 21;
            treeNode32.Text = "DataMemory";
            treeNode33.ImageIndex = 22;
            treeNode33.Name = "Buffer";
            treeNode33.SelectedImageIndex = 22;
            treeNode33.Text = "Buffer";
            treeNode34.Name = "Storing";
            treeNode34.Text = "Storing";
            treeNode35.Name = "BasicLibrary";
            treeNode35.Text = "BasicLibrary";
            treeNode36.ImageIndex = 23;
            treeNode36.Name = "Patient";
            treeNode36.SelectedImageIndex = 23;
            treeNode36.Text = "Patient";
            treeNode37.Name = "User";
            treeNode37.Text = "User";
            treeNode38.ImageIndex = 24;
            treeNode38.Name = "BloodPressureSensorNode";
            treeNode38.SelectedImageIndex = 24;
            treeNode38.Text = "BloodPressureSensorNode";
            treeNode39.ImageIndex = 25;
            treeNode39.Name = "TemperatureSensorNode";
            treeNode39.SelectedImageIndex = 25;
            treeNode39.Text = "TemperatureSensorNode";
            treeNode40.ImageIndex = 26;
            treeNode40.Name = "HeartRateSensorNode";
            treeNode40.SelectedImageIndex = 26;
            treeNode40.Text = "HeartRateSensorNode";
            treeNode41.ImageKey = "(默认值)";
            treeNode41.Name = "SensorNode";
            treeNode41.Text = "SensorNode";
            treeNode42.ImageIndex = 27;
            treeNode42.Name = "IoTGateway";
            treeNode42.SelectedImageIndex = 27;
            treeNode42.Text = "IoTGateway";
            treeNode43.Name = "Gateway";
            treeNode43.Text = "Gateway";
            treeNode44.ImageIndex = 17;
            treeNode44.Name = "802.15.4Channel";
            treeNode44.SelectedImageIndex = 17;
            treeNode44.Text = "802.15.4 Channel";
            treeNode45.ImageIndex = 17;
            treeNode45.Name = "802.15.1Channel";
            treeNode45.SelectedImageIndex = 17;
            treeNode45.Text = "802.15.1 Channel";
            treeNode46.ImageIndex = 17;
            treeNode46.Name = "802.11Channel";
            treeNode46.SelectedImageIndex = 17;
            treeNode46.Text = "802.11 Channel";
            treeNode47.ImageIndex = 16;
            treeNode47.Name = "EthernetChannel";
            treeNode47.SelectedImageIndex = 16;
            treeNode47.Text = "Ethernet Channel";
            treeNode48.Name = "Channel";
            treeNode48.Text = "Channel";
            treeNode49.ImageIndex = 28;
            treeNode49.Name = "IPv6Router";
            treeNode49.SelectedImageIndex = 28;
            treeNode49.Text = "IPv6Router";
            treeNode50.Name = "Router";
            treeNode50.Text = "Router";
            treeNode51.ImageIndex = 29;
            treeNode51.Name = "MedicalServer";
            treeNode51.SelectedImageIndex = 29;
            treeNode51.Text = "MedicalServer";
            treeNode52.Name = "Server";
            treeNode52.Text = "Server";
            treeNode53.Name = "CMIoTLibrary";
            treeNode53.Text = "CMIoTLibrary";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode53});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(215, 440);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // directoryIcons
            // 
            this.directoryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("directoryIcons.ImageStream")));
            this.directoryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.directoryIcons.Images.SetKeyName(0, "File.jpg");
            this.directoryIcons.Images.SetKeyName(1, "BloodPressure.png");
            this.directoryIcons.Images.SetKeyName(2, "Temperature.png");
            this.directoryIcons.Images.SetKeyName(3, "HartRate.png");
            this.directoryIcons.Images.SetKeyName(4, "BloodPressureSensor.png");
            this.directoryIcons.Images.SetKeyName(5, "TemperatureSensor.png");
            this.directoryIcons.Images.SetKeyName(6, "HartRateSensor.png");
            this.directoryIcons.Images.SetKeyName(7, "DisplayController.png");
            this.directoryIcons.Images.SetKeyName(8, "AudioController.png");
            this.directoryIcons.Images.SetKeyName(9, "ElectricMachineryController.png");
            this.directoryIcons.Images.SetKeyName(10, "MicroProcessor.png");
            this.directoryIcons.Images.SetKeyName(11, "ProtocolConverter.png");
            this.directoryIcons.Images.SetKeyName(12, "DataProcessor.png");
            this.directoryIcons.Images.SetKeyName(13, "DataAnalyzer.png");
            this.directoryIcons.Images.SetKeyName(14, "WiredModule.png");
            this.directoryIcons.Images.SetKeyName(15, "WirelessModule.png");
            this.directoryIcons.Images.SetKeyName(16, "WiredMedia.png");
            this.directoryIcons.Images.SetKeyName(17, "WirelessMedia.png");
            this.directoryIcons.Images.SetKeyName(18, "Register.png");
            this.directoryIcons.Images.SetKeyName(19, "RAM.png");
            this.directoryIcons.Images.SetKeyName(20, "ROM.png");
            this.directoryIcons.Images.SetKeyName(21, "DataMemory.png");
            this.directoryIcons.Images.SetKeyName(22, "Buffer.png");
            this.directoryIcons.Images.SetKeyName(23, "Patient.png");
            this.directoryIcons.Images.SetKeyName(24, "BloodPressureSensorNode.png");
            this.directoryIcons.Images.SetKeyName(25, "TemperatureSensorNode.png");
            this.directoryIcons.Images.SetKeyName(26, "HartRateSensorNode.png");
            this.directoryIcons.Images.SetKeyName(27, "IoTGateway.png");
            this.directoryIcons.Images.SetKeyName(28, "IPv6Router.png");
            this.directoryIcons.Images.SetKeyName(29, "MedicalServer.png");
            this.directoryIcons.Images.SetKeyName(30, "RouteModule.png");
            this.directoryIcons.Images.SetKeyName(31, "Monitor .png");
            this.directoryIcons.Images.SetKeyName(32, "BloodPressureMonitor.png");
            this.directoryIcons.Images.SetKeyName(33, "TemperatureMonitor.png");
            this.directoryIcons.Images.SetKeyName(34, "HeartRateMonitor.png");
            // 
            // Tree
            // 
            this.Tree.BackColor = System.Drawing.SystemColors.Control;
            this.Tree.Location = new System.Drawing.Point(4, 22);
            this.Tree.Name = "Tree";
            this.Tree.Padding = new System.Windows.Forms.Padding(3);
            this.Tree.Size = new System.Drawing.Size(211, 436);
            this.Tree.TabIndex = 1;
            this.Tree.Text = "Tree";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 21);
            this.textBox1.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(233, 58);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(643, 489);
            this.tabControl2.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.graphControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Design";
            // 
            // graphControl
            // 
            this.graphControl.AllowAddConnection = true;
            this.graphControl.AllowAddShape = true;
            this.graphControl.AllowDeleteShape = true;
            this.graphControl.AllowDrop = true;
            this.graphControl.AllowMoveShape = true;
            this.graphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphControl.AutomataPulse = 10;
            this.graphControl.AutoScroll = true;
            this.graphControl.BackgroundColor = System.Drawing.Color.White;
            this.graphControl.BackgroundImagePath = null;
            this.graphControl.BackgroundType = Netron.GraphLib.CanvasBackgroundType.FlatColor;
            this.graphControl.CausesValidation = false;
            this.graphControl.DefaultConnectionEnd = Netron.GraphLib.ConnectionEnd.NoEnds;
            this.graphControl.DefaultConnectionPath = "Default";
            this.graphControl.DoTrack = false;
            this.graphControl.EnableContextMenu = true;
            this.graphControl.EnableLayout = false;
            this.graphControl.EnableToolTip = true;
            this.graphControl.FileName = null;
            this.graphControl.GradientBottom = System.Drawing.Color.White;
            this.graphControl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.graphControl.GradientTop = System.Drawing.Color.LightSteelBlue;
            this.graphControl.GraphLayoutAlgorithm = Netron.GraphLib.GraphLayoutAlgorithms.SpringEmbedder;
            this.graphControl.GridSize = 20;
            this.graphControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graphControl.Location = new System.Drawing.Point(-4, -4);
            this.graphControl.Margin = new System.Windows.Forms.Padding(0);
            this.graphControl.Name = "graphControl";
            this.graphControl.RestrictToCanvas = false;
            this.graphControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.graphControl.ShowAutomataController = false;
            this.graphControl.ShowGrid = false;
            this.graphControl.Size = new System.Drawing.Size(643, 467);
            this.graphControl.Snap = false;
            this.graphControl.TabIndex = 0;
            this.graphControl.Text = "graphControl";
            this.graphControl.Zoom = 1F;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(635, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XModel v2.0  Copyright ©2019";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Library.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newInputPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOutputPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newInputoutputPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDebuggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Copy;
        private System.Windows.Forms.ToolStripButton Cut;
        private System.Windows.Forms.ToolStripButton Run;
        private System.Windows.Forms.ToolStripButton Pause;
        private System.Windows.Forms.ToolStripButton Stop;
        private System.Windows.Forms.ToolStripButton OpenContainer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Library;
        private System.Windows.Forms.TabPage Tree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList directoryIcons;
        private Netron.GraphLib.UI.GraphControl graphControl;
        private System.Windows.Forms.ToolStripButton Continue;

        public Netron.GraphLib.UI.GraphControl GraphControl
        {
            get { return graphControl; }
            set { graphControl = value; }
        }

    }
}

