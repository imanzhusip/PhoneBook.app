using System;

namespace PhoneBook.BLL
{
    public static class PhoneBookBLL
    {
        // Метод для добавления нового контакта в телефонную книгу.
        public static void AddContact(string[,] phoneList)
        {
            Console.Clear();

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string number = Console.ReadLine();

            try
            {
                for (int i = 0; i < phoneList.GetLength(0); i++)
                    for (int j = 0; j < phoneList.GetLength(1); j++)
                        if (phoneList[i, j] == null)
                        {
                            phoneList[i, j] = string.Format("{0} {1}", name, number);
                            Console.WriteLine("Записано!");
                            Console.WriteLine();
                            return;
                        }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // Метод для удаления контакта из телефонной книги.
        public static void DeleteContact(string[,] phoneList)
        {
            Console.Clear();
            Console.WriteLine("Список");

            for (int i = 0; i < phoneList.GetLength(0); i++)
                for (int j = 0; j < phoneList.GetLength(1); j++)
                    if (phoneList[i, j] != null)
                    {
                        int a = 1;
                        switch (i)
                        {
                            case 0:
                                a = j + a;
                                break;
                            case 1:
                                a = a + phoneList.GetLength(1) + j;
                                break;
                            case 2:
                                a = a + (phoneList.GetLength(1) * 2) + j;
                                break;
                            case 3:
                                a = a + (phoneList.GetLength(1) * 3) + j;
                                break;
                        }
                        Console.WriteLine("{0}. {1}", a, phoneList[i, j]);
                    }

            try
            {
                Console.Write("Введите номер удаляемого контакта: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                int index1 = index / phoneList.GetLength(1);

                switch (index)
                {
                    case 4:
                    case 8:
                    case 9:
                    case 12:
                    case 13:
                    case 14:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        index1 = index1 - 1;
                        break;
                }

                int index2 = index;

                while (index2 > phoneList.GetLength(1))
                {
                    index2 = index2 - phoneList.GetLength(1);
                }

                phoneList[index1, index2] = null;
                Console.WriteLine("Удалено!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // Метод для просмотра всех контактов в телефонной книге.
        public static void ViewContacts(string[,] phoneList)
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Список");
            for (int i = 0; i < phoneList.GetLength(0); i++)
                for (int j = 0; j < phoneList.GetLength(1); j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);

            Console.WriteLine();
        }

        // Метод для поиска контакта по имени или номеру телефона в телефонной книге.
        public static void SearchContact(string[,] phoneList)
        {
            Console.Clear();
            Console.WriteLine("1. Поиск по имени\n2. Поиск по номеру телефона");
            Console.Write("Выберите тип поиска: ");

            string searchType = Console.ReadLine();

            switch (searchType)
            {
                case "1":
                    Console.Write("Введите имя для поиска: ");
                    string nameToSearch = Console.ReadLine();
                    SearchByName(phoneList, nameToSearch);
                    break;
                case "2":
                    Console.Write("Введите номер телефона для поиска: ");
                    string numberToSearch = Console.ReadLine();
                    SearchByNumber(phoneList, numberToSearch);
                    break;
                default:
                    Console.WriteLine("Неверный тип поиска.");
                    break;
            }
        }

        // Метод для поиска контакта по имени в телефонной книге.
        public static void SearchByName(string[,] phoneList, string name)
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Результаты поиска по имени '{0}':", name);

            for (int i = 0; i < phoneList.GetLength(0); i++)
            {
                for (int j = 0; j < phoneList.GetLength(1); j++)
                {
                    if (phoneList[i, j] != null && phoneList[i, j].Contains(name))
                    {
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
                    }
                }
            }

            Console.WriteLine();
        }

        // Метод для поиска контакта по номеру телефона в телефонной книге.
        public static void SearchByNumber(string[,] phoneList, string number)
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Результаты поиска по номеру телефона '{0}':", number);

            for (int i = 0; i < phoneList.GetLength(0); i++)
            {
                for (int j = 0; j < phoneList.GetLength(1); j++)
                {
                    if (phoneList[i, j] != null && phoneList[i, j].Contains(number))
                    {
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
                    }
                }
            }

            Console.WriteLine();
        }

        // Метод для редактирования контакта в телефонной книге.
        public static void EditContact(string[,] phoneList)
        {
            Console.Clear();
            Console.WriteLine("Редактирование контакта");

            Console.WriteLine("Выберите номер контакта для редактирования:");

            int a = 1;
            for (int i = 0; i < phoneList.GetLength(0); i++)
                for (int j = 0; j < phoneList.GetLength(1); j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);

            try
            {
                Console.Write("Введите номер контакта: ");
                int contactNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                if (contactNumber >= 0 && contactNumber < phoneList.Length)
                {
                    Console.Write("Введите новое имя: ");
                    string newName = Console.ReadLine();
                    Console.Write("Введите новый номер телефона: ");
                    string newNumber = Console.ReadLine();

                    phoneList[contactNumber / phoneList.GetLength(1), contactNumber % phoneList.GetLength(1)] = string.Format("{0} {1}", newName, newNumber);
                    Console.WriteLine("Контакт отредактирован!");
                }
                else
                {
                    Console.WriteLine("Неверный номер контакта.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }
    }
}
