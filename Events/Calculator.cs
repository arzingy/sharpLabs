using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace events
{
    public class CalculateEventArgs : EventArgs
    {
        public int x
        {
            get;
        }
        public int y
        {
            get;
        }
        public CalculateEventArgs(int number, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.number = number;
        }
        public int number
        {
            get;
        }
    }
    class Calculator
    {
        public static bool first_time = true;
        public static List<long> numbers = new List<long>();
        public delegate void CalculateEventHandler(object sender, CalculateEventArgs e);
        public event CalculateEventHandler CalculateEventIsFinished;
        public bool is_active = true;
        public int relax_time;
        public Thread t;
        public Calculator(int relax_time)
        {
            this.relax_time = relax_time;
            if (first_time)
            {
                long i = 5;
                int n = 10, l = 1;
                while (l < 7)
                {
                    if (i >= n / 10)
                        numbers.Add(i);
                    if (n + 1 - i >= n / 10)
                        numbers.Add(n + 1 - i);
                    n *= 10;
                    l++;
                    string suck = Convert.ToString(i * i);
                    i = Convert.ToInt32(suck.Substring(suck.Length - l));
                }
                first_time = false;
            }
        }
        public void calculations()
        {
            while (is_active)
            {
                Random rand = new Random();
                int x = rand.Next(2, 1000000);
                int y = rand.Next(2, 1000000);
                if (x < y)
                    CalculateEventIsFinished(this, new CalculateEventArgs(Find_autonumber(x,y), x, y));
                else
                    CalculateEventIsFinished(this, new CalculateEventArgs(Find_autonumber(y, x), y, x));
                Thread.Sleep(relax_time);
            }
        }
        public void Stop_calculations(object sender, EventArgs e)
        {
            is_active = false;
            t.Abort();
            t.Join();
        }
        public void Start_calculations(object sender, EventArgs e)
        {
            is_active = true;
            t = new Thread(calculations);
            t.Start();
        }
        public int Find_autonumber(int x, int y)
        {
            int am = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= x && numbers[i] <= y)
                    am++;
            }
            return am;
        }
    }
}
