using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class ChessInGame
    {
        private Board chessBoard;
        private int turn;
        private Color colorTurn;
        private Piece[,] pieces;
        public bool End { get; private set; }
        public ChessInGame()
        {
            this.chessBoard = new Board(8, 8);
            this.turn = 1;
            this.colorTurn = Color.White;
            End = false;
            pieces = new Piece[,]{
                { 
                    new Rook(Color.Black, chessBoard),
                    new Knight(Color.Black, chessBoard),
                    new Bishop(Color.Black, chessBoard),
                    new King(Color.Black, chessBoard),
                    new Queen(Color.Black, chessBoard),
                    new Bishop(Color.Black, chessBoard),
                    new Knight(Color.Black, chessBoard),
                    new Rook(Color.Black, chessBoard)
                },
                { 
                    new Rook(Color.White, chessBoard),
                    new Knight(Color.White, chessBoard),
                    new Bishop(Color.White, chessBoard),
                    new King(Color.White, chessBoard),
                    new Queen(Color.White, chessBoard),
                    new Bishop(Color.White, chessBoard),
                    new Knight(Color.White, chessBoard),
                    new Rook(Color.White, chessBoard)
                },
            };
            PlacePieces();
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = chessBoard.RemovePiece(origin);
            piece.IncrementMovementAmount();
            Piece takenPiece = chessBoard.RemovePiece(destination);
            chessBoard.InsertPiece(piece, destination);
        }

        private void PlacePieces()
        {

            for (int i = 1; i < chessBoard.Lines + 1; i++)
            {
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new ChessPosition((char)(96 + i), 7).ToPosition());
                chessBoard.InsertPiece(pieces[0,i-1], new ChessPosition((char)(96 + i), 8).ToPosition());
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new ChessPosition((char)(96 + i), 2).ToPosition());
                chessBoard.InsertPiece(pieces[1, i - 1], new ChessPosition((char)(96 + i), 1).ToPosition());
            }

        }

        public Board GetBoard()
        {
            return this.chessBoard;
        }
    }
}
