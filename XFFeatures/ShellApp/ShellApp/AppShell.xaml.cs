using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ShellApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand SettingsCommand => new Command(async () =>
        {
            await PushPage(new SettingsPage());
        });

        private async Task PushPage(Page page)
        {
            await Current.Navigation.PushAsync(page);
            Current.FlyoutIsPresented = false;
        }

        private async void Navigate(object route)
        {
            ShellNavigationState state = Current.CurrentState;
            await Current.GoToAsync($"{state.Location}/{route}");
            Current.FlyoutIsPresented = false;
        }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        private void RegisterRoutes()
        {
            var _routes = new Dictionary<string, Type>
            {
                {"photos", typeof(PhotosPage) },
                {"articles", typeof(ArticlesPage) },
                {"projects", typeof(ProjectsPage) },
                {"settings", typeof(SettingsPage) }
            };

            foreach (var route in _routes)
            {
                Routing.RegisterRoute(route.Key,route.Value);
            }
        }
    }
}