using System;

namespace PhoneBook.DAL
{
    public class PhoneBookContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
       

        public PhoneBookContact() { }  // Добавьте конструктор по умолчанию

        public PhoneBookContact(string firstName, string lastName, string number, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            Email = email;
            
        }

        public override string ToString()
        {
            return $"Имя: {FirstName}, Фамилия: {LastName}, Телефон: {Number}, Почта: {Email}";
        }
    }
}
