using System;
using System.Collections.Generic;
using System.Globalization;

namespace Module3HW2
{
    public class ContactList
    {
        private readonly IAlphabetService _alphabetService;

        public ContactList(IAlphabetService alphabetService, CultureInfo culture)
        {
            _alphabetService = alphabetService;
            AlphabetConfig = _alphabetService.ReadAlphabet(@"C:\Users\Соня\source\repos\Module3HW2\Module3HW2\Configs\config.json");

            Culture = culture;

            Contacts = new Dictionary<string, List<Contact>>();
            AddSection();
        }

        public Dictionary<string, List<Contact>> Contacts { get; set; }

        private CultureInfo Culture { get; set; }

        private AlphabetConfig AlphabetConfig { get; set; }

        public void ShowAllContacts()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            foreach (var item in Contacts)
            {
                if (Contacts[item.Key].Count > 0)
                {
                    Console.WriteLine($"{item.Key}: ");

                    for (int i = 0; i < Contacts[item.Key].Count; i++)
                    {
                        Console.WriteLine($"{Contacts[item.Key][i]}");
                    }

                    Console.WriteLine();
                }
            }
        }

        public void AddContact(Contact contact)
        {
            if (char.IsDigit(contact.FullName.ToUpper()[0]))
            {
                Contacts["0-9"].Add(contact);
            }
            else if (!char.IsLetter(contact.FullName.ToUpper()[0]))
            {
                Contacts["#"].Add(contact);
            }
            else
            {
                bool isAdded = false;

                foreach (var item in Contacts)
                {
                    if (contact.FullName.ToUpper().StartsWith(item.Key))
                    {
                        Contacts[item.Key].Add(contact);
                        isAdded = true;
                    }
                }

                if (!isAdded)
                {
                    Contacts["#"].Add(contact);
                }
            }
        }

        private void AddSection()
        {
            foreach (var item in AlphabetConfig.Alphabets[Culture.Name])
            {
                Contacts.Add(item.ToString(), new List<Contact>());
            }

            Contacts.Add("#", new List<Contact>());
            Contacts.Add("0-9", new List<Contact>());
        }
    }
}
