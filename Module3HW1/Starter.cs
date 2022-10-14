using System;
using System.Globalization;

namespace Module3HW2
{
    public class Starter
    {
        private readonly IAlphabetService _alphabetService;

        public Starter(IAlphabetService alphabetService)
        {
            _alphabetService = alphabetService;
        }

        public void Run()
        {
            Console.WriteLine("1.English\n2.Українська\n");
            int choose = Convert.ToInt32(Console.ReadLine());

            CultureInfo culture;

            switch (choose)
            {
                case 1:
                    culture = new CultureInfo("en");
                    break;
                case 2:
                    culture = new CultureInfo("ua");
                    break;
                default:
                    culture = new CultureInfo("en");
                    break;
            }

            ContactList contactsContainer = new ContactList(_alphabetService, culture);

            Contact[] contactInfos = new Contact[]
            {
                new Contact("Mikael", "Mikael", "389029213"),
                new Contact("Antonio", "Antonio", "92378633"),
                new Contact("Filippo", "Filippo", "4566787637"),
                new Contact("Степан", "Ванщенко", "48993988678"),
                new Contact("Вікторія", "Дукачева", "37389028397"),
                new Contact("Іван", "Іванов", "37389028397"),
                new Contact("1188", "007", "837829"),
                new Contact("Рита", "/*Алькова", "0972")
            };

            foreach (var contact in contactInfos)
            {
                contactsContainer.AddContact(contact);
            }

            contactsContainer.ShowAllContacts();
        }
    }
}
