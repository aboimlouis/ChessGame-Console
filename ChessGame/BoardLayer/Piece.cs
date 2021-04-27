using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardLayer
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementAmount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }

        public void IncrementMovementAmount()
        {
            MovementAmount++;
        }

        public abstract bool[,] AllowedMovement();
    }
}
