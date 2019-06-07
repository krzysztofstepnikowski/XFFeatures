using System.Windows.Input;

namespace CollectionViewApp.ViewModels.Objects
{
    public class ContactObjectViewModel
    {
        public string Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public ICommand CallCommand { get; set; }
    }
}
