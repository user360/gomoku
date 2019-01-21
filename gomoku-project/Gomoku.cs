using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace gomoku_project
{
    public partial class Gomoku : Form
    {
        #region init 
        public enum PlayMode
        {
            PvC = 1,
            CvC = 0,
            PvP = -1
        }
        public struct LimitBoard
        {
            public static int Top = 1000;
            public static int Bot = -1;
            public static int Left = 1000;
            public static int Right = -1;
        }

        private Random _rand;
        private int _sizeBoard;
        private Board _board;
        private Box[,] _matrix;
        private List<Position> _movedList;
        private Player[] _players;
        private Graphics _graph;
        private bool _isStart;
        private PlayMode _mode; // play mode 
        private int _currTurn;  // current turn
        private Position _justMove; 
        private Position _head, _tail; // head and tail of continuous 
        private int _depth;
        private bool _isHaveWiner;
        private int _openedNodes;
        #endregion init

        public Gomoku()
        {
            InitializeComponent();
            _rand = new Random();
            _sizeBoard = pnlBoard.Width / Box.Size;
            _board = new Board(_sizeBoard);
            _matrix = new Box[_sizeBoard, _sizeBoard];
            for (int row = 0; row < _sizeBoard; row++)
            {
                for (int col = 0; col < _sizeBoard; col++)
                    _matrix[row, col] = new Box(col * Box.Size, row * Box.Size, Box.State.blank);
            }
            _movedList = new List<Position>();
            _players = new Player[2];  
            _graph = pnlBoard.CreateGraphics();
            _isStart = false;
            this.Text = "Gomoku - PvC";
            btnAIPlay.Enabled = false;
            _depth = 1;
            _isHaveWiner = false;
        }

        private void InitNewGame()
        {
            for (int i = 0; i < _sizeBoard; i++)
            {
                for (int j = 0; j < _sizeBoard; j++)
                    _matrix[i, j] = new Box(j * Box.Size, i * Box.Size, Box.State.blank);
            }
            _movedList.Clear();
            _graph.Clear(pnlBoard.BackColor);
            _board.Draw(_graph);
            InitPlayers();
            _isStart = true;
        }

        private void InitPlayers()
        {
            switch (_mode)
            {
                case PlayMode.PvC:
                    _players[0] = new Player("Com", Box.State.blue);
                    _players[1] = new Player("You", Box.State.red);
                    break;
                case PlayMode.CvC:
                    _players[0] = new Player("Blue", Box.State.blue);
                    _players[1] = new Player("Red", Box.State.red);
                    break;
                case PlayMode.PvP:
                    _players[0] = new Player("Blue", Box.State.blue);
                    _players[1] = new Player("Red", Box.State.red);
                    break;
                default:
                    break;
            }
        }

        private void DrawMovedList()
        {
            foreach (Position pos in _movedList)
            {
                _matrix[pos.Row, pos.Col].Draw(_graph);
            }
        }

        private bool HumanPlay(int xMouse, int yMouse)
        {
            if (xMouse % Box.Size == 0 || yMouse % Box.Size == 0)
                return false;   // nếu người chơi click vào đường kẻ thì return k xử lý

            // tính vị trị hàng và cột ứng với tọa độ chuột
            int row = yMouse / Box.Size;
            int col = xMouse / Box.Size;

            // kiếm tra ô cờ đã đi chưa
            if (_matrix[row, col].STT != Box.State.blank) 
                return false;

            this.UpdateGame(row, col);
            return true;
        }

        private void AIPlay()
        {
            //int miliSecond = (_depth-1) * 500;
            //Thread.Sleep(miliSecond);
            _openedNodes = 0;
            Thread s = new Thread(new ThreadStart(() => { lbStatus.Text = "Thinking..."; }));
            s.Start();
            s.Join();
            Node currNode = new Node(_sizeBoard, _matrix, _movedList.Count);
            Position bestMove = AlphaBeta.GetBestMove(currNode, _players[_currTurn].STT, _depth, ref _openedNodes);
            UpdateGame(bestMove.Row, bestMove.Col);
            lbStatus.Text = "";
            Thread e = new Thread(new ThreadStart(() => { lbNodes.Text = "Opened nodes: " + Convert.ToString(_openedNodes); }));
            e.Start();
            e.Join();
        }

        private void AIFirstPlay()
        { 
            UpdateGame(_sizeBoard / 2, _sizeBoard / 2);
        }

        private void UpdateGame(int row, int col)
        {
            _justMove = new Position(row, col);
            _matrix[row, col].STT = _players[_currTurn].STT;
            _matrix[row, col].Draw(_graph);
            _movedList.Add(_justMove);
            _currTurn ^= 1;
        }

        private bool IsFullBoard()
        {
            return (_sizeBoard * _sizeBoard == _movedList.Count);
        }

        private void DrawContinuous()
        {
            if (_head.Row == _tail.Row) // in a row
            {
                for (int j = _head.Col; j <= _tail.Col; j++)
                {
                    _graph.FillRectangle(Brushes.DarkSeaGreen, _matrix[_head.Row, j].Coord.X + 2, 
                        _matrix[_head.Row, j].Coord.Y + 2, Box.Size - 3, Box.Size - 3);
                    _matrix[_head.Row, j].Draw(_graph);
                }
            }
            else if (_head.Col == _tail.Col) // in a col
            {
                for (int i = _head.Row; i <= _tail.Row; i++)
                {
                    _graph.FillRectangle(Brushes.DarkSeaGreen, _matrix[i, _head.Col].Coord.X + 2,
                        _matrix[i, _head.Col].Coord.Y + 2, Box.Size - 3, Box.Size - 3);
                    _matrix[i, _head.Col].Draw(_graph);
                }
            }
            else if (_head.Col < _tail.Col) // in a left diagonal
            {
                for (int k = 0; k < 5; k++)
                {
                    _graph.FillRectangle(Brushes.DarkSeaGreen, _matrix[_head.Row + k, _head.Col + k].Coord.X + 2,
                        _matrix[_head.Row + k, _head.Col + k].Coord.Y + 2, Box.Size - 3, Box.Size - 3);
                    _matrix[_head.Row + k, _head.Col + k].Draw(_graph);
                }
            }
            else
            {
                for (int k = 0; k < 5; k++)
                {
                    _graph.FillRectangle(Brushes.DarkSeaGreen, _matrix[_head.Row + k, _head.Col - k].Coord.X + 2,
                        _matrix[_head.Row + k, _head.Col - k].Coord.Y + 2, Box.Size - 3, Box.Size - 3);
                    _matrix[_head.Row + k, _head.Col - k].Draw(_graph);
                }
            }
        }

        #region Checks end game

        private bool checkRow1()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            int c1 = _sizeBoard, c2 = -1;
            bool flag = true;
            for (int j = _justMove.Col + 1; j < _sizeBoard; j++)
            {
                if (_matrix[_justMove.Row, j].STT == currSTT && flag)
                {
                    continuous++;
                    _tail = new Position(_justMove.Row, j);
                }
                else if (_matrix[_justMove.Row, j].STT != Box.State.blank)
                {
                    c1 = j;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int j = _justMove.Col - 1; j >= 0; j--)
            {
                if (_matrix[_justMove.Row, j].STT == currSTT && flag)
                {
                    continuous++;
                    _head = new Position(_justMove.Row, j);
                }
                else if (_matrix[_justMove.Row, j].STT != Box.State.blank)
                {
                    c2 = j;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && c1 - c2 > 6);
        }
        private bool checkCol1()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            int r1 = _sizeBoard, r2 = -1;
            bool flag = true;
            for (int i = _justMove.Row + 1; i < _sizeBoard; i++)
            {
                if (_matrix[i, _justMove.Col].STT == currSTT && flag)
                {
                    continuous++;
                    _tail = new Position(i, _justMove.Col);
                }
                else if (_matrix[i, _justMove.Col].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = _justMove.Row - 1; i >= 0; i--)
            {
                if (_matrix[i, _justMove.Col].STT == currSTT && flag)
                {
                    continuous++;
                    _head = new Position(i, _justMove.Col);
                }
                else if (_matrix[i, _justMove.Col].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }
        private bool checkLeftDiagonal1()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            int r1 = _sizeBoard, r2 = -1;
            bool flag = true;
            for (int i = _justMove.Row + 1, j = _justMove.Col + 1; i < _sizeBoard && j < _sizeBoard; i++, j++)
            {
                if (_matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                    _tail = new Position(i, j);
                }
                else if (_matrix[i, j].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = _justMove.Row - 1, j = _justMove.Col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (_matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                    _head = new Position(i, j);
                }
                else if (_matrix[i, j].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }
        private bool checkRightDiagonal1()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            int r1 = _sizeBoard, r2 = -1;
            bool flag = true;
            for (int i = _justMove.Row + 1, j = _justMove.Col - 1; i < _sizeBoard && j >= 0; i++, j--)
            {
                if (_matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                    _tail = new Position(i, j);
                }
                else if (_matrix[i, j].STT != Box.State.blank)
                {
                    r1 = i;
                    break;
                }
                else flag = false;
            }
            flag = true;
            for (int i = _justMove.Row - 1, j = _justMove.Col + 1; i >= 0 && j < _sizeBoard; i--, j++)
            {
                if (_matrix[i, j].STT == currSTT && flag)
                {
                    continuous++;
                    _head = new Position(i, j);
                }
                else if (_matrix[i, j].STT != Box.State.blank)
                {
                    r2 = i;
                    break;
                }
                else flag = false;
            }
            return (continuous == 5 && r1 - r2 > 6);
        }

        private bool checkRow()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            for (int j = _justMove.Col + 1; j < _sizeBoard; j++)
            {
                if (_matrix[_justMove.Row, j].STT == currSTT)
                {
                    continuous++;
                    _tail = new Position(_justMove.Row, j);
                }
                else break;
            }
            for (int j = _justMove.Col - 1; j >= 0; j--)
            {
                if (_matrix[_justMove.Row, j].STT == currSTT)
                {
                    _head = new Position(_justMove.Row, j);
                    continuous++;
                }
                else break;
            }
            return (continuous == 5);
        }
        private bool checkCol()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            for (int i = _justMove.Row + 1; i < _sizeBoard; i++)
            {
                if (_matrix[i, _justMove.Col].STT == currSTT)
                {
                    continuous++;
                    _tail = new Position(i, _justMove.Col);
                }
                else break;
            }
            for (int i = _justMove.Row - 1; i >= 0; i--)
            {
                if (_matrix[i, _justMove.Col].STT == currSTT)
                {
                    continuous++;
                    _head = new Position(i, _justMove.Col);
                }
                else break; 
            }
            return (continuous == 5);
        }
        private bool checkLeftDiagonal()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            for (int i = _justMove.Row + 1, j = _justMove.Col + 1; i < _sizeBoard && j < _sizeBoard; i++, j++)
            {
                if (_matrix[i, j].STT == currSTT)
                {
                    continuous++;
                    _tail = new Position(i, j);
                }
                else break;
            }
            for (int i = _justMove.Row - 1, j = _justMove.Col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (_matrix[i, j].STT == currSTT)
                {
                    continuous++;
                    _head = new Position(i, j);
                }
                else break;
            }
            return (continuous == 5);
        }
        private bool checkRightDiagonal()
        {
            _head = _justMove;
            _tail = _justMove;
            Box.State currSTT = _matrix[_justMove.Row, _justMove.Col].STT;
            int continuous = 1;
            for (int i = _justMove.Row + 1, j = _justMove.Col - 1; i < _sizeBoard && j >= 0; i++, j--)
            {
                if (_matrix[i, j].STT == currSTT)
                {
                    continuous++;
                    _tail = new Position(i, j);
                }
                else break;
            }
            for (int i = _justMove.Row - 1, j = _justMove.Col + 1; i >= 0 && j < _sizeBoard; i--, j++)
            {
                if (_matrix[i, j].STT == currSTT)
                {
                    continuous++;
                    _head = new Position(i, j);
                }
                else break;
            }
            return (continuous == 5);
        }
        private bool IsGameOver()
        {
            if (checkRow1())
                return true;
            if (checkCol1())
                return true;
            if (checkLeftDiagonal1())
                return true;
            if (checkRightDiagonal1())
                return true;
            return false;
        }
        #endregion

        #region Handle some events of form
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...");
        }

        private void tsmiPvP_Click(object sender, EventArgs e)
        {
            btnAIPlay.Enabled = true;
            _isHaveWiner = false;
            _mode = PlayMode.PvP;
            InitNewGame();
            _currTurn = _rand.Next(2);
            LoadGameInfor();
        }

        private void tsmiCvC_Click(object sender, EventArgs e)
        {
            btnAIPlay.Enabled = true;
            _isHaveWiner = false;
            _mode = PlayMode.CvC;
            InitNewGame();
            _currTurn = _rand.Next(2);
            LoadGameInfor();
        }
   
        private void tsmiComStart_Click(object sender, EventArgs e)
        {
            btnAIPlay.Enabled = true;
            _isHaveWiner = false;
            _mode = PlayMode.PvC;
            InitNewGame();
            _currTurn = 0;
            AIFirstPlay();
            LoadGameInfor();
        }

        private void tsmiYouStart_Click(object sender, EventArgs e)
        {
            btnAIPlay.Enabled = true;
            _isHaveWiner = false;
            _mode = PlayMode.PvC;
            InitNewGame();
            _currTurn = 1;
            LoadGameInfor();
        }

        private void btnAIPlay_Click(object sender, EventArgs e)
        { 
            if (_isStart)
            {
                if (_movedList.Count == 0)
                {
                    AIFirstPlay();
                }
                else
                {
                    Thread t = new Thread(new ThreadStart(AIPlay));
                    t.Start();
                    t.Join();
                }
                if (IsFullBoard())
                {
                    MessageBox.Show("Full board! Let' play a new game!");
                    _isStart = false;
                    btnAIPlay.Enabled = false;
                    return;
                }
                if (IsGameOver())
                {
                    _isHaveWiner = true;
                    DrawContinuous();
                    Player winer = _players[_currTurn ^ 1];
                    MessageBox.Show(winer.Name + " WIN!");
                    _isStart = false;
                    btnAIPlay.Enabled = false;
                    return;
                }
                LoadGameInfor();
                Thread s = new Thread(new ThreadStart(() => { lbStatus.Text = "Ready"; }));
                s.Start();
                s.Join();   
            }
        }

        private void cbDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _depth = int.Parse(cbDepth.SelectedItem.ToString());
        }

        private void LoadGameInfor()
        {
            Graphics temp = pbTurn.CreateGraphics();
            if (_players[_currTurn].STT == Box.State.blue)
            {
                temp.FillRectangle(Brushes.White, 0, 0, pbTurn.Size.Width, pbTurn.Size.Height);
                temp.FillEllipse(Brushes.DarkBlue, 1, 1, pbTurn.Size.Width - 2, pbTurn.Size.Height - 2);
            }
            else
            {
                temp.FillRectangle(Brushes.White, 0, 0, pbTurn.Size.Width, pbTurn.Size.Height);
                temp.FillEllipse(Brushes.Red, 1, 1, pbTurn.Size.Width - 2, pbTurn.Size.Height - 2);
            }
        }

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawMovedList();
            _board.Draw(_graph);
            if (_isHaveWiner)
                DrawContinuous();
        }

        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isStart)
            {
                switch (_mode)
                {
                    case PlayMode.PvP:
                        if (!HumanPlay(e.X, e.Y))
                            return;
                        if (IsFullBoard())
                        {
                            _isStart = false;
                            btnAIPlay.Enabled = false;
                            MessageBox.Show("Full board! Let' play a new game!");
                            return;
                        }
                        if (IsGameOver())
                        {
                            _isStart = false;
                            _isHaveWiner = true;
                            btnAIPlay.Enabled = false;
                            DrawContinuous();
                            MessageBox.Show(_players[_currTurn ^ 1].Name + " WIN!");
                            return;
                        }
                        LoadGameInfor();
                        break;
                    case PlayMode.PvC:
                        if (!HumanPlay(e.X, e.Y))
                            return;
                        if (IsFullBoard())
                        {
                            _isStart = false;
                            btnAIPlay.Enabled = false;
                            MessageBox.Show("Full board! Let' play a new game!");
                            return;
                        }
                        if (IsGameOver())
                        {
                            _isStart = false;
                            _isHaveWiner = true;
                            btnAIPlay.Enabled = false;
                            DrawContinuous();
                            MessageBox.Show(_players[_currTurn ^ 1].Name + " WIN!");
                            return;
                        }
                        LoadGameInfor();
                        AIPlay();
                        if (IsFullBoard())
                        {
                            _isStart = false;
                            btnAIPlay.Enabled = false;
                            MessageBox.Show("Full board! Let' play a new game!");
                            return;
                        }
                        if (IsGameOver())
                        {
                            _isStart = false;
                            _isHaveWiner = true;
                            btnAIPlay.Enabled = false;
                            DrawContinuous();
                            MessageBox.Show(_players[_currTurn ^ 1].Name + " WIN!");
                            return;
                        }
                        LoadGameInfor();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Let's start a new game");
            }
        }
        #endregion
    }
}
