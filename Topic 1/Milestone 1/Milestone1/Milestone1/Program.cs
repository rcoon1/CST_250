using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    class MainClass
    {
        public static Board board;

        public static void Main(string[] args)
        {
            int response = 1;

             while (response != 0)
            {
                Console.Out.WriteLine("Please enter grid size for the game: ");
                int size = getUserInput();
                //checks for a invalid input
                if (size == -1) continue; 
                board = new Board(size);

                Console.Clear();
                printBoard();
            }
        }
        public static void printBoard()
        {
            Console.Out.WriteLine(string.Format(" BOARD {0}x{0} ", board.Size));
            int rows = board.Grid.GetLength(0);
            int cols = board.Grid.GetLength(1);
            //print the top line of headers
            for (int idx = 0; idx < cols; idx++)
            {
                if (idx == 0) Console.Out.Write("|");
                Console.Out.Write(string.Format(" {0} |", idx));
            }
            //new line for to actual grid
            printLineSeparator(cols);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    //print row and column elements
                    Console.Out.Write("| ");
                    if (board.Grid[row, col].Live==true)
                    {
                        Console.Out.Write("*");
                    }
                    else
                    {
                        Console.Out.Write(board.Grid[row, col].LiveNeighbors);
                    }
                    Console.Out.Write(" ");
                    //print the column number if at the end of a row
                    if (col == cols - 1) Console.Out.Write(string.Format("| {0} ", row));
                }
                //go to the next line
                printLineSeparator(cols);
            }
        }
        public static int getUserInput()
        {
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Out.WriteLine(string.Format("Input: ${0}", choice));
            }
            else
            {
                Console.Out.WriteLine("The input was invalid.");
                return -1;
            }
            return choice;
        }
        private static void printLineSeparator(int nbr)
        {
            Console.Out.Write("\n+");
            for (int idx = 0; idx < nbr; idx++)
            {
                Console.Out.Write("---+");
            }
            Console.Out.Write("\n");
        }
    }
}
