using Konsole;
using Konsole.Drawing;
using Konsole.Forms;
using Konsole.Internal;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.ConsoleColor;

namespace CSQA
{
    public class GUI
    {
        public void Konsole()
        {
            var interview = new Interview();
            var questions = new Interview();

            var c = new Window();
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
            content.WriteLine($"Вопрос: {}");

            sidebar.WriteLine("Ответ ...");

            status.Write("что тут");
            Console.ReadLine();
        }
    }
}