using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingAroundSimpleHashTable
{
    class SimpleHashTable
    {
        string[] theArray;
        int theSize;

        static void Main(string[] args)
        {
            SimpleHashTable table = new SimpleHashTable(30);

            //the values can not be more than 30 because the array size is 30!
            string[] elemntsToAdd = { "5", "10", "2", "15" };
            table.HashFunction1(elemntsToAdd, table.theArray);

            table.ShowTable();

            //the values can not be more than 30 because the array size is 30!
            //here they are exactly 30 elemenst and I' going to call the function to fit all elements and get
            //collusion to see how the other hash function is handling that
            table.ClearTheArray();
            string[] elemntsToAdd2 = { "100", "520", "552", "100", "480", "800", "360", "760", "390", "390",
                                       "100", "560", "280", "470", "333", "666", "160", "380", "137", "890",
                                       "245", "345", "456", "654", "745", "235", "546", "879", "234", "390" };
            table.HashFunction2(elemntsToAdd2, table.theArray);

            table.ShowTable();

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public void ClearTheArray()
        {
            theArray = Enumerable.Repeat("-1", theSize).ToArray();
        }

        //we are filling the array with default values so its much easier to work for now
        SimpleHashTable(int size)
        {
            this.theSize = size;
            theArray = new string[theSize];
            ClearTheArray();
        }

        //thi function is so simple assue that there is no conflict in items
        //just simple hash algorithm
        public void HashFunction1(string[] stringsToInsert, string[] theArray)
        {
            for (int i = 0; i < stringsToInsert.Length; i++)
            {
                int theArrayIndex = int.Parse(stringsToInsert[i]);
                string newValue = stringsToInsert[i];
                theArray[theArrayIndex - 1] = newValue;
            }
        }

        //this hash function is resolving the collusion problem by puting the items in 
        //next avilable index
        public void HashFunction2(string[] stringsToInsert, string[] theArray)
        {
            for (int i = 0; i < stringsToInsert.Length; i++)
            {
                int theArrayIndex = int.Parse(stringsToInsert[i]);
                string newValue = stringsToInsert[i];

                //we wan to sure that item will fit in the array
                int index = theArrayIndex % (theSize - 1);

                Console.WriteLine(" The calculated index = " + index.ToString() + " is for value " + newValue);

                while (theArray[index] != "-1")
                {
                    index++;

                    Console.WriteLine("Collusion try to put in index " + index.ToString());

                    index %= theSize;
                }

                theArray[index] = newValue;
            }
        }

        private void WriteLine(int count)
        {
            Console.WriteLine("");
            for (int i = 0; i < count; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        private string CreateColumnText(string value, int ColumnWidth)
        {
            if (ColumnWidth <= value.Length)
                return " ";

            string result = "";

            string[] col = Enumerable.Repeat(" ", ColumnWidth).ToArray();

            col[0] = " ";
            col[col.Length - 1] = "|";

            for (int i = 0; i < value.Length ; i++)
            {
                col[i + 1] = value[i].ToString();
            }

            foreach (string item in col)
            {
                result += item;
            }            

            return result;
        }

        public void ShowTable()
        {
            int colWidth = 10;
            //wanto to 10 elements in row
            int rows = theArray.Length / 10;
            int columns = theArray.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                WriteLine(columns * colWidth);

                for (int j = 0; j < columns; j++)
                {
                    string val = CreateColumnText( ( (columns * i) + j ).ToString(), colWidth);
                    Console.Write(val);
                }

                WriteLine(columns * colWidth);

                for (int j = 0; j < columns; j++)
                {
                    string val = CreateColumnText(theArray[((columns * i) + j)], colWidth);
                    Console.Write(val );
                }

                WriteLine(columns * colWidth);
            }

            WriteLine(columns * 2);
        }

    }
}
