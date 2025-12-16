using AoCHelper;

namespace AdventOfCode;

public partial class Day07 : BaseDay
{
    private char[][] _input;
    
    public Day07()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries).Select(x => x.ToCharArray()).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        long splits = 0;
        int startIndex = Array.IndexOf(_input[0], 'S');
        _input[1][startIndex] = '|';
        for (int row = 1; row < _input.Length - 1; row++)
        {
            for (int col = 0; col < _input[row].Length; col++)
            {
                if (_input[row][col] == '|')
                {
                    if (_input[row + 1][col] == '^')
                    {
                        _input[row + 1][col - 1] = '|';
                        _input[row + 1][col + 1] = '|';
                        splits++;
                    }
                    else
                    {
                        _input[row + 1][col] = '|';
                    }
                }
            }
        }
        return new ValueTask<string>(splits.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        // DFS
        return new ValueTask<string>();
    }
}
