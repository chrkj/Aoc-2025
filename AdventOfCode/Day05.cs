using AoCHelper;

namespace AdventOfCode;

public partial class Day05 : BaseDay
{
    private readonly string[] _input;
    
    public Day05()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries);
    }

    public override ValueTask<string> Solve_1()
    {
        int splitIndex = Array.IndexOf(_input, "");
        string[] rangeInput = _input.Take(splitIndex).ToArray();
        string[] idInput = _input.Skip(splitIndex + 1).ToArray();
        
        List<(long, long)> ranges = [];
        foreach (string range in rangeInput)
        {
            string[] strRange = range.Split("-");
            ranges.Add(new ValueTuple<long, long>(long.Parse(strRange[0]),long.Parse(strRange[1])));
        }

        int spoiledFoodCount = 0;
        foreach (string id in idInput)
        {
            bool spoiled = true;
            foreach (var range in ranges)
            {
                if (long.Parse(id) >= range.Item1 && long.Parse(id) <= range.Item2)
                {
                    spoiled = false;
                    break;
                }
            }

            if (!spoiled)
                spoiledFoodCount++;
        }
        return new ValueTask<string>(spoiledFoodCount.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int splitIndex = Array.IndexOf(_input, "");
        string[] rangeInput = _input.Take(splitIndex).ToArray();
        List<(long, long)> finalRanges = [];
        
        List<(long, long)> ranges = [];
        foreach (string range in rangeInput)
        {
            string[] strRange = range.Split("-");
            ranges.Add(new ValueTuple<long, long>(long.Parse(strRange[0]),long.Parse(strRange[1])));
        }
        ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        long currentMinRange = ranges[0].Item1;
        long currentMaxRange = ranges[0].Item2;
        for (int i = 1; i < ranges.Count; i++)
        {
            if (ranges[i].Item1 <= currentMaxRange)
            {
                if (ranges[i].Item2 > currentMaxRange)
                    currentMaxRange = ranges[i].Item2;
            }
            else
            {
                finalRanges.Add(new ValueTuple<long, long>(currentMinRange,currentMaxRange));
                currentMinRange = ranges[i].Item1;
                currentMaxRange = ranges[i].Item2;
            }
        }
        finalRanges.Add(new ValueTuple<long, long>(currentMinRange,currentMaxRange));

        long sum = 0;
        foreach (var finalRange in finalRanges)
            sum += finalRange.Item2 - finalRange.Item1 + 1;
        return new ValueTask<string>(sum.ToString());
    }
}
