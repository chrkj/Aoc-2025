using AoCHelper;

switch (args.Length)
{
    case 0:
        await Solver.SolveLast(opt => opt.ClearConsole = true);
        break;
    case 1 when args[0].Contains("all", StringComparison.CurrentCultureIgnoreCase):
        await Solver.SolveAll(opt =>
        {
            opt.ShowConstructorElapsedTime = true;
            opt.ShowTotalElapsedTimePerDay = true;
            opt.ShowOverallResults = true;
        });
        break;
    case 1:
        await Solver.Solve(new List<uint> { uint.Parse(args[0]) });
        break;
    default:
    {
        var indexes = args.Select(arg => uint.TryParse(arg, out var index) ? index : uint.MaxValue);

        await Solver.Solve(indexes.Where(i => i < uint.MaxValue));
        break;
    }
}
