using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] AllowedMovement()
        {
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];
            Position futurePosition = new Position(0, 0);

            //Northeast
            futurePosition.DefinePosition(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line - 1, futurePosition.Column - 1);
            }

            //Northeast
            futurePosition.DefinePosition(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line - 1, futurePosition.Column + 1);
            }

            //Southeast
            futurePosition.DefinePosition(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line + 1, futurePosition.Column + 1);
            }

            //Southwest
            futurePosition.DefinePosition(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(futurePosition) && CanMove(futurePosition))
            {
                validMovement[futurePosition.Line, futurePosition.Column] = true;
                if (Board.GetPiece(futurePosition) != null && Board.GetPiece(futurePosition).Color != Color)
                {
                    break;
                }
                futurePosition.DefinePosition(futurePosition.Line + 1, futurePosition.Column - 1);
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
            return "B";
        }
    }
}
