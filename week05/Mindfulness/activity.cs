using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        private string _activityName;
        private string _description;
        private int _durationSeconds;

        protected string ActivityName => _activityName;
        protected string Description => _description;
        protected int DurationSeconds => _durationSeconds;

        protected Activity(string name, string description)
        {
            _activityName = name;
            _description = description;
            _durationSeconds = 0;
        }

        public void Run()
        {
            ShowStartingMessage();
            SetDurationFromUser();
            PrepareToBegin();
            ExecuteActivity();
            ShowEndingMessage();
        }

        private void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {ActivityName} ===");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
        }

        private void SetDurationFromUser()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    _durationSeconds = seconds;
                    break;
                }
                Console.WriteLine("Please enter a positive integer for seconds.");
            }
        }

        private void PrepareToBegin()
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            Spinner.ShowCountdown(3);
        }

        private void ShowEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Spinner.ShowSpinner(3);
            Console.WriteLine($"You have completed the {ActivityName} for {DurationSeconds} seconds.");
            Spinner.ShowCountdown(3);
        }

        protected abstract void ExecuteActivity();
    }
}
