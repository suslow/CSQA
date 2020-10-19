using Terminal.Gui;

namespace CSQA1
{
    class GUI
    {
        static void MainGUI()
        {
            Application.Init();

            var n = MessageBox.Query(50, 7, "Опрос", "Начать опорос?", "Да", "Нет");


            Application.Run();
        }
    }
}
