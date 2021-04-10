using System;
using ChessGame.BoardLayer;
using ChessGame.ChessGame;
namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board chessBoard = new Board(8,8);
            chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(0, 0));
            chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(1, 3));
            chessBoard.InsertPiece(new King(Color.Black, chessBoard), new Position(2, 4));

            chessBoard.InsertPiece(new Rook(Color.White, chessBoard), new Position(0, 1));
            chessBoard.InsertPiece(new Rook(Color.White, chessBoard), new Position(1, 4));
            chessBoard.InsertPiece(new King(Color.White, chessBoard), new Position(2, 5));

            Display.PrintBoard(chessBoard);
        }
    }
}
