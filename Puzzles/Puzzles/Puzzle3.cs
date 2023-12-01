namespace AoC2020.Puzzles;

public class Puzzle3 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/puzzle-input-03.txt";
    protected override string PuzzleTitle => "--- Day 3: Toboggan Trajectory ---";

    private static bool CheckTree(string s, int index)
    {
        return s[index % s.Length] == '#';
    }

    private static int CountTreesInSlope(List<string> gridLines, int dx, int dy)
    {
        var numTrees = 0;
        var x = 0;
        var y = 0;
        
        while (y < gridLines.Count)
        {
            if (CheckTree(gridLines[y], x))
            {
                numTrees++;
            }

            x += dx;
            y += dy;
        }

        return numTrees;
    }
    
    public override int PartOne(IEnumerable<string> input)
    {
        return CountTreesInSlope(input.ToList(), 3, 1);
    }
    
    public override int PartTwo(IEnumerable<string> input)
    {
        var gridLines = input.ToList();
        var slopes = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
        
        var numTrees = 1;
        foreach (var (dx, dy) in slopes)
        {
            numTrees *= CountTreesInSlope(gridLines, dx, dy);
        }
        return numTrees;
    }
    
    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}