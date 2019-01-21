using System;
using System.Collections.Generic;

namespace gomoku_project
{
    public static class AlphaBeta
    {
        private static Box.State _own;
        private static Box.State _opp;

        #region Check End game
        private static bool checkRow1(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            int c1 = node.SizeBoard, c2 = -1;
            bool flag = true;
            for (int j = move.Col + 1; j < node.SizeBoard; j++)
            {
                if (node.Matrix[move.Row, j].STT == currSTT)
                {
                    continuous++;
                }
                else if (node.Matrix[move.Row, j].STT != Box.State.blank)
                {
                    c1 = j;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int j = move.Col - 1; j >= 0; j--)
            {
                if (node.Matrix[move.Row, j].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[move.Row, j].STT != Box.State.blank)
                {
                    c2 = j;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && c1 - c2 > 6);
        }
        private static bool checkCol1(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            int r1 = node.SizeBoard, r2 = -1;
            bool flag = true;
            for (int i = move.Row + 1; i < node.SizeBoard; i++)
            {
                if (node.Matrix[i, move.Col].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, move.Col].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = move.Row - 1; i >= 0; i--)
            {
                if (node.Matrix[i, move.Col].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, move.Col].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }
        private static bool checkLeftDiagonal1(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            int r1 = node.SizeBoard, r2 = -1;
            bool flag = true;
            for (int i = move.Row + 1, j = move.Col + 1; i < node.SizeBoard && j < node.SizeBoard; i++, j++)
            {
                if (node.Matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, j].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = move.Row - 1, j = move.Col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (node.Matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, j].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }
        private static bool checkRightDiagonal1(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            int r1 = node.SizeBoard, r2 = -1;
            bool flag = true;
            for (int i = move.Row + 1, j = move.Col - 1; i < node.SizeBoard && j >= 0; i++, j--)
            {
                if (node.Matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, j].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = move.Row - 1, j = move.Col + 1; i >= 0 && j < node.SizeBoard; i--, j++)
            {
                if (node.Matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                }
                else if (node.Matrix[i, j].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }

        private static bool checkRow(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            for (int j = move.Col + 1; j < node.SizeBoard; j++)
            {
                if (node.Matrix[move.Row, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            for (int j = move.Col - 1; j >= 0; j--)
            {
                if (node.Matrix[move.Row, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            return (continuous == 5);
        }
        private static bool checkCol(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            for (int i = move.Row + 1; i < node.SizeBoard; i++)
            {
                if (node.Matrix[i, move.Col].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            for (int i = move.Row - 1; i >= 0; i--)
            {
                if (node.Matrix[i, move.Col].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            return (continuous == 5);
        }
        private static bool checkLeftDiagonal(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            for (int i = move.Row + 1, j = move.Col + 1; i < node.SizeBoard && j < node.SizeBoard; i++, j++)
            {
                if (node.Matrix[i, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            for (int i = move.Row - 1, j = move.Col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (node.Matrix[i, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            return (continuous == 5);
        }
        private static bool checkRightDiagonal(Node node, Position move)
        {
            Box.State currSTT = node.Matrix[move.Row, move.Col].STT;
            int continuous = 1;
            for (int i = move.Row + 1, j = move.Col - 1; i < node.SizeBoard && j >= 0; i++, j--)
            {
                if (node.Matrix[i, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            for (int i = move.Row - 1, j = move.Col + 1; i >= 0 && j < node.SizeBoard; i--, j++)
            {
                if (node.Matrix[i, j].STT == currSTT)
                {
                    continuous++;
                }
                else break;
            }
            return (continuous == 5);
        }
        private static bool IsGameOver(Node node, Position move)
        {
            if (checkRow1(node, move))
                return true;
            if (checkCol1(node, move))
                return true;
            if (checkLeftDiagonal1(node, move))
                return true;
            if (checkRightDiagonal1(node, move))
                return true;
            return false;
        }
        private static bool IsTerminal(Node currNode, Position currMove, int currDepth)
        {
            if (IsGameOver(currNode, currMove))
                return true;
            if (currDepth == 0)
                return true;
            else if (currNode.IsFullBoard())
                return true;
            return false;
        }
        #endregion

        private static long Minimax(Node currNode, Position currMove, int currDepth, Box.State currState, long alpha, long beta, ref int openedNodes)
        {
            if (IsTerminal(currNode, currMove, currDepth))
            {
                if (currState == _opp)
                    return Heuristic.Eluavation(currNode, currMove);
                else if (currState == _own)
                    return (Heuristic.Eluavation(currNode, currMove) * (-1));
            }

            List<Position> moveList = currNode.IsCanMoves();
            if (currState == _own)
            {
                long bestScore = long.MinValue;
                foreach (Position move in moveList)
                {
                    currNode.Move(move, _own);
                    openedNodes += 1;
                    long score = Minimax(currNode, move, currDepth - 1, _opp, alpha, beta, ref openedNodes);
                    currNode.UnMove(move);
                    bestScore = Math.Max(bestScore, score);
                    alpha = Math.Max(alpha, bestScore);
                    if (beta <= alpha)
                        break;
                }
                return bestScore;
            }
            else
            {
                long bestScore = long.MaxValue;
                foreach (Position move in moveList)
                {
                    openedNodes += 1;
                    currNode.Move(move, _opp);
                    long score = Minimax(currNode, move, currDepth - 1, _own, alpha, beta, ref openedNodes);
                    currNode.UnMove(move);
                    bestScore = Math.Min(bestScore, score);
                    beta = Math.Min(beta, bestScore);
                    if (beta <= alpha)
                        break;
                }
                return bestScore;
            }
        }
        public static Position GetBestMove(Node currNode, Box.State maximizingPlayerSTT, int depth, ref int openedNodes)
        {
            openedNodes = 0;
            Random rand = new Random();
            _own = maximizingPlayerSTT;
            if (_own == Box.State.blue)
                _opp = Box.State.red;
            else _opp = Box.State.blue;

            long bestScore = long.MinValue;
            long alpha = long.MinValue;
            long beta = long.MaxValue;
            Dictionary<Position, long> dict = new Dictionary<Position, long>();
            List<Position> moveList = currNode.IsCanMoves();
            openedNodes += moveList.Count;
            for (int i = 0; i < moveList.Count; i++)
            {
                currNode.Move(moveList[i], _own);
                long score = Minimax(currNode, moveList[i], depth - 1, _opp, alpha, beta, ref openedNodes);
                currNode.UnMove(moveList[i]);
                dict.Add(moveList[i], score);
                if (bestScore < score)
                {
                    bestScore = score;
                }
            }
            List<Position> res = new List<Position>();
            foreach (Position key in dict.Keys)
            {
                if (dict[key] == bestScore)
                    res.Add(key);
            }
            return res[rand.Next(res.Count)];
        }
    }


}
