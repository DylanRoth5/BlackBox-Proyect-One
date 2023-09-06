namespace BlackBox_Proyect_One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menu();
            // Console.SetCursorPosition(5, 5); 
            string[,] m = new string[,] 
            {
                { "Name", "Lastname", "Age"},
                { "Teo", "Furlan", "20"},
                { "Enzo", "Labatte", "20"},
                { "Dylan", "Roth", "20"},
                { "Aylem", "Villalba", "20"}
            };
            string [,] m1 = new string[,] 
            {
                { "Name", "Lastname"},
                { "Teo", "Furlan"},
                { "Enzo", "Labatte"},
                { "Dylan", "Roth"},
                { "Aylem", "Villalba"}
            };
            string[,] m2 = new string[,] 
            {
                { "Name"},
                { "Teo"},
                { "Enzo"},
                { "Dylan"},
                { "Aylem"}
            };
            string[,] m3 = new string[,] {{ "Name", "Lastname", "Age"}};
            Table table = new Table(m);
            table.DrawTable();
            // table = new Table(m1);
            // Console.SetCursorPosition(35, 5);
            // table.DrawTable();
            // table = new Table(m2);
            // Console.SetCursorPosition(5, 17);
            // table.DrawTable();
            // table = new Table(m3);
            // Console.SetCursorPosition(35, 17);
            // table.DrawTable();
            // Console.SetCursorPosition(0, 30);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static void Menu()
        {
            string title = "Proyect One";
            string[] options = { "Ahorcado", "Tablas" };
            bool running = true;
            Tls.clear();
            while (running)
            {
                int result = Tls.WriteMenu(title, options);
                Tls.clear();
                switch (result)
                {
                    case 1: 
                        Tls.enterClear(); 
                        break;
                    case 2: 
                        Tls.enterClear(); 
                        break;
                    case 3:
                        Tls.enterClear(); 
                        break;
                    case 0: 
                        running = false; 
                        break;
                    default: 
                        Tls.OutLine("Algun error sucedio."); Tls.enterClear(); 
                        break;
                }
            }
        }
    }
}