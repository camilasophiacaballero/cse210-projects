using System;
using System.Collections.Generic;

namespace JournalProgram
{
    class PromptGenerator
    {
        public List<string> _prompts = new List<string>
        {
            "What was the best part of your day?",
            "Who was the most interesting person you interacted with today?",
            "What was the strongest emotion you felt today?",
            "What did you learn today?",
            "If you could do one thing differently today, what would it be?"
        };

        private readonly Random _random = new Random();

        public string GetRandomPrompt()
        {
            return _prompts[_random.Next(_prompts.Count)];
        }
    }
}
