namespace Module3HW2
{
    public class Contact
    {
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            FullName = $"{LastName} {FirstName}";
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }
        public override string ToString()
        {
            return $"{FullName}\n{PhoneNumber}";
        }
    }
}
