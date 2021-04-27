using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardLayer
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position()
        {
        }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public void DefinePosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Line.ToString());
            sb.Append(", ");
            sb.AppendLine(Column.ToString());
            return sb.ToString();
        }
    }
}
