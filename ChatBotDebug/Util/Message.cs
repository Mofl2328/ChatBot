using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotDebug.Util
{
    public class Message : INotifyPropertyChanged
    {
        public String author { get; }
        public String text { get; }
        public DateTime timestamp { get; }

        public Message(String author, String text, DateTime timestamp)
        {
            this.author = author;
            this.text = text;
            this.timestamp = timestamp;
        }

        public Message(String author, String text)
        {
            this.author = author;
            this.text = text;
            this.timestamp = DateTime.Now;
        }

        public bool isMe
        {
            get
            {
                if (author == "Ich")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
