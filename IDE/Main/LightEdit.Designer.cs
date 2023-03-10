namespace IDE
{
    partial class LightEdit
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightEdit));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤消UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重复RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行f5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鸣谢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.许可与版权声明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭CtrlF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.运行RToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1395, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem});
            this.文件FToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.打开OToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.打开OToolStripMenuItem.Image = global::IDE.Properties.Resources._disabled_open_file;
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.保存SToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.保存SToolStripMenuItem.Image = global::IDE.Properties.Resources.save;
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.QuietSave);
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.另存为AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            this.另存为AToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤消UToolStripMenuItem,
            this.重复RToolStripMenuItem,
            this.剪切TToolStripMenuItem,
            this.复制CToolStripMenuItem,
            this.粘贴PToolStripMenuItem,
            this.全选AToolStripMenuItem});
            this.编辑EToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 撤消UToolStripMenuItem
            // 
            this.撤消UToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.撤消UToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.撤消UToolStripMenuItem.Name = "撤消UToolStripMenuItem";
            this.撤消UToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.撤消UToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.撤消UToolStripMenuItem.Text = "撤消(&U)";
            this.撤消UToolStripMenuItem.Click += new System.EventHandler(this.Undo);
            // 
            // 重复RToolStripMenuItem
            // 
            this.重复RToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重复RToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重复RToolStripMenuItem.Name = "重复RToolStripMenuItem";
            this.重复RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重复RToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.重复RToolStripMenuItem.Text = "重复(&R)";
            this.重复RToolStripMenuItem.Click += new System.EventHandler(this.Redo);
            // 
            // 剪切TToolStripMenuItem
            // 
            this.剪切TToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.剪切TToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.剪切TToolStripMenuItem.Image = global::IDE.Properties.Resources.edit_cut1;
            this.剪切TToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切TToolStripMenuItem.Name = "剪切TToolStripMenuItem";
            this.剪切TToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切TToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.剪切TToolStripMenuItem.Text = "剪切(&T)";
            this.剪切TToolStripMenuItem.Click += new System.EventHandler(this.Cut);
            // 
            // 复制CToolStripMenuItem
            // 
            this.复制CToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.复制CToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.复制CToolStripMenuItem.Image = global::IDE.Properties.Resources.Copy;
            this.复制CToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem";
            this.复制CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.复制CToolStripMenuItem.Text = "复制(&C)";
            this.复制CToolStripMenuItem.Click += new System.EventHandler(this.Copy);
            // 
            // 粘贴PToolStripMenuItem
            // 
            this.粘贴PToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.粘贴PToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.粘贴PToolStripMenuItem.Image = global::IDE.Properties.Resources.d_Paste;
            this.粘贴PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripMenuItem.Name = "粘贴PToolStripMenuItem";
            this.粘贴PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴PToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.粘贴PToolStripMenuItem.Text = "粘贴(&P)";
            this.粘贴PToolStripMenuItem.Click += new System.EventHandler(this.Paste);
            // 
            // 全选AToolStripMenuItem
            // 
            this.全选AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.全选AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.全选AToolStripMenuItem.Name = "全选AToolStripMenuItem";
            this.全选AToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.全选AToolStripMenuItem.Text = "全选(&A)";
            this.全选AToolStripMenuItem.Click += new System.EventHandler(this.SelectAll);
            // 
            // 运行RToolStripMenuItem
            // 
            this.运行RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行f5ToolStripMenuItem});
            this.运行RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行RToolStripMenuItem.Name = "运行RToolStripMenuItem";
            this.运行RToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.运行RToolStripMenuItem.Text = "运行(&R)";
            // 
            // 运行f5ToolStripMenuItem
            // 
            this.运行f5ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.运行f5ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.运行f5ToolStripMenuItem.Image = global::IDE.Properties.Resources.detail;
            this.运行f5ToolStripMenuItem.Name = "运行f5ToolStripMenuItem";
            this.运行f5ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.运行f5ToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.运行f5ToolStripMenuItem.Text = "运行";
            this.运行f5ToolStripMenuItem.Click += new System.EventHandler(this.Run);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.鸣谢ToolStripMenuItem,
            this.许可与版权声明ToolStripMenuItem});
            this.帮助HToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.关于AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.关于AToolStripMenuItem.Image = global::IDE.Properties.Resources.help2;
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.AboutThis);
            // 
            // 鸣谢ToolStripMenuItem
            // 
            this.鸣谢ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.鸣谢ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.鸣谢ToolStripMenuItem.Image = global::IDE.Properties.Resources.Info_dark;
            this.鸣谢ToolStripMenuItem.Name = "鸣谢ToolStripMenuItem";
            this.鸣谢ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.鸣谢ToolStripMenuItem.Text = "鸣谢";
            // 
            // 许可与版权声明ToolStripMenuItem
            // 
            this.许可与版权声明ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.许可与版权声明ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.许可与版权声明ToolStripMenuItem.Image = global::IDE.Properties.Resources._48x48_check;
            this.许可与版权声明ToolStripMenuItem.Name = "许可与版权声明ToolStripMenuItem";
            this.许可与版权声明ToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.许可与版权声明ToolStripMenuItem.Text = "许可与版权声明";
            this.许可与版权声明ToolStripMenuItem.Click += new System.EventHandler(this.copyrightsAndLicense);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "code";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Save);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pycn";
            this.saveFileDialog1.FileName = "code";
            this.saveFileDialog1.Filter = "Py-CN文件|*.pycn|Py-CN编译后文件|*.py";
            this.saveFileDialog1.InitialDirectory = "C:\\Windows\\System32";
            this.saveFileDialog1.Title = "选择保存的文件:";
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(1395, 702);
            this.tabControl1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.UseStyleColors = true;
            this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl1_DragDrop);
            this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.LoadFile);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新RToolStripMenuItem,
            this.关闭CtrlF4ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 56);
            // 
            // 刷新RToolStripMenuItem
            // 
            this.刷新RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.刷新RToolStripMenuItem.Image = global::IDE.Properties.Resources.refresh;
            this.刷新RToolStripMenuItem.Name = "刷新RToolStripMenuItem";
            this.刷新RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.刷新RToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.刷新RToolStripMenuItem.Text = "从磁盘强制刷新";
            this.刷新RToolStripMenuItem.Click += new System.EventHandler(this.Refresh);
            // 
            // 关闭CtrlF4ToolStripMenuItem
            // 
            this.关闭CtrlF4ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭CtrlF4ToolStripMenuItem.Image = global::IDE.Properties.Resources.delete;
            this.关闭CtrlF4ToolStripMenuItem.Name = "关闭CtrlF4ToolStripMenuItem";
            this.关闭CtrlF4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.关闭CtrlF4ToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.关闭CtrlF4ToolStripMenuItem.Text = "不保存而强制关闭";
            this.关闭CtrlF4ToolStripMenuItem.Click += new System.EventHandler(this.CloseFile);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.isExeFile);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(144, 20);
            this.toolStripStatusLabel2.Text = "文件：已禁止修改。";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 759);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1395, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::IDE.Properties.Resources._48x48_Warn;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            this.toolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1100;
            this.timer3.Tick += new System.EventHandler(this.WriteDownMem);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.Black;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel4});
            this.statusStrip2.Location = new System.Drawing.Point(0, 733);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1395, 26);
            this.statusStrip2.TabIndex = 4;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(47, 20);
            this.toolStripStatusLabel6.Text = "输入: ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(1333, 20);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "在LightEdit模式下，您无法最大化。";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 30);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.配置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.配置ToolStripMenuItem.Image = global::IDE.Properties.Resources.edit___副本;
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.配置ToolStripMenuItem.Text = "...配置";
            this.配置ToolStripMenuItem.Click += new System.EventHandler(this.CodeConfig);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.SyncCC);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.BackgroundImage = global::IDE.Properties.Resources.help2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1860, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.help);
            // 
            // LightEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1395, 785);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LightEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RYCB Py-CN Editor - LightEdit模式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitByClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RunFile);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤消UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 运行RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行f5ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭CtrlF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.ToolStripMenuItem 鸣谢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 许可与版权声明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem 重复RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选AToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private MetroFramework.Controls.MetroTabControl tabControl1;
    }
}

