using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            WeatherForecastList.ItemSelected += (obj, sender) => WeatherForecastList.SelectedItem = null;
        }
    }
}