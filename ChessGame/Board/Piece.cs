﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementAmount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }
    }
}