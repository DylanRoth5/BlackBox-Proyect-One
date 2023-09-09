namespace BlackBox_Proyect_One
{
    internal class Program
    {
        //This is the main menu
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string title = "Proyect One";
            string[] options = { "Ahorcado", "Tablas" };
            bool running = true;
            Console.Clear();
            while (running)
            {
                //The menu function is called by passing it the title and an array of options
                int result = Py.menu(title, options);
                Console.Clear();
                switch (result)
                {
                    case 1: 
                        //Hangman game
                        Hung.Start();
                        Py.enterClear(); 
                        break;
                    case 2: 
                        //Table of Contents
                        nTable.Start();
                        Py.enterClear(); 
                        break;
                    case 0:
                        //Option to exit the menu
                        running = false; 
                        break;
                    default: 
                        //In case an error occurs, the default is executed
                        Py.printLine("Algun error sucedio."); Py.enterClear(); 
                        break;
                }
            }
        }
    }
}