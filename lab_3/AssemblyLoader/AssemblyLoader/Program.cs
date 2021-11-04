using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath;

            if (args.Length == 1)
            {
                assemblyPath = args[0];
            }
            else
            {
                Console.WriteLine("Input the path to assembly");
                assemblyPath = Console.ReadLine();
            }

            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Type[] types = assembly.GetTypes();

            Array.Sort(types, delegate (Type type1, Type type2) { return type1.FullName.CompareTo(type2.FullName); });

            foreach(Type type in types)
            {
                Console.WriteLine(type.FullName);

                Console.WriteLine("  Fields: ");
                foreach(FieldInfo field in type.GetFields())
                {
                    if (field.IsPublic)
                    {
                        Console.WriteLine($"    {field.Name}");
                    }
                }

                Console.WriteLine("Methods: ");
                foreach(MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        Console.WriteLine($"    {method.Name}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
