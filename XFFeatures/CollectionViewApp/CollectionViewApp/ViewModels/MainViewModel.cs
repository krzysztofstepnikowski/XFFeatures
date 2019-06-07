using System;
using System.Collections.ObjectModel;
using CollectionViewApp.Services;
using CollectionViewApp.ViewModels.Objects;

namespace CollectionViewApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ContactObjectViewModel> Contacts { get; set; }

        private readonly ContactsService _contactsService;

        public MainViewModel()
        {
            _contactsService = new ContactsService();
            GetContacts();
        }

        private void GetContacts()
        {
            var contacts = _contactsService.GetContacts();

            if (contacts == null)
            {
                throw new Exception("Contacts cannot be null");
            }

            Contacts = new ObservableCollection<ContactObjectViewModel>(contacts);
        }

        
    }
}
