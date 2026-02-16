using System.Text;

namespace AdventOfCode2025;

public class DayFour : Solution<int, int>
{
    public override int PartOne()
    {
        var input = GetPuzzleInput("DayFour");
        // var input = GetPuzzleInput("DayFourMock");

        var neighbours = new HashSet<(int Row, int Column)>
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1)
        };
        int result = 0;

        for (int row = 0; row < input.Length; row++)
        {
            for (int column = 0; column < input[row].Length; column++)
            {
                if (input[row][column] != '@') continue;
                
                if (IsAccessible(row, column, input.Length, input[row].Length, neighbours, input)) 
                    result++;
            }
        }
        
        return result;
    }

    private bool IsAccessible(
        int row,
        int column,
        int totalRows,
        int totalColumns,
        HashSet<(int Row, int Column)> neighbours,
        string[] input)
    {
        return IsAccessible(row, column, totalRows, totalColumns, neighbours, input.Select(x => x.ToCharArray()).ToArray());
    }
    
    private bool IsAccessible(
        int row,
        int column,
        int totalRows,
        int totalColumns,
        HashSet<(int Row, int Column)> neighbours,
        char[][] input)
    {
        var neighboursToActuallyCheck = new HashSet<(int Row, int Column)>(neighbours);
        
        if (row == 0) neighboursToActuallyCheck.RemoveWhere(x => x.Row == -1);
        else if (row == totalRows - 1) neighboursToActuallyCheck.RemoveWhere(x => x.Row == 1);

        if (column == 0) neighboursToActuallyCheck.RemoveWhere(x => x.Column == -1);
        else if (column == totalColumns - 1) neighboursToActuallyCheck.RemoveWhere(x => x.Column == 1);

        int counter = 0;

        foreach (var neighbour in neighboursToActuallyCheck)
        {
            if (input[row + neighbour.Row][column + neighbour.Column] == '@') counter++;
        }

        return counter < 4;
    }

    public override int PartTwo()
    {
        var input = GetPuzzleInput("DayFour");
        
        char[][] parsedInput = input.Select(x => x.ToCharArray()).ToArray();
        
        var neighbours = new HashSet<(int Row, int Column)>
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1)
        };
        
        var removeThisRound = new HashSet<(int Row, int Column)>();
        
        int result = 0;

        while (true)
        {
            int operationsThisRound = 0;
            removeThisRound.Clear();
            
            for (int row = 0; row < parsedInput.Length; row++)
            {
                for (int column = 0; column < parsedInput[row].Length; column++)
                {
                    if (parsedInput[row][column] != '@') continue;

                    if (IsAccessible(row, column, parsedInput.Length, parsedInput[row].Length, neighbours, parsedInput))
                    {
                        removeThisRound.Add((row, column));
                    }
                }
            }

            foreach (var tuple in removeThisRound)
            {
                parsedInput[tuple.Row][tuple.Column] = '.';
                operationsThisRound++;
                result++;
            }
            
            if (operationsThisRound == 0)
            {
                return result;
            }
        }
    }
}