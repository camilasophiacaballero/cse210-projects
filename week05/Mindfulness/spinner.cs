using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public static class Spinner
    {
        public static void ShowSpinner(int seconds)
        {
            char[] sequence = new char[] { '|', '/', '-', '\\' };
            Stopwatch sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(sequence[i % sequence.Length]);
                Thread.Sleep(250);
                Console.Write('\b');
                i++;
            }
            sw.Stop();
        }

        public static void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                string s = i.ToString();
                Console.Write(s);
                Thread.Sleep(1000);
                for (int k = 0; k < s.Length; k++)
                {
                    Console.Write('\b');
                }
                for (int k = 0; k < s.Length; k++)
                {
                    Console.Write(' ');
                }
                for (int k = 0; k < s.Length; k++)
                {
                    Console.Write('\b');
                }
            }
        }
    }
}
