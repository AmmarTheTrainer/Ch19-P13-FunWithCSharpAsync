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
        //public static async Task Main(string[] args)
        public static void Main(string[] args)
        {
            #region Internet Surfing

            int number = PrintNumbersAsync().Result;
            Console.WriteLine("\n Running PrintNumbers() ");
            PrintNumbers();


            #endregion

            #region Regular Content


            //Console.WriteLine(" ManagedThreadId ( Main ) = " + Thread.CurrentThread.ManagedThreadId);

            //////This is to prompt Visual Studio to upgrade project to C# 7.1
            //// List<int> l = default;

            ////string s = DoWork();
            //string s = await DoWorkAsync();
            ////DoWorkAsync();
            //Console.WriteLine(s);
            //Console.WriteLine(" [ after func call ] Working on another Thread... ");

            #endregion
            Console.ReadLine();
        }
        static async Task<string> MethodWithTryCatch()
        {
            try
            {
                //Do some work
                return "Hello";
            }
            catch (Exception ex)
            {
                await LogTheErrors();
                throw;
            }
            finally
            {
                await DoMagicCleanUp();
            }
        }
        static async ValueTask<int> ReturnAnInt()
        {
            await Task.Delay(1_000);
            return 5;
        }
        private static Task DoMagicCleanUp()
        {
            throw new NotImplementedException();
        }

        private static Task LogTheErrors()
        {
            throw new NotImplementedException();
        }

        private static void PrintNumbers()
        {
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                Console.Write(" "+i);
            }
        }
        private static async Task<int> PrintNumbersAsync()
        {
            Console.WriteLine();
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(" " + i);
                }
            });

            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(" " + i);
                }
            });

            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(" " + i);
                }
            //    return 0;
            });
            return 1;
        }
        //private static async Task PrintNumbersAsync()
        //{
        //    Console.WriteLine();
        //    await Task.Run(() =>
        //    {
        //        for (int i = 0; i < 20; i++)
        //        {
        //            Thread.Sleep(100);
        //            Console.Write(" " + i);
        //        }
        //    });

        //    //return 0;
        //}
        private static async Task<string> PrintNumbers2(int start , int end)
        {
            Console.WriteLine();
            for (int i = start; i < end; i++)
            {
                Console.Write(" " + i);
            }
            return "Done tun";
        }

        private static void Method1()
        {

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
