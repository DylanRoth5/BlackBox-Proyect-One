namespace BlackBox_Proyect_One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            // Statements
            string title = "Proyect One";
            string[] options = { "Ahorcado", "Tablas" };
            bool running = true;
            // Menu Program
            while (running){
                int result = Cs.menu(title, options);
                Cs.clear();
                switch (result){
                    case 1: 
                        Hangman.Start();
                        break;
                    case 2: 
                        nTable.Start();
                        break;
                    case 0: 
                        running = false; 
                        break;
                    default: 
                        Cs.printLine("Algun error sucedio."); Cs.enterClear(); 
                        break;
                }
                Cs.enterClear(); // this is so the menu doesn't start right away
            }
        }
    }
}