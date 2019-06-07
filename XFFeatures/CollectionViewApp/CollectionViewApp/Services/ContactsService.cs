using System.Collections.Generic;
using System.Linq;
using CollectionViewApp.Models;
using CollectionViewApp.PlatformServices;
using CollectionViewApp.ViewModels.Objects;
using Xamarin.Forms;

namespace CollectionViewApp.Services
{
    public class ContactsService
    {
        private List<Contact> _contacts;

        public ContactsService()
        {
            Initialize();
        }

        public List<ContactObjectViewModel> GetContacts()
        {
            return _contacts.Select(c => new ContactObjectViewModel
            {
                Avatar = $"image{c.Id}.jpg",
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                PhoneNumber = c.PhoneNumber,
                CallCommand = new Command<ContactObjectViewModel>(Call)
            }).ToList();
        }

        private void Initialize()
        {
            _contacts = new List<Contact>
            {
                new Contact("James", "Montemagno", "+48 725859940"),
                new Contact("Adam", "Logan", "+48 725859941"),
                new Contact("Peter", "Logan", "+48 725859942"),
                new Contact("Alice", "Logan", "+48 725859943"),
                new Contact("Tomasz", "Ciesielski", "+48 725859944"),
            };
        }

        private void Call(ContactObjectViewModel contact)
        {
            DependencyService.Get<ICallerService>().Call(contact.PhoneNumber);
        }
    }
}
