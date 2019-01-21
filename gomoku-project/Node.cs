using System.Collections.Generic;
using System.Linq;

namespace gomoku_project
{
    public class Node
    {
        private int _sizeBoard;
        private Box[,] _matrix;
        private int _movedCount;
        public int MovedCount { get => _movedCount; }
        public int SizeBoard { get => _sizeBoard;}
        public Box[,] Matrix { get => _matrix; }

        public Node(int szboard, Box[,] matrix, int movedCount)
        {
            _sizeBoard = szboard;
            _matrix = (Box[,])matrix.Clone();
            _movedCount = movedCount;
        }

        public bool IsFullBoard()
        {
            return (SizeBoard * SizeBoard == _movedCount);
        }

        public List<Position> IsCanMoves()
        {
            List<Position> moveList = new List<Position>();
            for (int i = 0; i < SizeBoard; i++)
            {
                for (int j = 0; j < SizeBoard; j++)
                {
                    if (Matrix[i,j].STT != Box.State.blank)    // ô đã đi rồi
                    {
                        for (int k = i - 2; k <= i + 2; k++)
                        {
                            if (k >= 0 && k < SizeBoard)
                            {
                                for (int l = j - 2; l <= j + 2; l++)
                                {
                                    if (l >= 0 && l < SizeBoard)
                                    {
                                        if (Matrix[k, l].STT == Box.State.blank && !moveList.Any(x => x.Row == k && x.Col == l)) // ô trống có thể đi
                                            moveList.Add(new Position(k,l));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return moveList;
        }

        public void Move(Position currMove, Box.State currSTT)
        {
            Matrix[currMove.Row, currMove.Col].STT = currSTT;
            _movedCount++;
        }

        public void UnMove(Position prevMove)
        {
            Matrix[prevMove.Row, prevMove.Col].STT = Box.State.blank;
            _movedCount--;
        }
    }
}
