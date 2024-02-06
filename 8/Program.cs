using System;
using System.Linq;

class Program
{
    static string filePath = "input.txt";
    static string[] lines = File.ReadAllLines(filePath); 
    static void Main()
    {
        string LRinstructions = lines[0];
        string searchTerm = "AAA";

        string currentLine = searchTerm;
        int steps = 0;
        int counter = 0;
        while (currentLine != "ZZZ")
        {
            int lineNumber = GetLine(lines, searchTerm);
            currentLine = lines[lineNumber].Substring(0,3);
            char side = LRinstructions[counter];
            if (side == 'L')
            {
                searchTerm = lines[lineNumber].Substring(7,3);
            }
            if (side == 'R')
            {
                searchTerm = lines[lineNumber].Substring(12,3);
            }
            counter++;
            if (counter > LRinstructions.Length-1)
            {
                counter = 0;
            }
            steps++;
        }
        Console.WriteLine(steps-1);
        
        //part2
        List<string> nodes = new List<string>();
        for(int i = 2; i < lines.Length; i++)
        {
            if (lines[i][2] == 'A')
            {
                nodes.Add(lines[i].Substring(0,3));
            }
        }

        string[] cycles = new string[nodes.Count()];
        for(int i = 0; i < nodes.Count(); i++)
        {
            cycles[i] = Steps(nodes[i]).ToString();
        }
        File.WriteAllLines("cycles", cycles);
    }
    static int Steps(string m)
    {
        string LRinstructions = lines[0];
        string searchTerm = m;

        string currentLine = searchTerm;
        int steps = 0;
        int counter = 0;
        while (currentLine[2] != 'Z')
        {
            int lineNumber = GetLine(lines, searchTerm);
            currentLine = lines[lineNumber].Substring(0,3);
            char side = LRinstructions[counter];
            if (side == 'L')
            {
                searchTerm = lines[lineNumber].Substring(7,3);
            }
            if (side == 'R')
            {
                searchTerm = lines[lineNumber].Substring(12,3);
            }
            counter++;
            if (counter > LRinstructions.Length-1)
            {
                counter = 0;
            }
            steps++;
        }
        return steps-1;
    }
    static int GetLine(string[] lines, string searchTerm)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].TrimStart().StartsWith(searchTerm))
            {
                return i;
            }
        }
        return -1;
    }
}


