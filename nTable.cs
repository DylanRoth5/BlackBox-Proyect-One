namespace BlackBox_Proyect_One
{
    internal class nTable
    {
        public static void Start(){

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
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

        }
    }
}