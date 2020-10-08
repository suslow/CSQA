using System;
using System.Collections.Generic;
using System.Linq;

namespace CSQA
{
    public class Interview
    {
        public Interview() { }

        public Person PersonInfo { get; set; }

        internal void Result()
        {
            int i = 1;
            Console.WriteLine("Результат тестирования:");
            Console.WriteLine($"Тест проходил - {PersonInfo.Name}");
            foreach (var item in PersonInfo.Answers)
            {
                Console.WriteLine($"Вопрос {i} - Ответ {item}");
                i++;
            }
        }

        public List<ItemQuestion> Questions { get; set; }

        public void Start()
        {
            PersonInfo = new Person();

            GetPersonInfo();
            Console.WriteLine("Начало опроса");
            foreach (var itemQuestion in Questions)
            {
                Console.WriteLine($"Вопрос: {itemQuestion.Question}");

                int i = 1;

                foreach (var itemAnswers in itemQuestion.AnswerOptions)
                {
                    Console.WriteLine($"{i}-{itemAnswers}");
                    i++;
                }

                // int indexAnswer;

                // while (true)
                // {
                //     var res = Int32.TryParse(Console.ReadLine(), out indexAnswer);
                //     if (res && indexAnswer > 0 && indexAnswer <= itemQuestion.AnswerOptions.Count)
                //     {
                //         break;
                //     }
                //     Console.WriteLine("Не правильный ввод");
                //     // KeyPress();
                // }
                // PersonInfo.Answers.Add(itemQuestion.AnswerOptions[indexAnswer - 1]);


                char[] alpha_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] alpha_a = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                char[] num = "4567890!()+_-={}[]<>/?.,|".ToCharArray();

                var res = Convert.ToChar(Console.ReadLine());
                while (true)
                {
                    if (alpha_A.Contains(res))
                    {
                        Console.WriteLine("Ввод заглавных букв ограничен");
                    }
                    if (alpha_a.Contains(res))
                    {
                        Console.WriteLine("Ввод строчных букв ограничен");
                    }
                    if (num.Contains(res))
                    {
                        Console.WriteLine("Ввод ограничен диапазоном 1-3");
                    }
                    PersonInfo.Answers.Add(itemQuestion.AnswerOptions[res-1]);
                }
            }
            Console.WriteLine("Конец опроса");
        }

        // char alpha;
        // int num;
        // public void NA()
        // {
        //     for (int i = 0; i < 26; i++)
        //     {
        //         alpha = Convert.ToChar(i + 65);
        //     }
        //         Console.WriteLine(alpha);

        //     for (int l = 4; l <= 9; l++)
        //     {
        //         num[] = l;
        //     }
        //         Console.WriteLine(num);

        // }


        // char[] alpha_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //     char[] alpha_a = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //     char[] num = "4567890!()+_-={}[]<>/?.,|".ToCharArray();
        //     // Console.WriteLine(alpha);
        //     // foreach (char ch in alpha)
        //     // {
        //     //     Console.WriteLine(ch);
        //     // }
        //     Console.WriteLine("Ввод:");
        //     var res = Convert.ToChar(Console.ReadLine());
        //     if (alpha_A.Contains(res))
        //     {
        //         Console.WriteLine("Ввод заглавных букв ограничен");
        //     }
        //     if (alpha_a.Contains(res))
        //     {
        //         Console.WriteLine("Ввод строчных букв ограничен");
        //     }
        //     if (num.Contains(res))
        //     {
        //         Console.WriteLine("Ввод ограничен диапазоном 1-3");
        //     }



        // public void KeyPress()
        // {


            // int index;
            // var number = Int32.TryParse(Console.ReadLine(), out index);
            // var e = new KeyPressEventArgs();
            // index = e.KeyChar;

            // if (e.KeyChar >= 52 || e.KeyChar <= 57)
            // {
            //     e.Handled = true;
            //     Console.WriteLine("Неправильный ввод. Введите значение в диапазоне 1-3.");
            // }

            // if (e.KeyChar >= 65 || e.KeyChar <= 122)
            // {
            //     e.Handled = true;
            //     Console.WriteLine("Неправильный ввод. Буквы для ввода не допступны.");
            // }

            // if (e.KeyChar >= 33 || e.KeyChar <= 47 && e.KeyChar >= 58 || e.KeyChar <= 64)
            // {
            //     e.Handled = true;
            //     Console.WriteLine("Неправильный ввод. Символы для ввода не доступны.");
            // }
        // }

        void GetPersonInfo()
        {
            Console.WriteLine("Введите имя: ");
            var name = Console.ReadLine();
            PersonInfo.Name = name;

            bool result;
            result = Char.IsUpper(name, 0);


            while (result == false)
            {
                Console.WriteLine("Вводите с заглавной буквы");
                break;
                // if (result == false)
                // {
                //     break;
                // }
            }


        }

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
        }
    }
}