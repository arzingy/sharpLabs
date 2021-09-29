using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            Tree tr = new Tree(); // создаём дерево
            string choice = "\0"; // переменная выбора в меню
            while (choice != "0")
            { // выводим меню
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Ввести новую вершину");
                if (tr.DoesTreeExist()) // эти опции выводятся только если дерево имеет хоть один узел
                {
                    Console.WriteLine("2. Выполнить задание");
                    Console.WriteLine("3. Удалить вершину");
                }
                Console.WriteLine("0. Выйти из программы");
                Console.Write("Введите номер действия: ");
                choice = Console.ReadLine();
                Console.WriteLine("\n\n");
                switch (choice) // в зависимости от выбранного действия...
                {
                    case "1": // ...добавляем вершину
                        Console.Write("Введите значение: ");
                        int v = Convert.ToInt32(Console.ReadLine());
                        if (tr.Insert(v))
                            Console.WriteLine(v + " вставлено успешно!");
                        else Console.WriteLine("Не удалось вставить " + v + "!");
                        break;
                    case "2": // ...выполняем задание
                        if (tr.DoesTreeExist())
                        {
                            Console.WriteLine("Значения вершин на пути от корня до минимального элемента:");
                            tr.DoToMinimal(info => Console.Write(info + " ")); // функция поочерёдно будет выводить вершины на пути к минимальной
                            Console.WriteLine();
                            Console.WriteLine("Среднее арифметическое значений: " + tr.MeanToMinimal()); // показываем среднее арифметическое
                        }
                        else Console.WriteLine("Действия, вызываемого 2, не существует"); // если в дереве нет узлов, то действия 2 просто не будет
                        break;
                    case "3": // ...удаляем вершину
                        if (tr.DoesTreeExist())
                        {
                            Console.Write("Введите значение: ");
                            int d = Convert.ToInt32(Console.ReadLine());
                            if (tr.Delete(d))
                                Console.WriteLine(d + " удалено успешно!");
                            else Console.WriteLine("Не удалось удалить " + d + "!");
                        }
                        else Console.WriteLine("Действия, вызываемого 3, не существует"); // если в дереве нет узлов, то действия 3 просто не будет
                        break;
                    case "0": // ...выходим из программы
                        Console.WriteLine("До свидания!");
                        break;
                    default: // ...показываем, что такого действия в меню нет
                        Console.WriteLine("Действия, вызываемого " + choice + ", не существует");
                        break;
                }
                Console.WriteLine("\n\n");
            }
            Console.ReadKey();
        }
    }
}
