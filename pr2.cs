using System;
using System.Text.RegularExpressions;

class Program{
    static void Main(string[] args){
        Console.WriteLine("(пж) Впиши час у форматі HH:mm:ss:");
        string input = Console.ReadLine();

        if (input.ToLower() == "earl"){
            Console.WriteLine("you was earl roll'd: https://www.youtube.com/watch?v=PMXCPVVYbsU&pp=ygUJcmlwIHRyYWN5");
        }
        else{
            Regex regex = new Regex(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");

            if (regex.IsMatch(input)){
                string[] timeComponents = input.Split(':');
                int hours = int.Parse(timeComponents[0]);
                int minutes = int.Parse(timeComponents[1]);
                int seconds = int.Parse(timeComponents[2]);

                string APm = hours >= 12 ? "PM" : "AM";
                hours = hours % 12;
                hours = hours == 0 ? 12 : hours;

                Console.WriteLine($"AM/PM: {hours:D2}:{minutes:D2}:{seconds:D2} {APm}");
            }
            else{
                Console.WriteLine("Перезапусти програму і пиши по формату:  HH:mm:ss");
            }
        }
    }
}