using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public int Difficulty { get; set; }

        public Board()
        {
            Size = 1;
            Difficulty = 20; 
            Grid = new Cell[Size, Size];
        }
        public Board(int size)
        {
            Size = size;
            Difficulty = 20; 
            Grid = new Cell[Size, Size];
            liveNeighbors();
        }

        public void liveNeighbors()
        {
            int space = (int)Math.Pow(Size, 2);
            int allowedBombs = (int)Math.Ceiling((decimal)space * ((decimal)Difficulty / 100));

            //create a 2D array that calculates live/dead cells
            Random rand = new Random();
            bool[] liveCells = new bool[space];

            //setup/populate set
            Double[] sortOrder = new Double[space];
            for (int index = 0; index < sortOrder.Length; index++)
                sortOrder[index] = rand.NextDouble();
            for (int index = 0; index < space; index++)
            {
                liveCells[index] = index < allowedBombs;
            }

            //randomize liveCell placement
            Array.Sort(sortOrder, liveCells);

            //go through 2D array and initialize all cells
            int liveCellIdx = 0;
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    Grid[row, col] = new Cell(col, row, false, liveCells[liveCellIdx], 0);
                    liveCellIdx++;
                }
            }

            //make a second pass through the grid
            CalculateLiveNeighbors();
        }

        public void CalculateLiveNeighbors()
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    CalculateLiveCellNeighbors(Grid[row, col]);
                }
            }
        }

        private void CalculateLiveCellNeighbors(Cell c)
        {
            if (c.Live)
            {
                c.LiveNeighbors = 9;
                return;
            }

            //test for any out of bounds errors
            Cell def = new Cell(0, 0, false, false, 0);
            Cell left = (c.Column - 1 >= 0) ? Grid[c.Row, c.Column - 1] : def;
            Cell right = (c.Column + 1 < Size) ? Grid[c.Row, c.Column + 1] : def;
            Cell top = (c.Row - 1 >= 0) ? Grid[c.Row - 1, c.Column] : def;
            Cell bottom = (c.Row + 1 < Size) ? Grid[c.Row + 1, c.Column] : def;
            Cell topRight = (c.Row - 1 >= 0 && c.Column + 1 < Size) ? Grid[c.Row - 1, c.Column + 1] : def;
            Cell topLeft = (c.Row - 1 >= 0 && c.Column - 1 >= 0) ? Grid[c.Row - 1, c.Column - 1] : def;
            Cell bottomRight = (c.Row + 1 < Size && c.Column + 1 < Size) ? Grid[c.Row + 1, c.Column + 1] : def;
            Cell bottomLeft = (c.Row + 1 < Size && c.Column - 1 >= 0) ? Grid[c.Row + 1, c.Column - 1] : def;

            int liveNeighbors = 0;
            foreach (Cell neighbor in new Cell[] { left, right, top, bottom, topRight, topLeft, bottomRight, bottomLeft })
            {
                liveNeighbors += neighbor.Live ? 1 : 0;
            }
            c.LiveNeighbors = liveNeighbors;
        }
    }
}
