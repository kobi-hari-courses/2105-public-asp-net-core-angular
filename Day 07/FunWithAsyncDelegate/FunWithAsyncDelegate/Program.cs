using System;
using System.Threading.Tasks;

namespace FunWithAsyncDelegate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AMethodThatAcceptsAction(async () =>
            {
                await Task.Delay(2000);
                Console.WriteLine("ABC");
            });
        }

        public static async Task AMethodThatAcceptsAction(Func<Task> asyncAction)
        {
            Console.WriteLine("1");
            await asyncAction();
            Console.WriteLine("2");
        }


        public static async void DoSomethingAsync()
        {
            await Task.Delay(2000);

            Console.WriteLine("Bla bla");

        }

        public static async Task DoSomethingAsync2()
        {
            await Task.Delay(2000);

            Console.WriteLine("Bla bla");
        }
    }
}
