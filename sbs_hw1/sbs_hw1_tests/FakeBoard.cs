using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sbs_hw1;

namespace sbs_hw1_tests
{
    class FakeBoard : IBoard
    {
        public string[,] _board;
        public string[,] board { get { return _board; } }

        public string this[int i, int j]
        {
            get
            {
                return _board[i, j];
            }
            set
            {
                _board[i, j] = value;
            }
        }

      
    }
}
