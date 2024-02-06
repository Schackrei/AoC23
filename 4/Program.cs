using System.Diagnostics.Metrics;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        if (File.Exists(filePath))
        {  
            int points = 0;
            string[] lines = File.ReadAllLines(filePath);
            List<int> matchingNumber = new List<int>();
            int[][] cards = new int[lines.Length][];
            int counter = 1;
            foreach (var l in lines)
            {
                int[] wins = winningNumbers(l);
                int[] numbers = playingNumbers(l);
                int matches = countMatches(wins, numbers);
                matchingNumber.Add(matches);
                cards[counter - 1] = new int[] { 1, matches };
                if (matches != 0)
                {
                    int tempPoints = (int)Math.Pow(2, matches -1);

                    points += tempPoints;
                }
                counter++;
            }
            int totalScratchcards = CalculateTotalScratchcards(cards);
            Console.WriteLine(points);
            Console.WriteLine(totalScratchcards);
        }
        else
        {
            Console.WriteLine("Die Datei existiert nicht.");
        }
    }
    static int CalculateTotalScratchcards(int[][] matchingNumbers)
    {
        for (int i = 0; i<matchingNumbers.Count(); i++)
        {
            int matches = matchingNumbers[i][1];
            Console.WriteLine(matches);
            int counter = 1;
            while (i + counter < matchingNumbers.Length && counter <= matches)
            {
                Console.WriteLine(matchingNumbers[i+counter][0]);
                matchingNumbers[i+counter][0] += 1 * matchingNumbers[i][0];
                Console.WriteLine(matchingNumbers[i+counter][0]);
                Console.WriteLine("------");
                counter++;
            }
            
        }
        int totalScratchcards = 0;
        foreach (var item in matchingNumbers)
        {
            totalScratchcards += item[0];
        }
        return totalScratchcards;
    }

    static int[] winningNumbers(string line)
    {
        int startIndex = line.IndexOf(":") + 1;
        int endIndex = line.IndexOf("|");
        int length = endIndex - startIndex;
        string firstNumbers = line.Substring(startIndex,length);
        string[] numbers = firstNumbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll(numbers, int.Parse);
    }
    static int[] playingNumbers(string line)
    {
        int startIndex = line.IndexOf("|") + 1;
        int endIndex = line.Length;
        int length = endIndex - startIndex;
        string secondNumbers = line.Substring(startIndex,length);
        string[] numbers = secondNumbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll(numbers, int.Parse);
    }
    static int countMatches(int[] win, int[] play)
    {
        int matches = 0;
        foreach (var number in play)
        {
            if (win.Contains(number))
            {
                matches++;
            }
        }
        return matches;
    }
}
