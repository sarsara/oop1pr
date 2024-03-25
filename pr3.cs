using System;
using System.Collections.Generic;

public class Program{
    public static void Main(string[] args) {
        List<Vaccination> vaccinations = new List<Vaccination>();
        vaccinations.Add(new OneTimeVaccination("Від грипу щоб не боліти", 5));
        vaccinations.Add(new RecurringVaccination("COVID-19 (ну то понятно, даже нічо говорити не буду)", 18, 80, 1));
        vaccinations.Add(new RecurringVaccination("Від тубіку", 12, 60, 2)); 
        vaccinations.Add(new OneTimeVaccination("Від пневмококку", 60));
        vaccinations.Add(new OneTimeVaccination("Від дифтерії", 7)); 
        vaccinations.Add(new RecurringVaccination("Від гепатиту Б", 20, 50, 2)); 
        
        Console.WriteLine("Введіть вік людини:");
        int age;
        if (int.TryParse(Console.ReadLine(), out age)){
            List<Vaccination> necessaryVaccinations = GetNecessaryVaccinations(vaccinations, age);
        
            Console.WriteLine($"Людині віком {age} необхідні наступні вакцинації:");
            foreach (var vaccination in necessaryVaccinations){
                Console.WriteLine(vaccination.Name);
            }
        }
        else{
            Console.WriteLine("Некоректний вік. Будь ласка, введіть ціле число.");
        }
    }

    public static List<Vaccination> GetNecessaryVaccinations(List<Vaccination> vaccinations, int age){
        List<Vaccination> necessaryVaccinations = new List<Vaccination>();
        foreach (var vaccination in vaccinations){
            if (vaccination.IsNeeded(age)){
                necessaryVaccinations.Add(vaccination);
            }
        }
        return necessaryVaccinations;
    }
}

public abstract class Vaccination{
    public string Name { get; protected set; }
    public abstract bool IsNeeded(int age);
}

public class OneTimeVaccination : Vaccination{
    private int _targetAge;

    public OneTimeVaccination(string name, int targetAge){
        Name = name;
        _targetAge = targetAge;
    }
    public override bool IsNeeded(int age){
        return age == _targetAge;
    }
}

public class RecurringVaccination : Vaccination {
    private int _minAge;
    private int _maxAge;
    private int _interval;

    public RecurringVaccination(string name, int minAge, int maxAge, int interval) {
        Name = name;
        _minAge = minAge;
        _maxAge = maxAge;
        _interval = interval;
    }
    public override bool IsNeeded(int age){
        return age >= _minAge && age <= _maxAge && (age - _minAge) % _interval == 0;
    }
}
