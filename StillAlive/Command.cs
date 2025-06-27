using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StillAlive
{
    enum CommandType
    {
        DELAY,
        WAIT,
        TEXT,
        WAIT_FOR_TEXT,
        CLEAR,
        ASCII_ART
    }
    internal class Command
    {
        public CommandType CommandType { get; set; }
        public string Parameter { get; set; }

        public Command(CommandType commandType, string parameter)
        {
            CommandType = commandType;
            Parameter = parameter;
        }
    }
}
