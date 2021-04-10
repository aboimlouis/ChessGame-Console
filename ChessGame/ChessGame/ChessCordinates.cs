using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardLayer;

namespace ChessGame.ChessGame
{
    class ChessCordinates
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessCordinates()
        {
        }

        public ChessCordinates(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Column);
            sb.Append(Line);

            return sb.ToString();
        }
    }
}
