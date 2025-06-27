using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StillAlive
{

    public delegate void TerminalAddString(string newText);
    public delegate void TerminalClear();

    internal class TerminalEngine
    {
        private List<Command> Commands = new List<Command>();
        private int currentDelay = 1;
        private int delayCountdown = 0;

        private int currentCommandIndex = 0;

        private int currentTextCursor = 0;

        private int waitInterval = 1;
        private int waitCountDown = 0;
        private bool isWaiting = false;


        public event TerminalAddString OnTerminalAddString;
        public event TerminalClear OnTerminalClear;

        public TerminalEngine(string _controlFile) 
        {
            string[] lines = _controlFile.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line)) continue;

                string[] commandParts = line.Split('|');
                if(commandParts.Length != 2) continue;

                CommandType commandType = (CommandType)Enum.Parse(typeof(CommandType), commandParts[0]);
                Commands.Add(new Command(commandType, commandParts[1]));
            }
        }

        public void Tick()
        {
            if (currentCommandIndex > Commands.Count - 1) return;
            switch (Commands[currentCommandIndex].CommandType)
            {
                case CommandType.DELAY:
                    {
                        currentDelay = Convert.ToInt32(Commands[currentCommandIndex].Parameter);
                        delayCountdown = currentDelay;
                        currentCommandIndex++;
                        break;
                    }
                case CommandType.CLEAR:
                    {
                        OnTerminalClear();
                        currentCommandIndex++;
                        break;
                    }
                case CommandType.TEXT:
                    {
                        currentTextCursor = 0;
                        Commands[currentCommandIndex].CommandType = CommandType.WAIT_FOR_TEXT;
                        break;
                    }
                case CommandType.WAIT:
                    {
                        if (!isWaiting) {
                            waitCountDown = Convert.ToInt32(Commands[currentCommandIndex].Parameter);
                            isWaiting = true;
                            break;
                        }

                        waitCountDown--;
                        if (waitCountDown == 0)
                        {
                            isWaiting = false;
                            currentCommandIndex++;
                        }

                        break;
                    }
                case CommandType.WAIT_FOR_TEXT:
                    {
                        
                        delayCountdown--;
                        if (delayCountdown <= 0)
                        {
                            if (!String.IsNullOrEmpty(Commands[currentCommandIndex].Parameter))
                                OnTerminalAddString(Commands[currentCommandIndex].Parameter[currentTextCursor++].ToString());

                            delayCountdown = currentDelay;

                            if (Commands[currentCommandIndex].Parameter.Length == currentTextCursor)
                            {
                                OnTerminalAddString(Environment.NewLine);
                                currentCommandIndex++;
                            }
                        }
                        break;
                    }
                case CommandType.ASCII_ART:
                    {
                        OnTerminalAddString(ASCII_ART.Elements[Commands[currentCommandIndex].Parameter]);
                        currentCommandIndex++;
                        break;
                    }
            }
        }
    }
}
