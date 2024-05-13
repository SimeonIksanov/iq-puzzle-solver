using System.Linq;
using System.Collections.Generic;
using Puzzle;

namespace PuzzleTests;

public class SolveTests
{
    [Fact]
    public void Solve_WhenProblem001_SolveCorrectly()
    {
        // Arrange
        var sut = new PuzzleGame();
        string[] usedPieces = new[]
        {
            "Piece01", "Piece02", "Piece04", "Piece05", "Piece06", "Piece07", "Piece09", "Piece10", "Piece11",
            "Piece12"
        };
        var pieces = sut.AllPieces;
        foreach (var piece in pieces)
        {
            if (usedPieces.Contains(piece.GetType().Name))
            {
                sut.SetPieceAsUsed(piece);
            }
        }

        for (int x = 0; x < sut.Board.Field.Length; x++)
        for (int y = 0; y < sut.Board.Field[x].Length; y++)
            if (x < 6)
                sut.Board.Field[x][y].Piece = pieces.First();
            else
                sut.Board.Field[x][y].Piece = null;
        
        // next is test
        // sut.Board.Field[6][0].Piece = pieces.First();

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
        for (int x = 0; x < board.Field.Length; x++)
        {
            for (int y = 0; y < board.Field[x].Length; y++)
            {
                if (!board.Field[x][y].Used) return false;
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