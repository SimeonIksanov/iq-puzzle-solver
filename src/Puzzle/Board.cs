using System.Text;

namespace Puzzle;

public abstract class Board
{
    protected readonly BoardCell[][] _field;

    protected Board(BoardCell[][] field)
    {
        _field = field;
    }
    
    public BoardCell[] this[int index] => _field[index];
    public int Length => _field.Length;
    protected bool HasCell(int x, int y)
    {
        if (x < 0 || y < 0) return false;
        if (x >= _field.Length) return false;
        if (y >= _field[x].Length) return false;
        return true;
    }

    public void RemovePiece(Piece piece)
    {
        for (int x = 0; x < _field.Length; x++)
        {
            for (int y = 0; y < _field[x].Length; y++)
            {
                if (_field[x][y].Piece == piece)
                {
                    _field[x][y].Piece = null;
                }
            }
        }
    }

    public bool TryApplyPiece(Piece piece)
    {
        var firstEmptyCellCoords = FindEmptyCell();
        // совмещаем найденную ячейку доски с левым-верхним(в левом "столбике" матрицы верхний) элементом piece
        var leftTopCoords = piece.GetLeftTopCoords();
        // координаты левого верхнего угла прямоугольника доски, куда проецируется матрица piece.Figure
        (int x, int y) boardCoords = (firstEmptyCellCoords.x, firstEmptyCellCoords.y - leftTopCoords.y);
        // проверяю что все ячейки доски для piece существуют и свободны, иначе выход
        for (int x = 0; x < piece.GetLength(0); x++)
        {
            for (int y = 0; y < piece.GetLength(1); y++)
            {
                bool isPartOfPiece = piece[x, y] > 0;
                bool hasBoardCell = HasCell(boardCoords.x + x, boardCoords.y + y);
                bool isBoardCellEmpty = hasBoardCell && _field[boardCoords.x + x][boardCoords.y + y].Piece is null;
                if ( isPartOfPiece && !isBoardCellEmpty) return false;
            }
        }
        
        // проверки пройдены, можно маркировать доску
        for (int x = 0; x < piece.GetLength(0); x++)
        {
            for (int y = 0; y < piece.GetLength(1); y++)
            {
                bool isPartOfPiece = piece[x, y] > 0;
                bool hasBoardCell = HasCell(boardCoords.x + x, boardCoords.y + y);
                bool isBoardCellEmpty = hasBoardCell && _field[boardCoords.x + x][boardCoords.y + y].Piece is null;
                if (isPartOfPiece && isBoardCellEmpty)
                {
                    _field[boardCoords.x + x][boardCoords.y + y].Piece = piece;
                }
            }
        }
        // TODO можно по другому сделать: проверять доступность и сразу маркировать,
        // а если вдруг обнаружится что piece не подходит -> удалить все маркировки
        // чтобы удалить повтор цикла

        return true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int x = 0; x < _field.Length; x++)
        {
            // char Selector(Cell c) => c.Used ? '*' : ' ';
            char Selector(BoardCell c) => c.Used ? '*' : ' ';

            sb.AppendLine(string.Join("", _field[x].Select(Selector)));
        }

        return sb.ToString();
    }

    private (int x, int y) FindEmptyCell()
    {
        for (int x = 0; x < _field.Length; x++)
        {
            for (int y = 0; y < _field[x].Length; y++)
            {
                if (_field[x][y].Piece is null)
                {
                    return (x, y);
                }
            }
        }

        throw new InvalidOperationException("Failed to find empty cell. Puzzle is solved!");
    }
}