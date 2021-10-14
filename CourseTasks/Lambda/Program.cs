using System;
using System.Collections.Generic;
using System.Linq;
namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person("Ivan", 14);
            var person2 = new Person("Kate", 23);
            var person3 = new Person("Alex", 35);
            var person4 = new Person("Kate", 14);
            var person5 = new Person("Alex", 63);

            var persons = new List<Person> { person1, person2, person3, person4, person5 };

            var uniqueNames = persons
                .Select(p => p.Name)
                .Distinct();

            Console.WriteLine("Уникальные имена: " + string.Join(", ", uniqueNames));

            var youngPersons = persons
                .Where(p => p.Age < 18);

            Console.WriteLine("Имена людей младше 18: " + string.Join(" | ", youngPersons));

            Console.WriteLine($"Средний возраст этих людей младне 18: {Math.Ceiling(youngPersons.Select(p => p.Age).Average())}");

            var nameGroups = persons
                .GroupBy(p => p.Name)
                .Select(a => new { persons = a.Key, avg = Math.Ceiling(a.Average(p => p.Age)) });

            var middleAgePersons = persons
                .OrderBy(p => p.Age)
                .Where(p => p.Age >= 20 && p.Age <= 45);

            Console.WriteLine(string.Join(" | ", middleAgePersons));

            Console.ReadKey();
        }
    }
}
