using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    //this hash table is not storing 0 values
    //because they are a lot in the array
    //so just saving the total numbers of 0
    class CustomizedHashTable
    {
        HashNode[] arrayHash;
        int Size;

        public CustomizedHashTable(int size)
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
            if (key == 0)
                return 0;

            return (key % Size) + 1;
        }

        public void Put(int key)
        {
           int hashIndex = Gethash(key);

            HashNode node = new HashNode(key, null);

            //we want to add in the begining of the list
            HashNode arrayNode = arrayHash[hashIndex];
            if (hashIndex == 0)
            {
                arrayNode.Value = arrayNode.Value == null ? 1:
                                                   (int)arrayNode.Value + 1;
            }
            else
            {
                node.Next = arrayNode.Next;
                arrayNode.Next = node;
            }
        }

        public int GetZeroCount()
        {
            HashNode arrayNode = arrayHash[0];
            return (int)arrayNode.Value;
        }

        public int Get(int key)
        {
            int result = 0;

            int hashIndex = Gethash(key);
            HashNode arrayNode = arrayHash[hashIndex];

            if (hashIndex == 0)
            {
                return 0;
            }

            while (arrayNode != null)
            {
                if (arrayNode.Key == key)
                {
                    result = arrayNode.Key;
                    break;
                }

                arrayNode = arrayNode.Next;
            }

            return result;
        }


    }
}
