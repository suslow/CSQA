using Terminal.Gui;

namespace CSQA
{
    class GUI
    {
        static int MainGUI()
        {
            Application.Init();

            var n = MessageBox.Query(50, 7, "Опрос", "Начать опорос?", "Да", "Нет");
            
            return n;
        }
    }
}
