using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{

    class HashNode
    {
        public int Key { get; set; }
        public Object Value { get; set; }        
        public HashNode Next;

        public HashNode(int key, Object value)
        {
            this.Key = key;
            this.Value = value;
            this.Next = null;
        }

        public HashNode()
        {
            this.Next = null;
        }
    }

    class HashTable<T>
    {
        HashNode[] arrayHash;
        int Size;

        public HashTable(int size)
        {
            this.Size = size;
            arrayHash = new HashNode[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                arrayHash[i] = new HashNode();
            }
        }

        // here the hash function is so simple
        private int Gethash(int key)
        {
            return key % Size;
        }

        public void Put(int key, Object value)
        {
            int hashIndex = Gethash(key);
            HashNode node = new HashNode(key, value);

            //we want to add in the begining of the list
            HashNode arrayNode = arrayHash[hashIndex];
            node.Next = arrayNode.Next;
            arrayNode.Next = node;
        }

        public T Get(int key)
        {
            T result = default(T);

            int hashIndex = Gethash(key);
            HashNode arrayNode = arrayHash[hashIndex];
            while(arrayNode != null)
            {
                if (arrayNode.Key == key)
                {
                    result = (T)arrayNode.Value;
                    break;
                }

                arrayNode = arrayNode.Next;
            }

            return result;
        }

    }
}
