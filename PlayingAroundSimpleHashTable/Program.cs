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
        int randomStepNumber = 5;

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

            table.FindKey("654");
            table.FindKey("100");           

            //want to make clussion
            string[] elemntsToAdd3 = { "30", "60", "90", "120", "150", "180",
                "210", "240", "270", "300", "330", "360", "390", "420", "450",
                "480", "510", "540", "570", "600", "989", "984", "320", "321",
                "400", "415", "450", "50", "660", "624" };

            table.ClearTheArray();
            table.HashFunction2(elemntsToAdd3, table.theArray);
            table.ShowTable();

            table.IncreaseArraySize(60);
            table.ShowTable();

            table.ClearTheArray();
            table.DoubleHashFunction(elemntsToAdd3, table.theArray);
            table.ShowTable();

            table.FindDoubleKey("989");

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

        //with prime numbers we can Avoid clustering and Get a better distribution
        //so e need to check if the number is prie or not
        public Boolean isPrime(int number)
        {
            if (number % 2 == 0)
                return false;

            //want to check all odd numbers
            for (int i = 3; i * i <= number; i+=2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        //we want to find the next prime number and increase the array size
        public int NextPrimeNumber(int number)
        {
            //there should be a prime number so the loop condition is true
            for (int i = number; true; i++)
            {
                if (isPrime(i))
                    return i;
            }
        }

        public void IncreaseArraySize(int arraySize)
        {
            int newSize = NextPrimeNumber(arraySize);

            //here we need to move ol array in new increased array
            MoveOldArray(newSize);
        }

        //for moving array we are going to create new array without empty spaces just to store numbers
        //create new array with the prime size and move values in again
        public void MoveOldArray(int size)
        {
            string[] cleanArray = RemoveEmptySpaces(theArray);

            theSize = size;
            theArray = new string[size];
            ClearTheArray(); //fill all elements with -1
            HashFunction2(cleanArray, theArray);
        }

        public string[] RemoveEmptySpaces(string[] arrayToRemoceSpaces)
        {
            List<string> array = arrayToRemoceSpaces.ToList();

            return array.Where(a => a != "-1").ToArray();
                
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
                int index = theArrayIndex % theSize;

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


        // we want to solve the cluster here with double hash
        // one way to this is going to randomize new index instead of going to the next when collusion occures
        public void DoubleHashFunction(string[] stringsToInsert, string[] theArray)
        {
            for (int i = 0; i < stringsToInsert.Length; i++)
            {
                int theArrayIndex = int.Parse(stringsToInsert[i]);
                string newValue = stringsToInsert[i];

                //we wan to sure that item will fit in the array
                int index = theArrayIndex % theSize;

                int step = randomStepNumber - (theArrayIndex % randomStepNumber);

                Console.WriteLine(" The calculated index = " + index.ToString() + " is for value " + newValue);

                while (theArray[index] != "-1")
                {
                    index += randomStepNumber;

                    Console.WriteLine("Collusion try to put in index " + index.ToString());

                    index %= theSize;
                }

                theArray[index] = newValue;
            }
        }

        public string FindKey(string key)
        {
            //first I'm looking to the index that the key supposed to be there
            int index = int.Parse(key) % theSize;

            while (theArray[index] != "-1")
            {
                if (theArray[index] == key)
                {
                    Console.WriteLine("I found the " + key +" in index " + index.ToString());
                    return theArray[index];
                }

                index++;
                index %= theSize;
            }

            Console.WriteLine(key + " not found");
            return null;
        }

        public string FindDoubleKey(string key)
        {
            //first I'm looking to the index that the key supposed to be there
            int index = int.Parse(key) % theSize;

            while (theArray[index] != "-1")
            {
                if (theArray[index] == key)
                {
                    Console.WriteLine("I found the " + key + " in index " + index.ToString());
                    return theArray[index];
                }

                index += randomStepNumber;
                index %= theSize;
            }

            Console.WriteLine(key + " not found");
            return null;
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
                    val = val.Contains("-1") ? val.Replace("-1","  ") : val;
                    Console.Write(val );
                }

                WriteLine(columns * colWidth);
            }

            WriteLine(columns * 2);
        }

    }
}
