﻿namespace BlackBox_Proyect_One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
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
                    default: Tls.OutLine("Mmm..."); Tls.enterClear(); break;
                }
            }
        }
    }
}