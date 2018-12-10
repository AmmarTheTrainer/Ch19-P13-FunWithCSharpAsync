using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch19_P13_FunWithCSharpAsync
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine(" ManagedThreadId ( Main ) = " + Thread.CurrentThread.ManagedThreadId);

            ////This is to prompt Visual Studio to upgrade project to C# 7.1
            // List<int> l = default;

            //string s = DoWork();
            string s = await DoWorkAsync();
            //DoWorkAsync();
            Console.WriteLine(s);
            Console.WriteLine(" [ after func call ] Working on another Thread... ");
            Console.ReadLine();

        }

        private static string DoWork()
        {
            Console.WriteLine(" Working ( DoWork() ) ... ");
            Console.WriteLine(" ManagedThreadId = " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return "Done with work!";
        }
        private static async Task<string> DoWorkAsync()
        {
            Console.WriteLine(" Working ( DoWork() ) ... ");
            Console.WriteLine(" ManagedThreadId = " + Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(3_000);
                Console.WriteLine(" Done with work ( Inside FUnction message ) ");
                return "Done with work";
            });
        }
    }
}
