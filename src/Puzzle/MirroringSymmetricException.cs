namespace Puzzle;

public class MirroringSymmetricException : Exception
{
    public MirroringSymmetricException() : base("Piece is symmetric")
    {
    }
}