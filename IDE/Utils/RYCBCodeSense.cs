using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using IDE.Properties;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IDE
{
    internal class RYCBCodeSense : ICompletionData
    {
        private CodeSenseType _type;
        internal static bool _completed = false;

        public RYCBCodeSense(string text, CodeSenseType type, string desc)
        {
            this.Text = text;
            this._type = type;
            this.Description = desc;
        }

        public RYCBCodeSense(string text, CodeSenseType type)
        {
            if (type == CodeSenseType.KEYWORD)
            {
                this.Text = text;
                this._type = type;
                this.Description = $"{text} 关键字";
            }
            else
            {
                this.Text = text;
                this._type = type;
                this.Description = "";
            }
        }

        public ImageSource Image => _type switch
        {
            CodeSenseType.FIELD => Imaging.CreateBitmapSourceFromHBitmap(Resources.field.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.FUNC => Imaging.CreateBitmapSourceFromHBitmap(Resources.func.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.KEYWORD => Imaging.CreateBitmapSourceFromHBitmap(Resources.keyword.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            _ => Imaging.CreateBitmapSourceFromHBitmap(Resources.help.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
        };

        public string Text { get; set; }

        public object Content => this.Text;

        public object Description { get; set; }

        public double Priority { get; }

        public static void Clear(ref string _)
        {
            if (_completed)
                _ = "";
        }

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Remove(completionSegment);
            textArea.Document.Replace(completionSegment, Text);
            _completed = true;
        }
    }

    internal class CodeAnalyser
    {
        private string[] tmpStringTables = { };

        internal CodeAnalyser(TextArea textArea)
        {
            if (textArea.Document.Text.Contains("def") | textArea.Document.Text.Contains("定义"))
            {
                tmpStringTables = textArea.Document.Text.Split('\n', ' ');
            }
        }

        internal string[] GetFunctions()
        {
            string[] retList = { };
            if (tmpStringTables.Length != 0)
            {
                for (int i = 0; i < tmpStringTables.Length; i++)
                {
                    var _ = tmpStringTables[i];
                    if (_.Contains("def") | _.Contains("定义"))
                    {
                        retList.Append(tmpStringTables[i + 1]);
                    }
                }
            }
            return retList.Length != 0 ? retList : new string[] { "bbb" };
        }
    }
}
