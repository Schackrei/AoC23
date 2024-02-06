using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        ProcessFile(filePath);
    }

    static void ProcessFile(string filePath)
    {
        int sumID = 0;
        int power = 0;
        int counter = 1;
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            //teil 1
            int[] highestValues = ExtractEntries(line);
            if (highestValues[0] <= 12 && highestValues[1] <= 13 && highestValues[2] <= 14)
            {
                sumID += counter;
            }
            //teil 2
            power += highestValues[0] * highestValues[1] * highestValues[2];
            counter++;
        }
        Console.WriteLine("Summe von IDs: " + sumID);
        Console.WriteLine("Power: " + power);
    }
    static int[] ExtractEntries(string line)
    {
        string[] entryStrings = line.Split(new char[] {':', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> games = new List<string>();
        string temp = "";
        foreach (var c in entryStrings)
        {
            if(!c.Contains("Game"))
            {
                temp += c + ",";
            }
            else
            {
                games.Add(temp);
                temp = "";
            }
        }
        games.Add(temp);
        
        for(int i = games.Count() -1; i>=0; i--)
        {
            if (games[i] == "")
            {
                games.Remove(games[i]);
            }
        }
        
        for (int i = 0; i < games.Count(); i++)
        {
            games[i] = games[i].Remove(games[i].Length-1);
        }

        string result = games[0];
        
        string[] values = result.Split(new char[] {',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        
        int[] numbers = GetHighestValues(values);
        return numbers;
    }

    static int[] GetHighestValues(string[] values)
    {
        int[] highestValues = new int[3];

        foreach (var entry in values)
        {
            if (entry.Contains("red"))
            {
                string temp = entry.Remove(entry.Length - 4);
                int number = int.Parse(temp);
                highestValues[0] = Math.Max(highestValues[0], number);
            }
            if (entry.Contains("green"))
            {
                string temp =entry.Remove(entry.Length - 6);
                int number = int.Parse(temp);
                highestValues[1] = Math.Max(highestValues[1], number);
            }
            if (entry.Contains("blue"))
            {
                string temp = entry.Remove(entry.Length - 5);
                int number = int.Parse(temp);
                highestValues[2] = Math.Max(highestValues[2], number);
            }
        }

        return highestValues;
    }
}
