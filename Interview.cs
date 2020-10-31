using System;
using System.Collections.Generic;
using System.Linq;

namespace CSQA
{
    public class Interview
    {
        public Interview() { }

        public Interview(Person personInfo)
        {
            this.PersonInfo = personInfo;
        }
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
                PersonInfo.Answers.Add(itemQuestion.AnswerOptions[indexAnswer - 1]);
            }
            Console.WriteLine("Конец опроса");
        }

        void GetPersonInfo()
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