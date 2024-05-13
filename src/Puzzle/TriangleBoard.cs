namespace Puzzle;

public class TriangleBoard : Board
{
    public TriangleBoard() : base(CreateNewField())
    {
    }
    
    private static BoardCell[][] CreateNewField()
    {
        return new BoardCell[][]
        {
            CreateRow(10),
            CreateRow(9),
            CreateRow(8),
            CreateRow(7),
            CreateRow(6),
            CreateRow(5),
            CreateRow(4),
            CreateRow(3),
            CreateRow(2),
            CreateRow(1)
        };
    }

    private static BoardCell[] CreateRow(int n)
    {
        return Enumerable.Range(0, n).Select((_) => new BoardCell()).ToArray();
    }

    /*
     # # # # # # # # # #
     # # # # # # # # #
     # # # # # # # #
     # # # # # # #
     # # # # # #
     # # # # #
     # # # #
     # # #
     # #
     #
    */
}