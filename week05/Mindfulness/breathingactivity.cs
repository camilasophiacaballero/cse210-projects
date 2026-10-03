using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        private readonly string[] _breathMessages = new string[] { "Breathe in...", "Breathe out..." };

        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void ExecuteActivity()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int messageIndex = 0;
            int pauseSeconds = 4;

            while (sw.Elapsed.TotalSeconds < DurationSeconds)
            {
                Console.WriteLine();
                Console.WriteLine(_breathMessages[messageIndex % 2]);

                for (int i = pauseSeconds; i >= 1 && sw.Elapsed.TotalSeconds < DurationSeconds; i--)
                {
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write('\b');
                    Console.Write(' ');
                    Console.Write('\b');
                }

                messageIndex++;
            }

            sw.Stop();
        }
    }
}
