using Startup.KernelObjects;
using System;
using System.Collections.Generic;

namespace Startup
{
    class Program
    {
        static List<IRunner> runners = new List<IRunner>();
        
        static void Main(string[] args)
        {
            InitRunners();

            runners.ForEach(r => r.Run());

            Console.ReadLine();
        }

        static void InitRunners()
		{
            runners.Add(new AutoResetEventSync());
            runners.Add(new MutexSync());
        }
    }
}
