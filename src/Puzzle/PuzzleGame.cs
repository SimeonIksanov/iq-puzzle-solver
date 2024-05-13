namespace Puzzle;

public class PuzzleGame
{
    private readonly HashSet<Piece> _usedPieces;
    private readonly HashSet<Piece> _unusedPieces;
    private readonly Piece[] _allPieces;
    private readonly Board _board;

    public PuzzleGame()
    {
        _board = new TriangleBoard();
        _allPieces = new Piece[]
        {
            new Piece01(), new Piece02(), new Piece03(), new Piece04(),
            new Piece05(), new Piece06(), new Piece07(), new Piece08(),
            new Piece09(), new Piece10(), new Piece11(), new Piece12()
        };
        _unusedPieces = new HashSet<Piece>(_allPieces);
        _usedPieces = new HashSet<Piece>(_allPieces.Length);
    }

    public void SetPieceAsUsed(Piece piece)
    {
        _unusedPieces.Remove(piece);
        _usedPieces.Add(piece);
    }

    public void SetPieceAsUnused(Piece piece)
    {
        _usedPieces.Remove(piece);
        _unusedPieces.Add(piece);
    }
    
    public bool Solve()
    {
        if (_unusedPieces.Count == 0) return true;
        var pieces = _unusedPieces.ToArray();
        foreach (var piece in pieces)
        {
            for (int rotationCount = 0; rotationCount <= piece.MaxRotationCount; rotationCount++)
            {
                if (TryApplyPiece(piece))
                {
                    SetPieceAsUsed(piece);
                    if (Solve()) return true;
                    SetPieceAsUnused(piece);
                    RemovePieceFromBoard(piece);
                }

                piece.Rotate();
            }

            if (piece.IsSymmetric) continue;

            piece.Mirror();
            for (int rotationCount = 0; rotationCount <= piece.MaxRotationCount; rotationCount++)
            {
                if (TryApplyPiece(piece))
                {
                    SetPieceAsUsed(piece);
                    if (Solve()) return true;
                    SetPieceAsUnused(piece);
                    RemovePieceFromBoard(piece);
                }

                piece.Rotate();
            }
        }

        return false;
    }

    public Board Board => _board;
    public IReadOnlyCollection<Piece> UsedPieces => _usedPieces.ToArray().AsReadOnly();
    public IReadOnlyCollection<Piece> UnusedPieces => _unusedPieces.ToArray().AsReadOnly();
    public IReadOnlyCollection<Piece> AllPieces => _allPieces;

    private bool TryApplyPiece(Piece piece) => _board.TryApplyPiece(piece);

    private void RemovePieceFromBoard(Piece piece) => _board.RemovePiece(piece);
}