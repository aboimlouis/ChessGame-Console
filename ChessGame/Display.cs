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
                for (int y = 0; y < board.Columns; y++) {
                    if (board.GetPiece(x, y) != null)
                    {
                        Console.Write(board.GetPiece(x, y)+" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
