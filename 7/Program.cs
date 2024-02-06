using System.Diagnostics.Metrics;

class Program
{
    static string filePath = "input.txt";
    static string[] lines = File.ReadAllLines(filePath);
    static void Main()
    {
        int[] bids = new int[lines.Length];
        int[][] hands = new int[lines.Length][];
        int counter = 1;
        List<int> fives = new List<int>();
        List<int> fours = new List<int>();
        List<int> houses = new List<int>();
        List<int> trios = new List<int>();
        List<int> duos = new List<int>();
        List<int> pair = new List<int>();
        List<int> highcard = new List<int>();
        foreach (var line in lines)
        {
            string tempHand = line.Substring(0,5);
            bids[counter-1] = int.Parse(line.Substring(6, line.Length -6));
            int[] values = new int[12];
            values[0] = countAppereance(tempHand, 'A');
            values[1] = countAppereance(tempHand, 'K');
            values[2] = countAppereance(tempHand, 'Q');
            //values[3] = countAppereance(tempHand, 'J');
            values[3] = countAppereance(tempHand, 'T');
            values[4] = countAppereance(tempHand, '9');
            values[5] = countAppereance(tempHand, '8');
            values[6] = countAppereance(tempHand, '7');
            values[7] = countAppereance(tempHand, '6');
            values[8] = countAppereance(tempHand, '5');
            values[9] = countAppereance(tempHand, '4');
            values[10] = countAppereance(tempHand, '3');
            values[11] = countAppereance(tempHand, '2');
            //part 2
            int joker = countAppereance(tempHand, 'J');
            
            if (values.Contains(1))
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 1 + joker;           
            }
            int pairCounter = 0;
            foreach (var c in values)
            {
                if (c == 2)
                {
                    pairCounter++;
                }
            }
            if (joker == 2)
            {
                pairCounter++;
            }
            if (pairCounter == 1)
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 2;
            }
            if (pairCounter == 2)
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 3;
            }
            if (values.Contains(3))
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 4;
            }
            if (values.Contains(4))
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 6;
            }
            if (values.Contains(5))
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 7;
            }
            if (values.Contains(2) && values.Contains(3))
            {
                hands[counter-1] = new int[2];
                hands[counter-1][0] = counter-1;
                hands[counter-1][1] = 5;
            }
            counter++;
        }
        foreach (var x in hands)
        {
            switch (x[1])
            {
                case 7:
                fives.Add(x[0]);
                break;
                case 6:
                fours.Add(x[0]);
                break;
                case 5:
                houses.Add(x[0]);
                break;
                case 4:
                trios.Add(x[0]);
                break;
                case 3:
                duos.Add(x[0]);
                break;
                case 2:
                pair.Add(x[0]);
                break;
                case 1:
                highcard.Add(x[0]);
                break;
            }
        }
        
        fives = sortList(fives);
        fours = sortList(fours);
        houses = sortList(houses);
        trios = sortList(trios);
        duos = sortList(duos);
        pair = sortList(pair);
        highcard = sortList(highcard);
        int sum = 0;
        int multi = 1;
        for (int i = 0; i < highcard.Count(); i++)
        {
            sum += bids[highcard[i]] * multi;
            multi++;
        }
        for (int i = 0; i < pair.Count(); i++)
        {
            sum += bids[pair[i]] * multi;
            multi++;
        }
        for (int i = 0; i < duos.Count(); i++)
        {
            sum += bids[duos[i]] * multi;
            multi++;
        }
        for (int i = 0; i < trios.Count(); i++)
        {            
            sum += bids[trios[i]] * multi;
            multi++;
        }
        for (int i = 0; i < houses.Count(); i++)
        {
            sum += bids[houses[i]] * multi;
            multi++;
        }
        for (int i = 0; i < fours.Count(); i++)
        {
            sum += bids[fours[i]] * multi;
            multi++;
        }
        for (int i = 0; i < fives.Count(); i++)
        {
            sum += bids[fives[i]] * multi;
            multi++;
        }

        Console.WriteLine(sum);
    }
    static List<int> sortList(List<int> list)
    {
        bool change = true;
        while (change)
        {
            change = false;
            for (int i = 0; i < list.Count()-1; i++)
            {
                string orig = lines[list[i]];
                string compare = lines[list[i+1]];
                if (sortCards2(orig, compare))
                {
                    int temp = list[i];
                    list[i] = list[i+1];
                    list[i+1] = temp;
                    change = true;
                }
            }
        }
        return list;
    }
    static int countAppereance(string line , char card)
    {
        int temp = 0;
        foreach (var item in line)
        {
            if (item == card)
            {
                temp++;
            }
        }
        return temp;
    }
    static bool sortCards(string orig, string compare)
    {
        for (int i = 0; i < orig.Length; i++)
        {
            char cOrig = orig[i];
            char cCompare = compare[i];
            int valueOrig = 0;
            int valueCompare = 0;

            switch (cOrig)
            {
                case 'A':
                    valueOrig = 14;
                    break;
                case 'K':
                    valueOrig = 13;
                    break;
                case 'Q':
                    valueOrig = 12;
                    break;
                case 'J':
                    valueOrig = 11;
                    break;
                case 'T':
                    valueOrig = 10;
                    break;
                default:
                    valueOrig = int.Parse(cOrig.ToString());
                    break;
            }

            switch (cCompare)
            {
                case 'A':
                    valueCompare = 14;
                    break;
                case 'K':
                    valueCompare = 13;
                    break;
                case 'Q':
                    valueCompare = 12;
                    break;
                case 'J':
                    valueCompare = 11;
                    break;
                case 'T':
                    valueCompare = 10;
                    break;
                default:
                    valueCompare = int.Parse(cCompare.ToString());
                    break;
            }

            if (valueOrig == valueCompare)
            {
                
            }
            if (valueOrig < valueCompare)
            {
                return false;
            }
            if (valueOrig > valueCompare)
            {
                return true;
            }
        }
        return false;
    }
    static bool sortCards2(string orig, string compare)
    {
        for (int i = 0; i < orig.Length; i++)
        {
            char cOrig = orig[i];
            char cCompare = compare[i];
            int valueOrig = 0;
            int valueCompare = 0;

            switch (cOrig)
            {
                case 'A':
                    valueOrig = 14;
                    break;
                case 'K':
                    valueOrig = 13;
                    break;
                case 'Q':
                    valueOrig = 12;
                    break;
                case 'J':
                    valueOrig = 1;
                    break;
                case 'T':
                    valueOrig = 10;
                    break;
                default:
                    valueOrig = int.Parse(cOrig.ToString());
                    break;
            }

            switch (cCompare)
            {
                case 'A':
                    valueCompare = 14;
                    break;
                case 'K':
                    valueCompare = 13;
                    break;
                case 'Q':
                    valueCompare = 12;
                    break;
                case 'J':
                    valueCompare = 1;
                    break;
                case 'T':
                    valueCompare = 10;
                    break;
                default:
                    valueCompare = int.Parse(cCompare.ToString());
                    break;
            }

            if (valueOrig == valueCompare)
            {
                
            }
            if (valueOrig < valueCompare)
            {
                return false;
            }
            if (valueOrig > valueCompare)
            {
                return true;
            }
        }
        return false;
    }
}