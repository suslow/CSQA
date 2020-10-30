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
        static int MainGUI()
        {
            var c = new Window();
            var consoles = c.SplitRows(
                    new Split(3, "Опрос", LineThickNess.Single),
                    new Split(0),
                    new Split(3, "status", LineThickNess.Single)
            );

            var n = MessageBox.Query(50, 7, "Опрос", "Начать опорос?", "Да", "Нет");
            
            return n;
        }
    }
}