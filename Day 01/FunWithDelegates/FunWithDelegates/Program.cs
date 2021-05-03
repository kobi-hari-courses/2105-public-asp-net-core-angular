using System;

namespace FunWithDelegates
{
    delegate void FunctionWithoutParams();
    delegate void FunctionWithSingleIntParam(int a);

    delegate int SingleNumberParamWithIntResult(int a);

    class Program
    {
        private static int _functionThatMultipliesByTwo(int a)
        {
            return a * 2;
        }

        public static void BasicFunWithDelegates()
        {
            var something = new Something();

            FunctionWithSingleIntParam f1 = something.Increase;
            f1 = something.Decrease;

            f1(12);

            int b = 20;

            // .net 2
            SingleNumberParamWithIntResult funckyFunc = delegate (int a)
            {
                return a * b;
            };

            // .net 3 with lambda expressions
            SingleNumberParamWithIntResult funckyFunc2 = a => a * b;


            // .net 3.5 + 
            Func<int, int> f3 = a => a * 2;

            Func<string, int, int, bool> f4 = (str, num1, num2) => str.Length > num1 + num2;
            Action a = () => Console.WriteLine("Hello World");
            Action<int> a2 = (int i) => Console.WriteLine(i);
            Action<string, bool, int, Something> a3 = (str, b, i, s) => { };


            MetodatEzer();

            f1.Invoke(12);
            Console.WriteLine(funckyFunc(15));
        }

        private static void DoSomethingWithNumber(Action<int> callback)
        {
            callback(42);
        }

        public static void FunWithMulticastDelegate()
        {
            Action<int> callback = i =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"The number is {i}");
            };

            callback += i =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"I received the number {i} now");
            };

            DoSomethingWithNumber(callback);
        }

        public static void DemoOfObserverPattern()
        {
            var p = new Printer();

            var admin = new Admin(p);
            var logger = new Logger(p);

            p.Print(new string[] { "Hello", "World" });

            admin.Disconnect();

            p.Print(new string[] { "Hi" });
        }

        static void Main(string[] args)
        {
            DemoOfObserverPattern();
        }

        public static void MetodatEzer()
        {
            SingleNumberParamWithIntResult funckyFunc = delegate (int a)
            {
                return a * 2;
            };

        }
    }
}
