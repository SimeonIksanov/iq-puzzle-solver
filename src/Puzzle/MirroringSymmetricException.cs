namespace Puzzle;

public class MirroringSymmetricException : Exception
{
    public MirroringSymmetricException() : base("Piece is symmetric")
    {
    }
}

public class InvalidFigure : Exception
{
    public InvalidFigure() : base("Invalid figure in Piece.")
    {
        
    }
}