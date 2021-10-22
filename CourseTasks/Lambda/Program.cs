using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person> { new Person("Ivan", 14), new Person("Kate", 23), new Person("Alex", 35), new Person("Kate", 14), new Person("Alex", 63) };

            List<string> uniqueNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Уникальные имена: " + string.Join(", ", uniqueNames));

            List<Person> youngPersons = persons
                .Where(p => p.Age < 18)
                .ToList();

            Console.WriteLine("Имена людей младше 18: " + string.Join(" | ", youngPersons));

            Console.WriteLine($"Средний возраст этих людей младше 18: {youngPersons.Average(p => p.Age)}");

            Dictionary<string, double> nameGroups = persons
                .GroupBy(p => p.Name)
                .ToDictionary(d => d.Key, d => d.Average(p => p.Age));

            Console.WriteLine("Группировка по имени со значением среднего возраста: " + string.Join(" | ", nameGroups.Select(pair => $"имя = {pair.Key}, средний возраст = {pair.Value}")));

            List<Person> middleAgePersons = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();

            Console.WriteLine(string.Join(" | ", middleAgePersons));

            Console.ReadKey();
        }
    }
}
