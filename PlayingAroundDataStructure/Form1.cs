using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Structure;
using SearchAlgorithms;

namespace PlayingAroundDataStructure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddToBox(string item)
        {
            Box.Items.Add(item);
        }
        private void DaynaicBtn_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            DynamicArray<int> d = new DynamicArray<int>();

            d.Put(50);
            AddToBox(d.GetSize().ToString());
            d.Put(12);
            AddToBox(d.GetSize().ToString());
            d.Put(1);
            AddToBox(d.GetSize().ToString());
            d.Put(6);
            AddToBox(d.GetSize().ToString());
            d.Put(44);
            AddToBox(d.GetSize().ToString());
            AddToBox("----------------");
            for (int i = 0; i < d.GetSize(); i++)
            {
                AddToBox(d[i].ToString());
            }
        }

        private void LinkedButton_Click(object sender, EventArgs e)
        {
            Data_Structure.LinkedList<int> list = new Data_Structure.LinkedList<int>();

            list.Add(5);
            list.Add(20);
            list.Add(60);


            Box.Items.Clear();

            foreach (string item in list.ToStringList())
            {
                AddToBox(item);
            }

            AddToBox("Delete head and show the result");

            list.Delete();

            foreach (string item in list.ToStringList())
            {
                AddToBox(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinkedDoubleList<int> list = new LinkedDoubleList<int>();

            list.Add(5);
            list.Add(20);
            list.Add(60);

            Box.Items.Clear();

            foreach (string item in list.ToStringList())
            {
                AddToBox(item);
            }

            AddToBox("Delete head and show the result");

            list.Delete();

            foreach (string item in list.ToStringList())
            {
                AddToBox(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            Data_Structure.HashTable<string> ht = new Data_Structure.HashTable<string>(10);

            ht.Put(20, "first element for key 20");
            ht.Put(4, "second element for key 4");
            ht.Put(40, "third element for jey 40");

            AddToBox("Seraching for key = 20");
            AddToBox(ht.Get(20));
            AddToBox("Seraching for key = 40");
            AddToBox(ht.Get(40));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            ArrayStack<int> stack = new ArrayStack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            if (stack.Push(6) == StackError.StackOverFlow)
                AddToBox("Stack Is Full");

            while (!stack.IsEmpty())
            {
                AddToBox(stack.Pop().ToString());
            }

            if (stack.Pop() == default(int))
            {
                AddToBox("Stack is empty");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            DynamicArrayStack<int> stack = new DynamicArrayStack<int>(5);

            stack.Push(1);
            AddToBox("Size is " + stack.GetSize().ToString());
            stack.Push(2);
            AddToBox("Size is " + stack.GetSize().ToString());
            stack.Push(3);
            AddToBox("Size is " + stack.GetSize().ToString());
            stack.Push(4);
            AddToBox("Size is " + stack.GetSize().ToString());
            stack.Push(5);
            AddToBox("Size is " + stack.GetSize().ToString());

            while (!stack.IsEmpty())
            {
                AddToBox(stack.Pop().ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            LinkedListStack<int> stack = new LinkedListStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while (!stack.IsEmpty())
            {
                AddToBox(stack.Pop().ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            ArrayQueue<string> q = new ArrayQueue<string>(4);

            q.Queue("item 1");
            q.Queue("item 2");
            q.Queue("item 3");
            q.Queue("item 4");
            if (q.Queue("testing queue size") == QueueError.IsFull)
            {
                AddToBox("Queue is full");
            }

            AddToBox("-----------");

            while (!q.IsEmpty())
            {
                AddToBox(q.Dequeue());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            DynamicArrayQueue<int> d = new DynamicArrayQueue<int>();

            d.Queue(50);
            AddToBox(d.GetSize().ToString());
            d.Queue(12);
            AddToBox(d.GetSize().ToString());
            d.Queue(1);
            AddToBox(d.GetSize().ToString());
            d.Queue(6);
            AddToBox(d.GetSize().ToString());
            d.Queue(44);
            AddToBox(d.GetSize().ToString());
            AddToBox("----------------");
            while (!d.IsEmpty())
            {
                AddToBox(d.Dequeue().ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            DoubleLInkedListQueue<int> q = new DoubleLInkedListQueue<int>();

            q.Queue(40);
            q.Queue(5);
            q.Queue(8);

            while (!q.IsEmpty())
            {
                AddToBox(q.Dequeue().ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            AddToBox("We want to merge two same sized linked list but with this structure");
            AddToBox("First element of Linked list 1 and Last Element of Linked list 2");
            AddToBox("Linked list 1 { 1, 2, 3, 4, 5, 6} ");
            AddToBox("Linked list 2 { 7, 8, 9, 10, 11, 12} ");
            AddToBox("The result is { 1, 12, 2, 11, 3, 10, 4, 9, 5, 8, 6, 7 }");
            AddToBox("we want to use best data structure with less memory usage");
            AddToBox("So, First Linked list is queue with linked list structure,");
            AddToBox(" but send one is stack with linked list structure");

            DoubleLInkedListQueue<int> l1 = new DoubleLInkedListQueue<int>();

            l1.Queue(1);
            l1.Queue(2);
            l1.Queue(3);
            l1.Queue(4);
            l1.Queue(5);
            l1.Queue(6);

            LinkedListStack<int> l2 = new LinkedListStack<int>();
            l2.Push(7);
            l2.Push(8);
            l2.Push(9);
            l2.Push(10);
            l2.Push(11);
            l2.Push(12);

            int i = 0;
            while (!l2.IsEmpty())
            {
                AddToBox(l1.Dequeue().ToString());
                AddToBox(l2.Pop().ToString());
                i++;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            AddToBox("We want to store arraye of numbers which contains a lot of 0");
            AddToBox("then we want to return value of specific elements");
            AddToBox("and total number of 0");
            AddToBox("array {0, 0, 0, 11, 8, ,1, 5, 0, 0, 9, 2, 0, 0}");
            AddToBox("total of 0 => 7");
            AddToBox("array[0] = 0");
            AddToBox("array [4] = 8");

            int[] numbers = { 0, 0, 0, 11, 8, 1, 5, 0, 0, 9, 2, 0, 0 };

            CustomizedHashTable hash = new CustomizedHashTable(numbers.Length);

            for (int i = 0; i < numbers.Length; i++)
            {
                hash.Put(numbers[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                AddToBox(hash.Get(numbers[i]).ToString());
            }

            AddToBox("----------");
            AddToBox("Total number of zeros" + hash.GetZeroCount().ToString());

        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Student> list = new List<Student>();

            AddToBox("The collection is list");
            list.Add(new Student { Name = "Tina", Age = 36 });
            list.Add(new Student { Name = "John", Age = 25 });
            list.Add(new Student { Name = "Anna", Age = 40 });

            Box.Items.Clear();

            foreach (Student item in list)
            {
                AddToBox(string.Format("Name : {0}, Age : {1}", item.Name, item.Age));
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            System.Collections.Generic.LinkedList<Student> list =
                new System.Collections.Generic.LinkedList<Student>();

            AddToBox("The collection is linked list");
            list.AddLast(new Student { Name = "Tina", Age = 36 });
            list.AddLast(new Student { Name = "John", Age = 25 });
            list.AddLast(new Student { Name = "Anna", Age = 40 });

            foreach (Student item in list)
            {
                AddToBox(string.Format("Name : {0}, Age : {1}", item.Name, item.Age));
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            //Retrieving a value by using its key is very fast, close to O(1)
            //the key value has to be unique and not null
            //but the value van be null
            Dictionary<int, Student> list =
                new Dictionary<int, Student>();

            AddToBox("The collection is Dictionary");
            list.Add(0, new Student { Name = "Tina", Age = 36 });
            list.Add(1, new Student { Name = "John", Age = 25 });
            list.Add(2, new Student { Name = "Anna", Age = 40 });

            for (int i = 0; i < list.Count; i++)
            {
                AddToBox(string.Format("Name : {0}, Age : {1}", list[i].Name, list[i].Age));
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            //is not sorted and doesn't accept duplicate values
            HashSet<Student> list = new HashSet<Student>();

            AddToBox("The collection is Hashset");
            list.Add(new Student { Name = "Tina", Age = 36 });
            list.Add(new Student { Name = "John", Age = 25 });
            list.Add(new Student { Name = "Anna", Age = 40 });

            foreach (Student item in list)
            {
                AddToBox(string.Format("Name : {0}, Age : {1}", item.Name, item.Age));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            /*
             * The SortedList generic class is a binary search tree with O(log n) retrieval, 
             * where n is the number of elements in the dictionary. In this, it is similar to the 
             * SortedDictionary generic class. The two classes have similar object models, 
             * and both have O(log n) retrieval. Where the two classes differ is in memory use and 
             * speed of insertion and removal: 
             * 
             * SortedList uses less memory than SortedDictionary.
             * SortedDictionary has faster insertion and removal operations for unsorted data, O(log n) as 
             * opposed to O(n) for SortedList.
             * 
             * If the list is populated all at once from sorted data, SortedList is faster than SortedDictionary.
             */
            Box.Items.Clear();

            SortedList<int, Student> list = new SortedList<int, Student>();


            AddToBox("The collection is SortedList");
            list.Add(36, new Student { Name = "Tina", Age = 36 });
            list.Add(25, new Student { Name = "John", Age = 25 });
            list.Add(40, new Student { Name = "Anna", Age = 40 });

            foreach (var item in list)
            {
                AddToBox(string.Format("Key => {0} : Name : {1}, Age : {2}", item.Key, item.Value.Name, item.Value.Age));
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //This class implements a queue as a circular array

            Box.Items.Clear();

            Queue<Student> list = new Queue<Student>();


            AddToBox("The collection is SortedList");
            list.Enqueue(new Student { Name = "Tina", Age = 36 });
            list.Enqueue(new Student { Name = "John", Age = 25 });
            list.Enqueue(new Student { Name = "Anna", Age = 40 });

            while (list.Count > 0)
            {
                Student st = list.Dequeue();
                AddToBox(string.Format("Name : {0}, Age : {1}", st.Name, st.Age));
            }
        }

        private int Fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * (Fact(n - 1));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
            int n = 4;
            AddToBox(string.Format("({0})! = > {1}", n, Fact(n)));
            n = 5;
            AddToBox(string.Format("({0})! = > {1}", n, Fact(n)));

        }

        private void ExploreTree(NodeDouble root)
        {
            if (root == null)
                return;

            AddToBox(root.Value.ToString());

            ExploreTree(root.Next);
            ExploreTree(root.Previous);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            LinkedDoubleList<string> tree = new LinkedDoubleList<String>();

            NodeDouble root = new NodeDouble("A", null, null);
            NodeDouble l1 = new NodeDouble("B", null, null);
            NodeDouble l2 = new NodeDouble("C", null, null);
            root.Next = l2;
            root.Previous = l1;

            NodeDouble l3 = new NodeDouble("D", null, null);
            NodeDouble l4 = new NodeDouble("E", null, null);
            NodeDouble l5 = new NodeDouble("F", null, null);
            NodeDouble l6 = new NodeDouble("G", null, null);

            l1.Next = l4;
            l1.Previous = l3;
            l2.Previous = l5;
            l2.Next = l6;

            ExploreTree(root);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            LinearSearch search = new LinearSearch( 9999 ,10000);

            if (search.IsFound)
            {
                AddToBox(string.Format("Searching {0} with linear search and found nuber in {1} try.",
                    9999, search.Try));
            }
            else
            {
                AddToBox("not found");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            BinarySearch search = new BinarySearch(9999, 10000);

            if (search.IsFound)
            {
                AddToBox(string.Format("Searching {0} with binary search and found nuber in {1} try.",
                    9999, search.Try));
            }
            else
            {
                AddToBox("not found");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            InterpolationSearch search = new InterpolationSearch(9999, 10000);

            if (search.IsFound)
            {
                AddToBox(string.Format("Searching {0} with interpolation search and found nuber in {1} try.",
                    9999, search.Try));
            }
            else
            {
                AddToBox("not found");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            int[] array = { 6, 50, 1, 45, 2, 40 };
            AddToBox("Before Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }

            Sorts.BubbleSort(array);
            AddToBox("After Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            int[] array = { 6, 50, 1, 45, 2, 40 };
            AddToBox("Before Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }

            Sorts.SelectionSort(array);
            AddToBox("After Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            int[] array = { 6, 50, 1, 45, 2, 40 };
            AddToBox("Before Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }

            Sorts.QuickSort(array);
            AddToBox("After Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            int[] array = { 6, 50, 1, 45, 2, 40 };
            AddToBox("Before Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }

            MergeSort s = new MergeSort();
            s.PrepareForSort(array);
            AddToBox("After Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Box.Items.Clear();

            IComparable[] array = { 6, 50, 1, 45, 2, 40 };
            AddToBox("Before Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }

            Sorts.HeapSort(array);
            AddToBox("After Sort . . .");
            for (int i = 0; i < array.Length; i++)
            {
                AddToBox(array[i].ToString());
            }
        }
    }
}
