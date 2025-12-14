using AoCHelper;

namespace AdventOfCode;

public partial class Day06 : BaseDay
{
    private readonly string[][] _input;
    
    public Day06()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries).Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        long sum = 0;
        for (int i = 0; i < _input[0].Length; i++)
        {
            long runningSum = long.Parse(_input[0][i]);
            for (int j = 1; j < _input.Length - 1; j++)
            {
                switch (_input[^1][i])
                {
                    case "*":
                        runningSum *= long.Parse(_input[j][i]);
                        break;
                    case "+":
                        runningSum += long.Parse(_input[j][i]);
                        break;
                }
            }
            sum += runningSum;
        }
        return new ValueTask<string>(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>();
    }
}
