// PhoneBookContact.cs в пространстве имен PhoneBook.DAL

namespace PhoneBook.DAL
{
    public class PhoneBookContact
    {
        public string FirstName { get; set; }
        
        public string Number { get; set; }
        

        public override string ToString()
        {
            return $"Имя: {FirstName}  Номер: {Number}";
        }
    }
}
