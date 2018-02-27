using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public interface IMyHashtable<TKey, TValue>
    {
        TValue Find(TKey key);
        void Add(TKey key, TValue value);
        void Remove(TKey key);
        int Count();
    }


    public class MyHashtable<TKey, TValue> : IMyHashtable<TKey, TValue>
    {

        private readonly int size;
        internal readonly LinkedList<KeyValuePair<TKey, TValue>>[] items;

        public MyHashtable(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        public void Add(TKey key, TValue value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            KeyValuePair<TKey, TValue> item = new KeyValuePair<TKey, TValue>(key, value);
            linkedList.AddLast(item);
        }

        public TValue Find(TKey key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            foreach (KeyValuePair<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(TValue);
        }

        public void Remove(TKey key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<TKey, TValue> foundItem = default(KeyValuePair<TKey, TValue>);
            foreach (KeyValuePair<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        internal int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValuePair<TKey, TValue>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<TKey, TValue>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public int Count()
        {
            int counter = 0;
            foreach(var bucket in items)
            {
                if (bucket != null)
                {
                    counter += bucket.Count;
                }
            }
            return counter;
        }
    }
}
