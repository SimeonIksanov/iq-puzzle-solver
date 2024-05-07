using Puzzle;

namespace PuzzleTests;

internal static class CompareUtils
{
    public static bool Equals(Piece sut, byte[,] expected)
    {
        if (sut.Figure.GetLength(0) != expected.GetLength(0)
            || sut.Figure.GetLength(1) != expected.GetLength(1))
            return false;
        
        for (int x = 0; x < expected.GetLength(0); x++)
        for (int y = 0; y < expected.GetLength(1); y++)
        {
            if (sut.Figure[x, y] != expected[x, y]) return false;
        }

        return true;
    }
}