using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public void Add(string newString, string fileName)
        {
            list.Clear();//очищаем список перед наполнением 
            list.Add(newString); //добавляем в список
            if (listChanged != null) listChanged(); //вызываем обработчик изменения списка
            File.WriteAllLines(fileName, list); //сохраняем файл
        }
        /*
        public void Remove(int index)//удаление
        {
            list.RemoveAt(index); //удаляем из списка
            if (listChanged != null) listChanged(); //вызываем обработчик изменения списка
            File.WriteAllLines(fileName, list);  //сохраняем файл
        }*/

        public void Search(String str, String fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                bool found = false;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IndexOf(str) > -1)
                    {
                        Console.WriteLine(line);
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("По запросу ничего не найдено.");
                }
            }
        }
    }
}