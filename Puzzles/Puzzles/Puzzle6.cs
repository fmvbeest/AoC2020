namespace AoC2020.Puzzles;

public class Puzzle6 : PuzzleBase<IEnumerable<IEnumerable<string>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-06.txt";
    protected override string PuzzleTitle => "--- Day 6: Custom Customs ---";

    private static int CountDistinctQuestions(IEnumerable<string> answeredQuestions)
    {
        return string.Join("", answeredQuestions).Distinct().Count();
    }
    
    private int CountDistinctQuestions2(IEnumerable<string> answeredQuestions)
    {
        answeredQuestions = answeredQuestions.ToArray();
        var commonAnswered = answeredQuestions.First().ToCharArray();
        
        foreach (var answers in answeredQuestions)
        {
            if (string.IsNullOrEmpty(answers)) continue;
            commonAnswered = commonAnswered.Intersect(answers).ToArray();
        }
        
        return commonAnswered.Distinct().Count();
    }
    
    public override int PartOne(IEnumerable<IEnumerable<string>> input)
    {
        return input.Sum(CountDistinctQuestions);
    }
    
    public override int PartTwo(IEnumerable<IEnumerable<string>> input)
    {
        return input.Sum(CountDistinctQuestions2);
    }
    
    public override IEnumerable<IEnumerable<string>> Preprocess(IPuzzleInput input, int part = 1)
    {
        var index = 0;
        return input.GetAllLines().
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++);
    }
}