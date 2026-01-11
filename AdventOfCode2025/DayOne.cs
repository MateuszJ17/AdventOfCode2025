namespace AdventOfCode2025;

public class DayOne : Solution<int, int>
{
    // 1084
    public override int PartOne()
    {
        var input = GetPuzzleInput("DayOne");
        int startPosition = 50;
        int result = 0;

        foreach (var line in input)
        {
            var direction = line[0];
            var directionSign = direction == 'L' ? -1 : 1;
            var numberOfTicks = int.Parse(line.AsSpan(1));

            var newPosition = (startPosition + (numberOfTicks * directionSign)) % 100;
            if (newPosition < 0)
                newPosition += 100;
            
            startPosition = newPosition;
            if (startPosition == 0)
                result++;
        }

        return result;
    }
    
    // 6475
    public override int PartTwo()
    {
        var input = GetPuzzleInput("DayOne");
        int startPosition = 50;
        int result = 0;

        foreach (var line in input)
        {
            var direction = line[0];
            var directionSign = direction == 'L' ? -1 : 1;
            var numberOfTicks = int.Parse(line.AsSpan(1));
            var originalPosition = startPosition;
            var endPosition = startPosition;

            if (directionSign > 0)
                endPosition += numberOfTicks;
            else
                endPosition -= numberOfTicks;

            result += numberOfTicks / 100;

            endPosition %= 100;
            if (endPosition < 0)
                endPosition += 100;

            if (originalPosition == 0)
            {
                startPosition = endPosition;
                continue;
            }

            if (endPosition == 0 ||
                (directionSign > 0 && endPosition < originalPosition) ||
                (directionSign < 0 && endPosition > originalPosition))
                result++;
            
            startPosition = endPosition;
        }

        return result;
    }
}