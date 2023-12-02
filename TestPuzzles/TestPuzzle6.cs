using AoC2020.Puzzles;

namespace TestPuzzles;

public class TestPuzzle6
{
    private readonly PuzzleInput _testInput = new("Input/test-input-06.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-06.txt");
    private readonly Puzzle6 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(11, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(6506, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(6, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(3243, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}