using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;

namespace StillAlive
{
    public partial class Form1 : Form
    {
        
        TerminalEngine LyricsTerminalEngine;
        TerminalEngine CreditsTerminalEngine;
        TerminalEngine AsciiArtTerminalEngine;

        SoundPlayer SoundPlayer;

        public Form1()
        {
            InitializeComponent();
            timer1.Stop();


            LyricsTerminalEngine = new TerminalEngine(Properties.Resources.lyrics);
            LyricsTerminalEngine.OnTerminalAddString += (string newText) => {
                LyricsTerminalBox.AddText(newText);
            };
            LyricsTerminalEngine.OnTerminalClear += () => {
                LyricsTerminalBox.ClearTerminal();
            };


            CreditsTerminalEngine = new TerminalEngine(Properties.Resources.credits);
            CreditsTerminalEngine.OnTerminalAddString += (string newText) => {
                CreditsTerminalBox.AddText(newText);
            };
            CreditsTerminalEngine.OnTerminalClear += () => {
                CreditsTerminalBox.ClearTerminal();
            };


            AsciiArtTerminalEngine = new TerminalEngine(Properties.Resources.art);
            AsciiArtTerminalEngine.OnTerminalAddString += (string newText) => {
                tbAsciiArt.Text = newText;
            };
            AsciiArtTerminalEngine.OnTerminalClear += () => {
                tbAsciiArt.Text = string.Empty;
            };


            SoundPlayer = new SoundPlayer(Properties.Resources.Still_Alive);
            SoundPlayer.LoadCompleted += SoundPlayer_LoadCompleted;
            SoundPlayer.LoadAsync();

        }

        private void SoundPlayer_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SoundPlayer.Play();
            timer1.Start();
        }

        private void textBox1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }

        Stopwatch stopwatch = new Stopwatch();
        long delay = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            stopwatch.Stop();
            delay += stopwatch.ElapsedMilliseconds - timer1.Interval;
            for (int i = 0; i < delay / timer1.Interval; i++)
            {
                Tick();
                delay -= timer1.Interval;
            }
            stopwatch.Restart();

            Tick();
        }

        private void Tick()
        {
            LyricsTerminalEngine.Tick();
            CreditsTerminalEngine.Tick();
            AsciiArtTerminalEngine.Tick();
        }
    }
}
