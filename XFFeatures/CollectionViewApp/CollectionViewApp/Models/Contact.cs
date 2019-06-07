namespace CollectionViewApp.Models
{
    public class Contact
    {
        private static int _counter = 1;
        public Contact(string firstname, string lastname, string phoneNumber)
        {
            Id = $"{_counter++}";
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
        }

        public string Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string PhoneNumber { get; }
    }
}
