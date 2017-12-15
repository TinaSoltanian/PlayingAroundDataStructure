using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Maze

    {
        private int[,] MazePath;
        public int[,] Solution;
        private int Cols;
        private int Rows;

        public Maze(int[,] map)
        {
            this.MazePath = map; ;
            this.Cols = map.GetLength(0);
            this.Rows = map.GetLength(1);
            Solution = new int[Cols, Rows];
        }

        public bool Solve()
        {
            if (!Solve(MazePath, 0, 0, Solution))
                return false;

            return true;
        }

        private bool IsSafeToTravel(int x, int y)
        {
            return (x >= 0 && x < Cols && y >= 0 && y < Rows && MazePath[x, y] == 1);
        }
        private bool Solve(int[,] map, int x, int y, int[,] solution)
        {
            //we solve the maze
            if (x == Cols - 1 || y == Rows - 1)
            {
                solution[x, y] = 1;
                return true;
            }
            else if (x == Cols - 1 || y == Rows - 1)
            {
                solution[x, y] = 0;
                return false;
            }

            if (IsSafeToTravel(x, y))
            {
                solution[x, y] = 1;

                if (Solve(map, x + 1, y, solution))
                    return true;

                if (Solve(map, x, y + 1, solution))
                    return true;

                solution[x, y] = 0;
                return false;
            }

            return false;
        }
    }
}
