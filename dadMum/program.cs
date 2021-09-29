using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dad_mum_csharp
{
    class Speaker
    {
        private string saying;
        private int repeat_number;
        private int wait_time;
        private static int general_written_number = 0;
        private static Mutex mtx = new Mutex();

        public static int general_repeat_number = 15;

        public Speaker(string saying_, int repeat_number_, int wait_time_)
        {
            this.saying = saying_;
            this.repeat_number = repeat_number_;
            this.wait_time = wait_time_;
        }

        public Speaker()
        {
            this.saying = "";
            this.repeat_number = 0;
            this.wait_time = 0;
        }

        public void Print() // функция, выводящая сообщения
        {
            int tmp1 = repeat_number;

            while (tmp1 != 0 && general_written_number < general_repeat_number)
            {

                mtx.WaitOne();
                Console.WriteLine("Поток №" + Thread.CurrentThread.ManagedThreadId.ToString() + ": " + this.saying);
                tmp1--;
                general_written_number++;
                mtx.ReleaseMutex();

                Thread.Sleep(this.wait_time);
            }
        }

        ~Speaker() // деструктор
        {

        }

    }

    class program
    {
        static void Main(string[] args)
        {

            int n; // вводим нужную информацию
            Console.Write("Введите число потоков: ");
            n = Convert.ToInt32(Console.ReadLine());
            int m;
            Console.Write("Введите общее число повторений: ");
            m = Convert.ToInt32(Console.ReadLine());
            Speaker.general_repeat_number = m;
            Console.WriteLine();

            string msg;
            int rpt;
            int wt;
            Speaker[] speakers = new Speaker[n];
            for (int i = 0; i < n; i++) // для каждого потока вводим нужную информацию
            {
                Console.Write("Введите текст сообщения: ");
                msg = Console.ReadLine();
                Console.Write("Введите количество повторений: ");
                rpt = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите задержку в милисекундах: ");
                wt = Convert.ToInt32(Console.ReadLine());

                speakers[i] = new Speaker(msg, rpt, wt);
                Console.WriteLine();
            }

            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                threads[i] = new Thread(speakers[i].Print);
                threads[i].Start();
                Thread.Sleep(1);
            }

            for (int i = 0; i < n; i++) // соединяем потоки с главным потоком, чтобы программа не заканчивалась
            {
                threads[i].Join();
            }

            Console.ReadKey();
        }
    }
}