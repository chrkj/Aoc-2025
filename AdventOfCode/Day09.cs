using AoCHelper;

namespace AdventOfCode;

public partial class Day09 : BaseDay
{
    private long[][] _input;
    
    public Day09()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries).Select(x => x.Split(',').Select(long.Parse).ToArray()).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        long largestArea = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            for (int j = i + 1; j < _input.Length; j++)
            {
                //Console.WriteLine(_input[i][0]+","+_input[i][1]+"   "+_input[j][0]+","+_input[j][1]);
                //Console.WriteLine((Math.Abs(_input[i][0] - _input[j][0]) + 1) *
                //                 (Math.Abs(_input[i][1] - _input[j][1]) + 1));
                long area = (Math.Abs(_input[i][0] - _input[j][0]) + 1) * (Math.Abs(_input[i][1] - _input[j][1]) + 1);
                if (area > largestArea)
                    largestArea = area;
            }
        }
        return new ValueTask<string>(largestArea.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>();
    }

}

