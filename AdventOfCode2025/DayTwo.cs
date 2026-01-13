using System.Text;

namespace AdventOfCode2025;

public class DayTwo : Solution<long, long>
{
    public override long PartOne()
    {
        var input = GetPuzzleInput("DayTwo");
        var allIds = input[0].Split(',');
        long result = 0;

        foreach (var id in allIds)
        {
            var splitId = id.Split('-');
            var firstId = splitId[0];
            var secondId = splitId[1];

            var currentNumber = long.Parse(firstId);
            var rangeEnd = long.Parse(secondId);
            
            while (currentNumber <= rangeEnd)
            {
                var isNumberOfDigitsOdd = currentNumber.ToString().Length % 2 == 1;
                if (isNumberOfDigitsOdd)
                {
                    currentNumber++;
                    continue;
                }
                
                if (IsInvalidIdPartOne(currentNumber.ToString()))
                    result += currentNumber;
                currentNumber++;
            }
        }
        
        return result;
    }

    private bool IsInvalidIdPartOne(string id)
    {
        var idLength = id.Length;
        var counter = 0;

        for (int i = 0; i < idLength / 2; i++)
        {
            if (id[i] == id[(idLength / 2) + i])
                counter ++;
        }

        var result = counter == idLength / 2;
        
        return result;
    }

    public override long PartTwo()
    {
        var input = GetPuzzleInput("DayTwo");
        var allIds = input[0].Split(',');
        long result = 0;

        foreach (var id in allIds)
        {
            var splitId = id.Split('-');
            var firstId = splitId[0];
            var secondId = splitId[1];

            var currentNumber = long.Parse(firstId);
            var rangeEnd = long.Parse(secondId);
            
            while (currentNumber <= rangeEnd)
            {
                if (currentNumber.ToString().Length > 1 && IsInvalidIdPartTwo(currentNumber.ToString()))
                    result += currentNumber;
                currentNumber++;
            }
        }
        
        return result;
    }
    
    private bool IsInvalidIdPartTwo(string id)
    {
        var idLength = id.Length;
        
        var set = id.ToHashSet();

        // all digits are the same
        if (set.Count == 1)
            return true;

        var potentialSequence = new StringBuilder();

        for (int i = 0; i < idLength / 2; i++)
        {
            potentialSequence.Append(id[i]);
            
            if (i == 0 || idLength % potentialSequence.Length!= 0)
                continue;

            var testNumber = new StringBuilder(potentialSequence.ToString());
            var timesToAppend = idLength / potentialSequence.Length;
            
            for (int j = 0; j < timesToAppend - 1; j++)
                testNumber.Append(potentialSequence.ToString());
            
            if (testNumber.ToString() == id)
                return true;
        }

        return false;
    }
}