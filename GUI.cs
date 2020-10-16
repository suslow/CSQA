using Terminal.Gui;

namespace CSQA
{
    class Demo
    {
        static int Main()
        {
            Application.Init();

            var n = MessageBox.Query(50, 7,
                "Опрос", "Начать порос?", "Да", "Нет");

            return n;
        }
    }
}
