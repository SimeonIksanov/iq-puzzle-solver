using Puzzle;

namespace PuzzleTests;

public class PieceTests
{
    [Theory]
    [MemberData(nameof(ProvideTestData))]
    public void GetLeftTopCoords_WhenCorrectFigure_ReturnsCoords(Piece piece, (int x, int y) expected)
    {
        // Arrange
        // Act
        var actual = piece.GetLeftTopCoords();
        // Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<Object[]> ProvideTestData()
    {
        yield return [new Piece01(), (0, 1)];
        yield return [new Piece02(), (0, 0)];
        yield return [new Piece03(), (0, 0)];
        yield return [new Piece04(), (0, 0)];
    }
}