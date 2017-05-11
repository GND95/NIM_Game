using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIM
{
    public partial class Form1 : Form
    {
        int Sticks;
        Random R;
        
        public Form1()
        {
            InitializeComponent();
            R = new Random();
            Sticks = R.Next(10) + 10;
            ShowGame();
            label2.Text = "It is your turn, player.";
        }

        void ShowGame()
        {
            string Temp = "";
            for (int i = 0; i < Sticks; i++)
                Temp += "  |";
            label1.Text = Temp;
        }

        void TakeSticks(int N)
        {
         //Human turn
            Sticks -= N;
            GameOver(true);
            //Computer turn
            int c = (Sticks - 1) % 4;
            if (c==0)
                c = R.Next(3) + 1;
            Sticks -= c;
            ShowGame();
            label2.Text = "I took " + c.ToString() + " sticks";
            GameOver(false);
        }

        void GameOver(bool Player)
        {
            if (Sticks < 2)
            {
                ShowGame();
                string Message = "You lose this round...";
                if (Sticks == 1)
                {
                    if (Player == true)
                        Message = "You won this round...";
                }
                MessageBox.Show(Message, "Game Over");
                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TakeSticks(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TakeSticks(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TakeSticks(3);
        }
    }
}
