using System.Collections.Generic;

namespace SortingVector_Csharp
{
    class CompareClass : IComparer<string>
    {
        private static int Counter_Of_Symbols_After_Dot(string str)
        {
            int counter = 0;
            bool is_significiant_figure;
            int position_of_dot = -1;

            for (int i = 0; i < str.Length; i++) // выясняем текущую позицию точки в числе
            {
                if (str[i] == '.')
                {
                    position_of_dot = i;
                }
            }
            if (position_of_dot == -1)
            {
                return 0;
            }

            // считаем количество цифр в дробной части

            // рассмотрение ситуации на незначащие цифры ,например 1.123000 (послелние 3 - нуля незначащие цифры)
            if (str[str.Length - 1] == '0')
            {
                is_significiant_figure = false;
                for (int i = str.Length - 2; i > position_of_dot; i--)
                {
                    if (!is_significiant_figure)
                    {
                        if (str[i] != '0')
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
                for (int i = str.Length; i > position_of_dot; i--)
                {
                    counter++;
                }
                return counter;
            }
        }
        public int Compare(string x, string y) // сравниваем количества цифр в дробной части
        {
            int a = Counter_Of_Symbols_After_Dot(y);
            int b = Counter_Of_Symbols_After_Dot(x);
            if (a > b)
                return 1;
            if (a < b)
                return -1;
            return 0;
        }

    }
}
