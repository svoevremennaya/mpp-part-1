using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicList
{
    public class DynamicList<T> : IEnumerable
    {
        private T[] list;
        public int Count;

        public DynamicList()
        {
            list = new T[0];
            Count = 0;
        }

        public DynamicList(int length)
        {
            list = new T[length];
            Count = 0;
        }
        
        public void Add(T item)
        {
            if (list.Length == 0)
            {
                Array.Resize(ref list, 1);
            }
            else if (list.Length == Count)
            {
                Array.Resize(ref list, list.Length * 2);
            }

            list[Count] = item;
            Count++;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(list, item);
            if (index >= 0)
            {
                list = list.Where((val, ind) => ind != index).ToArray();
                Count--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                list = list.Where((val, ind) => ind != index).ToArray();
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            Count = 0;
            Array.Resize(ref list, 0);
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return list[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index >= 0 && index < Count)
                {
                    list[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }
    }
}
