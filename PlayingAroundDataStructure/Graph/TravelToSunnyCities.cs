using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class TravelToSunnyCities
    {
        private int[,] Map;
        private int[,] Solution;
        private int Cols;
        private int Rows;

        public List<int> Result { get; set; }

        public TravelToSunnyCities(int[,] map)
        {
            this.Map = map;;
            this.Cols = map.GetLength(0);
            this.Rows = map.GetLength(1);
            Solution = new int[Cols,Rows];
            Result = new List<int>();
        }

        public bool DoTravel()
        {
            bool r = true;
            if (!DoTravel(Map, 0, 0, Solution))
                r = false;

            Result.Clear();
            for (int i = 0; i < Cols; i++)
            {
                int days = 0;
                for (int j = 0; j < Rows; j++)
                {
                    days += Solution[i,j];
                }

                Result.Add(days);
            }

            return r;
        }

        private bool IsSafeToTravel(int x, int y)
        {
            return (x >= 0 && x < Cols && y >= 0 && y < Rows && Map[x, y] == 1);
        }
        private bool DoTravel(int[,] map, int x, int y, int[,] solution)
        {
            //we solve the maze
            if (x == Cols -1 && y == Rows - 1)
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

                if (DoTravel(map, x + 1, y + 1, solution))
                    return true;

                if (DoTravel(map, x, y + 1, solution))
                    return true;

                solution[x, y] = 0;
                return false;
            }

            return false;
        }
    }
}
