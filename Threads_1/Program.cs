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
            t.Name = "Метод Main";
            Console.WriteLine("Имя потока: {0}", t.Name);
            Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
            Console.WriteLine("Приоритет потока: {0}", t.Priority);
            Console.WriteLine("Статус потока: {0}", t.ThreadState);
            // получаем домен приложения
            Console.WriteLine("Домен приложения: {0}", Thread.GetDomain().FriendlyName);

            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        public static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);                
                Thread.Sleep(300);
                Thread.CurrentThread.Abort();
            }
        }
    }
}
