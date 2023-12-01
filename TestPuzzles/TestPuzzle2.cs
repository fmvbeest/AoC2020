using AoC2020.Puzzles;

namespace TestPuzzles;

public class TestPuzzle2
{
    private readonly PuzzleInput _testInput = new("Input/test-input-02.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-02.txt");
    private readonly Puzzle2 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(2, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(628, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(1, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(705, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}