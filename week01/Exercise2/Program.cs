using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        string letter = "";
        string sign = "";

        if (percentage >= 90) { letter = "A"; }
        else if (percentage >= 80) { letter = "B"; }
        else if (percentage >= 70) { letter = "C"; }
        else if (percentage >= 60) { letter = "D"; }
        else { letter = "F"; }

        int lastDigit = percentage % 10;
        if (lastDigit >= 7) { sign = "+"; }
        else if (lastDigit < 3) { sign = "-"; }
        else { sign = ""; }

        if (percentage >= 93 || letter == "F")
        { 
            sign = ""; 
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percentage >= 70) 
        { 
            Console.WriteLine("Congratulations! You passed the class!"); 
        }
        else 
        { 
            Console.WriteLine("Keep trying, you'll get it next time!"); 
        }
    }
}