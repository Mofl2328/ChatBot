using ChatBotDebug.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotDebug.Model.Interfaces
{
    interface IConnector
    {
        Task sendMessage(string text, string from, string to);
    }
}
