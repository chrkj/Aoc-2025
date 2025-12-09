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
        long sumOfJolts = 0;
        foreach (string bank in _input)
        {
            int[] batteries = new int[12];
            int lastBatteryIndex = 0;
            int maxJoltValue = int.MinValue;
            for (int i = bank.Length + lastBatteryIndex - 12; i >= 0; i--)
            {
                if (bank[i] - '0' >= maxJoltValue)
                {
                    maxJoltValue = bank[i] - '0'; 
                    lastBatteryIndex = i;
                }
            }
            batteries[0] = lastBatteryIndex;
            
            for (int i = 1; i < 12; i++)
            {
                maxJoltValue = int.MinValue;
                for (int j = lastBatteryIndex + 1; j < bank.Length - 12 + i + 1; j++)
                {
                    if (bank[j] - '0' > maxJoltValue)
                    {
                        maxJoltValue = bank[j] - '0'; 
                        lastBatteryIndex = j;
                    }
                }
                batteries[i] = lastBatteryIndex;
            }

            sumOfJolts += 100000000000 * (long)(bank[batteries[0]] - '0') +
                10000000000 * (long)(bank[batteries[1]] - '0') +
                1000000000 * (long)(bank[batteries[2]] - '0') +
                100000000 * (long)(bank[batteries[3]] - '0') +
                10000000 * (long)(bank[batteries[4]] - '0') +
                1000000 * (long)(bank[batteries[5]] - '0') +
                100000 * (long)(bank[batteries[6]] - '0') +
                10000 * (long)(bank[batteries[7]] - '0') +
                1000 * (long)(bank[batteries[8]] - '0') +
                100 * (long)(bank[batteries[9]] - '0') +
                10 * (long)(bank[batteries[10]] - '0') +
                1 * (long)(bank[batteries[11]] - '0');
        }
        return new ValueTask<string>(sumOfJolts.ToString());
    }
}
