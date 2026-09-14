using System;

// Added a feature to record the user's mood for the day. 

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            Console.WriteLine("Welcome to the Journal Program!");

            while (running)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    Console.Write("How are you feeling today? (Mood): ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry
                    {
                        _date = date,
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood
                    };

                    myJournal.AddEntry(newEntry);
                }
                else if (choice == "2")
                {
                    myJournal.DisplayAll();
                }
                else if (choice == "3")
                {
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                }
                else if (choice == "4")
                {
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                }
                else if (choice == "5")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
