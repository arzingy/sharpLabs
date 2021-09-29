using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // для работы с регулярными выражениями
using System.IO;

namespace regexp_borsukov
{
    class Program
    {
        static void Main(string[] args)
        {
            string writepathIn = @"D:\ВУЗ\Лабы\irunner\regexp_borsukov\regexp_borsukov\input.txt"; // путь входного файла (вам нужно изменить на свой!)
            string writepathOut = @"D:\ВУЗ\Лабы\irunner\regexp_borsukov\regexp_borsukov\output.txt"; // путь выходного файла (вам нужно изменить на свой!)
            List<string> strings = new List<string>(); // переменная, хранящая строки без GUID
            try
            {
                using (StreamReader sr = new StreamReader(writepathIn, System.Text.Encoding.Default)) // читаем входной файл
                {
                    if (sr.EndOfStream) // если он пуст...
                        throw new Exception("Входной файл пуст!"); // выводим ошибку
                    else // иначе...
                    {
                        string line; // переменная читаемой строки
                        while ((line = sr.ReadLine()) != null) // пока во входном фалйе есть непрочитанные строки...
                            if (!Regex.IsMatch(line, @"(^|\s)[\da-fA-F]{8}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{12}(\s|$)")) // если в строке нет GUID...
                                                                                                                                             // подробнее о выражении
                                                                                                                                             // (^|\s) и (\s|$) проверяют, чтобы GUID либо отделялся пробелами, либо был в начале или конце строки
                                                                                                                                             // [\da-fA-F]{8} в квадратных скобках указано, что мы ищем любую цифру или букву от a до f (независимо от регистра), а в фигурных - сколько раз мы ищем это
                                strings.Add(line); // добавляем в strings
                    }
                }
                using (StreamWriter sw = new StreamWriter(writepathOut, false, System.Text.Encoding.Default)) // работаем с выходным файлом
                {
                    foreach (var item in strings) // каждый элемент из strings...
                        sw.WriteLine(item); // выводим в выходной файл
                }
                Console.WriteLine("В выходной файл внесены все необходимые данные"); // выводим сообщение об окончании работы
            }
            catch (Exception ex) // если во время работы с файлами произошла какая-либо ошибка (например, входного файла не существует), то...
            {
                Console.WriteLine(ex.Message); // выведется ошибка
            }
            Console.WriteLine("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
