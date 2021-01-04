using System;
using System.Threading;

namespace Startup.KernelObjects
{
	class MutexSync : IRunner
    {
        static Mutex mutexObj = new Mutex();
        static int x = 0;

        public void Run()
        {
            Console.WriteLine($"Starting Mutex...");

            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }
        public static void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
