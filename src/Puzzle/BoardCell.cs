namespace Puzzle;

public class BoardCell
{
    internal BoardCell()
    {
    }

    public bool Used => Piece is not null;

    public Piece? Piece { get; set; }
}