using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] AllowedMovement()
        {
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];

            Position futurePosition = new Position(0, 0);



            //north
            futurePosition.DefinePosition(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                { 
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line - 1, futurePosition.Column);
            }

            //east
            futurePosition.DefinePosition(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line, futurePosition.Column + 1);
            }

            //south
            futurePosition.DefinePosition(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line + 1, futurePosition.Column);
            }

            //west
            futurePosition.DefinePosition(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line, futurePosition.Column - 1);
            }

            return validMovement;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
