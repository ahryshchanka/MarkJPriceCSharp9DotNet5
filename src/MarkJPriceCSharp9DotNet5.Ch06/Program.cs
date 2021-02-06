using System;
using System.Collections.Generic;
using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch06
{
    static class Program
    {
        static void Main()
        {
            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill" };

            var baby1 = mary.ProcreateWith(harry);
            baby1.Name = "Gary";

            var baby2 = Person.Procreate(harry, jill);

            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine(format: "{0}'s first child is named \"{1}\".", arg0: harry.Name, arg1: harry.Children[0].Name);

            WriteLine($"5! is {Factorial(5)}");

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"{dv1} + {dv2} = {dv3}");
        }

        private static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }

            return LocalFactorial(number);

            static int LocalFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * LocalFactorial(localNumber - 1);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public List<Person> Children { get; } = new();

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }
    }
}