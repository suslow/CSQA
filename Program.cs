using System;

namespace CSQA
{
    class Program
    {
        static void Main(string[] args)
        {
            var gui = new GUI();
            var interview = new Interview();
            interview.InitTest();

            do
            {
                gui.Konsole();
                // interview.Start();
                // interview.Result();
                // Console.WriteLine("Чтобы завершить опрос нажмите - {Q}");
                // Console.WriteLine("Для продолжения опроса нажмите любую клавишу");
            }
            while (ConsoleKey.Q != Console.ReadKey(true).Key);

        }
    }
}
