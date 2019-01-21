using System.Drawing;

namespace gomoku_project
{
    public class Box
    {
        public enum State
        {
            red = 1,
            blue = 0,
            blank = -1
        }
   
        private State _stt;
        public State STT { get => _stt; set => _stt = value; }

        private static int _size = 25;
        public static int Size { get => _size; }

        private Point _coord;
        public Point Coord { get => _coord; }

        public Box(int x, int y, State stt) {_coord.X = x; _coord.Y = y; _stt = stt; }

        public void Draw(Graphics grs)
        {
            switch (STT)
            {
                case State.blue:
                    grs.FillEllipse(Brushes.DarkBlue, _coord.X + 2, _coord.Y + 2, Size - 4, Size - 4);
                    //grs.DrawImage(gomoku_project.Properties.Resources.O,
                    //    _coord.X + 1, _coord.Y + 1, Size - 1, Size - 1);
                    break;
                case State.red:
                    grs.FillEllipse(Brushes.Red, _coord.X + 2, _coord.Y + 2, Size - 4, Size - 4);
                    //grs.DrawImage(gomoku_project.Properties.Resources.X,
                    //    _coord.X + 1, _coord.Y + 1, Size - 1, Size - 1);
                    break;
                default:
                    break;
            }
        }
    }
}
