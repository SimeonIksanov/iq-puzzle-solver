using Puzzle;

namespace PuzzleTests;

public class SolveTests
{
    [Fact]
    public void Solve_WhenProblem001_SolveCorrectly()
    {
        // Arrange
        var sut = new PuzzleGame();
        var dummyPiece = new DummyPiece();
        string[] usedPieces = new[]
        {
            "Piece01", "Piece02", "Piece04", "Piece05", "Piece06", "Piece07", "Piece09", "Piece10", "Piece11",
            "Piece12"
        };
        var pieces = sut.AllPieces;
        foreach (var piece in pieces)
            if (usedPieces.Contains(piece.GetType().Name))
            {
                sut.SetPieceAsUsed(piece);
            }

        for (int x = 0; x < sut.Board.Length; x++)
        for (int y = 0; y < sut.Board[x].Length; y++)
            if (x < 6)
                sut.Board[x][y].Piece = dummyPiece;
            else
                sut.Board[x][y].Piece = null;
        
        // Act
        sut.Solve();

        // Assert
        Assert.True(sut.UnusedPieces.Count == 0 && IsAllCellsFilled(sut.Board));
    }
    
    [Fact]
    public void Solve_WhenFieldEmpty_SolveCorrectly()
    {
        // Arrange
        var sut = new PuzzleGame();

        // Act
        sut.Solve();

        // Assert
        Assert.True(sut.UnusedPieces.Count == 0 && IsAllCellsFilled(sut.Board));
    }

    private bool IsAllCellsFilled(Board board)
    {
        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                if (!board[x][y].Used) return false;
            }
        }

        return true;
    }
}

/*
 ******0000
 ******000
 ******00
 ******0
 ******
 *****
 ****
 ***
 **
 *
 */