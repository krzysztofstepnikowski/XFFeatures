using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace ShellApp.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageBoxDialog : PopupPage
    {
        public MessageBoxDialog()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync(true);
        }
    }
}