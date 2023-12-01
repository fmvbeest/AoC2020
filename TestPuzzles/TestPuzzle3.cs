using AoC2020.Puzzles;

namespace TestPuzzles;

public class TestPuzzle3
{
    private readonly PuzzleInput _testInput = new("Input/test-input-03.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-03.txt");
    private readonly Puzzle3 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(7, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(270, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(336, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(2122848000, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}