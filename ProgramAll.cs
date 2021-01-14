using Konsole;
using Konsole.Drawing;
using Konsole.Forms;
using Konsole.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.ConsoleColor;


namespace CSQA
{
    class Program
    {
        // Person PersonInfo = new Person();
        public List<ItemQuestion> Questions { get; set; }

        public void InitTest()
        {
            var question1 = new ItemQuestion
            {
                Question = "Вопрос 1",
                AnswerOptions = new List<string>
                {
                "Ответ А",
                "Ответ Б",
                "Ответ В"
                }
            };

            var question2 = new ItemQuestion
            {
                Question = "Вопрос 2",
                AnswerOptions = new List<string>
                {
                "Ответ А",
                "Ответ Б",
                "Ответ В"
                }
            };

            Questions = new List<ItemQuestion>
            {
                question1,
                question2
            };
            Console.WriteLine($"Првоерка квестионс: {Questions}");
        }
        public void Test()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Person PersonInfo { get; set; }
        public void GetPersonInfo()
        {
            bool result;
            while (true)
            {
                Console.WriteLine("Введите имя: ");
                var name = Console.ReadLine();
                PersonInfo.Name = name;

                result = Char.IsUpper(name, 0);
                if (result == false)
                {
                    Console.WriteLine("Вводите с заглавной буквы");
                }
                else
                {
                    break;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            string itemQ = null;
            Program PerInf = new Program();
            Console.WriteLine("Начало опроса");
            foreach (var itemQuestion in PerInf.Questions)
            {
                Console.WriteLine($"Вопрос: {itemQuestion.Question}");

                itemQ = itemQuestion.Question;

                int t = 1;

                foreach (var itemAnswers in itemQuestion.AnswerOptions)
                {
                    Console.WriteLine($"{t}-{itemAnswers}");
                    t++;
                }

                char[] alpha_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] alpha_a = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                char[] num = "0!()+_-={}[]<>/?.,|@#$%^&*".ToCharArray();

                char res;
                int indexAnswer;
                while (true)
                {
                    var chk = Char.TryParse(Console.ReadLine(), out res);
                    indexAnswer = (int)Char.GetNumericValue(res);
                    if (chk == false)
                    {
                        Console.WriteLine("Не правильный ввод. Допускается ввод только одного символа.");
                    }
                    else if (alpha_A.Contains(res))
                    {
                        Console.WriteLine("Ввод заглавных букв ограничен");
                    }
                    else if (alpha_a.Contains(res))
                    {
                        Console.WriteLine("Ввод строчных букв ограничен");
                    }
                    else if (indexAnswer > itemQuestion.AnswerOptions.Count)
                    {
                        Console.WriteLine($"Ввод ограничен диапазоном 1-{itemQuestion.AnswerOptions.Count}");
                    }
                    else if (num.Contains(res))
                    {
                        Console.WriteLine($"Ввод ограничен диапазоном 1-{itemQuestion.AnswerOptions.Count}");
                    }
                    else
                    {
                        break;
                    }
                }
                PerInf.PersonInfo.Answers.Add(itemQuestion.AnswerOptions[indexAnswer - 1]);
            }
            Console.WriteLine("Конец опроса");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            var c = new Window();
            c.ForegroundColor = ConsoleColor.DarkCyan;
            var consoles = c.SplitRows(
                    new Split(3, "Опрос", LineThickNess.Single),
                    new Split(0),
                    new Split(3, "status", LineThickNess.Single)
            );

            var headline = consoles[0];
            var status = consoles[2];

            var contents = consoles[1].SplitColumns(
                    new Split(0, "Вопросы", LineThickNess.Double), //{ Foreground = ConsoleColor.White, Background = ConsoleColor.Cyan },
                    new Split(20, "Варанты ответов")
            );
            var content = contents[0];
            var sidebar = contents[1];

            headline.Write("Пройдите опрос выбираяя подходящий ответ");
            content.WriteLine($"Вопрос: {itemQ}");

            sidebar.WriteLine("Ответ ...");

            status.Write("...");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int i = 1;
            Console.WriteLine("Результат тестирования:");
            Console.WriteLine($"Тест проходил - {PerInf.PersonInfo.Name}");
            foreach (var item in PerInf.PersonInfo.Answers)
            {
                Console.WriteLine($"Вопрос {i} - Ответ {item}");
                i++;
            }

        }
        // while (ConsoleKey.Q != Console.ReadKey(true).Key);
    }
}
