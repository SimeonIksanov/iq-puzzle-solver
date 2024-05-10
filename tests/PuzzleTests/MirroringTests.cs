using Puzzle;

namespace PuzzleTests;

public class MirroringTests
{
    [Theory]
    [MemberData(nameof(ProvideNonSymmetricTestData))]
    public void MirroringVertical_WhenFigureIsNotSymmetric_SuccessfulyMirrored(Piece sut, byte[,] expected)
    {
        // Arrange
        
        // Act
        sut.Mirror();
        
        // Assert
        Assert.True(CompareUtils.Equals(sut,expected));
    }

    [Theory]
    [MemberData(nameof(ProvideSymmetricTestData))]
    public void Mirroring_WhenFigureIsSymmetric_ThrowsMirroringException(Piece sut)
    {
        // Arrange
        // Act
        Action action = sut.Mirror;
        // Assert
        Assert.Throws<MirroringSymmetricException>(action);
    }
    public static IEnumerable<object[]> ProvideNonSymmetricTestData()
    {
        yield return [new Piece02(), new byte[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } }];
    }
    
    public static IEnumerable<object[]> ProvideSymmetricTestData()
    {
        yield return [new Piece01()];
        yield return [new Piece05()];
        yield return [new Piece06()];
    }
}