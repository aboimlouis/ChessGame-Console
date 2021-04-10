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
            if (occupiedSpace(position))
            {
                throw new BoardException("Space occupied by another piece!");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool occupiedSpace(Position position)
        {
            validPosition(position);
            return GetPiece(position) != null;
        }

        public bool validPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
                return false;
            else
                return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
            {
                throw new BoardException("Invalid Position!!");
            }
        }
    }
}
