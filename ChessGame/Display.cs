using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;

namespace ChessGame
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int x = 0; x < board.Lines; x++)
            {
                Console.Write(8 - x + " ");
                for (int y = 0; y < board.Columns; y++) 
                {
                    PrintPiece(board.GetPiece(x, y));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintMovement(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor movementBg = ConsoleColor.DarkGray;
            for (int x = 0; x < board.Lines; x++)
            {
                Console.Write(8 - x + " ");
                for (int y = 0; y < board.Columns; y++)
                {
                    if (possibleMoves[x,y])
                    {
                        Console.BackgroundColor = movementBg;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBg;
                    }
                    PrintPiece(board.GetPiece(x, y));
                    Console.Write(" ");
                    Console.BackgroundColor = originalBg;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            
        }

        public static ChessPosition ReadChessPosition()
        {
            string input = Console.ReadLine();
            char column = input[0];
            int line = int.Parse(input[1].ToString());
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece != null)
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
            else
            {
                Console.Write("-");
            }
            
        }
    }
}
