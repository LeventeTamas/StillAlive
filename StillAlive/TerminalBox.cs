using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StillAlive
{
    internal class TerminalBox : Panel
    {
      
        private static Font FONT = new Font("Courier New", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        private static Color FONT_COLOR = Color.FromArgb(226, 163, 2);
        private static int TEXTBOX_MARGIN = 18;

        public TextBox textBox1;

        public TerminalBox()
        {

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Resize += TerminalBox_Resize;
            
            this.BorderStyle = BorderStyle.None;

            textBox1 = new TextBox();
            textBox1.Font = FONT;
            textBox1.ForeColor = FONT_COLOR;
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.None;
            textBox1.Location = new Point(TEXTBOX_MARGIN-5, TEXTBOX_MARGIN-5);
            textBox1.Width = this.Width - (TEXTBOX_MARGIN * 2);
            textBox1.Height = this.Height - (TEXTBOX_MARGIN * 2);

            this.Controls.Add(textBox1);
        }

        private void TerminalBox_Resize(object sender, EventArgs e)
        {
            CreateFrame();
            textBox1.Width = this.Width - (TEXTBOX_MARGIN * 2);
            textBox1.Height = this.Height - (TEXTBOX_MARGIN * 2);
        }

        public void CreateFrame()
        {
            int numOfRows, numOfColumns;

            // 1. calculate columns and rows
            string testString = "-";
            while (GetStringSize(testString, FONT).Width < this.Width) testString += "-";
            numOfColumns = testString.Length - 1;
            testString = "|";
            while (GetStringSize(testString, FONT).Height < this.Height) testString += Environment.NewLine + "|";
            numOfRows = testString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length -1;
            

            // 2.1 create horizontal line
            string horizontalLine = "";
            for (int i = 0; i < numOfColumns-1; i++)
                horizontalLine += '-';

            // 2.2 Create frame string
            StringBuilder sb = new StringBuilder();
            // create top line
            sb.AppendLine(horizontalLine);
            for (int i = 0; i < numOfRows - 2; i++)
            {
                string line = "|";
                // fill the remaining chars with 'space'
                for (int j = 0; j < numOfColumns-2; j++)
                    line += " ";

                line += "|";
                sb.AppendLine(line);
            }
            // create bottom line
            sb.Append(horizontalLine);

            // 3. Draw frame
            Bitmap canvas = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.Black);
                g.PageUnit = GraphicsUnit.Pixel;
                g.DrawString(sb.ToString(), FONT, new SolidBrush(FONT_COLOR), 0, 0);
            }
            this.BackgroundImage = canvas;
        }

        public void AddText(string _text)
        {
            textBox1.AppendText(_text);
        }

        internal void ClearTerminal()
        {
            textBox1.Clear();
        }

        private Size GetStringSize(string _string, Font _font)
        {
            return TextRenderer.MeasureText(_string, _font);
        }


    }
}
