using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    class Journal
    {
        private readonly List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries yet.");
            }
            else
            {
                foreach (Entry entry in _entries)
                {
                    entry.Display();
                }
            }
        }

        public void LoadFromFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();

            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];
                    loadedEntry._promptText = parts[1];
                    loadedEntry._entryText = parts[2];
                    
                    if (parts.Length >= 4)
                    {
                        loadedEntry._mood = parts[3];
                    }
                    else
                    {
                        loadedEntry._mood = "Not recorded";
                    }

                    _entries.Add(loadedEntry);
                }
            }

            Console.WriteLine("Journal loaded successfully.");
        }

        public void SaveToFile(string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
    }
}
