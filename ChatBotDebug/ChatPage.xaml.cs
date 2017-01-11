using ChatBotDebug.Model;
using ChatBotDebug.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ChatBotDebug
{
    public partial class ChatPage : ContentPage
    {
        protected Chat activeChat;
        private string participantId;
        public ChatPage(ApplicationManager _appManager, string participantId)
        {

            InitializeComponent();
            this.participantId = participantId;

            activeChat = new Chat(_appManager, participantId);
            Storage.receiver = new System.Collections.ObjectModel.ObservableCollection<Util.Message>();
            messagesField.ItemsSource = activeChat.receiver;
        }


        /***
         * 
         * 
         * 
         */
        async void OnSend(object sender, EventArgs e)
        {
            var tmpInput = inputField.Text;
            inputField.Text = "";
            await activeChat.sendMessage(tmpInput);


            //ScrollDown();
        }
        void ScrollDown()
        {
            messagesField.ScrollTo(activeChat.getLast(), ScrollToPosition.End, true);
        }

        void onKeyboardOpen(object sender, EventArgs e)
        {
            //add resizing for messageField
        }

    }

}
