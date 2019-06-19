using System;
using Rg.Plugins.Popup.Extensions;
using ShellApp.CustomControl;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageBoxPage : ContentPage
    {
        public MessageBoxPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var popup = new MessageBoxDialog();
            App.Current.MainPage.Navigation.PushPopupAsync(popup, true);
        }
    }
}