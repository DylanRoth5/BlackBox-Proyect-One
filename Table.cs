using System.Diagnostics.Contracts;

namespace BlackBox_Proyect_One
{
    internal class Table
    {
        // Multi-Dimensional array that stores the values of the table's cells
        string[,] matrix;
        // constructor declaration
        public Table(string[,] matrix)
        {
            this.matrix = matrix;
        }

        public void DrawTable()
        {
            char topLeft;
            char topRight;
            char bottomLeft = '╚';
            char bottomRight = '╝';
            //
            int x = Console.CursorLeft; int y = Console.CursorTop;
            int aux = x;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Stores the value of x at the beginnig of each column
                x = aux;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int width = CalculateColumnWidth(j) + 2;
                    // conditions
                    // if it's the fist row...
                    if (i == 0)
                    {
                        // first cell, that is J == 0, uses '╔' as topLeft the rest of them, the ones
                        // that builds the roof, need to be '╦'
                        topLeft = (j == 0) ? '╔' : '╦';
                        // the top right corner in the first row     
                        topRight = '╗';
                        // in case that it to be the left wall column, that is j = 0, the bottomLeft
                        // char will be a corner, else, it will be and an up and horizontal intersection.
                        // this needs to be written here for the case that the table has only one row
                        bottomLeft = (j == 0) ? '╚' : '╩';
                    }
                    // if it's the last row...
                    else if (i == matrix.GetLength(0) - 1)
                    {
                        // prints a ╠ if in the first column and a ╬ for the rest of them
                        topLeft = (j == 0) ? '╠' : '╬';
                        // always prints ╣ at the top right corner of each cell, if it's not the last
                        // one, it'll just be over-written by the top left corner ()from the one, 
                        // it'll just be over-written by the top left corner from the next cell 
                        topRight = '╣';
                        // in the first column's left end a corner gonna be printed, but in the other
                        // cases (if table has at least two columns) an up and horizontal intersection
                        bottomLeft = (j == 0) ? '╚' : '╩';
                        // assigning the ╝ simbol to the bottom right value here ensures that if the 
                        // has only one column, a coner will properly be written, if it's not the last
                        // column, the symbol'll just be over-written by the bottomLeft char from the
                        // following cell
                        bottomRight = '╝';
                    }
                    // if they are internal rows... 
                    else
                    {
                        // In case of being the first column, the a '╠' should be printed given that 
                        // this are internal rows but in an external column, if they are internal 
                        // columns as well, a '╬' will printed
                        topLeft = (j == 0) ? '╠' : '╬';
                        // Same as in the previous code's block...
                        topRight = '╣';
                    }
                    // Creates an string contatenating the chars to be used as corners so they
                    // can be passed to the Draw.rect()'s corners value
                    string corners = string.Concat(topLeft, topRight, bottomLeft, bottomRight);
                    // Prints the cell corresponding to the matrix[i, j] word
                    Draw.rect(x, y, width, 2, '═', '║', corners);
                    // If the first row is the title's row, so if i = 0 the word is going to be written
                    // in red to make it clear that it's a title, else it'll be just printed in white
                    Console.ForegroundColor = (i == 0) ? ConsoleColor.Red : ConsoleColor.White;
                    Py.printAt( x + 1, y + 1,$" {matrix[i, j]}");
                    // Resets the ForegroungColour to white
                    Console.ForegroundColor = ConsoleColor.White;
                    // increments the x coordinate with the widht value so the next column starts where
                    // this one ends 
                    x += width;
                }
                // increments the y coordinate one space for the floor of the cell and one for the 
                // beginning of the next row's words
                y += 2;
            }
            // Leaves one line after the table
            Console.WriteLine("\n\n");
        }

        private int CalculateColumnWidth(int col)
        {
            // Given the index "col" of a column from the matrix, returns the min widht that the column
            // must have in order that the longest word can be written inside it with one space before
            // and one after it.  
            int width = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                width = (matrix[i, col].Length > width) ? matrix[i, col].Length + 2 : width;
            }
            return width;
        }

        private int CalculateHeight()
        {
            // returns the amount of rows multiplied by 2 because each row needs one space for the words
            // and another for the roof behind each cell, the + 1 is because of the roof of the first row 
            return matrix.GetLength(0) * 2 + 1;
        }

    }
}