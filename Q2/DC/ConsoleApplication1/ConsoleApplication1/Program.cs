using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        int[] mon = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public void days(int y1, int y2, int m1, int m2, int d1, int d2)
        {
            int count = 0, i;
            for (i = y1; i < y2; i++)
            {
                if (i % 4 == 0)
                    count += 366;
                else
                    count += 365;
            }
            count -= month(m1, y1);
            count -= d1;
            count += month(m2, y2);
            count += d2;
            if (count < 0)
                count = count * -1;
            Console.WriteLine("The no. of days b/w " + d1 + "/" + m1 + "/" + y1 + " and " + d2 + "/" + m2 + "/" + y2 + " is " + count + " days");
            Console.ReadKey();
        }
        public int month(int a, int yy)
        {
            int x = 0, c;
            for (c = 0; c < a - 1; c++)
            {
                if (c == 1)
                {
                    if (yy % 4 == 0)
                        x += 29;
                    else
                        x += 28;
                }
                else
                    x += mon[c];
            }
            return (x);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            int d1, m1, y1, d2, m2, y2;
            Console.WriteLine("Enter first date(dd/mm/yyyy) : ");
            d1 = Convert.ToInt32(Console.ReadLine());
            m1 = Convert.ToInt32(Console.ReadLine());
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second date(dd/mm/yyyy) : ");
            d2 = Convert.ToInt32(Console.ReadLine());
            m2 = Convert.ToInt32(Console.ReadLine());
            y2 = Convert.ToInt32(Console.ReadLine());
            if (y2 >= y1)
            {
                p.days(y1, y2, m1, m2, d1, d2);
            }

            else
            {
                p.days(y2, y1, m2, m1, d2, d1);
            }

        }
    }
}
