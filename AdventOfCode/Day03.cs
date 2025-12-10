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

            sumOfJolts += 
                100000000000L * (bank[batteries[0]] - '0') +
                10000000000L * (bank[batteries[1]] - '0') +
                1000000000L * (bank[batteries[2]] - '0') +
                100000000L * (bank[batteries[3]] - '0') +
                10000000L * (bank[batteries[4]] - '0') +
                1000000L * (bank[batteries[5]] - '0') +
                100000L * (bank[batteries[6]] - '0') +
                10000L * (bank[batteries[7]] - '0') +
                1000L * (bank[batteries[8]] - '0') +
                100L * (bank[batteries[9]] - '0') +
                10L * (bank[batteries[10]] - '0') +
                1L * (bank[batteries[11]] - '0');
        }
        return new ValueTask<string>(sumOfJolts.ToString());
    }
}
