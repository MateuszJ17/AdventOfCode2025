namespace AdventOfCode2025;

public class DayTwo : Solution<long, int>
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
                
                if (IsInvalidId(currentNumber.ToString()))
                    result += currentNumber;
                currentNumber++;
            }
        }
        
        return result;
    }

    private bool IsInvalidId(string id)
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

    public override int PartTwo()
    {
        throw new NotImplementedException();
    }
}