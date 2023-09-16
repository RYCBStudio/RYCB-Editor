﻿#region 导入命名空间
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Search;
using Microsoft.Scripting.Utils;
using Sunny.UI;
using TextEditor = ICSharpCode.AvalonEdit.TextEditor;
#endregion

namespace IDE
{
    public partial class Main : Form
    {
        #region 一堆变量和常量
        private static readonly string STARTUP_PATH = Program.STARTUP_PATH;
        private static readonly IniFile reConf = Program.reConf;
        private static readonly Stopwatch stopwatch = new();
        private string title = "选择文件：", filter = "Py-CN文件|*.pycn|Py-CN编译后文件(Python 文件)|*.py|所有文件|*.*";
        private static StreamWriter keepFile;
        private string LightEdit_File;
        private bool NoTip, isModified = false, LightEdit = false;
        private TextEditor edit;
        private int tmp_, _i;
        private static string CachePath = Application.StartupPath + "\\Cache\\";
        private static readonly Process proc = Process.GetCurrentProcess();
        //private static StreamWriter CacheWriter;
        //private struct elementHost1
        //{
        //    private elementHost1()
        //    {
        //    }

        //    Size Size = new Size(852, 293);
        //}
        private static ErrorMessageBox errMsgBox;
        internal static string XshdFilePath;
        public const string VERSION = "0.0.2";
        public const string FRIENDLY_VER = "0.0.2-Beta.64";
        public static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        public string text_tsl2;
        #endregion
        #region 一堆方法
        #region 构造函数
        /// <summary>
        /// Common
        /// </summary>
        public Main()
        {
            try
            {
                InitializeComponent();
                InitializeTranslation();
                Program.splash.metroProgressBar1.PerformStep();
            }
            catch (Exception ex)
            {
                try
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}\nInnerEx:\n{ex.InnerException.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                    else
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
                catch (NullReferenceException ex1)
                {
                    MessageBox.Show($"{ex1.GetType()}\n{ex1.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// LightEdit
        /// </summary>
        /// <param name="file">File</param>
        public Main(string file)
        {
            try
            {
                InitializeComponent();
                InitializeTranslation();
                LightEdit_File = file;
                LightEdit = true;
                Program.splash.metroProgressBar1.PerformStep();
            }
            catch (Exception ex)
            {
                try
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}\nInnerEx:\n{ex.InnerException.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                    else
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
                catch (NullReferenceException ex1)
                {
                    MessageBox.Show($"{ex1.GetType()}\n{ex1.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region 初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            XshdFilePath = reConf.ReadString("Editor", "XshdFilePath", STARTUP_PATH + "\\Config\\Highlighting");
            //CacheWriter = new(CachePath + "\\Cache.pycncachelist", true, Encoding.UTF8);
            ClearLog();
            edit = new TextEditor()
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(Editor.Back),
                Foreground = new SolidColorBrush(Editor.Fore),
                FontSize = reConf.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
            };
            edit.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            edit.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            elementHost1.Child = edit;
            //快速搜索功能
            SearchPanel.Install(edit.TextArea);
            using (Stream s = new FileStream(XshdFilePath + "\\Py-CN.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
            if (LightEdit)
            {
                edit.Load(LightEdit_File);
                tabPage1.Text = GetFileName(LightEdit_File);
                tabPage1.ToolTipText = LightEdit_File;
            }
        }
        #endregion
        #region 打开文件
        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == null || openFileDialog1.FileName == "")
                {
                    return;
                }
                var tmp = @openFileDialog1.FileName.Split('\\')[@openFileDialog1.FileName.Split('\\').Length - 1];
                var _ = tmp.Split('.')[tmp.Split('.').Length - 1];
                if (tmp.Equals("BOOTMGR", StringComparison.CurrentCultureIgnoreCase))
                {
                    toolStripStatusLabel2.Text = "Windows NT " + _I18nFile.ReadString("I18n", "text.inprogram.bootfile", "text.inprogram.bootfile") + "(.efi|BOOTMGR)" + text_tsl2;
                    var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + toolStripStatusLabel2.Text + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                    var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else
                {
                    CheckFileTypeAndAlert(_, tmp);
                }
            }
            else { }
        }
        #endregion
        #region 关于
        private void AboutThis(object sender, EventArgs e)
        {
            LOGGER.WriteLog("即将打开“关于”窗口。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            About form = new();
            form.Show();
            LOGGER.WriteLog("成功。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            LOGGER.WriteLog($"窗口位置：({form.Location.X}, {form.Location.Y})", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
        }
        #endregion
        #region 新建文件
        private void New(object sender, EventArgs e)
        {
            var nf = new NewFile("输入文件名");
            LOGGER.WriteLog("新建文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            var _ds = nf.ShowDialog(this);
            var fileName = nf.GetFileName();
            if (string.IsNullOrEmpty(fileName) || nf.GetStatus() == NewFile.FileStatus.Failed)
            {
                LOGGER.WriteLog("已取消新建文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                return;
            }

            TableLayoutPanel table = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "tableLayoutPanel2",
                RowCount = 1,
                Size = new System.Drawing.Size(858, 299),
                TabIndex = 0,
            };
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50F));

            var tab = new TabPage
            {
                Text = fileName,
                BackColor = tabPage1.BackColor,
                ForeColor = tabPage1.ForeColor
            };
            LOGGER.WriteLog($"TabPage已准备就绪。\n文件名: {tab.Text}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            var tmpEHost = new ElementHost
            {
                Size = elementHost1.Size,
                Location = elementHost1.Location,
                BackColor = elementHost1.BackColor,
                ForeColor = elementHost1.ForeColor
            };
            table.Controls.Add(tmpEHost, 0, 0);
            LOGGER.WriteLog("ElementHost已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            var tmpEditor = new TextEditor
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(Editor.Back),
                Foreground = new SolidColorBrush(Editor.Fore),
                FontSize = reConf.ReadInt("Editor", "Size"),
                ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,

            };
            LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditor.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            // 快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);

            // 设置语法规则
            LOGGER.WriteLog("正在获取语法规则信息..");
            var tmpLanguage = AutoGetLanguage(tab.Text);
            var resourceName = XshdFilePath + $"\\{tmpLanguage}.xshd";
            LOGGER.WriteLog("语法规则信息获取成功。");
            LOGGER.WriteLog($"语法规则: {tmpLanguage}\t\t对应文件名: {resourceName}");
            using (Stream s = new FileStream(resourceName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            LOGGER.WriteLog("语法规则已成功设置。");

            tmpEHost.Child = tmpEditor;
            tab.Controls.Add(table);
            tabControl1.TabPages.Add(tab);
            LOGGER.WriteLog("所有设置均已完成。");
        }
        #endregion
        #region 实时保存
        private void Save(object sender, EventArgs e)
        {
            toolStripStatusLabel8.Visible = false;
            toolStripStatusLabel9.Visible = false;
            var _editor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
            if (tabControl1.SelectedTab != tabPage1 & tabControl1.SelectedTab.ToolTipText != null & tabControl1.SelectedTab.ToolTipText != "")
            {
                try
                {
                    StreamWriter streamWriter = new(tabControl1.SelectedTab.ToolTipText, false, Encoding.UTF8);
                    streamWriter.Write(_editor.Text);
                    streamWriter.Close();
                    toolStripStatusLabel8.Image = Properties.Resources.file_saved_dark;
                    toolStripStatusLabel9.Text = _I18nFile.ReadString("I18n", "text.st.filesaved", "text.st.filesaved");
                    tabControl1.SelectedTab.Text.Replace("*", "");
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel8.Image = Properties.Resources.file_save_failed_dark;
                    toolStripStatusLabel9.Text = _I18nFile.ReadString("I18n", "text.st.filesavefailed", "text.st.filesavefailed");
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
            else
            {
                toolStripStatusLabel8.Image = Properties.Resources.file_ready_to_save_dark;
                toolStripStatusLabel9.Text = _I18nFile.ReadString("I18n", "text.st.filereadytosave", "text.st.filereadytosave");
            }
            toolStripStatusLabel8.Visible = true;
            toolStripStatusLabel9.Visible = true;
        }
        #endregion
        #region 另存为
        private void SaveFile(object sender, EventArgs e)
        {
            var _editor = GetTextEditor();
            if (_editor == null)
            {
                return;
            }

            saveFileDialog1.FileName = GetTabTitle();
            UpdateSaveFileDialogFilter();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                    {
                        return;
                    }

                    using (var streamWriter = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))
                    {
                        streamWriter.Write(_editor.Text);
                    }

                    UpdateTabPageInfo(saveFileDialog1.FileName);
                    tabControl1.SelectedTab.Tag = saveFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    // 处理异常情况
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
        }

        private TextEditor GetTextEditor()
        {
            var selectedTab = tabControl1.SelectedTab;
            if (selectedTab == null)
            {
                return null;
            }

            if (selectedTab.Controls[0] is not TableLayoutPanel table)
            {
                return null;
            }

            return (table.Controls[0] as ElementHost).Child as TextEditor;
        }

        private string GetTabTitle()
        {
            var fileName = tabControl1.SelectedTab.Text.Replace("*", "");
            return fileName;
        }

        private void UpdateSaveFileDialogFilter()
        {
            string filter;
            var fileName = saveFileDialog1.FileName;

            if (fileName.Contains(".py"))
            {
                filter = "Python|*.py|Py-CN|*.pycn||*.*";
            }
            else if (fileName.Contains(".pycn"))
            {
                filter = "Py-CN|*.pycn|Python|*.py||*.*";
            }
            else
            {
                filter = "|*.*|Python|*.py|Py-CN|*.pycn";
            }

            saveFileDialog1.Filter = filter;
        }

        private void UpdateTabPageInfo(string fileName)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                tabControl1.SelectedTab.Text = GetFileNameFromPath(fileName);
                tabControl1.SelectedTab.ToolTipText = fileName;
            }
            else
            {
                var tab = new TabPage() { Text = GetFileNameFromPath(fileName), ToolTipText = fileName };
                // 添加选项卡的其他相关代码...
            }
        }

        private string GetFileNameFromPath(string path)
        {
            return path.Split('\\').Last();
        }

        #endregion
        #region 自定义设置
        private void CustomSet(object sender, EventArgs e)
        {
            Form cs = new CustomSettings(STARTUP_PATH + "\\config")
            {
                Owner = this
            };
            cs.Show();
        }
        #endregion
        #region 运行
        private void Run(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1 & tabPage1.Text != _I18nFile.ReadString("I18n", "text.tc.tp.tmp", tabPage1.Text))
                {
                    var _tmpFileName = Convert.ToString(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
                    ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                    if (tabControl1.SelectedTab.ToolTipText.Contains(".pycn"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = "\"" + tabControl1.SelectedTab.ToolTipText + "\"",
                            CreateNoWindow = true,
                        });
                        SetPyCNFileCache(GetFileName(tabControl1.SelectedTab.ToolTipText) + Path.GetExtension(tabControl1.SelectedTab.ToolTipText)); ;
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                            errMsgBox.Show();
                            return;
                        }
                        Process.Start(".\\Runner.exe", "\"" + tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py") + "\"");
                    }
                    else if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        var error = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                            errMsgBox.Show();
                            return;
                        }
                        Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText);
                    }
                }
                else
                {
                    if (tabControl1.SelectedTab.ToolTipText == "" | tabControl1.SelectedTab.ToolTipText is null)
                    {
                        string tmpPath;
                        ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                        if (tabControl1.SelectedTab == tabPage1 & tabPage1.Text == _I18nFile.ReadString("I18n", "text.tc.tp.tmp", tabPage1.Text))
                        {
                            tmpPath = Application.StartupPath + "\\$tmp_code\\tmp.pycn";
                            StreamWriter sw = new(tabPage1.ToolTipText, false, Encoding.UTF8);
                            sw.Write((((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor).Text);
                            sw.Close();
                        }
                        tmpPath = Application.StartupPath + "\\$tmp_code\\" + tabControl1.SelectedTab.Text.Split('*')[0];
                        StreamWriter streamWriter = new(tmpPath, false, Encoding.UTF8);
                        streamWriter.Write((((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor).Text);
                        streamWriter.Close();
                        tabControl1.SelectedTab.Tag = tmpPath;
                        if (tmpPath.Contains(".pycn"))
                        {
                            ProcessStartInfo tmpSI = new()
                            {
                                FileName = ".\\Compiler.exe",
                                Arguments = "\"" + tmpPath + "\"",
                                CreateNoWindow = true,
                            };
                            Process.Start(tmpSI);
                            SetPyCNFileCache(GetFileName(tmpPath) + Path.GetExtension(tmpPath)); ;
                            var error = RunPythonSrcipt(@tmpPath)[1];
                            if (error != "")
                            {
                                errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                                errMsgBox.Show();
                                return;
                            }
                            Process.Start(".\\Runner.exe", "\"" + tmpPath.Replace(".pycn", ".py") + "\"");
                        }
                        else if (tmpPath.Contains(".py"))
                        {
                            var error = RunPythonSrcipt(tmpPath)[1];
                            if (error != "")
                            {
                                errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                                errMsgBox.Show();
                                return;
                            }
                            Process.Start(".\\Runner.exe", tmpPath);
                        }
                        return;
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains("exe"))
                    {
                        Process.Start(@tabControl1.SelectedTab.ToolTipText);
                    }
                    else if (Path.GetExtension(tabControl1.SelectedTab.ToolTipText) == ".pycn")
                    {
                        ProcessStartInfo tmpSI = new()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = "\"" + tabControl1.SelectedTab.ToolTipText + "\"",
                            CreateNoWindow = true,
                        };
                        Process.Start(tmpSI);
                        SetPyCNFileCache(GetFileName(tabControl1.SelectedTab.ToolTipText) + Path.GetExtension(tabControl1.SelectedTab.ToolTipText)); ;
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py"))[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                            errMsgBox.Show();
                            return;
                        }
                        Process.Start(".\\Runner.exe", "\"" + tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py") + "\"");
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor, this);
                            errMsgBox.Show();
                            return;
                        }
                        ProcessStartInfo ps = new ProcessStartInfo()
                        {
                            FileName = ".\\Runner.exe",
                            Arguments = @tabControl1.SelectedTab.ToolTipText,
                            //WindowStyle = ProcessWindowStyle.Hidden,
                        };
                        Process p = new() { StartInfo = ps };
                        p.Start();
                        //var p_name = p.MainWindowTitle;

                        //p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                        //Task.Run(() =>
                        //{
                        //    if (SetWindow.FindWindow(p_name))
                        //    {
                        //        this.Invoke(new Action(() =>
                        //        {
                        //            SetWindow.SetParent(panel1.Handle, p_name);  //设置父容器
                        //        }));
                        //    }
                        //    else
                        //    {
                        //        LOGGER.WriteErrLog(new InvalidOperationException("未查找到窗体。"), EnumMsgLevel.ERROR, EnumPort.CLIENT);
                        //    }
                        //});
                    }
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog(ex, EnumMsgLevel.FATAL, EnumPort.CLIENT);
            }
        }
        #endregion
        #region 执行CMD
        /// <summary>
        /// 执行带返回值的CMD
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="interpreter">解释器</param>
        /// <param name="interpreter_params">解释器参数</param>
        /// <returns></returns>
        internal static string ExecuteCMDWithOutput(string command, string interpreter, string interpreter_params)
        {
            ProcessStartInfo processInfo = new(interpreter, $"{interpreter_params} " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true
            };

            Process process = new() { StartInfo = processInfo };
            process.Start();
            var outpup = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return outpup;
        }
        #endregion
        #region <FUNC> GetFileType
        /// <summary>
        /// 判断文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetFileType(object sender, EventArgs e)
        {
            var fileName = tabControl1.SelectedTab.Text;
            var extension = Path.GetExtension(fileName).TrimStart('.');

            statusStrip1.Visible = IsSupportedFileExtension(extension);

            var memoryUsage = GetDigitalMemory() - tmp_;
            toolStripStatusLabel3.Text = $"{_I18nFile.ReadString("I18n", "text.st.mem", "text.st.mem")} {GetMemory()} {(memoryUsage > 0 ? ('+'.ToString() + memoryUsage.ToString()) : memoryUsage)}MB";

            if (isModified)
            {
                SetModifiedTabTitle();
            }
        }

        private bool IsSupportedFileExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case "exe":
                case "dll":
                    return true;
                case "zip":
                case "7z":
                case "rar":
                case "001":
                case "tgz":
                case "tar":
                    return true;
                case "mp3":
                case "mp4":
                    return true;
                case "crx":
                    return true;
                case "png":
                case "jpg":
                case "gif":
                case "webp":
                case "jpeg":
                case "jfif":
                case "ico":
                case "bmp":
                    return true;
                case "jar":
                    return true;
                case "pak":
                case "pkg":
                    return true;
                case "e":
                    return true;
                case "xltd":
                    return true;
                case "iso":
                    return true;
                case "efi":
                    return true;
                case "sb2":
                case "sb3":
                    return true;
                default:
                    return false;
            }
        }

        private void SetModifiedTabTitle()
        {
            try
            {
                var text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
            catch (NullReferenceException)
            {
                var text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
        }
        #endregion
        #region <FUNC> 占位方法
        private void func_0a1(string tmp)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == tmp)
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }
            TableLayoutPanel table = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "tableLayoutPanel2",
                RowCount = 1,
                Size = new System.Drawing.Size(858, 299),
                TabIndex = 0,
            };
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50F));

            TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
            ElementHost tmpEHost = new()
            {
                Size = elementHost1.Size,
                Location = elementHost1.Location
            };
            table.Controls.Add(tmpEHost, 0, 0);
            var tmpEditor = edit;
            tmpEditor.Text = "";
            //快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);
            tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            var file = AutoGetLanguage(newTab.Text);
            using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            tmpEHost.Child = tmpEditor;
            newTab.Controls.Add(table);
            tabControl1.TabPages.Add(newTab);
            newTab.ToolTipText = openFileDialog1.FileName;
            tmpEditor.Load(@openFileDialog1.FileName);
            tabControl1.SelectedTab = newTab;
        }
        #endregion
        #region <FUNC> 占位方法
        private bool func_0a2(string tssl2Text, string fileDesc)
        {
            toolStripStatusLabel2.Text = tssl2Text + _I18nFile.ReadString("I18n", "text.st.editprohibited", "text.st.editprohibited");
            var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.normalfile.0", "text.inprogram.normalfile.0") + ' ' + fileDesc + _I18nFile.ReadString("I18n", "text.inprogram.normalfile.1", "text.inprogram.normalfile.1");
            var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
            if (dResult != DialogResult.Yes) { return false; }
            statusStrip1.Show();
            return true;
        }
        #endregion
        #region 关闭选项卡
        private void CloseFile(object sender, EventArgs e)
        {
            var tab = tabControl1.TabPages[tabControl1.SelectedIndex];
            if (tab.Equals(tabPage1))
            {
                if (!NoTip)
                {
                    if (MessageBoxEX.Show("无法关闭临时页面！", "提示", MessageBoxButtons.OKCancel, new string[] { "不再显示", "我已知晓" }) == DialogResult.OK)
                    {
                        NoTip = true;
                        reConf.Write("General", "NoTipForClosingTempPage", NoTip);
                    }
                }
            }
            else
            {
                tab.Controls[0].Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
        }
        #endregion
        #region 获取程序运行时内存占用
        /// <summary>
        /// 获取程序运行时内存占用
        /// </summary>
        /// <returns>string形式的内存</returns>
        public static string GetMemory()
        {
            var b = proc.PrivateMemorySize64;
            for (var i = 0; i < 2; i++)
            {
                b /= 1024;
            }
            return b < 1000 ? (b + "MB") : (Math.Round((double)b / 1024, 2) + "GB");
        }
        #endregion
        #region 写入内存
        private void WriteDownMem(object sender, EventArgs e)
        {
            tmp_ = GetDigitalMemory();
            HelpButton.Location = new System.Drawing.Point(this.Width - 44, 7);
        }
        #endregion
        #region 帮助窗口
        private void help(object sender, EventArgs e)
        {
            Uri url = new($"File:///{Environment.CurrentDirectory}/help.html");
            Help help = new(url);
            help.Show();
            this.Hide();
        }
        #endregion
        #region 获取int型的内存
        /// <summary>
        /// 获取int型的内存
        /// </summary>
        /// <returns>int型的内存</returns>
        public static int GetDigitalMemory()
        {
            var proc = Process.GetCurrentProcess();
            var b = proc.PrivateMemorySize64;
            for (var i = 0; i < 2; i++)
            {
                b /= 1024;
            }
            return (int)b;
        }
        #endregion
        #region 代码设置
        private void CodeConfig(object sender, EventArgs e)
        {
            CodeSettings cc = new();
            //timer4.Start();
            cc.Show();
        }
        #endregion
        #region 识别文件语言
        /// <summary>
        /// 识别文件语言
        /// </summary>
        /// <param name="SuffixName">文件后缀名</param>
        /// <param name="log">是否记录于日志中</param>
        /// <returns>语言类型</returns>
        public static string AutoGetLanguage(string SuffixName, bool log = true)
        {
            SuffixName = Path.GetExtension(SuffixName);
            if (log)
            {
                LOGGER.WriteLog($"已获取文件名: {SuffixName}");
            }
            if (SuffixName.Contains(".cs"))
            {
                return "C-Sharp";
            }
            else if (SuffixName.Contains(".pycn") | SuffixName.Contains(".pyCN"))
            {
                return "Py-CN";
            }
            else if (SuffixName.Contains(".py") | SuffixName.Contains(".pyw") | SuffixName.Contains(".pyi"))
            {
                return "Python";
            }
            else if (SuffixName.Contains(".xml") | SuffixName.Contains(".xshd"))
            {
                return "XML";
            }
            else
            {
                return "PlainText";
            }

        }
        #endregion
        #region 清除日志
        private void ClearLog()
        {
            File.WriteAllText(LOGGER.logPath, "");
            LOGGER.WriteLog("已清除过期的日志文件！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
        }
        #endregion
        #region 许可与版权声明
        private void copyrightsAndLicense(object sender, EventArgs e)
        {
            new LicenseAndCopyrights().Show();
        }
        #endregion
        #region 检查语法错误
        private void CheckSyntaxError(object sender, EventArgs e)
        {
            var editor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
            var content = editor.Text;
            if (tabControl1.SelectedTab.ToolTipText != null)
            {
                var ret = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                PythonErrorAnalyzer.Init(ret);
                var res = PythonErrorAnalyzer.AnalyzePythonFile(content);
                var types = (List<string>)res["Type"];
                var desc = (List<string>)res["Description"];
                var lines = (List<int>)res["Line"];
                var tmpEx = new ListViewItem("[ERROR]", imageKey: "EII");
                for (; _i < types.Count; _i++)
                {
                    tmpEx.Text = "   ";
                    tmpEx.ImageKey = "exception";
                    listView1.Items.Add(tmpEx);
                }
                foreach (var item in types)
                {
                    listView1.Items[types.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item });
                }
                foreach (var item in desc)
                {
                    listView1.Items[desc.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item });
                }
                foreach (var item in lines)
                {
                    listView1.Items[lines.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ToString() });
                }
            }
        }
        #endregion
        #region 循环判断：窗体是否处于最大化状态
        private void IsMaximized(object sender, EventArgs e)
        {

        }
        #endregion
        #region 测试崩溃
        private void TestCrash(object sender, EventArgs e)
        {
            throw new Exception("测试异常");
        }
        #endregion
        #region 退出
        private void ExitByClosing(object sender, FormClosingEventArgs e)
        {
            var dRes = MessageBoxEX.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo, new string[] { "是", "否" });
            LOGGER.WriteLog("已询问退出，返回值：" + dRes, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            if (dRes == DialogResult.Yes)
            {
                LOGGER.WriteLog("Stopping!", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                Process.GetCurrentProcess().Kill();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
        #region 静默保存
        private void QuietSave(object sender, EventArgs e)
        {
            try
            {
                var result = tabControl1.SelectedTab.ToolTipText;
                var tmpEditor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
                if (result != "" | result != string.Empty)
                {
                    StreamWriter sw = new(result, false, Encoding.UTF8);
                    sw.Write(tmpEditor.Text);
                    sw.Flush();
                    sw.Close();
                    tabControl1.SelectedTab.Text.Replace("*", "");
                }
                else
                {
                    SaveFile(sender, e);
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog($"已捕捉异常：{ex.Message}", ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
            //StreamWriter sw = new();
        }
        #endregion
        #region 代码提示
        private CompletionWindow _codeSense;
        private string tmpCompletionStr = "";

        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {

            // 处理文本修改和代码提示
            HandleTextModification(e.Text, (TextArea)sender);

            // 清除临时完成字符串和标记状态
            ClearTemporaryCompletion();

            toolStripStatusLabel7.Text = tmpCompletionStr;
        }

        private string GetLineInTextEditor(TextEditor _editor, string text)
        {
            foreach (var item in _editor.Text.GetLines())
            {
                if (item.Contains(text))
                {
                    return item;
                }
            }
            return string.Empty;
        }

        private void HandleTextModification(string text, TextArea textArea)
        {
            Regex _regex_unclosedstring = new("\".+[^\")]");
            Regex _regex_closedstring = new("\".+\"");
            var _editor = ((ElementHost)((TableLayoutPanel)tabControl1.SelectedTab.Controls[0]).Controls[0]).Child as TextEditor;
            tmpCompletionStr += text;
            if (!text[0].IsLetterOrDigit())
            {
                tmpCompletionStr = "";
            }
            else if (_regex_unclosedstring.IsMatch(GetLineInTextEditor(_editor, text)) & !_regex_closedstring.IsMatch(GetLineInTextEditor(_editor, text)))
            {
                tmpCompletionStr = "";
            }
            else
            {
                _codeSense = new CompletionWindow(textArea)
                {
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                };
                var completionData = _codeSense.CompletionList.CompletionData;
                var _keywords = new string[] { };
                var _specialdefs = new string[] { };
                var _builtins = new string[] { };
                var _fields = new string[] { };
                var tmp = tabControl1.SelectedTab.Text;
                var lang = AutoGetLanguage(tmp, false);
                var _tmpfilepath = (string)tabControl1.SelectedTab.Tag;
                switch (lang)
                {
                    case "Python":
                        _keywords = LangKeywords.Keywords.python;
                        _specialdefs = LangKeywords.SpecialDefs.python;
                        _builtins = LangKeywords.BulitIns.py;
                        if (!_tmpfilepath.IsNullOrEmpty())
                        {
                            _fields = PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Global"].ToArray();
                            _fields.AddRange(PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Private"]);
                        }
                        break;
                    case "Py-CN":
                        _keywords = LangKeywords.Keywords.pycn;
                        _specialdefs = LangKeywords.SpecialDefs.pycn;
                        _builtins = LangKeywords.BulitIns.pycn;
                        if (!_tmpfilepath.IsNullOrEmpty())
                        {
                            _fields = PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Global"].ToArray();
                            _fields.AddRange(PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Private"]);
                        }
                        break;
                    case "C-Sharp":
                        _keywords = LangKeywords.Keywords.cs;
                        _specialdefs = LangKeywords.SpecialDefs.cs;
                        break;
                    case "XML":
                        break;
                    case "PlainText":
                        break;
                }
                foreach (var item in _keywords.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.KEYWORD));
                }
                foreach (var item in _specialdefs.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.FIELD));
                }
                foreach (var item in _builtins.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.BUILTIN));
                }
                foreach (var item in _fields.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.FIELD));
                }

                if (completionData.Count > 0)
                {
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => { _codeSense = null; };
                }
                else
                {
                    tmpCompletionStr = "";
                }
            }
        }

        private bool IsKeywordMatched(string keyword)
        {
            var pinyin = ChinsesePinYinHelper.GetPinYinFull(keyword);
            return pinyin.StartsWith(tmpCompletionStr)/* || pinyin != tmpCompletionStr*/;
        }

        private void ClearTemporaryCompletion()
        {
            RYCBCodeSense.Clear(ref tmpCompletionStr);
            RYCBCodeSense._completed = false;
        }

        #endregion
        #region 判断代码是否已修改
        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            tabControl1.SelectedTab.Text += tabControl1.SelectedTab.Text.Contains("*") ? "" : "*";
            if (e.Text.Length > 0 && _codeSense != null && !e.Text[0].IsLetterOrDigit())
            {
                _codeSense.CompletionList.RequestInsertion(e);
            }
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            HelpButton.Location = new System.Drawing.Point(this.Width - 44, 7);
            SizeController.Start();
        }

        private bool TabControl1_BeforeRemoveTabPage(object sender, int index)
        {
            var tab_count = tabControl1.TabPages.Count;
            var tab = tabControl1.SelectedTab;
            if (tab_count == 1)
            {
                var editor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
                tab.Text = _I18nFile.Read("I18n", "text.tc.tp.tmp", "text.tc.tp.tmp");
                editor.Text = "";
                return false;
            }
            else
            {
                tab.Controls[0].Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
            return true;
        }

        private void FirstInit(object sender, EventArgs e)
        {
            ExecuteCMDWithOutput("mkdir " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect", "cmd", "/s /c");
            keepFile = new StreamWriter(new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\.KEEP", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), Encoding.UTF8);
            stopwatch.Start();
            LOGGER.WriteLog($"窗口大小修改成功 (水平长度{this.Size.Width}px, 垂直长度{this.Size.Height}px)", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口位置：{this.Location}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口PID：{Process.GetCurrentProcess().Id}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口句柄：{Process.GetCurrentProcess().Handle}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog("主程序正在初始化...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            keepFile.WriteLine(long.MinValue);
            keepFile.Flush();
            this.Location = new System.Drawing.Point(1, 1);
            NoTip = reConf.ReadBool("General", "NoTipForClosingTempPage");
            statusStrip1.Hide();
            openFileDialog1.Filter = filter;
            openFileDialog1.Title = title;
            text_tsl2 = toolStripStatusLabel2.Text;
            LOGGER.WriteLog("编辑器控件加载完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\SoftInfo",
                $"""
                [Version]
                Version={VERSION}
                friendly={FRIENDLY_VER}

                [Startup]
                param_count=0
                params=None
                path={STARTUP_PATH}
                """);
            this.Resize += new System.EventHandler(this.ResizeControls);
            Program.splash.metroProgressBar1.PerformStep();
            stopwatch.Stop();
            if (reConf.ReadBool("DevMode", "DevMode"))
            {
                开发者选项DToolStripMenuItem.Visible = true;
            }
            var time = stopwatch.Elapsed;
            var end_time = time.TotalSeconds;
            LOGGER.WriteLog("主程序初始化成功！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"主程序初始化时间共计：{Math.Round(end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            var _end_time = Program.startTime.TotalSeconds;
            LOGGER.WriteLog($"初始化时间共计：{Math.Round(_end_time + end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            Program.splash.metroProgressBar1.PerformStep();
            Program.splash.metroProgressBar1.Value = Program.splash.metroProgressBar1.Maximum;
            Program.splash.Close();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
            this.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void ForceExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private new void Layout(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Length >= 32)
            {
                tabControl1.ItemSize = new System.Drawing.Size(500, tabControl1.ItemSize.Height);
            }
            else if (tabControl1.SelectedTab.Text.Length >= 16)
            {
                tabControl1.ItemSize = new System.Drawing.Size(350, tabControl1.ItemSize.Height);
            }
            else if (tabControl1.SelectedTab.Text.Length >= 8)
            {
                tabControl1.ItemSize = new System.Drawing.Size(200, tabControl1.ItemSize.Height);
            }
            else
            {
                tabControl1.ItemSize = new System.Drawing.Size(100, tabControl1.ItemSize.Height);
            }
        }

        #endregion
        #region 后台运行Python代码 (Copyright © 2023 RYCBStudio by CC 2.0 License)
        private static string[] RunPythonSrcipt(string path, string python = "python.exe")
        {
            var pythonSrcipt = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = python,
                    Arguments = "\"" + path + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true,
                }
            };
            pythonSrcipt.Start();
            return new string[] { pythonSrcipt.StandardOutput.ReadToEnd(), pythonSrcipt.StandardError.ReadToEnd() };
        }
        #endregion
        #region 打开百宝箱
        private void OpenTheTBox(object sender, EventArgs e)
        {
            new TBox().Show();
        }
        #endregion
        #region 界面调整
        private void Validating_Layout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Layout(sender, new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selecting));
        }

        private void Layout(object sender, EventArgs e)
        {
            Layout(sender, new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selecting));
        }
        #endregion
        #region 退出
        private void Exit(object sender, EventArgs e)
        {
            ExitByClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }
        #endregion
        #region 重启
        private void Restart(object sender, EventArgs e)
        {
            var dRes = MessageBox.Show("确定重启吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            LOGGER.WriteLog("已询问重启，返回值：" + dRes, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            if (dRes == DialogResult.Yes)
            {
                LOGGER.WriteLog("Stopping!", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                var programpath = Application.ExecutablePath;
                var arguments = Environment.GetCommandLineArgs().Skip(1).ToArray();
                System.Diagnostics.ProcessStartInfo startinfo = new()
                {
                    FileName = programpath,
                    UseShellExecute = true,
                    Arguments = string.Join(" ", arguments)
                };
                Process.Start(startinfo);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                return;
            }
        }
        #endregion
        #region “鸣谢”模块
        private void Thanks(object sender, EventArgs e)
        {
            new Thanks().Show();
        }
        #endregion
        #region 全选
        private void SelectAll(object sender, EventArgs e)
        {
            var _editor = (tabControl1.SelectedTab.Controls[0] as ElementHost).Child as TextEditor;
            _editor.SelectAll();
        }
        #endregion
        #region 捐助
        private void DonateLink(object sender, EventArgs e)
        {
            Process.Start("https://afdian.net/a/RYCBStudio");
        }
        #endregion
        #region 查找
        private void Find(object sender, EventArgs e)
        {
            //new RYCBSearchPanel(((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor).Show();
        }

        private void LayoutForConsole(object sender, EventArgs e)
        {
            if (SetWindow.intPtr != IntPtr.Zero)
            {
                Thread t = new Thread(SetWindow.ResizeWindow);
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(50); //略加延时
                timer2.Stop();  //停止定时器
            }
        }
        #endregion

        #region 清理缓存
        private void ClearCache(object sender, EventArgs e)
        {
            new CacheCleaner().Show();
        }
        #endregion
        #region 检查文件类型并发出警告
        private void CheckFileTypeAndAlert(string fileExtension, string tmp)
        {
            #region 特殊文件
            if (fileExtension.Equals("exe"))
            {
                if (func_0a2("exe", _I18nFile.ReadString("I18n", "text.inprogram.fileex.exe", "text.inprogram.fileex.exe") + "(.exe)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("dll"))
            {
                if (func_0a2("dll", _I18nFile.ReadString("I18n", "text.inprogram.fileex.dll", "text.inprogram.fileex.dll") + "(.dll)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("zip") || fileExtension.Equals("7z") || fileExtension.Equals("rar") ||
                     fileExtension.Equals("001") || fileExtension.Equals("tgz") || fileExtension.Equals("tar") ||
                     fileExtension.Equals("bin"))
            {
                if (func_0a2("zip|7z|rar|001|tgz|tar|bin", _I18nFile.ReadString("I18n", "text.inprogram.fileex.compressed", "text.inprogram.fileex.compressed") + "(.zip|.7z|.rar|.001|.tgz|.tar|bin)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("mp3"))
            {
                if (func_0a2("mp3", _I18nFile.ReadString("I18n", "text.inprogram.fileex.media", "text.inprogram.fileex.media") + "(.mp3)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("mp4"))
            {
                if (func_0a2("mp4", _I18nFile.ReadString("I18n", "text.inprogram.fileex.vedio", "text.inprogram.fileex.vedio") + "(.mp4)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("crx"))
            {
                if (func_0a2("crx", _I18nFile.ReadString("I18n", "text.inprogram.fileex.crx", "text.inprogram.fileex.crx") + "(.crx)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("png") || fileExtension.Equals("jpg") || fileExtension.Equals("gif") ||
                     fileExtension.Equals("webp") || fileExtension.Equals("jpeg") || fileExtension.Equals("jfif") ||
                     fileExtension.Equals("ico") || fileExtension.Equals("bmp"))
            {
                if (func_0a2("png|jpg|gif|webp|jpeg|jfif|ico|bmp", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pic", "text.inprogram.fileex.pic") + "(.png|.jpg|.gif|.webp|.jpeg|.jfif|.ico|.bmp)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("jar"))
            {
                if (func_0a2("jar", _I18nFile.ReadString("I18n", "text.inprogram.fileex.jar", "text.inprogram.fileex.jar") + "(.jar)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("pak") || fileExtension.Equals("pkg"))
            {
                if (func_0a2("pkg", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pak", "text.inprogram.fileex.pak") + "(.pak|.pkg)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("e"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e.0", "text.inprogram.fileex.e.0"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("xltd"))
            {//迅雷临时数据文件
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("iso"))
            {
                if (func_0a2("iso", _I18nFile.ReadString("I18n", "text.inprogram.fileex.iso", "text.inprogram.fileex.iso") + "(.iso)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("vmdk"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk.warn", "text.inprogram.fileex.vmdk.warn");//"文件，该操作将引起IDE未响应和内存溢出，从而导致程序崩溃且极有可能使您的计算机卡死、崩溃甚至蓝屏，请确认是否继续打开：";
                DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("sb2") | fileExtension.Equals("sb3"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.sb.intro", "text.inprogram.fileex.sb.intro"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            #endregion
            #region 普通文件
            else
            {
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == tmp)
                    {
                        tabControl1.SelectedTab = tab;
                        return;
                    }
                }
                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                table.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.Percent, 50F));
                table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50F));

                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName, BackColor = tabPage1.BackColor };
                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                };
                table.Controls.Add(tmpEHost);
                TextEditor tmpEditor = new()
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily("Consolas"),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    ShowLineNumbers = true,
                };
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                //快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);
                var file = AutoGetLanguage(newTab.Text);
                using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(table);
                newTab.ToolTipText = @openFileDialog1.FileName;
                tabControl1.TabPages.Add(newTab);
                tmpEditor.Load(@openFileDialog1.FileName);
                tabControl1.SelectedTab = newTab;
            }
            #endregion
        }
        #endregion
        #region 获取文件名
        public static string GetFileName(string path)
        {
            // 使用 LastIndexOf 方法查找最后一个路径分隔符的索引
            var lastSeparatorIndex = path.LastIndexOf('\\');

            // 如果找到了路径分隔符，则提取文件名
            if (lastSeparatorIndex >= 0)
            {
                return path.Substring(lastSeparatorIndex + 1);
            }

            // 如果没有找到路径分隔符，则返回整个字符串作为文件名（假设输入字符串本身就是文件名）
            return path;
        }
        #endregion
        #region 创建PyCN文件缓存文件夹，以便更好地清除
        private void SetPyCNFileCache(string fileName)
        {
            //CacheWriter.WriteLine(fileName);
        }
        #endregion
        #endregion
    }
}