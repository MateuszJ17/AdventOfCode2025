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
        throw new NotImplementedException();
    }
}