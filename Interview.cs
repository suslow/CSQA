using System;
using System.Collections.Generic;

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

        public void Start(object sender, KeyPressEventArgs e)
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

                int indexAnswer;

                while (true)
                {
                    var res = Int32.TryParse(Console.ReadLine(), out indexAnswer);
                    if (res && indexAnswer > 0 && indexAnswer <= itemQuestion.AnswerOptions.Count)
                    {
                        break;
                    }
                    Console.WriteLine("Не правильный ввод");
                    KeyPress();
                }
                PersonInfo.Answers.Add(itemQuestion.AnswerOptions[indexAnswer - 1]);


            }
            Console.WriteLine("Конец опроса");
        }

        public void KeyPress(object sender, KeyPressEventArgs e)
        {
            Key = new KeyPressEventArgs();

            if (e.KeyChar <= 48 || e.KeyChar >= 52)
            e.Handled = true;
        }

        void GetPersonInfo()
        {
            Console.WriteLine("Введите имя: ");
            var name = Console.ReadLine();
            PersonInfo.Name = name;
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