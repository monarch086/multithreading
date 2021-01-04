using System;
using System.Threading;

namespace Startup.KernelObjects
{
	class AutoResetEventSync : IRunner
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        static int x = 0;

        public void Run()
        {
            Console.WriteLine($"Starting AutoResetEvent...");

            for (int i = 0; i < 5; i++)
            {
                var myThread = new Thread(Count);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }

        public static void Count()
        {
            waitHandler.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            waitHandler.Set();
        }
    }
}
