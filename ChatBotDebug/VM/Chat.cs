using ChatBotDebug.Model;
using ChatBotDebug.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotDebug.VM
{
    public class Chat
    {
        private ApplicationManager _applicationManager;

        public String participantId
        {
            get; private set;
        }

        public ObservableCollection<Message> messages
        {
            get;
            private set;
        }


        public Message getLast()
        {
            return messages.Last();
        }

        public Chat(ApplicationManager applicationManager, string participantId)
        {
            this.participantId = participantId;
            this._applicationManager = applicationManager;
            this.messages = _applicationManager.getChatManager().getMessages(participantId);
        }

        async public Task sendMessage(string input)
        {
            await _applicationManager.getChatManager().sendMessage(input, participantId);
        }



    }
}
