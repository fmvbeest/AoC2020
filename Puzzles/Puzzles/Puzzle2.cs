namespace AoC2020.Puzzles;

public class Puzzle2 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/puzzle-input-02.txt";
    protected override string PuzzleTitle => "--- Day 2: Password Philosophy ---";

    private static bool ValidPassword(string s, bool countPolicy = true)
    {
        var data = s.Split(':');
        var password = data[1].Trim();

        data = data[0].Split(' ');
        var target = data[1][0];
        data = data[0].Split('-');
        var min = int.Parse(data[0]);
        var max = int.Parse(data[1]);

        if (countPolicy)
        {
            var count = password.Count(c => c == target);

            return count >= min && count <= max;
        }

        return password[min - 1] == target ^ password[max - 1] == target;
    }
    
    public override int PartOne(IEnumerable<string> input)
    {
        return input.Count(line => ValidPassword(line));
    }
    
    public override int PartTwo(IEnumerable<string> input)
    {
        return input.Count(line => ValidPassword(line, countPolicy:false));
    }
    
    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}