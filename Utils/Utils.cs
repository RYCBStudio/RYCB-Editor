﻿using Microsoft.Win32;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.International.Converters.PinYinConverter;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Drawing;
using Sunny.UI;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using Microsoft.Diagnostics.Runtime;
using System.Security.Cryptography;
using System.Net;

namespace IDE
{
    public class FileTypeRegistryFactory
    {
        /// <summary>
        /// 文件类型注册信息
        /// </summary>
        public class FileTypeRegInfo
        {
            /// <summary>  
            /// 扩展名  
            /// </summary>  
            public string ExtendName;  //".pycn"  
            /// <summary>  
            /// 说明  
            /// </summary>  
            public string Description; //"The Py-CN Project项目文件"  
            /// <summary>  
            /// 关联的图标  
            /// </summary>  
            public string IconPath;
            /// <summary>  
            /// 应用程序  
            /// </summary>  
            public string ExePath;

            public FileTypeRegInfo()
            {
            }
            public FileTypeRegInfo(string extendName)
            {
                this.ExtendName = extendName;
            }
        }

        /// <summary>  
        /// 注册自定义的文件类型。  
        /// </summary>  
        public class FileTypeRegister
        {
            /// <summary>  
            /// 使文件类型与对应的图标及应用程序关联起来
            /// </summary>          
            public static void RegisterFileType(FileTypeRegInfo regInfo)
            {
                if (FileTypeRegistered(regInfo.ExtendName))
                {
                    return;
                }

                //HKEY_CLASSES_ROOT/.pycn
                var fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
                var relationName = regInfo.ExtendName.Substring(1,
                                                                   regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
                fileTypeKey.SetValue("", relationName);
                fileTypeKey.Close();

                //HKEY_CLASSES_ROOT/PYCN_FileType
                var relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
                relationKey.SetValue("", regInfo.Description);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/DefaultIcon
                var iconKey = relationKey.CreateSubKey("DefaultIcon");
                iconKey.SetValue("", regInfo.IconPath);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell
                var shellKey = relationKey.CreateSubKey("Shell");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open
                var openKey = shellKey.CreateSubKey("Open");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open/Command
                var commandKey = openKey.CreateSubKey("Command");
                commandKey.SetValue("", regInfo.ExePath + " %1"); // " %1"表示将被双击的文件的路径传给目标应用程序
                relationKey.Close();
            }

            /// <summary>  
            /// 更新指定文件类型关联信息  
            /// </summary>      
            public static bool UpdateFileTypeRegInfo(FileTypeRegInfo regInfo)
            {
                if (!FileTypeRegistered(regInfo.ExtendName))
                {
                    return false;
                }

                var extendName = regInfo.ExtendName;
                var relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                var relationKey = Registry.ClassesRoot.OpenSubKey(relationName, true);
                relationKey.SetValue("", regInfo.Description);
                var iconKey = relationKey.OpenSubKey("DefaultIcon", true);
                iconKey.SetValue("", regInfo.IconPath);
                var shellKey = relationKey.OpenSubKey("Shell");
                var openKey = shellKey.OpenSubKey("Open");
                var commandKey = openKey.OpenSubKey("Command", true);
                commandKey.SetValue("", regInfo.ExePath + " %1");
                relationKey.Close();
                return true;
            }

            /// <summary>  
            /// 获取指定文件类型关联信息  
            /// </summary>          
            public static FileTypeRegInfo GetFileTypeRegInfo(string extendName)
            {
                if (!FileTypeRegistered(extendName))
                {
                    return null;
                }
                FileTypeRegInfo regInfo = new(extendName);

                var relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                var relationKey = Registry.ClassesRoot.OpenSubKey(relationName);
                regInfo.Description = relationKey.GetValue("").ToString();
                var iconKey = relationKey.OpenSubKey("DefaultIcon");
                regInfo.IconPath = iconKey.GetValue("").ToString();
                var shellKey = relationKey.OpenSubKey("Shell");
                var openKey = shellKey.OpenSubKey("Open");
                var commandKey = openKey.OpenSubKey("Command");
                var temp = commandKey.GetValue("").ToString();
                regInfo.ExePath = temp.Substring(0, temp.Length - 3);
                return regInfo;
            }

            /// <summary>  
            /// 指定文件类型是否已经注册  
            /// </summary>          
            public static bool FileTypeRegistered(string extendName)
            {
                var softwareKey = Registry.ClassesRoot.OpenSubKey(extendName);
                if (softwareKey != null)
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class LangKeywords
    {
        public static class Keywords
        {
            public static readonly string[] pycn = { "and", "as", "assert", "async", "await", "break", "捕获", "捕获", "遍历", "不是", "不", "continue", "class", "尝试运行", "尝试", "抽象资源处理逻辑", "抽象处理逻辑", "抽象", "当", "定义", "定义方法", "定义函数", "打断循环", "等候", "等待", "断言", "当作", "def", "del", "elif", "else", "except", "finally", "for", "from", "否则", "否则如果", "非本地变量", "非本地化变量", "global", "或", "或者", "if", "import", "in", "is", "假", "快速", "空", "lambda", "->", "匿名函数", "nonlocal", "not", "or", "抛出", "pass", "raise", "return", "如果", "若捕获", "删除", "使变量全局", "使变量全局化", "try", "通过", "跳过并继续", "while", "with", "yield", "异步", "异步操作", "抑或", "占位语句", "占位符", "作为", "真" };
            public static readonly string[] python = { "False", "None", "True", "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del", "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "nonlocal", "not", "or", "pass", "raise", "return", "try", "while", "with", "yield" };
            public static readonly string[] cs = { "add", "and", "alias", "ascending", "args", "async", "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "group", "init", "into", "join", "let", "nameof", "nint", "not", "notnull", "nuint", "on", "or", "orderby", "partial", "record", "remove", "select", "set", "unmanaged", "value", "var", "when", "where", "with", "yield", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
        }

        public static class SpecialDefs
        {
            public static readonly string[] pycn = { "__dir__", "__getattr__", "__abs__", "__del__", "__hex__", "__int__", "__len__", "__add__", "__aenter__", "__aexit__", "__aiter__", "__await__", "__bool__", "__bytes__", "__call__", "__ceil__", "__class_getitem__", "__cmp__", "__coerce__", "__complex__", "__contains__", "__copy__", "__deepcopy__" };
            public static readonly string[] python = pycn;
            public static readonly string[] cs = { "#define", "#undef", "#if", "#else", "#elif", "#endif", "#line", "#error", "#warning", "#region", "#endregion" };
        }

        public static class BulitIns
        {
            public static readonly string[] py = { "abs", "aiter", "all", "anext", "any", "ascii", "bin", "bool", "breakpoint", "bytearray", "bytes", "callable", "chr", "classmethod", "compile", "complex", "delattr", "dict", "dir", "divmod", "enumerate", "eval", "exec", "filter", "float", "format", "frozenset", "getattr", "globals", "hasattr", "hash", "help", "hex", "id", "input", "int", "isinstance", "issubclass", "iter", "len", "list", "locals", "map", "max", "memoryview", "min", "next", "object", "oct", "open", "ord", "pow", "print", "property", "range", "repr", "reversed", "round", "set", "setattr", "slice", "sorted", "staticmethod", "str", "sum", "super", "tuple", "type", "vars", "zip", "__import__" };
            public static readonly string[] pycn = { "abs", "aiter", "all", "anext", "any", "ascii", "bin", "bool", "breakpoint", "bytearray", "bytes", "callable", "chr", "compile", "complex", "delattr", "dict", "dir", "divmod", "enumerate", "eval", "exec", "filter", "float", "format", "frozenset", "getattr", "globals", "hasattr", "hash", "help", "hex", "id", "input", "int", "isinstance", "issubclass", "iter", "len", "list", "locals", "map", "max", "memoryview", "min", "next", "object", "oct", "open", "ord", "pow", "print", "property", "range", "repr", "reversed", "round", "set", "setattr", "slice", "sorted", "str", "sum", "super", "tuple", "type", "vars", "zip", "__import__", "取绝对值", "异步_迭代器", "全为真", "异步_下一个元素", "有真", "ASCII字符", "二进制", "布尔值", "断点", "字节数组", "不可变字节数组", "是否可调用", "解码", "编译", "复数", "删除属性", "字典", "获取名称列表", "整除和取余", "获取枚举对象", "还原", "动态执行", "从函数新建迭代器", "浮点数", "格式化字符串", "冻结集合", "获取属性", "获取命名空间", "是否有属性", "哈希值", "帮助", "十六进制", "标识值", "获取输入", "整数", "是否是实例", "是否是子类", "迭代器", "获取长度", "列表", "获取本地符号表", "映射", "最大值", "获取内存视图", "最小值", "下一个元素", "基类", "八进制", "打开文件", "编码", "幂", "打印", "属性值", "生成序列", "转换为解释器可读", "逆转", "四舍五入", "集合", "设置属性", "切片", "排序", "字符串", "求和", "超类", "元组", "类型", "获取字典属性", "并行迭代", "__导入__" };
        }
    }

    public static class PypiHelper
    {
        public static (Dictionary<string, List<string>>, string) ParseLinkWithContent(string html)
        {
            Dictionary<string, List<string>> res = new();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var linkNodes = doc.DocumentNode.SelectNodes("//span[@class='package-snippet__name']");
            var names = new List<string>();
            var descs = new List<string>();
            var vers = new List<string>();
            foreach (var linkNode in linkNodes)
            {
                string link = linkNode.GetDirectInnerText();
                names.Add(link);

            }
            linkNodes = doc.DocumentNode.SelectNodes("//p[@class='package-snippet__description']");
            foreach (var linkNode in linkNodes)
            {
                string link = linkNode.GetDirectInnerText();
                descs.Add(link);
            }
            linkNodes = doc.DocumentNode.SelectNodes("//span[@class='package-snippet__version']");
            foreach (var linkNode in linkNodes)
            {
                string link = linkNode.GetDirectInnerText();
                vers.Add(link);
            }
            linkNodes = doc.DocumentNode.SelectNodes("//a[@class='button button-group__button']");
            int max = 0;
            foreach (var node in linkNodes)
            {
                string link = node.GetDirectInnerText();
                try
                {
                    if (max <= Convert.ToInt32(link))
                    {
                        max = Convert.ToInt32(link);
                    }
                }
                catch { }
            }
            res.Add("name", names);
            res.Add("desc", descs);
            res.Add("ver", vers);
            return (res, max.ToString());
        }

        public static string GetHtml(string url)
        {
            string res = "";
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            res = sr.ReadToEnd();
            sr.Close();
            client.Dispose();
            return res;
        }

        public static List<Dictionary<string, string>> ConvertToDict(Dictionary<string, List<string>> res)
        {
            List<Dictionary<string, string>> ret = new(res["name"].Count);
            var i = 0;

            var names = res["name"];
            var descs = res["desc"];
            var vers = res["ver"];
            foreach (var val in names)
            {
                Dictionary<string, string> tmp = new()
                {
                    {
                        "name",
                        val
                    },
                    {
                        "desc",
                        descs[names.IndexOf(val)]
                    },
                    {
                        "ver",
                        vers[names.IndexOf(val)]
                    }
                };
                ret.Add(tmp);
            }

            return ret;
        }
    }

    public static class ChinsesePinYinHelper
    {
        ///<summary>
        /// 汉字
        /// </summary>
        private static string ChineseReg = "^[\\u4E00-\\u9FA5]+$";

        public static string GetPinYinFull(string str)
        {
            var pySb = new StringBuilder();
            foreach (var itemChar in str)
            {
                //过滤非汉字的字符，直接返回
                var reg = new Regex(ChineseReg);
                if (!reg.IsMatch(itemChar.ToString()))
                {
                    pySb.Append(itemChar);
                }
                else
                {
                    var chineseChar = new ChineseChar(itemChar);
                    var pyStr = chineseChar.Pinyins.First().ToLower();
                    pySb.Append(pyStr.Substring(0, pyStr.Length - 1));
                }
            }
            return pySb.ToString();
        }
    }

    public static class BinaryFileReader
    {
        /// <summary>
        /// 读取一个二进制文件的数据。
        /// </summary>
        /// <param name="filePath">文件完整路径</param>
        /// <returns>一个元组，包含二进制元数据和字符串数据。</returns>
        public static (string, string) ReadBinaryFile(string filePath)
        {
            var binaryString = "";
            var textString = "";

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    binaryString += ConvertBytesToBinaryString(buffer, bytesRead);
                    textString += Encoding.Default.GetString(buffer, 0, bytesRead);
                }
            }

            return (binaryString, textString);
        }

        private static string ConvertBytesToBinaryString(byte[] bytes, int length)
        {
            var binaryString = "";
            for (var i = 0; i < length; i++)
            {
                binaryString += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            return binaryString;
        }
    }

    public static class Cmd
    {
        private static string CmdPath = @"C:\Windows\System32\cmd.exe";
        /// <summary>
        /// 执行cmd命令 返回cmd窗口显示的信息
        /// 多命令请使用批处理命令连接符：
        /// <![CDATA[
        /// &:同时执行两个命令
        /// |:将上一个命令的输出,作为下一个命令的输入
        /// &&：当&&前的命令成功时,才执行&&后的命令
        /// ||：当||前的命令失败时,才执行||后的命令]]>
        /// </summary>
        ///<param name="cmd">执行的命令</param>
        public static string RunCmd(string cmd)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            var p = new Process();
            p.StartInfo.FileName = CmdPath;
            p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true; //不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口写入命令
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.AutoFlush = true;

            //获取cmd窗口的输出信息
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            return output;
        }
    }

    public static class GlobalSettings
    {
        /// <summary>
        /// 程序主语言
        /// </summary>
        public static string language = Program.reConf.ReadString("General", "Language", "zh-CN");

        /// <summary>
        /// 程序主字体
        /// </summary>
        public static string MainFontName = "Microsoft YaHei UI";

        /// <summary>
        /// 崩溃尝试次数
        /// </summary>
        public static int CrashAttempts = Program.reConf.ReadInt("CrashHanding", "CrashAttempts", 3);

        /// <summary>
        /// 扩展包路径
        /// </summary>
        internal static string packagePath = "./Package";

        /// <summary>
        /// 使用运行程序来检查错误
        /// </summary>
        internal static bool useRuntimeCompileCheck = false;

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string commonTempFilePath = Program.STARTUP_PATH + "\\Cache\\" + DateTime.Now.GetHashCode().ToString();

        /// <summary>
        /// 主题
        /// </summary>
        internal static Tuple<string, Color, Color> theme = Themes.GetTheme(Program.reConf.ReadString("General", "Theme", "Dark"));

        internal static List<string> keywords;

        public static Dictionary<string, string> language_set = new()
        {
            { "简体中文", "zh-CN" },
            { "繁體中文", "zh-TD" },
            { "English", "en-US" },
            { "日本語", "ja-JP" },
        };

        public static Dictionary<string, Dictionary<string, string>> theme_set = new()
        {
            { "zh-CN", new(){{ "浅色", "Light" }, { "深色", "Dark" }, { "IDEA", "IDEA_Dark" }, { "自定义", "Custom" } } },
            { "zh-TD", new(){{ "淺色", "Light" }, { "深色", "Dark" }, { "IDEA", "IDEA_Dark" }, { "自定義", "Custom" } } },
            { "en-US", new(){{ "Light", "Light" }, { "Dark", "Dark" }, { "IDEA", "IDEA_Dark" }, { "Custom", "Custom" } } },
            { "ja-JP", new(){{ "ライト", "Light" }, { "ダーク", "Dark" }, { "IDEA", "IDEA_Dark" }, { "カスタム", "Custom" } } },
        };

        public static Dictionary<string, List<System.Windows.Media.Color>> editor_color_set = new()
        {
            { "Dark", new(){System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6), System.Windows.Media.Color.FromRgb(0x1E, 0x1F, 0x22) } },
            { "Light",  new(){System.Windows.Media.Color.FromRgb(8, 8, 8), System.Windows.Media.Color.FromRgb(255, 255, 255) }},
        };

        /// <summary>
        /// 可信任的扩展包作者
        /// </summary>
        public static List<string> TrustedAuthors =
        [
            "RYCB Studio",
            "RYCBStudio",
            "QYF-RYCBStudio",
            "QYF",
        ];

        public static class Downloading
        {
            public static bool ParallelDownload = Program.reConf.ReadBool("Downloading", "ParallelDownload", true);
            public static bool AutoParallelCount = Program.reConf.ReadBool("Downloading", "AutoParallelCount", false);
            public static int ParallelCount = (AutoParallelCount ? Program.reConf.ReadInt("Downloading", "ParallelCount", Environment.ProcessorCount * 2) : Environment.ProcessorCount * 2);
        }

        public static class Pypi
        {
            public static string source = Program.reConf.ReadString("Python", "Pypi.Source");
        }
    }

    internal class Themes
    {
        /// <summary>
        /// Themes.Dark
        /// </summary>
        internal static Tuple<string, Color, Color> Dark =
            new("Dark", Color.WhiteSmoke, Color.Black);
        /// <summary>
        /// Themes.Light
        /// </summary>
        internal static Tuple<string, Color, Color> Light =
            new("Light", SystemColors.ControlText, SystemColors.Control);
        /// <summary>
        /// Themes.IDEA
        /// </summary>
        internal static Tuple<string, Color, Color> IDEA_Dark =
            new("IDEA_Dark", ColorTranslator.FromHtml("#DFE1E5"), ColorTranslator.FromHtml("#2B2D30"));
        /// <summary>
        /// Themes.Custom
        /// </summary>
        internal static Tuple<string, Color, Color> Custom =
            new("Custom", ColorTranslator.FromHtml(Program.reConf.ReadString("Theme", "Custom.ForeGround", "#FFF5F5F5")),
            ColorTranslator.FromHtml(Program.reConf.ReadString("Theme", "Custom.BackGround", "#FF000000")));

        internal static Tuple<string, Color, Color> GetTheme(string themeText)
        {
            return themeText switch
            {
                "Dark" => Dark,
                "Light" => Light,
                "IDEA" or "idea" or "IDEA_Dark" => IDEA_Dark,
                _ => Custom,
            };
        }
    }

    public class PythonVariableAnalyzer
    {
        private string content;
        private List<string> lines = [];
        internal PythonVariableAnalyzer(string content)
        {
            this.content = content;
        }

        private void GetLines()
        {
            lines.AddRange(content.Split('\n'));
        }

        private bool matchVar(string line)
        {
            Regex varRegex = new("([_a-zA-Z])+[0-9]*\\s*=.*");
            if (varRegex.IsMatch(line))
            {
                return true;
            }
            return false;
        }

        private string GetVar(string line)
        {
            Regex illegalVarName = new("^[0-9]+.*=.*");
            try
            {
                if (illegalVarName.IsMatch(line)) { return string.Empty; }
                return line.Trim().Replace(" ", "").Split('=')[0];
            }
            catch
            {
                return string.Empty;
            }
        }

        internal List<string> Process()
        {
            List<string> vars = [];
            GetLines();
            foreach (string line in lines)
            {
                if (matchVar(line))
                {
                    if (GetVar(line) == string.Empty) { continue; }
                    vars.Add(GetVar(line));
                }
            }
            return vars;
        }
    }


    public static class Extensions
    {

        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public static int CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);
                }
                //得到原文件根目录下的所有文件
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);//复制文件
                }
                //得到原文件根目录下的所有文件夹
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);//构建目标路径,递归复制文件
                }
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }

        public static bool DecompressFile(string zipPath, string filePath)
        {
            bool exeRes = true;
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                string message = "";
                string command0 = "cd \"" + Program.STARTUP_PATH + "\\Tools\"";
                string command = "";

                command = $"7Z x -t7z \"" + zipPath + "\" -o\"" + filePath + "\" -y";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine(command0);
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");
                //process.WaitForExit();
                message = process.StandardOutput.ReadToEnd();//要等压缩完成后才可以来抓取这个压缩文件

                process.Close();
                if (!message.Contains("Everything is Ok"))
                {
                    exeRes = false;
                }
            }
            catch
            {
                exeRes = false;
            }

            return exeRes;
        }
        public static int GetFilesCount(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            int totalFile = 0;
            totalFile += dirInfo.GetFiles().Length;//获取全部文件
            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir.FullName);
            }
            return totalFile;
        }

        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                var file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                var retVal = md5.ComputeHash(file);
                file.Close();
                var sb = new StringBuilder();
                for (var i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                FrmMain.LOGGER.Err(new Exception("GetMD5HashFromFile() fail,error:" + ex.Message), EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
            return string.Empty;
        }

        public static string GetSHA1(string s)
        {
            var file = new FileStream(s, FileMode.Open);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var retval = sha1.ComputeHash(file);
            file.Close();

            var sc = new StringBuilder();
            for (var i = 0; i < retval.Length; i++)
            {
                sc.Append(retval[i].ToString("x2"));
            }
            return sc.ToString();
        }

        public static string GetSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }

        /// <summary>
        /// 指示指定的Unicode字符是香属于字母或十进制数字类别。
        /// </summary>
        /// <param name="c">要计算的Unicode字符。</param>
        /// <returns>如果<paramref name="c"/>是字母或十进制数，则为<see langword="true"/>; 否则为<see langword="false"/>。</returns>
        public static bool IsLetterOrDigit(this char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }

        /// <summary>
        /// 检查指定字符串所对应的字体是否存在。
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <returns>如果计算机中存在<paramref name="fontName"/>，则为<see langword="true"/>；否则为<see langword="false"/>。</returns>
        public static bool FontExists(this string fontName)
        {
            using var font = new Font(fontName, 12);
            return string.Equals(font.Name, fontName, StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// 检查指定字符串所对应的字体是否存在。若不存在，则替换成<paramref name="substituteFontName"/>对应的字体。
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="substituteFontName">替换字体</param>
        /// <returns>如果计算机中存在<paramref name="fontName"/>，则不进行操作；否则替换成<paramref name="substituteFontName"/>对应的字体。</returns>
        public static string FontExists(this string fontName, string substituteFontName)
        {
            using var font = new Font(fontName, 12);
            if (!font.Name.Equals(fontName, StringComparison.OrdinalIgnoreCase))
            {
                font.Dispose();
                return substituteFontName;
            }
            return fontName;
        }


        /// <summary>
        /// 读取I18n文件中的本地化值
        /// </summary>
        /// <param name="iniFile">I18n文件类</param>
        /// <param name="translationKey">翻译的键</param>
        /// <returns>本地化结果</returns>
        public static string Localize(this IniFile iniFile, string translationKey)
        {
            return iniFile.ReadString("I18n", translationKey, translationKey);
        }

        /// <summary>
        /// 读取Ini文件中的字符串值
        /// </summary>
        /// <param name="iniFile">I18n文件类</param>
        /// <param name="section">需读取的Section</param>
        /// <param name="key">需读取的键</param>
        /// <returns>读取结果</returns>
        public static string ReadString(this IniFile iniFile, string section, string key)
        {
            return iniFile.ReadString(section, key, "none");
        }

        /// <summary>
        /// 将路径中的空格替换为程序可读的形式。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>不含可见空格的路径。</returns>
        public static string ReplaceSpacesInPath(this string path)
        {
            return path.Replace(" ", "%20");
        }

        /// <summary>
        /// <code>获取string.split('\n')的值。</code>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns><code>string.split('\n')的值。</code></returns>
        public static string[] GetLines(this string str)
        {
            return str.Split('\n', '\r');
        }

        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="ctrl">控件名</param>
        public static void Enable(this Control ctrl)
        {
            ctrl.Enabled = true;
        }

        /// <summary>
        /// 显示控件
        /// </summary>
        /// <param name="ctrl">控件名</param>
        public static void ShowControl(this Control ctrl)
        {
            ctrl.Visible = true;
        }

        /// <summary>
        /// 隐藏控件
        /// </summary>
        /// <param name="ctrl">控件名</param>
        public static void HideControl(this Control ctrl)
        {
            ctrl.Visible = false;
        }

        /// <summary>
        /// 在字符串数组中查找第一个包含指定字符串的项。
        /// </summary>
        /// <param name="array">指定字符串数组</param>
        /// <param name="findstr">需要查找的字符串</param>
        /// <returns>若找到，返回项值；否则返回<see cref="string.Empty"/>。</returns>
        public static string FindFirstIfContains(this string[] array, string findstr)
        {
            foreach (var item in array)
            {
                if (item.Contains(findstr))
                {
                    return item;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 在字符串中查找不包含指定字符串。
        /// </summary>
        /// <param name="str">指定查找字符串</param>
        /// <param name="findstr">需要查找的字符串</param>
        /// <returns>若找到，返回<paramref name="str"/>；否则返回<see cref="string.Empty"/>。</returns>
        public static string FindIfNotContains(this string str, string findstr)
        {
            if (!str.Contains(findstr))
            {
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 确定指定项是否位于<see cref="ListView.ListViewItemCollection"/>集合内。
        /// </summary>
        /// <param name="lc"></param>
        /// <param name="item">需要确定的项</param>
        /// <param name="sign">扩展标志</param>
        /// <returns>如果集合中包含该项，则为<see langword="true"/>；否则为<see langword="false"/>。</returns>
        public static bool Contains(this ListView.ListViewItemCollection lc, ListViewItem item, int sign)
        {
            if (sign <= -1) { return lc.Contains(item); }
            foreach (ListViewItem _item in lc)
            {
                if (_item.EqualsPrivate(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 确定集合内是否全是<see langword="true"/>。
        /// </summary>
        /// <returns>如果集合中全是<see langword="true"/>，则为<see langword="true"/>；否则为<see langword="false"/>。</returns>
        public static bool AllIsTrue(this IEnumerable<bool> e)
        {
            foreach (var _item in e)
            {
                if (!_item)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 尝试将一个<see langword="object"/>类型转换为<typeparamref name="T"/>所指的类型。
        /// </summary>
        /// <typeparam name="T">需转换为的类型。</typeparam>
        /// <param name="o">传入的<see langword="object"/>类型。</param>
        /// <returns>转换的类型。</returns>
        public static T TryConvertToAny<T>(this object o)
        {
            var result = Convert.ChangeType(o, typeof(T));
            return (T)result;
        }

        /// <summary>
        /// 向ListBox中添加项目
        /// </summary>
        /// <param name="lb">需添加项目的ListBox</param>
        /// <param name="item">需添加的项目</param>
        public static void Add(this UIUserControl lb, object item)
        {
            var _lb = (UIListBox)lb;
            _lb.Items.Add(item);
            lb.Invalidate(false);
        }

        /// <summary>
        /// 在ListBox中删除项目
        /// </summary>
        /// <param name="lb">需删除项目的ListBox</param>
        /// <param name="item">需删除的项目</param>
        public static void Delete(this UIUserControl lb, object item)
        {
            var _lb = (UIListBox)lb;
            if (_lb.SelectedIndex != -1)
            {
                _lb.Items.Remove(item);
            }
            _lb.SelectedIndex = 0;
            lb.Invalidate(false);
        }

        /// <summary>
        /// 在ListBox中删除项目
        /// </summary>
        /// <param name="lb">需删除项目的ListBox</param>
        /// <param name="index">需删除的项目的下标</param>
        public static void DeleteAt(this UIUserControl lb, int index)
        {
            var _lb = (UIListBox)lb;
            if (_lb.SelectedIndex != -1)
            {
                _lb.Items.RemoveAt(index);
            }
            _lb.SelectedIndex = 0;
            lb.Invalidate(false);
        }

        /// <summary>
        /// 将两个字符串拼接在一起
        /// </summary>
        /// <param name="s">string母类</param>
        /// <param name="c">拼接两个字符串(<paramref name="c1"/>和<paramref name="c2"/>)的字符串</param>
        /// <param name="c1">拼接的第一个字符串></param>
        /// <param name="c2">拼接的第二个字符串</param>
        public static string Combine2WithChar(string c1, string c2, string c)
        {
            return c1 + c + c2;
        }


        private static bool EqualsPrivate(this ListViewItem item, ListViewItem item1)
        {
            bool[] signs = { false, false, false };
            if (item.Text == item1.Text) { signs[0] = true; }
            if (item.ImageIndex == item1.ImageIndex) { signs[1] = true; }
            if (item.SubItems.Equals(item1.SubItems)) { signs[2] = true; }
            if (signs.AllIsTrue()) { return true; }
            return false;
        }
    }

    public class OverridedMethods
    {

    }

    public class Dictionaries
    {

        internal static string _7za_download_link = "https://www.7-zip.org/a/7z2301-extra.7z";

        public static class Exceptions
        {
            public static readonly Dictionary<string, string> cs = new()
            {
                {"System.OutOfMemoryException", "内存溢出"},
                {"System.NullReferenceException", "空引用"},
                {"System.IndexOutOfRangeException", "索引超出范围"},
                {"System.DivideByZeroException", "除以零"},
                {"System.InvalidCastException", "无效的类型转换"},
                {"System.FormatException", "格式化"},
                {"System.ArithmeticException", "算术"},
                {"System.NotSupportedException", "不支持的操作"},
                {"System.OverflowException", "溢出"},
                {"System.IO.IOException", "输入/输出"},
                {"System.FileNotFoundException", "文件未找到"},
                {"System.ArgumentNullException", "参数为空"},
                {"System.ArgumentException", "无效的参数"},
                {"System.TimeoutException", "超时"},
                {"System.ObjectDisposedException", "已释放对象"},
                {"System.Security.SecurityException", "安全性"},
                {"System.Reflection.TargetInvocationException", "目标调用"},
                {"System.PlatformNotSupportedException", "不支持的平台"}
            };
            public static readonly Dictionary<string, string> python = new()
            {
                {"Exception", "异常"},
                {"TypeError", "不正确类型"},
                {"ValueError", "传递给方法的参数具有正确的类型，但值不合适"},
                {"NameError", "尝试访问不存在的变量/名称"},
                {"SyntaxError", "语法错误"},
                {"IndentationError", "缩进错误"},
                {"AttributeError", "尝试访问对象不存在的属性或方法"},
                {"KeyError", "尝试访问字典中不存在的键"},
                {"IndexError", "索引超出序列范围"},
                {"FileNotFoundError", "文件未找到"},
                {"IOException", "输入/输出操作失败"},
                {"DivideByZeroException", "除数为零"},
                {"OverflowException", "数值运算结果太大而无法表示"},
                {"RuntimeException", "运行时错误"},
                {"ImportException", "导入模块失败"},
                {"ModuleNotFoundException", "模块未找到"},
                {"KeyboardInterrupt", "用户中断执行程序"}
            };
        }
    }

    public class PythonErrorAnalyzer
    {
        public static List<Dictionary<string, string>> AnalyzePythonFile(string content)
        {
            GlobalSettings.useRuntimeCompileCheck = Program.reConf.ReadBool("Run", "useRuntimeCompileCheck", false);
            string fileName;
            try
            {
                fileName = (content.Substring(0, 5).Contains(" ") ? "abcdefghijk" : content.Substring(0, 5)).GetHashCode() + ".py";
            }
            catch
            {
                fileName = DateTime.Now.ToString().GetHashCode().ToString() + ".py";
            }
            if (content.Contains("import turtle")) { GlobalSettings.useRuntimeCompileCheck = false; }
            var filePath = Path.GetTempPath() + "\\" + fileName;
            File.WriteAllText(filePath, content);
            var result = new List<Dictionary<string, string>>();
            ProcessStartInfo psi;
            // 使用 python 解释器编译文件，并获取错误信息
            if (GlobalSettings.useRuntimeCompileCheck)
            {
                psi = new ProcessStartInfo("python", $" \"{filePath}\"")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
            }
            else
            {
                psi = new ProcessStartInfo("python", $"-m py_compile \"{filePath}\"")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
            }

            var process = new Process
            {
                StartInfo = psi
            };
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(error))
            {
                Regex file_line = new("File \".+\", line \\d");
                Regex exp = new(".+:\\s.+");

                var errorLinesString = error.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                Dictionary<string, string> v = [];
                if (errorLinesString.Length == 1)
                {
                    var list = errorLinesString[0].Split(" on line ");
                    for (int i = 0; i < list.Length; i++)
                    {
                        var line = list[i];
                        Regex single_line_exp = new("[a-zA-Z]{1}\\w+([Ee]rror|[Ee]xception)");
                        try
                        {
                            if (single_line_exp.IsMatch(line))
                            {
                                var _ = line.Split(": ");
                                for (int j = 0; j < _.Length; j++)
                                {
                                    var item = _[j];
                                    if (single_line_exp.IsMatch(item))
                                    {
                                        v.Add("Type", item.Trim());
                                        v.Add("Desc", _[j + 1]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                v.Add("Line", line.Split(", line")[1].Replace(")", ""));
                            }
                        }
                        catch (Exception ex) { FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT); }

                    }
                }
                foreach (var lineString in errorLinesString)
                {
                    try
                    {
                        if (file_line.IsMatch(lineString))
                        {
                            v.Add("Line", lineString.Split(new string[] { "line " }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        }
                        else if (exp.IsMatch(lineString))
                        {
                            v.Add("Type", lineString.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            v.Add("Desc", lineString.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        }
                    }
                    catch (Exception ex) { FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT); }
                }
                result.Add(v);
            }

            return result;
        }
    }

    public class PythonSyntaxErrorChecker
    {
        public static string SyntaxCheck(string pyhonScript)
        {
            pyhonScript = pyhonScript.Replace("\r", "").Replace("\t", "    ");
            var lines = pyhonScript.Split('\n');
            int LastSpaceCount = 0, NextSpaceCount = 0, CurrentCount = 0;
            string temStart = "", temEnd = "", msg = "";
            var MustEqual = false;
            for (var i = 0; i < lines.Length; i++)
            {
                CurrentCount = SpaceCount(lines[i]);
                temEnd = lines[i].TrimEnd(new char[] { ' ' });
                temStart = lines[i].TrimStart(new char[] { ' ' });
                if (string.IsNullOrEmpty(temEnd))
                    continue;
                if (temStart.StartsWith("#"))
                    continue;

                if (CurrentCount < NextSpaceCount)
                {
                    if (temStart.StartsWith("def ") || temStart.StartsWith("class "))
                    {
                        MustEqual = true;
                        NextSpaceCount = 4;
                    }
                    else if (temStart.StartsWith("else:") || temStart.StartsWith("else ") || temStart.StartsWith("elif "))
                    {
                        if (CurrentCount < NextSpaceCount - 4 && MustEqual)
                        {
                            msg += "|Ls-" + (i + 1) + "-Le|" + "|Ds-expect new line\r\n-De|";
                        }
                    }
                    else if (MustEqual)
                        msg += "|Ls-" + (i + 1) + "-Le|" + "|Ds-expect new line\r\n-De|";
                }
                else if (CurrentCount > NextSpaceCount)
                {
                    msg += "|Ls-" + (i + 1) + "-Le|" + "|Ds-unexpected indent\r\n-De|";
                }
                else if (CurrentCount == NextSpaceCount)
                {
                    MustEqual = false;
                }
                if (temStart.StartsWith("def ") || temStart.StartsWith("class "))
                {
                    if (CurrentCount != 0)
                        msg += "|Ls-" + (i + 1) + "-Le|" + "|Ds-unexpected space in front of the line\r\n-De|";
                    if (!temEnd.EndsWith(":"))
                    {
                        msg += "|Ls-" + (i + 1) + "-Le|" + "|Ds-should end with ':'\r\n-De|";
                    }
                    MustEqual = true;
                    NextSpaceCount = 4;
                }
                else if (temEnd.EndsWith(":"))
                {
                    MustEqual = true;
                    NextSpaceCount = CurrentCount + 4;
                }
                else if (CurrentCount != 0)
                {
                    NextSpaceCount = CurrentCount;
                }
                LastSpaceCount = CurrentCount;
            }
            if (msg == "")
                msg = "Find No Error.";
            return msg;
        }


        static int SpaceCount(string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                    return i;
            }
            return 0;
        }
    }

    public static class MiniDumpReader
    {
        public static string ReadDumpFile(string dumpFilePath)
        {
            var res = "";

            using (var dataTarget = DataTarget.LoadDump(dumpFilePath))
            {
                var clrInfo = dataTarget.ClrVersions[0];
                var clrRuntime = clrInfo.CreateRuntime();

                foreach (var thread in clrRuntime.Threads)
                {
                    res += $"#Thread {thread.OSThreadId}\n";

                    foreach (var frame in thread.EnumerateStackTrace())
                    {
                        res += $"{frame}\n";
                    }
                }
            }

            return res;
        }
    }

    public static class SetWindow
    {
        public static IntPtr intPtr;         //第三方应用窗口的句柄

        /// <summary>
        /// 调整第三方应用窗体大小
        /// </summary>
        public static void ResizeWindow()
        {
            ShowWindow(intPtr, 0);  //先将窗口隐藏
            ShowWindow(intPtr, 3);  //再将窗口最大化，可以让第三方窗口自适应容器的大小
        }

        /// <summary>
        /// 循环查找第三方窗体
        /// </summary>
        /// <returns></returns>
        public static bool FindWindow(string formName)
        {
            for (var i = 0; i < 100; i++)
            {
                //按照窗口标题查找Python窗口
                var vHandle = FindWindow(null, formName);
                if (vHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100);  //每100ms查找一次，直到找到，最多查找10s
                    continue;
                }
                else      //找到返回True
                {
                    intPtr = vHandle;
                    return true;
                }
            }
            intPtr = IntPtr.Zero;
            return false;
        }


        /// <summary>
        /// 将第三方窗体嵌入到容器内
        /// </summary>
        /// <param name="hWndNewParent">父容器句柄</param>
        /// <param name="windowName">窗体名</param>
        public static void SetParent(IntPtr hWndNewParent, string windowName)
        {
            ShowWindow(intPtr, 0);                 //先将窗体隐藏，防止出现闪烁
            SetParent(intPtr, hWndNewParent);      //将第三方窗体嵌入父容器                    
            Thread.Sleep(100);                      //略加延时
            ShowWindow(intPtr, 3);                 //让第三方窗体在容器中最大化显示
            RemoveWindowTitle(intPtr);             // 去除窗体标题
        }


        /// <summary>
        /// 去除窗体标题
        /// </summary>
        /// <param name="vHandle">窗口句柄</param>
        public static void RemoveWindowTitle(IntPtr vHandle)
        {
            var style = GetWindowLong(vHandle, -16);
            style &= ~0x00C00000;
            SetWindowLong(vHandle, -16, style);
        }


        #region API 需要using System.Runtime.InteropServices;

        [DllImport("user32.dll ", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);   //将外部窗体嵌入程序

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);      //按照窗体类名或窗体标题查找窗体

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);                  //设置窗体属性

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        #endregion
    }

    namespace Infrastructure
    {
        public static class MiniDump
        {
            // Taken almost verbatim from http://blog.kalmbach-software.de/2008/12/13/writing-minidumps-in-c/
            [Flags]
            public enum Option : uint
            {
                // From dbghelp.h:
                Normal = 0x00000000,
                WithDataSegs = 0x00000001,
                WithFullMemory = 0x00000002,
                WithHandleData = 0x00000004,
                FilterMemory = 0x00000008,
                ScanMemory = 0x00000010,
                WithUnloadedModules = 0x00000020,
                WithIndirectlyReferencedMemory = 0x00000040,
                FilterModulePaths = 0x00000080,
                WithProcessThreadData = 0x00000100,
                WithPrivateReadWriteMemory = 0x00000200,
                WithoutOptionalData = 0x00000400,
                WithFullMemoryInfo = 0x00000800,
                WithThreadInfo = 0x00001000,
                WithCodeSegs = 0x00002000,
                WithoutAuxiliaryState = 0x00004000,
                WithFullAuxiliaryState = 0x00008000,
                WithPrivateWriteCopyMemory = 0x00010000,
                IgnoreInaccessibleMemory = 0x00020000,
                ValidTypeFlags = 0x0003ffff,
            }

            enum ExceptionInfo
            {
                None,
                Present
            }

            //typedef struct _MINIDUMP_EXCEPTION_INFORMATION {
            //    DWORD ThreadId;
            //    PEXCEPTION_POINTERS ExceptionPointers;
            //    BOOL ClientPointers;
            //} MINIDUMP_EXCEPTION_INFORMATION, *PMINIDUMP_EXCEPTION_INFORMATION;
            [StructLayout(LayoutKind.Sequential, Pack = 4)]  // Pack=4 is important! So it works also for x64!
            struct MiniDumpExceptionInformation
            {
                public uint ThreadId;
                public IntPtr ExceptionPointers;
                [MarshalAs(UnmanagedType.Bool)]
                public bool ClientPointers;
            }

            //BOOL
            //WINAPI
            //MiniDumpWriteDump(
            //    __in HANDLE hProcess,
            //    __in DWORD ProcessId,
            //    __in HANDLE hFile,
            //    __in MINIDUMP_TYPE DumpType,
            //    __in_opt PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam,
            //    __in_opt PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam,
            //    __in_opt PMINIDUMP_CALLBACK_INFORMATION CallbackParam
            //    );
            // Overload requiring MiniDumpExceptionInformation
            [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]

            static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, ref MiniDumpExceptionInformation expParam, IntPtr userStreamParam, IntPtr callbackParam);

            // Overload supporting MiniDumpExceptionInformation == NULL
            [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
            static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

            [DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
            static extern uint GetCurrentThreadId();

            static bool Write(SafeHandle fileHandle, Option options, ExceptionInfo exceptionInfo)
            {
                var currentProcess = Process.GetCurrentProcess();
                var currentProcessHandle = currentProcess.Handle;
                var currentProcessId = (uint)currentProcess.Id;
                MiniDumpExceptionInformation exp;
                exp.ThreadId = GetCurrentThreadId();
                exp.ClientPointers = false;
                exp.ExceptionPointers = IntPtr.Zero;
                if (exceptionInfo == ExceptionInfo.Present)
                {
                    exp.ExceptionPointers = Marshal.GetExceptionPointers();
                }
                return exp.ExceptionPointers == IntPtr.Zero ? MiniDumpWriteDump(currentProcessHandle, currentProcessId, fileHandle, (uint)options, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero) : MiniDumpWriteDump(currentProcessHandle, currentProcessId, fileHandle, (uint)options, ref exp, IntPtr.Zero, IntPtr.Zero);
            }

            static bool Write(SafeHandle fileHandle, Option dumpType)
            {
                return Write(fileHandle, dumpType, ExceptionInfo.None);
            }

            public static Boolean TryDump(String dmpPath, Option dmpType = Option.Normal)
            {
                var path = Path.Combine(Environment.CurrentDirectory, dmpPath);
                var dir = Path.GetDirectoryName(path);
                if (dir != null && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    return Write(fs.SafeFileHandle, dmpType);
                }
            }
        }
    }

}