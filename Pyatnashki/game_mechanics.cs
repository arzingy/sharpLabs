using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyatnashki_borsukov
{
    class game_mechanics
    {
        bool changednum; // булевая переменная для проверки состояния поля
        int xe, ye; // координаты пустой пятнашки
        int[,] map = new int[4,4]; // наше поле
        int[] arr = new int[16]; // массив, запоминающий порядок пятнашки для повтора игры
        static Random r = new Random(); // переменная для рандома

        static List<int> Generator() // функция, расставляющая числа от 0 до 15 в рандомном порядке
        {
            List<int> result = new List<int>();

            while (result.Count != 16)
            {
                int temp = r.Next(0, 16);
                if (result.Contains(temp))
                    continue;
                else
                    result.Add(temp);
            }
            return result;
        }

        public int getnum(int p) // возвращает значение пятнашки
        {
            int x, y; // переменные коррдинат пятнашки
            potoco(p, out x, out y); // определяем координаты пятнашки
            if (x < 0 || y < 0 || x > 3 || y > 3) return 0; // проверяем, чтобы координаты не вылезли из массива
            return map[x, y]; // возвращаем значение пятнашки
        }

        private int cotopo(int x, int y) // определяет позицию пятнашки по координатам
        {
            return x * 4 + y;
        }

        private void potoco(int p, out int x, out int y) // определяет координаты пятнашки по её позиции
        {
            x = p / 4; // частное от деления - номер строки
            y = p % 4; // остаток от деления - номер столбца
        }

        public void game_start() // запуск новой игры
        {
            changednum = false; // меняем значение переменной для корректной работы
            var some = Generator(); // генерируем рандомную последовательность числе от 0 до 15
            int x = 0, y = 0;
            foreach (var i in some) // для каждого значения последовательности
            {
                map[x, y] = i; // присваеиваем его пятнашке
                arr[x * 4 + y] = i; // запоминаме порядок значений для повтора игры
                if (i == 0) // запоминаем координаты пустой пятнашки
                {
                    xe = x;
                    ye = y;
                }
                y++; // идём по столбцам
                if (y==4) // доходя до конца, переходим на следующую строку
                {
                    x++;
                    y = 0;
                }
            }
        }

        public void game_start_again() // расставляет пятнашки по старым местам
        {
            changednum = false; // меняем значение переменной для корректной работы
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    map[x, y] = arr[x * 4 + y]; // каждой пятнашке присваиваем её изначальное значение
                    if (arr[x * 4 + y] == 0) // запоминаем координаты нулевой пятнашки
                    {
                        xe = x;
                        ye = y;
                    }
                }
        }

        public void shift(int p) // двигает пятнашки
        {
            int x, y; // переменные координат пятнашки
            potoco(p, out x, out y); // определяем координаты пятнашки
            if (Math.Abs(xe - x) + Math.Abs(ye - y) == 1) // если пятнашка находятся рядом с пустой
            {
                changednum = true; // произошло движение
                map[xe, ye] = map[x, y]; // пустая клетка заполнилась пятнашкой
                map[x, y] = 0; // бывшая заполненная клетка опустела
                xe = x; // присваиваем пустышке координаты
                ye = y;
            }
        }

        public bool changed() // возвращает значение изменения поля для добавления хода
        {
            return changednum;
        }

        public bool checking_stuff() // проверка поля на победу
        {
            changednum = false; // меняем значение переменной для корректной работы
            if (xe == ye && ye == 3) // проверяем, является ли последняя клетка пустой
            {
                for (int x = 0; x < 4; x++)
                    for (int y = 0; y < 4; y++)
                    {
                        int fina = cotopo(x, y);
                        if (fina < 13) // проверяем значения первых тринадцати пятнашек
                            if (!(map[x, y] == fina + 1))
                                return false;
                    }
                return true; // если все значения от 1 до 13 находятся на своих местах - игрок победил!
            }
            return false;
        }
    }
}
