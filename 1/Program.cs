using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int sum = 0;
                while (!reader.EndOfStream)
                {
                    string first = "";
                    string last = "";
                    string tempWord = "";
                    string line = reader.ReadLine();

                    for (int i = 0; i < line.Length; i++)
                    {
                        tempWord += line[i];
                        char c = line[i];
                        string word = containNumberText(tempWord);
                        if (word != "x")
                        {
                            first = word;
                            break;
                        }
                        if (char.IsDigit(c))
                        {
                            first += c;
                            break;
                        }
                    }
                    tempWord = "";
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        tempWord += line[i];
                        char c = line[i];
                        string word = containNumberText(reverseString(tempWord));
                        if (word != "x")
                        {
                            last = word;
                            break;
                        }
                        if (char.IsDigit(c))
                        {
                            last += c;
                            break;
                        }
                    }
                    sum += int.Parse(first + last);
                    Console.WriteLine("first: "  + first);
                    Console.WriteLine("last: " + last);
                    Console.WriteLine(first + last);
                    Console.WriteLine(sum);
                    Console.WriteLine("----------");
                }
                Console.WriteLine(sum);
            }
        }
        else
        {
            Console.WriteLine("Die Datei existiert nicht.");
        }
    }

    static string containNumberText(string text)
    {
        if (text.Contains("zero"))
        {
            return "0";
        }
        if (text.Contains("one"))
        {
            return "1";
        }
        if (text.Contains("two"))
        {
            return "2";
        }
        if (text.Contains("three"))
        {
            return "3";
        }
        if (text.Contains("four"))
        {
            return "4";
        }
        if (text.Contains("five"))
        {
            return "5";
        }
        if (text.Contains("six"))
        {
            return "6";
        }
        if (text.Contains("seven"))
        {
            return "7";
        }
        if (text.Contains("eight"))
        {
            return "8";
        }
        if (text.Contains("nine"))
        {
            return "9";
        }
        return "x";
    }

    static string reverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
