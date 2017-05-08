using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbs_hw1
{
    public partial class Form1 : Form
    {
        string user_sing = "0";
        string ai_sing = "X";
        int step_count = 9; // число пустых клеток

        Button[,] buttons;
        public Form1()
        {
            InitializeComponent();
            buttons = new Button[,] { { button1, button2, button3 }, { button6, button5, button4 }, { button9, button8, button7 } };
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "")
                return;
            step_count--;
            btn.Text = user_sing;
            check();
            ai_step();
            check();
        }

        private void ai_step()
        {
           foreach(Button btn in buttons)
            { 
                if (btn.Text == "")
                {
                    btn.Text = ai_sing;
                    break;
                }
            }
            step_count--;
        }

        private void check()
        {
            string sign = "";
            // вертикально
            for(int i = 0; i < buttons.GetLength(0); i++)
            {
                if((buttons[i, 0].Text == buttons[i, 1].Text) && (buttons[i, 0].Text == buttons[i, 2].Text) && (buttons[i, 0].Text != ""))
                    sign =  buttons[i, 0].Text;
            }
            // горизонтально
            for (int i = 0; i < buttons.GetLength(1); i++)
            {
                if ((buttons[0, i].Text == buttons[1, i].Text) && (buttons[0, i].Text == buttons[2, i].Text) && (buttons[0, i].Text != ""))
                    sign = buttons[0, i].Text;
            }
            // главная диагональ
            if ((buttons[0, 0].Text == buttons[1, 1].Text) && (buttons[1, 1].Text == buttons[2, 2].Text) && (buttons[0, 0].Text != ""))
                sign = buttons[0, 0].Text;
            // побочная диагональ
            if ((buttons[2, 0].Text == buttons[1, 1].Text) && (buttons[1, 1].Text == buttons[0, 2].Text) && (buttons[2, 0].Text != ""))
                sign = buttons[2, 0].Text;
            if (sign == user_sing)
            {
                result.Text = "Победа";
                lock_board(false);
            }
            else if (sign == ai_sing)
            {
                result.Text = "Поражение";
                lock_board(false);
            }
            else if (step_count == 0)
            {
                result.Text = "Ничья";
                lock_board(false);
            }
        }

        private void clear_board()
        {
            foreach (Button btn in buttons)
                btn.Text = "";
        }

        private void lock_board(bool val)
        {
            foreach (Button btn in buttons)
                btn.Enabled = val;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear_board();
            step_count = 9;
            lock_board(true);
            result.Text = "";
            if (radio0.Checked) {
                user_sing = "0";
                ai_sing = "X";
            }
            else
            {
                user_sing = "X";
                ai_sing = "0";
            }
        }

    }
}
