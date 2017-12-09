using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> d = new DynamicArray<int>();

            d.Put(50);
            Console.WriteLine(d.GetSize());
            d.Put(12);
            Console.WriteLine(d.GetSize());
            d.Put(1);
            Console.WriteLine(d.GetSize());
            d.Put(6);
            Console.WriteLine(d.GetSize());
            d.Put(44);
            Console.WriteLine(d.GetSize());
            Console.WriteLine("----------------");
            for (int i = 0; i < d.GetSize(); i++)
            {
                Console.WriteLine(d[i]);
            }

            Console.ReadKey();
        }
    }
}
