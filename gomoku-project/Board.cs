using System.Drawing;

namespace gomoku_project
{
    public class Board
    {
        private static int _size;
        public static int Size { get => _size; }
        public Board(int size)
        {
            _size = size;
        }
        public void Draw(Graphics grs)
        {
            Pen pen = new Pen(Color.SkyBlue);
            for (int i = 0; i <= Size; i++)
            {
                grs.DrawLine(pen, 0, i * Box.Size, Size * Box.Size, i * Box.Size);
            }
            for (int i = 0; i <= Size; i++)
            {
                grs.DrawLine(pen, i * Box.Size, 0, i * Box.Size, Size * Box.Size);
            }
        }
    }
}
