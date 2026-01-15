using System.Text;

namespace AdventOfCode2025;

public class DayThree : Solution<int, int>
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

    public override int PartTwo()
    {
        throw new NotImplementedException();
    }
}