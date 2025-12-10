using AoCHelper;

namespace AdventOfCode;

public partial class Day04 : BaseDay
{
    private readonly char[][] _input;

    private readonly int[][] _offsets  =
    [
        [1,  0],  
        [1,  1],  
        [0,  1],  
        [-1,  1], 
        [-1,  0], 
        [-1, -1], 
        [0, -1],  
        [1, -1]   
    ];
    
    public Day04()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split("\n", StringSplitOptions.TrimEntries).Select(s => s.ToArray()).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        int accessibleRolls = 0;
        for (int row = 0; row < _input.Length; row++)
        {
            for (int col = 0; col < _input[0].Length; col++)
            {
                if (_input[row][col] != '@')
                    continue;
                
                int adjRollCount = 0;
                foreach (int[] dir in _offsets)
                {
                    if (!Utils.IsWithinBounds(_input, row+dir[0], col+dir[1]))
                        continue;
                    if (_input[row+dir[0]][col+dir[1]] == '@')
                        adjRollCount++;
                    if (adjRollCount == 4)
                        break;
                }

                if (adjRollCount < 4)
                    accessibleRolls++;
            }
        }
        return new ValueTask<string>(accessibleRolls.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int removedRolls = 0;
        int removedThisIter = 1;
        while (removedThisIter != 0)
        {
            removedThisIter = 0;
            for (int row = 0; row < _input.Length; row++)
            {
                for (int col = 0; col < _input[0].Length; col++)
                {
                    if (_input[row][col] != '@')
                        continue;

                    int adjRollCount = 0;
                    foreach (int[] dir in _offsets)
                    {
                        if (!Utils.IsWithinBounds(_input, row + dir[0], col + dir[1]))
                            continue;
                        if (_input[row + dir[0]][col + dir[1]] == '@')
                            adjRollCount++;
                        if (adjRollCount == 4)
                            break;
                    }

                    if (adjRollCount < 4)
                    {
                        _input[row][col] = '.';
                        removedRolls++;
                        removedThisIter++;
                    }
                }
            }
        }
        return new ValueTask<string>(removedRolls.ToString());
    }
}
