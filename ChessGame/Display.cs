using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;

namespace ChessGame
{
    class Display
    {
        public static void PrintTurn(ChessInGame inGame)
        {
            PrintBoard(inGame.ChessBoard);
            PrintTakenPieces(inGame);
            Console.WriteLine();
            Console.WriteLine("Turn: " + inGame.Turn);
            Console.WriteLine("Waiting for play: " + inGame.ColorTurn.ToString());

            if (!inGame.End)
            {
                if (inGame.Check)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CHECK");
                    Console.ForegroundColor = consoleColor;
                }
            }
            else
            {
                Console.WriteLine("Check Mate!");
                Console.WriteLine("The winner is: " + inGame.ColorTurn);
            }
        }

        public static void PrintTakenPieces(ChessInGame inGame)
        {
            Console.WriteLine("Taken pieces:");
            Console.Write("White: ");
            PrintPieceList(inGame.TakenPieces(Color.White));
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Black: ");
            PrintPieceList(inGame.TakenPieces(Color.Black));
            Console.ForegroundColor = consoleColor;
        }

        public static void PrintPieceList(List<Piece> pieces)
        {
            Console.Write("[ ");
            pieces.ForEach(piece => Console.Write(piece + " "));
            Console.Write("]");
            Console.WriteLine();
        }
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
            Console.WriteLine();
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
                    Console.ForegroundColor = ConsoleColor.Blue;
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
