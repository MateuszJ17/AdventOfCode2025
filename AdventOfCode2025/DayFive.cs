namespace AdventOfCode2025;

public class DayFive : Solution<int, int>
{
    public override int PartOne()
    {
        var input = GetPuzzleInput("DayFive");
        int result = 0;
        
        var emptyLineIndex = Array.IndexOf(input, "");
        string[] ranges = input[..emptyLineIndex];
        string[] ingredients = input[(emptyLineIndex + 1)..].ToArray();

        (long RangeStart, long RangeEnd)[] rangesParsed = ranges.Select(x => x.Split('-')).Select(x => (long.Parse(x[0]), long.Parse(x[1]))).ToArray();

        foreach (var ingredient in ingredients)
        {
            long ingredientId = long.Parse(ingredient);
            foreach (var range in rangesParsed)
            {
                if (ingredientId >= range.RangeStart && ingredientId <= range.RangeEnd)
                {
                    result++;
                    break;
                }
            }
        }
        
        return result;
    }

    public override int PartTwo()
    {
        throw new NotImplementedException();
    }
}