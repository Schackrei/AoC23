using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        string[] lines = File.ReadAllLines(filePath);
        List<long>  seeds = new List<long>();
        List<long[]> seedToSoil = new List<long[]>();
        List<long[]> soilToFertilizer = new List<long[]>();
        List<long[]> fertilizerToWater = new List<long[]>();
        List<long[]> waterToLight = new List<long[]>();
        List<long[]> lightToTemperature = new List<long[]>();
        List<long[]> temperatureToHumidity= new List<long[]>();
        List<long[]> humidityToLocation= new List<long[]>();
        string listName = "";
        if (File.Exists(filePath))
        {
            foreach (var line in lines)
            {
                //"  seeds: 79 14 55 13              
                //"
                if (line == "seeds: 2149186375 163827995 1217693442 67424215 365381741 74637275 1627905362 77016740 22956580 60539394 586585112 391263016 2740196667 355728559 2326609724 132259842 2479354214 184627854 3683286274 337630529")
                {
                    int startIndex = line.IndexOf(":") + 1;
                    int endIndex = line.Length;
                    int length = endIndex - startIndex;
                    string seedNumbers = line.Substring(startIndex,length);
                    string[] numbers = seedNumbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < numbers.Length-1; i+=2)
                    {
                        int counter = 0;
                        while (counter < long.Parse(numbers[i+1]))
                        {
                            seeds.Add(long.Parse(numbers[i])+counter);
                            counter++;
                        }

                    }
                }
                if (line == "seed-to-soil map:")
                {
                    listName = "seedToSoil";
                }
                if (line == "soil-to-fertilizer map:")
                {
                    listName = "soilToFertilizer";
                }
                if (line == "fertilizer-to-water map:")
                {
                    listName = "fertilizerToWater";
                }
                if (line == "water-to-light map:")
                {
                    listName = "waterToLight";
                }
                if (line == "light-to-temperature map:")
                {
                    listName = "lightToTemperature";
                }
                if (line == "temperature-to-humidity map:")
                {
                    listName = "temperatureToHumidity";
                }
                if (line == "humidity-to-location map:")
                {
                    listName = "humidityToLocation";
                }
                if (line != "" && char.IsDigit(line[0]))
                {
                    switch (listName)
                    {
                        case "seedToSoil":
                            seedToSoil.Add(fillList(line));
                            break;
                        case "soilToFertilizer":
                            soilToFertilizer.Add(fillList(line));
                            break;
                        case "fertilizerToWater":
                            fertilizerToWater.Add(fillList(line));
                            break;
                        case "waterToLight":
                            waterToLight.Add(fillList(line));
                            break;
                        case "lightToTemperature":
                            lightToTemperature.Add(fillList(line));
                            break;
                        case "temperatureToHumidity":
                            temperatureToHumidity.Add(fillList(line));
                            break;
                        case "humidityToLocation":
                            humidityToLocation.Add(fillList(line));
                            break;
                    }

                }

            }
            long location = int.MaxValue;
            foreach (var seed in seeds)
            {
                long destination = 0;
                bool foundMatch = false;
                for (int i = 0; i < seedToSoil.Count; i++)
                {
                    long[] arrayTemp = seedToSoil[i];
                    if (seed >= arrayTemp[1] && seed <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = seed - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        foundMatch = true;
                        break;
                    }
                    if (!foundMatch)
                    {
                        destination = seed;
                    }
                }
                for (int i = 0; i < soilToFertilizer.Count; i++)
                {
                    long[] arrayTemp = soilToFertilizer[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                    }
                }
                for (int i = 0; i < fertilizerToWater.Count; i++)
                {
                    long[] arrayTemp = fertilizerToWater[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                    }
                }
                for (int i = 0; i < waterToLight.Count; i++)
                {
                    long[] arrayTemp = waterToLight[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                    }
                }
                for (int i = 0; i < lightToTemperature.Count; i++)
                {
                    long[] arrayTemp = lightToTemperature[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                    }
                }
                for (int i = 0; i < temperatureToHumidity.Count; i++)
                {
                    long[] arrayTemp = temperatureToHumidity[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                    }
                }
                for (int i = 0; i < humidityToLocation.Count; i++)
                {
                    long[] arrayTemp = humidityToLocation[i];
                    if (destination >= arrayTemp[1] && destination <= arrayTemp[1] + arrayTemp[2]-1)
                    {
                        long temp = destination - arrayTemp[1];
                        destination = arrayTemp[0] + temp;
                        break;
                        
                    }
                    
                }
                if (destination < location)
                {
                    location = destination;
                }
            }
            Console.WriteLine(location);
        }
        else
        {
            Console.WriteLine("Die Datei existiert nicht.");
        }
        
    }
    static long[] fillList(string line)
    {
        long[] values = new long[3];
        string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbers.Length; i++)
        {
            values[i] = long.Parse(numbers[i]);
        }
        return values;
    }
}