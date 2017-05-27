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

        IActionXO game;
        Dictionary<string, int[]> buttonsCoord;
        Button[,] buttons;
        public Form1()
        {
            InitializeComponent();
            
            buttonsCoord = new Dictionary<string, int[]>();
            buttonsCoord.Add("button1", new int[]{ 0, 0});
            buttonsCoord.Add("button2", new int[] { 0, 1 });
            buttonsCoord.Add("button3", new int[] { 0, 2 });
            buttonsCoord.Add("button6", new int[] { 1, 0 });
            buttonsCoord.Add("button5", new int[] { 1, 1 });
            buttonsCoord.Add("button4", new int[] { 1, 2 });
            buttonsCoord.Add("button9", new int[] { 2, 0 });
            buttonsCoord.Add("button8", new int[] { 2, 1 });
            buttonsCoord.Add("button7", new int[] { 2, 2 });

            buttons = new Button[,] { { button1, button2, button3 }, { button6, button5, button4 }, { button9, button8, button7 } };
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "")
                return;
            int i = buttonsCoord[btn.Name][0];
            int j = buttonsCoord[btn.Name][1];
            game.userStep(i, j);
            display();
            check();
            game.aiStep();
            display();
            check();
        }

        void display()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    buttons[i, j].Text = game.Board[i, j];
        }

     

        private void check()
        {
            game.check();
           if(game.status != "")
            {
                result.Text = game.status;
                lock_board(false);
            }
        }


        private void lock_board(bool val)
        {
            foreach (Button btn in buttons)
                btn.Enabled = val;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lock_board(true);
            result.Text = "";
            string userSign, aiSign;
            if (radio0.Checked) {
                userSign = "0";
                aiSign = "X";
            }
            else
            {
                userSign = "X";
                aiSign = "0";
            }
            game = new GameLogic(aiSign, userSign);
            display();
        }

        private void exception_Click(object sender, EventArgs e)
        {
            try
            {
                game.userStep(5, 5);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
