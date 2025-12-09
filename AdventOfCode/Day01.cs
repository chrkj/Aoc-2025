using AoCHelper;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string[] _input;
    
    public Day01()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split('\n');
    }

    private static void Clamp(ref int number)
    {
        if (number is > 99 or < 0)
            number %= 100;
    }

    public override ValueTask<string> Solve_1()
    {
        int password = 0;
        int currentDialNumber = 50;
        foreach (string instruction in _input)
        {
            switch (instruction[0])
            {
                case 'L':
                    currentDialNumber -= int.Parse(instruction[1..]);
                    Clamp(ref currentDialNumber);
                    break;
                case 'R':
                    currentDialNumber += int.Parse(instruction[1..]);
                    Clamp(ref currentDialNumber);
                    break;
            }

            if (currentDialNumber == 0)
                password++;

        }
        return new ValueTask<string>(password.ToString());
    }
    
    public override ValueTask<string> Solve_2()
    {
        int password = 0;
        int currentDialNumber = 1000000000 + 50;;
        foreach (string instruction in _input)
        {
            switch (instruction[0])
            {
                case 'L':
                    for (int i = 0; i < int.Parse(instruction[1..]); i++)
                    {
                        currentDialNumber -= 1;
                        if ((currentDialNumber % 100) == 0)
                            password++;
                    }
                    break;
                case 'R':
                    for (int i = 0; i < int.Parse(instruction[1..]); i++)
                    {
                        currentDialNumber += 1;
                        if ((currentDialNumber % 100) == 0)
                            password++;
                    }
                    break;
            }
            
        }
        return new ValueTask<string>(password.ToString());
    }
}
