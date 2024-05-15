using Puzzle;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        PrintWelcomeMessage();

        var puzzleGame = new PuzzleGame();
        
        string[] usedPieces = ReadUsedPieces();
        byte[][] userEnteredBoard = ReadInitialBoard();
        
        SetUsedPieces(puzzleGame, usedPieces);
        SetUsedBoardCells(puzzleGame, userEnteredBoard);
        var solved = puzzleGame.Solve();

        Console.WriteLine(solved ? "Решена" : "Не получилось решить");

        PrintBoard(puzzleGame);

        Console.WriteLine("Конец");
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Добро пожаловать в IQ Puzzle Solver!");

        Console.WriteLine("для продолжения нажмите любую клавишу..");
        Console.ReadKey(true);
    }

    private static void PrintBoard(PuzzleGame puzzleGame)
    {
        for (int y = 0; y < puzzleGame.Board[0].Length; y++)
        {
            int x = 0;
            while (x < 10 && y < puzzleGame.Board[x].Length)
            {
                if (puzzleGame.Board[x][y].Used)
                    PrintPuzzlePiece(puzzleGame.Board[x][y].Piece);
                else Console.Write(" ");
                Console.Write(" ");
                x++;
            }

            Console.WriteLine();
        }
    }

    private static void SetUsedBoardCells(PuzzleGame puzzleGame, byte[][] userEnteredBoard)
    {
        var dummyPiece = new DummyPiece();
        for (int x = 0; x < puzzleGame.Board.Length; x++)
        for (int y = 0; y < puzzleGame.Board[x].Length; y++)
            if (userEnteredBoard[x][y] > 0)
                puzzleGame.Board[x][y].Piece = dummyPiece;
            else
                puzzleGame.Board[x][y].Piece = null;
    }

    private static void SetUsedPieces(PuzzleGame puzzleGame, string[] usedPieces)
    {
        var pieces = puzzleGame.AllPieces;
        if (usedPieces.Length == 0) return;
        foreach (var piece in pieces)
        {
            if (usedPieces.Contains(piece.GetType().Name))
            {
                puzzleGame.SetPieceAsUsed(piece);
            }
        }
    }

    private static string[] ReadUsedPieces()
    {
        bool error = true;
        var nums = new List<int>();
        string errorMessage = "";
        while (error)
        {
            Console.Clear();
            Console.Write(error
                ? errorMessage + Environment.NewLine + Environment.NewLine
                : "");
            error = false;
            PrintPuzzlePieces();
            Console.Write("Номера использованых деталей: ");
            string line = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(line)) return [];

            var splitted = line.Split(' ', ';', ',');
            foreach (var item in splitted)
            {
                if (Int32.TryParse(item, out int num) && num is > 0 and <= 12)
                    nums.Add(num);
                else
                {
                    errorMessage = $"Ошибка во вводе. Должно быть число от 1 до 12, найдено {item}";
                    error = true;
                    break;
                }
            }

            if (!error) break;
        }
        
        return nums
            .Select(n => $"Piece{n:D2}")
            .ToArray();
    }

    private static byte[][] ReadInitialBoard()
    {
        Console.WriteLine(
            "Введи начальную конфигурацию(# - для занятой ячейки, любой символ - пустые ячейки;10 строк, начиная с 10 столбиков, заканчивая 1)");
        var lines = new List<byte[]>(10);
        for (int i = 0; i < 10; i++)
        {
            var line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line))
                lines.Add(line.Select(c => c == '#' ? (byte)1 : (byte)0).ToArray());
        }

        return TransposeArray(lines);
    }

    private static byte[][] TransposeArray(List<byte[]> matrixIn)
    {
        var matrixOut = new byte[10][]
        {
            new byte[10],
            new byte[9],
            new byte[8],
            new byte[7],
            new byte[6],
            new byte[5],
            new byte[4],
            new byte[3],
            new byte[2],
            new byte[1]
        };
        for (int y = 0; y < matrixIn.Count; y++)
        {
            for (int x = 0; x < matrixIn[y].Length; x++)
            {
                matrixOut[x][y] = matrixIn[y][x];
            }
        }

        return matrixOut;
    }

    static void PrintPuzzlePieces()
    {
        string line =
            "piece01    piece02    piece03    piece04   piece05" + Environment.NewLine +
            "   #        # # #      # #        # #" + Environment.NewLine +
            " # # #      #          # #        #         # # # #" + Environment.NewLine +
            "   #        #          #          # #" + Environment.NewLine +
            "" + Environment.NewLine +
            "piece06   piece07    piece08    piece09   piece10     piece11    piece12" + Environment.NewLine +
            " # #       # # # #    # # # #    # # #     # #         # #        # # #" + Environment.NewLine +
            " # #       #            #        #           # # #     #           # #" + Environment.NewLine +
            "" + Environment.NewLine;
        Console.WriteLine(line);
    }

    static void PrintPuzzlePiece(Piece piece)
    {
        var map = new Dictionary<Color, ConsoleColor>
        {
            { Color.Blue, ConsoleColor.DarkBlue },
            { Color.Green, ConsoleColor.Green },
            { Color.LightBlue, ConsoleColor.Blue },
            { Color.LightViolet, ConsoleColor.DarkMagenta },
            { Color.Orange, ConsoleColor.Magenta },
            { Color.Pink, ConsoleColor.DarkCyan },
            { Color.Red, ConsoleColor.Red },
            { Color.Violet, ConsoleColor.DarkYellow },
            { Color.White, ConsoleColor.White },
            { Color.Yellow, ConsoleColor.Yellow },
            { Color.Grey, ConsoleColor.Gray }
            
        };
        Console.ForegroundColor = map[piece.Color];
        Console.Write(piece.Print());
        
        Console.ResetColor();
    }
}

public static class PieceExtensions
{
    public static string Print(this Piece piece)
    {
        var name = piece.GetType().Name;
        return name == "DummyPiece" ? "00" : name.Substring(5);
    }
}
/*
##00
*/