using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicList
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<string> list = new DynamicList<string>();
            list.Add("tv");
            list.Add("smartphone");
            PrintDynamicList<string>(list);
            Console.WriteLine("Number of elements in list: " + list.Count);

            list.Add("fridge");
            list.Add("tablet");
            list.Add("laptop");
            PrintDynamicList<string>(list);
            Console.WriteLine("Number of elements in list: " + list.Count);

            list.Remove("tablet");
            PrintDynamicList<string>(list);
            Console.WriteLine("Number of elements in list: " + list.Count);

            list.RemoveAt(3);
            PrintDynamicList<string>(list);
            Console.WriteLine("Number of elements in list: " + list.Count);

            list.Clear();
            PrintDynamicList<string>(list);
            Console.WriteLine("Number of elements in list: " + list.Count);
            Console.ReadLine();
        }

        static void PrintDynamicList<T>(DynamicList<T> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
