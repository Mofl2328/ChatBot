using ChatBotDebug.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatBotDebug
{
    public partial class MainPage : ContentPage
    {
        private ApplicationManager _appManager;

        public MainPage()
        {
            InitializeComponent();
            _appManager = new ApplicationManager();

        }

        async void OnTestClick(object sender, EventArgs e)
        {
            //await DisplayAlert("Test", "Before Action", "Continue");
            await Navigation.PushAsync(new ChatPage(_appManager, "bot"));
            //await Navigation.PushAsync(new MainPage());

        }
    }
}
