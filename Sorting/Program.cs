using System;
using System.Collections.Generic;

namespace SortingVector_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();

            if (ListFunctions.ReadList(numbers))
            {
                CompareClass cmp = new CompareClass();
                numbers.Sort(cmp);
                ListFunctions.PrintList(numbers);
            }
            Console.WriteLine("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
