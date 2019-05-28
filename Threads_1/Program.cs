using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // получаем текущий поток
            Thread t = Thread.CurrentThread;

            //получаем имя потока
            Console.WriteLine("Имя потока: {0}", t.Name);
            Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
            Console.WriteLine("Приоритет потока: {0}", t.Priority);
            Console.WriteLine("Состояние потока: {0}", t.ThreadState);            
            Console.WriteLine("Домен приложения: {0}", Thread.GetDomain().FriendlyName); // получаем домен приложения

            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine("Основной поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        public static void Count()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("Дочерний поток:");
                Console.WriteLine(i * i);
                for (int j = 0; j < 100000000; j++)  // нагружаем процессор бесполезными вычислениями))
                {
                    double x = 123;
                    double y = x * Math.Pow(x, x++);
                }
                Thread.Sleep(300);
            }
        }
    }
}
