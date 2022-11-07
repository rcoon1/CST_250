using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    public class Cell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }
        public int LiveNeighbors { get; set; }

        public Cell()
        {
            Column = -1;
            Row = -1;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }
        public Cell(int col, int row, bool visited, bool live, int liveNeighbors)
        {
            Column = col;
            Row = row;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }
    }
}
