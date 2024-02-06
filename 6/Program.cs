class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        string[] lines = File.ReadAllLines(filePath);
        long[] times = getTimes(lines[0]);
        long[] distance = getDistance(lines[1]);
        long[] wins = new long[times.Length];
        long records = 0;
        for (int i = 0; i < times.Length; i++)
        {
            long tempTime = times[i];

            int counter = 0;
            while(counter <= tempTime)
            {
                if (counter * (tempTime - counter) > distance[i])
                {

                    records++;
                }

                counter++;
            }
            wins[i] = records;
            records = 0;
        }
        long winMultiplier = wins[0];
        for (int i = 1; i < wins.Length; i++)
        {
            winMultiplier *= wins[i];
        }
        Console.WriteLine("number of ways you can beat the record multiplied: " + winMultiplier);

    }
    static long[] getTimes(string line)
    {
        int startIndex = line.IndexOf(":") + 1;
        int endIndex = line.Length;
        int length = endIndex - startIndex;
        string[] numbers = line.Substring(startIndex,length).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll(numbers, long.Parse);
    }
    static long[] getDistance(string line)
    {
        int startIndex = line.IndexOf(":") + 1;
        int endIndex = line.Length;
        int length = endIndex - startIndex;
        string[] numbers = line.Substring(startIndex,length).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll(numbers, long.Parse);
    }
}