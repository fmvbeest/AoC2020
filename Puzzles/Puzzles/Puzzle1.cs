namespace AoC2020.Puzzles;

public class Puzzle1 : PuzzleBase<IEnumerable<int>, int, int>
{
    protected override string Filename => "Input/puzzle-input-01.txt";
    protected override string PuzzleTitle => "--- Day 1: Report Repair ---";
    
    public override int PartOne(IEnumerable<int> input)
    {
        var report = input.ToList();
        return report.Where(x => report.Contains(2020 - x)).Select(x => x * (2020 - x)).FirstOrDefault();
    }
    
    public override int PartTwo(IEnumerable<int> input)
    {
        var report = input.ToList();
        return (from x in report from y in report.Where(y => report.Contains(2020 - (x + y))) 
            select x * y * (2020 - (x + y))).FirstOrDefault();
    }
    
    public override IEnumerable<int> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(int.Parse);
    }
}