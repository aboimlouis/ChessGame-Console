﻿using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class ChessInGame
    {
        public Board ChessBoard { get; private set; }
        public  int Turn { get; private set; }
        public bool End { get; private set; }
        public Color ColorTurn { get; private set; }
        private Piece[,] pieces;
        public ChessInGame()
        {
            this.ChessBoard = new Board(8, 8);
            this.Turn = 1;
            this.ColorTurn = Color.White;
            End = false;
            pieces = new Piece[,]{
                { 
                    new Rook(Color.Black, ChessBoard),
                    new Knight(Color.Black, ChessBoard),
                    new Bishop(Color.Black, ChessBoard),
                    new King(Color.Black, ChessBoard),
                    new Queen(Color.Black, ChessBoard),
                    new Bishop(Color.Black, ChessBoard),
                    new Knight(Color.Black, ChessBoard),
                    new Rook(Color.Black, ChessBoard)
                },
                { 
                    new Rook(Color.White, ChessBoard),
                    new Knight(Color.White, ChessBoard),
                    new Bishop(Color.White, ChessBoard),
                    new King(Color.White, ChessBoard),
                    new Queen(Color.White, ChessBoard),
                    new Bishop(Color.White, ChessBoard),
                    new Knight(Color.White, ChessBoard),
                    new Rook(Color.White, ChessBoard)
                },
            };
            PlacePieces();
        }

        private void ExecuteMove(Position origin, Position destination)
        {
            Piece piece = ChessBoard.RemovePiece(origin);
            piece.IncrementMovementAmount();
            Piece takenPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(piece, destination);
        }

        public void ExecutePlay(Position origin, Position destination)
        {
            ExecuteMove(origin, destination);
            Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            ColorTurn = ColorTurn == Color.White ? Color.Black : Color.White;
        }

        private void PlacePieces()
        {

            for (int i = 1; i < ChessBoard.Lines + 1; i++)
            {
                ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition((char)(96 + i), 7).ToPosition());
                ChessBoard.InsertPiece(pieces[0,i-1], new ChessPosition((char)(96 + i), 8).ToPosition());
                ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition((char)(96 + i), 2).ToPosition());
                ChessBoard.InsertPiece(pieces[1, i - 1], new ChessPosition((char)(96 + i), 1).ToPosition());
            }

        }
    }
}
