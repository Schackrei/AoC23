class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        if (File.Exists(filePath))
        {
            int sum = 0;
            int product = 0;
            int tempProduct = 1;
            
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    char c = lines[i][j];
                    if (!char.IsDigit(c) && c != '.')
                    {
                        int numbNeighbours = checkNumberOfNeighbours(lines, i,j);
                        if (numbNeighbours == 2)
                        {
                            List<string> strings = new List<string>();
                            List<int> Numbers = new List<int>();
                            List<string> sth = checkSurroundingPart2(lines, i, j, 0);
                            foreach (var item in sth)
                            {
                                strings.Add(item);
                            }
                            sth = checkSurroundingPart2(lines, i, j, 1);
                            foreach (var item in sth)
                            {
                                strings.Add(item);
                            }
                            sth = checkSurroundingPart2(lines, i, j, -1);
                            foreach (var item in sth)
                            {
                                strings.Add(item);
                            }
                            
                            foreach (var item in strings)
                            {
                                Numbers.Add(int.Parse(item));
                            }
                            foreach (var item in Numbers)
                            {
                                if (item != 0)
                                {
                                    tempProduct *= item;

                                }
                            }
                            
                            product += tempProduct;
                            tempProduct = 1;
                        }

                        if (i > 0)
                        {
                            sum += checkSurrounding(lines, i, j, -1);
                        }
                        sum += checkSurrounding(lines, i, j, 0);
                        if (i < lines.Length)
                        {
                        sum += checkSurrounding(lines, i, j, 1);
                        }
                    }
                }

            }
            Console.WriteLine(sum);
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine("Die Datei existiert nicht.");
        }
    }
    static int checkNumberOfNeighbours(string[] lines, int i, int j)
    {
        int numbNeighbours = 0;
        if (i > 0)
        {
           if (char.IsDigit(lines[i-1][j])){numbNeighbours++;}
           else
           {
           if (j - 1 >= 0 && char.IsDigit(lines[i-1][j-1])){numbNeighbours++;}
           if (j + 1 <= lines.Length-1 && char.IsDigit(lines[i-1][j+1])){numbNeighbours++;}
           }
        }
        if (j - 1 >= 0 && char.IsDigit(lines[i][j-1])){numbNeighbours++;}
        if (j - 1 >= 0 && char.IsDigit(lines[i][j+1])){numbNeighbours++;}
        if (i < lines.Length-1)
        {
            if (char.IsDigit(lines[i+1][j])){numbNeighbours++;}
            else
            {
            if (j - 1 >= 0 && char.IsDigit(lines[i+1][j-1])){numbNeighbours++;}
            if (j + 1 <= lines.Length-1 && char.IsDigit(lines[i+1][j+1])){numbNeighbours++;}
            }
        }
        return numbNeighbours;
    }
    static List<string> checkSurroundingPart2(string[] lines, int i, int j, int d)
    {
        string temp = "";
        int tempNumb = 0;
        List<string> seperateNumbers = new List<string>();
        char cNext = lines[i+d][j];
        List<char> numbers = new List<char>();
        if (char.IsDigit(cNext))
        {
                int counter = 0;
                
                while (j-counter >= 0 &&char.IsDigit(lines[i+d][j-counter]))
                {
                    numbers.Insert(0,lines[i+d][j-counter]);
                    counter++;
                }
                counter = 1;
                while (j + counter <= lines.Length -1 && char.IsDigit(lines[i+d][j+counter]))
                {
                    numbers.Add(lines[i+d][j+counter]);
                    counter++;
                }
            
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                seperateNumbers.Add(temp);
                tempNumb = int.Parse(temp);
                temp = "";
            }
        }
        else
        {
            numbers = new List<char>();

            if (char.IsDigit(lines[i+d][j-1]))
            {
                int counter = 1;
                
                while (j-counter >= 0 && char.IsDigit(lines[i+d][j-counter]))
                {
                    numbers.Insert(0,lines[i+d][j-counter]);
                    counter++;
                }

            }
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                seperateNumbers.Add(temp);
                tempNumb += int.Parse(temp);
                temp = "";
            }
            numbers = new List<char>();

            if (char.IsDigit(lines[i+d][j+1]))
            {
                int counter = 1;
                while (j + counter <= lines.Length -1 && char.IsDigit(lines[i+d][j+counter]))
                {
                    numbers.Add(lines[i+d][j+counter]);
                    counter++;
                } 
            }
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                seperateNumbers.Add(temp);
                tempNumb += int.Parse(temp);
                temp = "";
            }
        }
        return seperateNumbers;
    }
    static int checkSurrounding(string[] lines, int i, int j, int d)
    {
        string temp = "";
        int tempNumb = 0;
        char cNext = lines[i+d][j];
        List<char> numbers = new List<char>();
        if (char.IsDigit(cNext))
        {
                int counter = 0;
                
                while (j-counter >= 0 &&char.IsDigit(lines[i+d][j-counter]))
                {
                    numbers.Insert(0,lines[i+d][j-counter]);
                    counter++;
                }
                counter = 1;
                while (j + counter <= lines.Length -1 && char.IsDigit(lines[i+d][j+counter]))
                {
                    numbers.Add(lines[i+d][j+counter]);
                    counter++;
                }
            
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                tempNumb = int.Parse(temp);
                temp = "";
            }
        }
        else
        {
            numbers = new List<char>();

            if (char.IsDigit(lines[i+d][j-1]))
            {
                int counter = 1;
                
                while (j-counter >= 0 && char.IsDigit(lines[i+d][j-counter]))
                {
                    numbers.Insert(0,lines[i+d][j-counter]);
                    counter++;
                }

            }
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                tempNumb += int.Parse(temp);
                temp = "";
            }
            numbers = new List<char>();

            if (char.IsDigit(lines[i+d][j+1]))
            {
                int counter = 1;
                while (j + counter <= lines.Length -1 && char.IsDigit(lines[i+d][j+counter]))
                {
                    numbers.Add(lines[i+d][j+counter]);
                    counter++;
                } 
            }
            foreach (char c in numbers)
            {
                temp += c;
            }
            if (temp != "")
            {
                tempNumb += int.Parse(temp);
                temp = "";
            }
        }
        return tempNumb;
    }
}
