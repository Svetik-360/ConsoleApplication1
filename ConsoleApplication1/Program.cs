using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static public int DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Главное меню");
            Console.WriteLine();
            Console.WriteLine("1. Добавить новую ИП или ЮЛ");
            Console.WriteLine("2. Найти ИП или ЮЛ");
            Console.WriteLine("3. Список задач, встреч и др.");
            Console.WriteLine("0. Выход");
            Console.WriteLine();
            Console.Write("Введите число и нажмите клавишу Enter: ");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);// в int 
        }
        static public int DisplayMenuOrganizer()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. Добавить мероприятие");
            Console.WriteLine("2. Найти мероприятие");
            Console.WriteLine("3. Назад");
            Console.WriteLine();
            Console.Write("Введите число и нажмите клавишу Enter: ");
            var result = Console.ReadLine();

            return Convert.ToInt32(result);// в int 
        }
        static void Main(string[] args)
        {
            try
            {
                int userInput = 0;
                do
                {
                    userInput = DisplayMenu();
                    string organizationStr = "", organizerStr = "";
                    FileClass data = new FileClass("data.txt");

                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Вввод данных\nНазвание\tАдрес\tТелефон");
                            organizationStr = Console.ReadLine();
                            data.Add(organizationStr, "data.txt");
                            Console.WriteLine("Успешно добавлены!\nДля продолжения нажмите Enter!");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Введите номер телефона: ");
                            organizationStr = Console.ReadLine();
                            data.Search(organizationStr, "data.txt");
                            Console.WriteLine("Для продолжения нажмите Enter!");
                            Console.ReadLine();
                            break;
                        case 3:
                            do
                            {
                                userInput = DisplayMenuOrganizer();
                                switch (userInput)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Вввод данных\nНаименование\tДата начала\tДата окончания\tТелефон организации");
                                        organizerStr = Console.ReadLine();
                                        data.Add(organizerStr, "organizer.txt");
                                        Console.WriteLine("Для продолжения нажмите Enter!");
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Введите номер телефона организации: ");
                                        String phone = Console.ReadLine();
                                        data.Search(phone, "organizer.txt");
                                        Console.WriteLine("Для продолжения нажмите Enter!");
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        userInput = DisplayMenu();
                                        break;
                                    default:
                                        Console.WriteLine("Не существующее значение!");
                                        userInput = DisplayMenuOrganizer();
                                        break;
                                }

                            } while (userInput != 0);
                            break;
                        default:
                            Console.WriteLine("Не существующее значение!");
                            userInput = DisplayMenu();
                            break;
                    }

                } while (userInput != 0);


                //System.Threading.Thread.Sleep(1000);//Пауза

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}