using System.Text;

namespace AdventOfCode2025;

public class DayThree : Solution<int, long>
{
    public override int PartOne()
    {
        var input = GetPuzzleInput("DayThree");
        // var input = new List<string>
        // {
        //     "818181911112111"
        // };
        
        int result = 0;
        var combined = new StringBuilder();

        foreach (var bank in input)
        {
            char firstNum = '0';
            char secondNum = '0';

            int secondStartingIndex = 1;

            for (int i = 0; i < bank.Length - 1; i++)
            {
                if (bank[i] > firstNum)
                {
                    firstNum = bank[i];
                    secondStartingIndex = i + 1;
                }
            }

            for (int i = secondStartingIndex; i < bank.Length; i++)
            {
                if (bank[i] > secondNum) secondNum = bank[i];
            }

            combined.Append(firstNum);
            combined.Append(secondNum);
            
            result += int.Parse(combined.ToString());
            
            combined.Clear();
        }

        return result;
    }

    public override long PartTwo()
    {
        var input = GetPuzzleInput("DayThree");
        
        long result = 0;
        var combined = new StringBuilder();

        foreach (var bank in input)
        {
            int counter = 12;
            int startIndex = 0;
            
            for (int i = 0; i < 12; i++)
            {
                char bestPick = '0';
                int bestPickIndex = 0;
                
                for (int j = startIndex; j <= bank.Length - counter; j++)
                {
                    if (bank[j] > bestPick)
                    {
                        bestPick = bank[j];
                        bestPickIndex = j;
                    }
                }
                
                combined.Append(bestPick);
                startIndex = bestPickIndex + 1;
                counter--;
            }
            
            result += long.Parse(combined.ToString());
            
            combined.Clear();
        }

        return result;
    }
}