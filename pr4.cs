using System;
using System.Collections.Generic;
using System.Linq;

record Person(string FirstName, string LastName, DateTime Birthday);

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            // База деяких людей
            new Person("Джон", "Доє", new DateTime(1995, 5, 10)),
            new Person("Микита", "Кожум'яка", new DateTime(2001, 8, 25)),
            new Person("Tariq", "Trotter", new DateTime(1998, 10, 3)),
            new Person("Joe", "Mama", new DateTime(2093, 9, 20)),
            new Person("Lord", "Quas", new DateTime(1999, 1, 18))
        };

        var filteredPeople = people.Where(person => person.Birthday.Year > 2000)
                                   .OrderBy(person => person.LastName)
                                   .ThenBy(person => person.FirstName);

        Console.WriteLine("Результат:");
        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Birthday:dd-MM-yyyy}");
        }
    }
}
