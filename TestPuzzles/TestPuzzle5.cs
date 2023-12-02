using AoC2020.Puzzles;

namespace TestPuzzles;

public class TestPuzzle5
{
    private readonly PuzzleInput _testInput = new("Input/test-input-05.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-05.txt");
    private readonly Puzzle5 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(820, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(933, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(711, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}