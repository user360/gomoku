using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gomoku_project
{
    public class Player
    {
        private Box.State _stt;
        private String _name;
        public string Name { get => _name; set => _name = value; }
        internal Box.State STT { get => _stt; set => _stt = value; }

        public Player(String name, Box.State stt)
        {
            _stt = stt;
            _name = name;
        }
    }
}
