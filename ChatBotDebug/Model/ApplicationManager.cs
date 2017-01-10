using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotDebug.Model
{
    public class ApplicationManager
    {
        public ChatManager _chatManager
        {
            get; private set;
        }

        public string _accountManager { get; private set; }

        public ApplicationManager()
        {
            _accountManager = "Moritz";
            _chatManager = new ChatManager(this, _accountManager);
        }

        public ChatManager getChatManager()
        {
            return _chatManager;
        }
    }
}
