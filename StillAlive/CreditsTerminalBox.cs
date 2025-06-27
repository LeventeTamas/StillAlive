using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StillAlive
{
    internal class CreditsTerminalBox : TerminalBox
    {
        public void AddText(string _text)
        {
            string text = _text;
            string[] lines = _text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Length > 17)
            {
                text = _text.Substring(lines.Length-16, 17);
            }
            textBox1.AppendText(_text);
        }
    }
}
