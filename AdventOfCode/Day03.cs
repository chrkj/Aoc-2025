using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode;

public partial class Day02 : BaseDay
{
    private readonly long[][] _input;
    
    public Day02()
    {
        string inputString = File.ReadAllText(InputFilePath);
        _input = inputString.Split(',').Select(s =>
        {
            string[] p = s.Split('-');
            return new[] { long.Parse(p[0]), long.Parse(p[1]) };
        }).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        long answer = 0;
        foreach (long[] range in _input)
        {
            for (long i = range[0]; i < range[1] + 1; i++)
            {
                if (i.ToString().Length % 2 != 0) 
                    continue;
                
                string asStr = i.ToString();
                int mid = asStr.Length / 2;
                string firstHalf = asStr[..mid];
                string secondHalf = asStr.Substring(mid, mid);

                if (firstHalf != secondHalf) 
                    continue;
                answer += i;
            }
        }
        return new ValueTask<string>(answer.ToString());
    }
    
    [GeneratedRegex(@"^(.+)\1+$")]
    private static partial Regex PrecompiledRegex();
    
    public override ValueTask<string> Solve_2()
    {
        long answer = 0;
        foreach (long[] range in _input)
        {
            for (long i = range[0]; i < range[1] + 1; i++)
            {
                var re = PrecompiledRegex();
                
                if (re.IsMatch(i.ToString()))
                    answer += i;
            }
        }
        return new ValueTask<string>(answer.ToString());
    }

    
}
