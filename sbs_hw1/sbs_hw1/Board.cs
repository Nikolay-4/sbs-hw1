using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbs_hw1
{
    interface IBoard
    {
        string[,] board { get;}
        string this[int i, int j] { get;  set; }

    }
    class Board :IBoard
    {
        string[,] _board;
        public string [,] board { get { return _board; } }
        public Board()
        {
            _board = new string[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _board[i, j] = "";
        }
        
        public string this[int i, int j]
        {
            get
            {
                if (i > 3 || j > 3 || i < 0 || j < 0)
                    throw new Exception("выход за пределы поля");
                else
                    return _board[i, j];
            }
            set
            {
                if (i > 3 || j > 3 || i < 0 || j < 0)
                    throw new Exception("выход за пределы поля");
                if ((value != "X") && (value != "0") && (value != ""))
                    throw new Exception("неверное значение");
                else
                    _board[i, j] = value;
            }
        }
    }
}
