using AoC2020.Puzzles;

namespace TestPuzzles;

public class TestPuzzle4
{
    private readonly PuzzleInput _testInput = new("Input/test-input-04.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-04.txt");
    private readonly Puzzle4 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(2, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(213, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(2, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(147, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}