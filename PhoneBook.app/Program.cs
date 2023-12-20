using System;

namespace PhoneBook.app
{
    class Program
    {
        // Размеры массива для хранения контактов
        private static int n = 4;
        private static int m = 5;
        // Массив для хранения контактов, где n - количество строк, m - количество столбцов
        private static string[,] phoneList = new string[n, m];

        static void Main()
        {
            while (true)
            {
                // Выводит пользователю меню с выбором действий
                Console.WriteLine("1. Создать запись\n2. Удалить запись\n3. Найти контакт\n4. Вывести на экран все записи телефонной книги\n5. Редактировать контакт\n6. Выход");
                Console.Write("Введите команду: ");

                // Читает ввод пользователя
                string com = Console.ReadLine();

                // Обработка выбора пользователя
                switch (com)
                {
                    case "1":
                        phoneNew(); // Вызывает функцию для создания нового контакта
                        break;
                    case "2":
                        phoneDelete(); // Вызывает функцию для удаления контакта
                        break;
                    case "3":
                        phoneSearch(); // Вызывает функцию для поиска контакта
                        break;
                    case "4":
                        phoneView(); // Вызывает функцию для вывода на экран всех контактов
                        break;
                    case "5":
                        phoneEdit(); // Вызывает функцию для редактирования контакта
                        break;
                    case "6":
                        return; // Завершает программу
                    default:
                        Console.WriteLine("Неверная команда. Попробуйте еще раз.\n");
                        break;
                }
            }
        }

        static void phoneNew()
        {
            Console.Clear();

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string number = Console.ReadLine();

            try
            {
                // Поиск первой свободной ячейки в массиве и запись нового контакта
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
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

        static void phoneDelete()
        {
            Console.Clear();
            Console.WriteLine("Список");

            // Выводит на экран список контактов с номерами
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (phoneList[i, j] != null)
                    {
                        int a = 1;
                        switch (i)
                        {
                            case 0:
                                a = j + a;
                                break;
                            case 1:
                                a = a + m + j;
                                break;
                            case 2:
                                a = a + (m * 2) + j;
                                break;
                            case 3:
                                a = a + (m * 3) + j;
                                break;
                        }
                        Console.WriteLine("{0}. {1}", a, phoneList[i, j]);
                    }

            try
            {
                // Пользователь вводит номер удаляемого контакта
                Console.Write("Введите номер удаляемого контакта: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                int index1 = index / 4;

                // Коррекция индекса при необходимости
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

                // Коррекция индекса при необходимости
                while (index2 > 4)
                {
                    index2 = index2 - 5;
                }

                // Удаление контакта
                phoneList[index1, index2] = null;
                Console.WriteLine("Удалено!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void phoneView()
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Список");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);

            Console.WriteLine();
        }

        static void phoneSearch()
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
                    SearchByName(nameToSearch);
                    break;
                case "2":
                    Console.Write("Введите номер телефона для поиска: ");
                    string numberToSearch = Console.ReadLine();
                    SearchByNumber(numberToSearch);
                    break;
                default:
                    Console.WriteLine("Неверный тип поиска.");
                    break;
            }
        }

        static void SearchByName(string name)
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Результаты поиска по имени '{0}':", name);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (phoneList[i, j] != null && phoneList[i, j].Contains(name))
                    {
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
                    }
                }
            }

            Console.WriteLine();
        }

        static void SearchByNumber(string number)
        {
            Console.Clear();
            int a = 1;
            Console.WriteLine("Результаты поиска по номеру телефона '{0}':", number);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (phoneList[i, j] != null && phoneList[i, j].Contains(number))
                    {
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
                    }
                }
            }

            Console.WriteLine();
        }

        static void phoneEdit()
        {
            Console.Clear();
            Console.WriteLine("Редактирование контакта");

            Console.WriteLine("Выберите номер контакта для редактирования:");

            // Показать список контактов
            int a = 1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);

            try
            {
                // Пользователь вводит номер контакта для редактирования
                Console.Write("Введите номер контакта: ");
                int contactNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                if (contactNumber >= 0 && contactNumber < n * m)
                {
                    // Пользователь вводит новое имя и новый номер телефона
                    Console.Write("Введите новое имя: ");
                    string newName = Console.ReadLine();
                    Console.Write("Введите новый номер телефона: ");
                    string newNumber = Console.ReadLine();

                    // Обновление данных контакта
                    phoneList[contactNumber / m, contactNumber % m] = string.Format("{0} {1}", newName, newNumber);
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
