using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardLayer
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board()
        {
        }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece GetPiece(int line, int column)
        {
            return Pieces[line, column];
        }
        public Piece GetPiece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }
        public void InsertPiece(Piece piece, Position position)
        {
            if (OccupiedSpace(position))
            {
                throw new BoardException("Space occupied by another piece!");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }
            Piece removedPiece = GetPiece(position);
            removedPiece.Position = null;
            Pieces[position.Line, position.Column] = null;
            return removedPiece;

        }

        public bool OccupiedSpace(Position position)
        {
            ValidPosition(position);
            return GetPiece(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
                return false;
            else
                return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!!");
            }
        }
    }
}
