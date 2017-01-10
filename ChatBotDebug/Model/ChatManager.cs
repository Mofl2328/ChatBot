using ChatBotDebug.Model.Connector;
using ChatBotDebug.Model.Interfaces;
using ChatBotDebug.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotDebug.Model
{
    public class ChatManager
    {
        private ApplicationManager applicationManager;
        public string username { get; private set; }

        public ChatManager(ApplicationManager applicationManager, string username)
        {
            this.applicationManager = applicationManager;
            this.username = username;
            allChats = new Dictionary<string, Chat>();
        }

        private Dictionary<string, Chat> allChats;

        private class Chat
        {
            public IConnector connector;
            public ObservableCollection<Message> messages;

            public Chat(ObservableCollection<Message> messages, IConnector connector)
            {
                this.messages = messages;
                this.connector = connector;
            }
        }

        public ObservableCollection<Message> getMessages(string participantId)
        {
            Chat resultCol;
            if (allChats.ContainsKey(participantId))
            {
                allChats.TryGetValue(participantId, out resultCol);
            }
            else
            {
                var tmpList = new ObservableCollection<Message>();
                resultCol = new Chat(tmpList, new DirectLineConnector(tmpList));
                allChats.Add(participantId, resultCol);
            }
            return resultCol.messages;
        }

        async public Task sendMessage(string message, string participantId)
        {
            if (allChats.ContainsKey(participantId))
            {
                Chat resultCol;
                allChats.TryGetValue(participantId, out resultCol);
                await resultCol.connector.sendMessage(message, applicationManager._accountManager, participantId);

            }
            else
            {

            }
        }
    }
}
