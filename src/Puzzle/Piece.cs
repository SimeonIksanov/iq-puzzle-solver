namespace Puzzle;

public abstract class Piece
{
    private byte[,] _figure;

    protected Piece(byte[,] figure)
    {
        _figure = figure;
    }

    public Color Color { get; init; }
    public byte MaxRotationCount { get; init; } = 3;
    public bool IsSymmetric { get; init; }
    
    // TODO Заменить на индексатор
    public byte[,] Figure => _figure;

    public (int x, int y) GetLeftTopCoords()
    {
        int x = 0;
        for (int y = 0; y < _figure.GetLength(1); y++)
        {
            if (_figure[x, y] > 0) return (x, y);
        }

        throw new InvalidFigure();
    }

    public void Rotate()
    {
        Transpose();
        ReorderEachColumn();
    }

    public void Mirror()
    {
        if (IsSymmetric) throw new MirroringSymmetricException();

        int width = _figure.GetLength(0), height = _figure.GetLength(1);
        for (int y = 0; y < height; y++)
        {
            int l = 0, r = width - 1;
            while (l < r)
            {
                (_figure[l, y], _figure[r, y]) = (_figure[r, y], _figure[l, y]);
                l++;
                r--;
            }
        }
    }

    private void Transpose()
    {
        /*
         123    147
         456 -> 258
         789    369
        */
        var transposed = new byte[_figure.GetLength(1), _figure.GetLength(0)];
        for (int y = 0; y < _figure.GetLength(0); y++)
        for (int x = 0; x < _figure.GetLength(1); x++)
            transposed[x, y] = _figure[y, x];
        _figure = transposed;
    }

    private void ReorderEachColumn()
    {
        /*
         147    369
         258 -> 258
         369    147
        */
        var lenY = _figure.GetLength(0);
        var lenX = _figure.GetLength(1) - 1;
        for (int y = 0; y < lenY; y++)
        {
            var top = 0;
            while (top < lenX - top)
            {
                (_figure[y, top], _figure[y, lenX - top]) = (_figure[y, lenX - top], _figure[y, top]);
                top++;
            }
        }
    }
}

public class Piece01 : Piece
{
    internal Piece01() : base(new byte[,]
    {
        { 0, 1, 0 },
        { 1, 1, 1 },
        { 0, 1, 0 }
    })
    {
        IsSymmetric = true;
        MaxRotationCount = 0;
        Color = Color.White;
    }
}

public class Piece02 : Piece
{
    internal Piece02() : base(new byte[,]
    {
        { 1, 1, 1 },
        { 1, 0, 0 },
        { 1, 0, 0 }
    })
    {
        Color = Color.Blue;
    }
}

public class Piece03 : Piece
{
    internal Piece03() : base(new byte[,]
    {
        { 1, 1 },
        { 1, 1 },
        { 1, 0 }
    })
    {
        Color = Color.LightViolet;
    }
}

public class Piece04 : Piece
{
    internal Piece04() : base(new byte[,]
    {
        { 1, 1 },
        { 1, 0 },
        { 1, 1 }
    })
    {
        Color = Color.Yellow;
    }
}

public class Piece05 : Piece
{
    internal Piece05() : base(new byte[,]
    {
        { 1, 1, 1, 1 }
    })
    {
        IsSymmetric = true;
        MaxRotationCount = 1;
        Color = Color.Green;
    }
}

public class Piece06 : Piece
{
    internal Piece06() : base(new byte[,]
    {
        { 1, 1 },
        { 1, 1 }
    })
    {
        IsSymmetric = true;
        MaxRotationCount = 0;
        Color = Color.Orange;
    }
}

public class Piece07 : Piece
{
    internal Piece07() : base(new byte[,]
    {
        { 1, 1, 1, 1 },
        { 1, 0, 0, 0 }
    })
    {
        Color = Color.Green;
    }
}

public class Piece08 : Piece
{
    internal Piece08() : base(new byte[,]
    {
        { 1, 1, 1, 1 },
        { 0, 1, 0, 0 }
    })
    {
        Color = Color.Violet;
    }
}

public class Piece09 : Piece
{
    internal Piece09() : base(new byte[,]
    {
        { 1, 1, 1 },
        { 0, 0, 1 }
    })
    {
        Color = Color.Pink;
    }
}

public class Piece10 : Piece
{
    internal Piece10() : base(new byte[,]
    {
        { 1, 1, 0, 0 },
        { 0, 1, 1, 1 }
    })
    {
        Color = Color.Pink;
    }
}

public class Piece11 : Piece
{
    internal Piece11() : base(new byte[,]
    {
        { 1, 1 },
        { 1, 0 }
    })
    {
        Color = Color.Red;
    }
}

public class Piece12 : Piece
{
    internal Piece12() : base(new byte[,]
    {
        { 1, 0, 0 },
        { 1, 1, 0 },
        { 0, 1, 1 }
    })
    {
        Color = Color.LightBlue;
    }
}

/*
piece01    piece02    piece03    piece04   piece05
   #        # # #      # #        # #
 # # #      #          # #        #         # # # #
   #        #          #          # #

piece06   piece07    piece08    piece09   piece10     piece11    piece12
 # #       # # # #    # # # #    # # #     # #         # #        # # #
 # #       #            #        #           # # #     #           # #

 rotation clockwise
 # #    # # #      #
 #          #      #    #
 #               # #    # # #

 mirror
 # #  # #
   #  #
   #  #
*/