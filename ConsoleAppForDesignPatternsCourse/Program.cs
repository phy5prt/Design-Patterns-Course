using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleAppForDesignPatternsCourse
{
    class Journal
    { 
    private readonly List<string> journalEntries = new List<string>();
        private static int count = 0;
        public int addJournalEntry(string journalEntry) {
           
            journalEntries.Add($"{++count}:{journalEntry}");
            return count;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, journalEntries);
        }
        public void removeJournalEntry(int index) {
            journalEntries.RemoveAt(index);
        }
    }
    class Persistance
    {
        public void saveToFile(Journal journal, string filename, bool overwrite=false)
        {
            if (overwrite || !File.Exists(filename)) 
            {
                File.WriteAllText(filename,journal.ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            journal.addJournalEntry("I am learning pattern");
            journal.addJournalEntry("So I will be a genius");


            Persistance persist = new Persistance();
            var filename = @"D:\learning code copy sept2\_Design-Patterns-Course\ConsoleAppForDesignPatternsCourse\journal.txt";
            persist.saveToFile(journal, filename, true);


            Process.Start("notepad.exe", filename );
            //Process.Start(filename);
            Console.WriteLine(journal) ;
            
        }
     
    }
}
