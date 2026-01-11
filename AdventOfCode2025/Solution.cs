namespace AdventOfCode2025;

public abstract class Solution<T1, T2>
{
    public abstract T1 PartOne();
    public abstract T2 PartTwo();

    protected string[] GetPuzzleInput(string puzzleName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "PuzzlesInputs", $"{puzzleName}.txt");
        
        if (!Path.Exists(path))
        {
            Console.WriteLine("Input file not found");
            return [];
        }
        
        return File.ReadAllLines(path);
    }
}