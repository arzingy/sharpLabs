using System;
using System.Collections.Generic;
using System.IO;

namespace SortingVector_Csharp
{
    class ListFunctions
    {
        static public bool ReadList(List<string> numbers)
        {
            string writePath = @"D:\ВУЗ\Лабы\sortingsharp\sortingsharp\sorting.txt"; // записываем путь к файлу (вам надо его изменить!!!)
            using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default)) // считываем информацию с файла
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    numbers.Add(line);
            }
            return true;
        }
        static public void PrintList(List<string> vs) // выводим числа
        {
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
