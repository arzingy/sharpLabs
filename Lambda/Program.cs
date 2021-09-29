using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

namespace lambda
{
    class Program
    {
        delegate int comp(string a);
        static comp d;
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-Ru", false);
                Encoding enc = Encoding.GetEncoding(1251);

                string writePath = @"D:\ВУЗ\Лабы\lambda\lambda\input.txt";
                List<string> str = new List<string>();
                using (StreamReader sr = new StreamReader(writePath, enc))
                {
                    if (!File.Exists(writePath))
                        throw new Exception ("Файл не открыт!");
                    if (sr.EndOfStream)
                        throw new Exception ("Входной файл пуст!");
                    else
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                            str.Add(line);
                    }
                }

                d = (string a) =>
                {
                    int counter = 0;
                    bool is_significiant_figure;
                    int position_of_dot = -1;
                    int k = 0;

                    foreach (char symbol in a) // выясняем текущую позицию точки в числе
                    {
                        if (symbol == '.')
                        {
                            position_of_dot = k;
                            break;
                        }
                        k++;
                    }
                    if (position_of_dot == -1)
                    {
                        return 0;
                    }

                    // считаем количество цифр в дробной части

                    // рассмотрение ситуации на незначащие цифры ,например 1.123000 (послелние 3 - нуля незначащие цифры)
                    if (a[a.Length - 1] == '0')
                    {
                        is_significiant_figure = false;
                        for (int i = a.Length - 2; i > position_of_dot; i--)
                        {
                            if (!is_significiant_figure)
                            {
                                if (a[i] != '0')
                                {
                                    counter++;
                                    is_significiant_figure = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            counter++;
                        }
                        return counter;
                    }
                    else
                    {
                        for (int i = a.Length; i > position_of_dot; i--)
                        {
                            counter++;
                        }
                        return counter;
                    }
                };
                string temp;
                for (int i = 0; i < str.Count; i++)
                    for (int j = i + 1; j < str.Count; j++)
                        if (d(str[i]) < d(str[j]))
                        {
                            temp = str[i];
                            str[i] = str[j];
                            str[j] = temp;
                        }
                foreach (string l in str)
                    Console.WriteLine(l);
                Console.WriteLine("Нажмите любую клавишу . . .");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
