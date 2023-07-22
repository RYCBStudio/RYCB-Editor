﻿using System.Windows.Forms;

namespace IDE
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鸣谢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.许可与版权声明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.开发者选项DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.崩溃测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成本地化示例文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new Sunny.UI.UITabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭CtrlF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.SyntaxErrorChecker = new System.Windows.Forms.Timer(this.components);
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiListBox1 = new Sunny.UI.UIListBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.HelpButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.开发者选项DToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem});
            this.文件FToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(71, 28);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.新建NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目ToolStripMenuItem,
            this.文件ToolStripMenuItem});
            this.新建NToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.新建NToolStripMenuItem.Image = global::IDE.Properties.Resources.edit;
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.新建NToolStripMenuItem.Text = "新建";
            // 
            // 项目ToolStripMenuItem
            // 
            this.项目ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.项目ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.项目ToolStripMenuItem.Image = global::IDE.Properties.Resources.Window;
            this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
            this.项目ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.项目ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.项目ToolStripMenuItem.Text = "项目";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.文件ToolStripMenuItem.Image = global::IDE.Properties.Resources.file_common;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.New);
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
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(71, 28);
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
            // 
            // 重复RToolStripMenuItem
            // 
            this.重复RToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重复RToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重复RToolStripMenuItem.Name = "重复RToolStripMenuItem";
            this.重复RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重复RToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.重复RToolStripMenuItem.Text = "重复(&R)";
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
            // 
            // 全选AToolStripMenuItem
            // 
            this.全选AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.全选AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.全选AToolStripMenuItem.Name = "全选AToolStripMenuItem";
            this.全选AToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.全选AToolStripMenuItem.Text = "全选(&A)";
            // 
            // 运行RToolStripMenuItem
            // 
            this.运行RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem});
            this.运行RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行RToolStripMenuItem.Name = "运行RToolStripMenuItem";
            this.运行RToolStripMenuItem.Size = new System.Drawing.Size(73, 28);
            this.运行RToolStripMenuItem.Text = "运行(&R)";
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.运行ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行ToolStripMenuItem.Image = global::IDE.Properties.Resources.Run1;
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.Run);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义CToolStripMenuItem,
            this.选项OToolStripMenuItem});
            this.工具TToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(72, 28);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.自定义CToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.自定义CToolStripMenuItem.Text = "自定义(&C)";
            this.自定义CToolStripMenuItem.Click += new System.EventHandler(this.CustomSet);
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.选项OToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.选项OToolStripMenuItem.Text = "选项(&O)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.鸣谢ToolStripMenuItem,
            this.许可与版权声明ToolStripMenuItem});
            this.帮助HToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(75, 28);
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
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(135, 28);
            this.toolStripTextBox1.Text = "语法高亮类型：";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.BackColor = System.Drawing.Color.Black;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox1.ForeColor = System.Drawing.Color.White;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "(内置) Python",
            "(内置) Py-CN",
            "(内置) 纯文本",
            "(内置) C#"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(135, 28);
            // 
            // 开发者选项DToolStripMenuItem
            // 
            this.开发者选项DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.崩溃测试ToolStripMenuItem,
            this.生成本地化示例文件ToolStripMenuItem});
            this.开发者选项DToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.开发者选项DToolStripMenuItem.Name = "开发者选项DToolStripMenuItem";
            this.开发者选项DToolStripMenuItem.Size = new System.Drawing.Size(119, 28);
            this.开发者选项DToolStripMenuItem.Text = "开发者选项(&D)";
            // 
            // 崩溃测试ToolStripMenuItem
            // 
            this.崩溃测试ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.崩溃测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.崩溃测试ToolStripMenuItem.Name = "崩溃测试ToolStripMenuItem";
            this.崩溃测试ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.崩溃测试ToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.崩溃测试ToolStripMenuItem.Text = "崩溃测试";
            this.崩溃测试ToolStripMenuItem.Click += new System.EventHandler(this.TestCrash);
            // 
            // 生成本地化示例文件ToolStripMenuItem
            // 
            this.生成本地化示例文件ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.生成本地化示例文件ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.生成本地化示例文件ToolStripMenuItem.Name = "生成本地化示例文件ToolStripMenuItem";
            this.生成本地化示例文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.End)));
            this.生成本地化示例文件ToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.生成本地化示例文件ToolStripMenuItem.Text = "生成本地化示例文件";
            this.生成本地化示例文件ToolStripMenuItem.Click += new System.EventHandler(this.GenerateI18nExampleFile);
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
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabControl1.Frame = null;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 65);
            this.tabControl1.MainPage = "";
            this.tabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowCloseButton = true;
            this.tabControl1.Size = new System.Drawing.Size(1722, 853);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.StyleCustomMode = true;
            this.tabControl1.TabBackColor = System.Drawing.Color.Black;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tabControl1.BeforeRemoveTabPage += new Sunny.UI.UITabControl.OnBeforeRemoveTabPage(this.TabControl1_BeforeRemoveTabPage);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新RToolStripMenuItem,
            this.关闭CtrlF4ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 56);
            // 
            // 刷新RToolStripMenuItem
            // 
            this.刷新RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.刷新RToolStripMenuItem.Image = global::IDE.Properties.Resources.refresh;
            this.刷新RToolStripMenuItem.Name = "刷新RToolStripMenuItem";
            this.刷新RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.刷新RToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.刷新RToolStripMenuItem.Text = "刷新(&R)";
            // 
            // 关闭CtrlF4ToolStripMenuItem
            // 
            this.关闭CtrlF4ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭CtrlF4ToolStripMenuItem.Image = global::IDE.Properties.Resources.delete;
            this.关闭CtrlF4ToolStripMenuItem.Name = "关闭CtrlF4ToolStripMenuItem";
            this.关闭CtrlF4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.关闭CtrlF4ToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.关闭CtrlF4ToolStripMenuItem.Text = "关闭";
            this.关闭CtrlF4ToolStripMenuItem.Click += new System.EventHandler(this.CloseFile);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1722, 823);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "(临时)";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(4, 4);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1704, 810);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
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
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 947);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1902, 26);
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
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(757, 20);
            this.toolStripStatusLabel4.Text = "                                                                                 " +
    "                                                                                " +
    "                          ";
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
            this.toolStripStatusLabel7});
            this.statusStrip2.Location = new System.Drawing.Point(0, 921);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1902, 26);
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
            // timer5
            // 
            this.timer5.Interval = 1000;
            this.timer5.Tick += new System.EventHandler(this.IsMaximized);
            // 
            // SyntaxErrorChecker
            // 
            this.SyntaxErrorChecker.Tick += new System.EventHandler(this.CheckSyntaxError);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiListBox1);
            this.uiGroupBox1.FillColor = System.Drawing.Color.Black;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.Black;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.uiGroupBox1.Location = new System.Drawing.Point(1729, 70);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Radius = 10;
            this.uiGroupBox1.RectColor = System.Drawing.Color.Red;
            this.uiGroupBox1.Size = new System.Drawing.Size(165, 848);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.StyleCustomMode = true;
            this.uiGroupBox1.TabIndex = 7;
            this.uiGroupBox1.Text = "错误和警告";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.Visible = false;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiListBox1
            // 
            this.uiListBox1.FillColor = System.Drawing.Color.Black;
            this.uiListBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiListBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.uiListBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiListBox1.Items.AddRange(new object[] {
            "TestErr1",
            "TestErr2"});
            this.uiListBox1.ItemSelectForeColor = System.Drawing.Color.White;
            this.uiListBox1.Location = new System.Drawing.Point(4, 33);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox1.RectColor = System.Drawing.Color.OrangeRed;
            this.uiListBox1.RectSize = 2;
            this.uiListBox1.ScrollBarColor = System.Drawing.Color.Silver;
            this.uiListBox1.ShowText = false;
            this.uiListBox1.Size = new System.Drawing.Size(156, 811);
            this.uiListBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiListBox1.StyleCustomMode = true;
            this.uiListBox1.TabIndex = 0;
            this.uiListBox1.Text = "uiListBox1";
            this.uiListBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckErr);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox2.ForeColor = System.Drawing.SystemColors.Menu;
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripComboBox2.Size = new System.Drawing.Size(200, 28);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.ContextMenuStrip = this.contextMenuStrip2;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1902, 28);
            this.toolStrip1.TabIndex = 6;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::IDE.Properties.Resources.Run;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton2.Text = "运行";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::IDE.Properties.Resources.Debug_Color;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton1.Text = "调试";
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton.BackgroundImage = global::IDE.Properties.Resources.help2;
            this.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(1860, 12);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(30, 30);
            this.HelpButton.TabIndex = 5;
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.help);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1902, 973);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RYCB Py-CN Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitByClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FirstInit);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤消UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Sunny.UI.UITabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭CtrlF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.ToolStripMenuItem 鸣谢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 许可与版权声明ToolStripMenuItem;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem 重复RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选AToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripMenuItem 项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.Timer SyntaxErrorChecker;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIListBox uiListBox1;
        private System.Windows.Forms.ToolStripMenuItem 开发者选项DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 崩溃测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成本地化示例文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行RToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
    }
}

