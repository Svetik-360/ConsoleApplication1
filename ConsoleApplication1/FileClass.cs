using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class FileClass
    {
        public delegate void OnListChanged(); //делегат
        public List<string> list; //список со строками
        private string fileName; //имя файла
        public OnListChanged listChanged; // делегатная переменная

        public FileClass(string fileName) //конструктор - заполняет список из файла
        {
            this.fileName = fileName;
            list = File.ReadAllLines(fileName).ToList();
        }

        public void Add(string newString)
        {
            list.Add(newString); //добавляем в список
            if (listChanged != null) listChanged(); //вызываем обработчик изменения списка
            File.WriteAllLines(fileName, list); //сохраняем файл
        }

        public void Remove(int index)
        {
            list.RemoveAt(index); //удаляем из списка
            if (listChanged != null) listChanged(); //вызываем обработчик изменения списка
            File.WriteAllLines(fileName, list);  //сохраняем файл
        }

        public void Search(String str)
        {
            bool found = false;

            using (StreamReader reader = new StreamReader("data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IndexOf(str) > -1)
                    {
                        Console.WriteLine(line);
                        break;
                    }
                }
            }

            Console.WriteLine("Found: {0}", found);
        }
    }
}
