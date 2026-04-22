using AoCHelper;

namespace AdventOfCode;

public partial class Day08 : BaseDay
{
    private int[][] _input;
    
    public Day08()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries).Select(x => x.Split(',').Select(int.Parse).ToArray()).ToArray();
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
