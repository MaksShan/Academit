using System;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable
    {
        private List<string>[] table;

        public HashTable(int size)
        {
            table = new List<string>[size];
        }

        public int GetListIndex(string item)
        {
            return Math.Abs(item.GetHashCode() % table.Length);
        }

        public void SetItem(string item)
        {
            int index = GetListIndex(item);

            if (table[index] == null)
            {
                table[index] = new List<string>();

                table[index].Add(item);
            }
            else
            {
                table[index].Add(item);
            }
        }

        public int GetItemIndex(string searchItem)
        {
            int index = GetListIndex(searchItem);

            if (table[index] == null)
            {
                return -1;
            }

            for (int i = 0; i < table[index].Count; i++)
            {
                if (table[index][i].Equals(searchItem))
                {
                    return i;
                }
            }

            return -1;
        }

        public string RemoveItem(string itemToRemove)
        {
            int index = GetListIndex(itemToRemove);

            try
            {
                table[index].RemoveAt(GetItemIndex(itemToRemove));

                return $"Элемент \"{itemToRemove}\" был удален";
            }
            catch (ArgumentOutOfRangeException)
            {
                return $"Элемента \"{itemToRemove}\" не существует";
            }
        }
    }
}
