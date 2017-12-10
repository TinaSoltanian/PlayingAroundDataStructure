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
            AddToBox( ht.Get(20));
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
    }
}
