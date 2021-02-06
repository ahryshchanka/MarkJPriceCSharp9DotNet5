using System;
using System.Linq;
using System.Reflection;

using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch02
{
    static class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            WriteLine($"There are {args.Length} arguments.");

            foreach (string arg in args)
            {
                WriteLine(arg);
            }

            foreach (var r in Assembly.GetEntryAssembly()!.GetReferencedAssemblies())
            {
                var assembly = Assembly.Load(new AssemblyName(r.FullName));

                int methodCount = 0;

                foreach (var t in assembly.DefinedTypes)
                {
                    methodCount += t.GetMethods().Length;
                }
                Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.", arg0: assembly.DefinedTypes.Count(), arg1: methodCount, arg2: r.Name);
            }

            WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
            WriteLine("---");
            WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
            WriteLine("---");
            WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");
            WriteLine("---");

            WriteLine("Using doubles:");
            double a = 0.1;
            double b = 0.2;
            WriteLine(a + b == 0.3 ? $"{a} + {b} equals 0.3" : $"{a} + {b} does NOT equal 0.3");

            WriteLine("Using decimal:");
            decimal c = .1m;
            decimal d = .2m;
            WriteLine(c + d == 0.3m ? $"{c} + {d} equals 0.3" : $"{c} + {d} does NOT equal 0.3");

            dynamic anotherName = "Ahmed";
            int length = anotherName.Length;

            DateTime date = new(2021, 2, 6, new(), new(), new());
            WriteLine(date);

            int? thisCouldBeNull = null;
            WriteLine(thisCouldBeNull);
            WriteLine(thisCouldBeNull.GetValueOrDefault());

            WriteLine("--------------------------------------------------------------------------");
            WriteLine("Type    Byte(s) of memory               Min                            Max");
            WriteLine("--------------------------------------------------------------------------");
            WriteLine($"sbyte   {sizeof(sbyte),-4} {sbyte.MinValue,30} {sbyte.MaxValue,30}");
            WriteLine($"byte    {sizeof(byte),-4} {byte.MinValue,30} {byte.MaxValue,30}");
            WriteLine($"short   {sizeof(short),-4} {short.MinValue,30} {short.MaxValue,30}");
            WriteLine($"ushort  {sizeof(ushort),-4} {ushort.MinValue,30} {ushort.MaxValue,30}");
            WriteLine($"int     {sizeof(int),-4} {int.MinValue,30} {int.MaxValue,30}");
            WriteLine($"uint    {sizeof(uint),-4} {uint.MinValue,30} {uint.MaxValue,30}");
            WriteLine($"long    {sizeof(long),-4} {long.MinValue,30} {long.MaxValue,30}");
            WriteLine($"ulong   {sizeof(ulong),-4} {ulong.MinValue,30} {ulong.MaxValue,30}");
            WriteLine($"float   {sizeof(float),-4} {float.MinValue,30} {float.MaxValue,30}");
            WriteLine($"double  {sizeof(double),-4} {double.MinValue,30} {double.MaxValue,30}");
            WriteLine($"decimal {sizeof(decimal),-4} {decimal.MinValue,30} {decimal.MaxValue,30}");
            WriteLine("--------------------------------------------------------------------------");
        }
    }
}