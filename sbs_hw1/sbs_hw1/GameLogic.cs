using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbs_hw1
{

    interface IActionXO
    {
        void userStep(int i, int j);
        void aiStep();
        string status
        {
            get;
        }
        void check();
        string[,] Board
        {
            get;
        }
        void saveStats();

        List<Stats> getStats();
        double getAvgWin();
    }

    class GameLogic : IActionXO
    {
        GameStats gameStats;
        public string status { get; private set; }
        IBoard board;
        public string[,] Board
        {
            get { return board.board; }
        }
        int emptyCell;
        string userSign;
        int numUserSteps;
        string aiSign;

        public GameLogic(string _aiSign, string _userSign)
        {
            board = new Board();
            gameStats = new GameStats();
            userSign = _userSign;
            aiSign = _aiSign;
            clear_board();
            emptyCell = 9;
            status = "";
        }

        public void userStep(int i, int j)
        {
            board[i, j] = userSign;
            emptyCell--;
            numUserSteps++;
        }
        private void clear_board()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = "";
        }

        public void aiStep()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(board[i, j] == "")
                    {
                        board[i, j] = aiSign;
                        emptyCell--;
                        return;
                    }
                }
            }
        }

        public void check()
        {
            string sign = "";
            // вертикально
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == board[i, 1]) && (board[i, 0] == board[i, 2]) && (board[i, 0] != ""))
                    sign = board[i, 0];
            }
            // горизонтально
            for (int i = 0; i < 3; i++)
            {
                if ((board[0, i] == board[1, i]) && (board[0, i] == board[2, i]) && (board[0, i] != ""))
                    sign = board[0, i];
            }
            // главная диагональ
            if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]) && (board[0, 0] != ""))
                sign = board[0, 0];
            // побочная диагональ
            if ((board[2, 0] == board[1, 1]) && (board[1, 1] == board[0, 2]) && (board[2, 0] != ""))
                sign = board[2, 0];
            
            if (sign == userSign)
            {
                status = "Победа";
            }
            else if (sign == aiSign)
            {
                status = "Поражение";
            }
            else if (emptyCell == 0)
            {
                status = "Ничья";
            }
        }

        public void saveStats()
        {
            gameStats.add(status, userSign, numUserSteps);
        }

        public List<Stats> getStats()
        {
            gameStats.getAllStats();
            return gameStats.listStats;
        }

        public double getAvgWin()
        {
            return gameStats.getAvgWin();
        }
    }
}
