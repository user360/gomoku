using System;
using System.Collections.Generic;
using System.Linq;
namespace gomoku_project
{
    public class Position
    {
        private int _row;
        private int _col;
        public int Row { get => _row; }
        public int Col { get => _col; }
        public Position(int row, int col)
        {
            _row = row;
            _col = col;
        }     
    }
}
