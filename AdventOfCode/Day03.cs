using AoCHelper;

namespace AdventOfCode;

public partial class Day03 : BaseDay
{
    private readonly string[] _input;
    
    public Day03()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries);
    }

    public override ValueTask<string> Solve_1()
    {
        long sumOfJolts = 0;
        foreach (string bank in _input)
        {
            int maxJoltValueLeft = int.MinValue;
            int maxJoltIndexLeft = 0;
            for (int i = bank.Length - 2; i >= 0; i--)
            {
                if (bank[i] - '0' >= maxJoltValueLeft)
                {
                    maxJoltValueLeft = bank[i] - '0'; 
                    maxJoltIndexLeft = i;
                }
            }
            int maxJoltValueRight = int.MinValue;
            for (int i = maxJoltIndexLeft + 1; i < bank.Length; i++)
            {
                if (bank[i] - '0' >= maxJoltValueRight)
                {
                    maxJoltValueRight = bank[i] - '0';
                }
            }
            sumOfJolts += maxJoltValueLeft * 10 + maxJoltValueRight;
        }
        return new ValueTask<string>(sumOfJolts.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>();
    }

    
}
