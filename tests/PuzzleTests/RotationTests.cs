using Puzzle;

namespace PuzzleTests;

public class RotationTests
{
    [Theory]
    [MemberData(nameof(ProvideTestData))]
    public void RotateAntiClockWiseXTimes(Piece sut, int count, byte[,] expected)
    {
        // Arrange
        for (int x = 0; x < count - 1; x++)
            sut.Rotate();

        // Act
        sut.Rotate();

        // Assert
        Assert.True(CompareUtils.Equals(sut, expected));
    }

    public static IEnumerable<object[]> ProvideTestData()
    {
        yield return [new Piece01(), 1, new byte[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }];
        yield return [new Piece01(), 2, new byte[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }];
        yield return [new Piece01(), 3, new byte[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }];
        yield return [new Piece01(), 4, new byte[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }];

        yield return [new Piece02(), 1, new byte[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }];
        yield return [new Piece02(), 2, new byte[,] { { 0, 0, 1 }, { 0, 0, 1 }, { 1, 1, 1 } }];
        yield return [new Piece02(), 3, new byte[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } }];
        yield return [new Piece02(), 4, new byte[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 1, 0, 0 } }];

        yield return [new Piece03(), 1, new byte[,] { { 1, 1, 1 }, { 0, 1, 1 } }];
        yield return [new Piece03(), 2, new byte[,] { { 0, 1 }, { 1, 1 }, { 1, 1 } }];
        yield return [new Piece03(), 3, new byte[,] { { 1, 1, 0 }, { 1, 1, 1 } }];
        yield return [new Piece03(), 4, new byte[,] { { 1, 1 }, { 1, 1 }, { 1, 0 } }];

        yield return [new Piece04(), 1, new byte[,] { { 1, 1, 1 }, { 1, 0, 1 } }];
        yield return [new Piece04(), 2, new byte[,] { { 1, 1 }, { 0, 1 }, { 1, 1 } }];
        yield return [new Piece04(), 3, new byte[,] { { 1, 0, 1 }, { 1, 1, 1 } }];
        yield return [new Piece04(), 4, new byte[,] { { 1, 1 }, { 1, 0 }, { 1, 1 } }];

        yield return [new Piece05(), 1, new byte[,] { { 1 }, { 1 }, { 1 }, { 1 } }];
        yield return [new Piece05(), 2, new byte[,] { { 1, 1, 1, 1 } }];
        yield return [new Piece05(), 3, new byte[,] { { 1 }, { 1 }, { 1 }, { 1 } }];
        yield return [new Piece05(), 4, new byte[,] { { 1, 1, 1, 1 } }];

        yield return [new Piece06(), 1, new byte[,] { { 1, 1 }, { 1, 1 } }];
        yield return [new Piece06(), 2, new byte[,] { { 1, 1 }, { 1, 1 } }];

        yield return [new Piece07(), 1, new byte[,] { { 1, 1 }, { 0, 1 }, { 0, 1 }, { 0, 1 } }];
        yield return [new Piece07(), 2, new byte[,] { { 0, 0, 0, 1 }, { 1, 1, 1, 1 } }];
        yield return [new Piece07(), 3, new byte[,] { { 1, 0 }, { 1, 0 }, { 1, 0 }, { 1, 1 } }];
        yield return [new Piece07(), 4, new byte[,] { { 1, 1, 1, 1 }, { 1, 0, 0, 0 } }];

        yield return [new Piece08(), 1, new byte[,] { { 0, 1 }, { 1, 1 }, { 0, 1 }, { 0, 1 } }];
        yield return [new Piece08(), 2, new byte[,] { { 0, 0, 1, 0 }, { 1, 1, 1, 1 } }];
        yield return [new Piece08(), 3, new byte[,] { { 1, 0 }, { 1, 0 }, { 1, 1 }, { 1, 0 } }];
        yield return [new Piece08(), 4, new byte[,] { { 1, 1, 1, 1 }, { 0, 1, 0, 0 } }];

        yield return [new Piece09(), 1, new byte[,] { { 0, 1 }, { 0, 1 }, { 1, 1 } }];
        yield return [new Piece09(), 2, new byte[,] { { 1, 0, 0 }, { 1, 1, 1 } }];
        yield return [new Piece09(), 3, new byte[,] { { 1, 1 }, { 1, 0 }, { 1, 0 } }];
        yield return [new Piece09(), 4, new byte[,] { { 1, 1, 1 }, { 0, 0, 1 } }];

        yield return [new Piece10(), 1, new byte[,] { { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, 0 } }];
        yield return [new Piece10(), 2, new byte[,] { { 1, 1, 1, 0 }, { 0, 0, 1, 1 } }];
        yield return [new Piece10(), 3, new byte[,] { { 0, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 } }];
        yield return [new Piece10(), 4, new byte[,] { { 1, 1, 0, 0 }, { 0, 1, 1, 1 } }];

        yield return [new Piece11(), 1, new byte[,] { { 1, 1 }, { 0, 1 } }];
        yield return [new Piece11(), 2, new byte[,] { { 0, 1 }, { 1, 1 } }];
        yield return [new Piece11(), 3, new byte[,] { { 1, 0 }, { 1, 1 } }];
        yield return [new Piece11(), 4, new byte[,] { { 1, 1 }, { 1, 0 } }];

        yield return [new Piece12(), 1, new byte[,] { { 0, 1 }, { 1, 0 }, { 0, 1 }, { 1, 0 }, { 0, 1 } }];
        yield return [new Piece12(), 2, new byte[,] { { 0, 1, 0, 1, 0 }, { 1, 0, 1, 0, 1 } }];
        yield return [new Piece12(), 3, new byte[,] { { 1, 0 }, { 0, 1 }, { 1, 0 }, { 0, 1 }, { 1, 0 } }];
        yield return [new Piece12(), 4, new byte[,] { { 1, 0, 1, 0, 1 }, { 0, 1, 0, 1, 0 } }];
    }
}