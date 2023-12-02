namespace AoC2020.Puzzles;

public class Puzzle5 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/puzzle-input-05.txt";
    protected override string PuzzleTitle => "--- Day 5: Binary Boarding ---";

    private static int ParseBoardingPass(string s)
    {
        var lowerRow = 0;
        var upperRow = 127;

        var lowerCol = 0;
        var upperCol = 7;
        
        foreach (var c in s)
        {
            switch (c)
            {
                case 'F': upperRow -= Convert.ToInt32(Math.Ceiling((upperRow - (double)lowerRow) / 2));
                    break;
                case 'B': lowerRow += Convert.ToInt32(Math.Ceiling((upperRow - (double)lowerRow) / 2));
                    break;
                case 'L': upperCol -= Convert.ToInt32(Math.Ceiling((upperCol - (double)lowerCol) / 2));
                    break;
                case 'R': lowerCol += Convert.ToInt32(Math.Ceiling((upperCol - (double)lowerCol) / 2));
                    break;
            }
        }

        return lowerRow * 8 + lowerCol;
    }
    
    public override int PartOne(IEnumerable<string> input)
    {
        return input.Select(ParseBoardingPass).Max();
    }
    
    public override int PartTwo(IEnumerable<string> input)
    {
        var seatIds = new HashSet<int>();
        
        foreach (var line in input)
        {
            seatIds.Add(ParseBoardingPass(line));
        }
        
        var seatsLeft = Enumerable.Range(0, seatIds.Max())
            .Except(Enumerable.Range(0, 8))
            .Except(Enumerable.Range(127*8, 8))
            .Except(seatIds);
        
        return seatsLeft.First();
    }
    
    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}