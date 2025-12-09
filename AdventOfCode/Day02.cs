using AoCHelper;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly int[][] _input;
    
    public Day02()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split(',').Select(s =>
        {
            string[] p = s.Split('-');
            return new[] { int.Parse(p[0]), int.Parse(p[1]) };
        }).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>();
    }
    
    public override ValueTask<string> Solve_2()
    {
        
        return new ValueTask<string>();
    }
}
