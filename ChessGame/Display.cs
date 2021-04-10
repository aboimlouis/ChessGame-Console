using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int x = 0; x < board.Lines; x++)
            {
                Console.Write(8 - x + " ");
                for (int y = 0; y < board.Columns; y++) {
                    if (board.GetPiece(x, y) != null)
                    {
                        PrintPiece(board.GetPiece(x, y));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
