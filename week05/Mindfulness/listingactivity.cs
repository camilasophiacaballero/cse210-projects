using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private readonly string[] _prompts = new string[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _random = new Random();

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void ExecuteActivity()
        {
            Console.WriteLine();
            string prompt = _prompts[_random.Next(_prompts.Length)];
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("You will have a few seconds to think before listing begins.");
            Spinner.ShowCountdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing items. Press Enter after each item.");

            List<string> items = new List<string>();
            Stopwatch sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                int remainingMs = (int)Math.Max(0, (DurationSeconds - sw.Elapsed.TotalSeconds) * 1000);
                string entry = ReadLineWithTimeout(remainingMs).GetAwaiter().GetResult();
                if (entry == null)
                {
                    break;
                }
                if (!string.IsNullOrWhiteSpace(entry))
                {
                    items.Add(entry.Trim());
                }
            }

            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items:");
            foreach (var it in items)
            {
                Console.WriteLine($"- {it}");
            }
        }

        private async Task<string> ReadLineWithTimeout(int timeoutMilliseconds)
        {
            if (timeoutMilliseconds <= 0)
            {
                return null;
            }

            Task<string> readTask = Task.Run(() => Console.ReadLine());
            Task delayTask = Task.Delay(timeoutMilliseconds);

            Task finished = await Task.WhenAny(readTask, delayTask);
            if (finished == readTask)
            {
                return readTask.Result;
            }
            else
            {
                return null;
            }
        }
    }
}
