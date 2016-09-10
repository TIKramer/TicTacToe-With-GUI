using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeGame : Form
    {
        bool player_Ones_Turn = true;
        int turn_Count = 0;
        public TicTacToeGame()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutPage = new AboutBox1();
            aboutPage.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for playing! :)", "Good bye");
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player_Ones_Turn = true;
            turn_Count = 0;
            WinnerTxt.Visible = false;
            resetButtons();
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
          
                Button selected_Button = (Button)sender;
                selected_Button.Text = (player_Ones_Turn) ? "X" : "O";
                player_Ones_Turn = !player_Ones_Turn;
                selected_Button.Enabled = false;
                if (turn_Count >= 3)
                    Check_Winner(selected_Button);
                turn_Count++;
                if(turn_Count > 8)
            {
                WinnerTxt.Text = "It is a draw!";
                WinnerTxt.Visible = true;
            }
            
         
        }

        private void Check_Winner(Button selectedButton)
        {
            Char[] name = selectedButton.Name.ToCharArray();
            Boolean winner = false;
            //Check across


            Control horizontal1 = TicTacToeBoard.Controls["" + name[0] + 1];  
            Control horizontal2 = TicTacToeBoard.Controls["" + name[0] + 2];
            Control horizontal3 = TicTacToeBoard.Controls["" + name[0] + 3];
            Control vertical1 = TicTacToeBoard.Controls["" + 'A' + name[1]];
            Control vertical2 = TicTacToeBoard.Controls["" + 'B' + name[1]];
            Control vertical3 = TicTacToeBoard.Controls["" + 'C' + name[1]];
            //Only checks horizontal related to selected button position
          
           
            if (horizontal1.Text.Equals(horizontal2.Text) && horizontal1.Text.Equals(horizontal3.Text) && !String.IsNullOrEmpty(horizontal2.Text))
            {
                winner = true;
                changeBackColor((Button)horizontal1, (Button)horizontal2, (Button)horizontal3);
            }
            //Only checks verticaly related to selected button position

            else if (vertical1.Text.Equals(vertical2.Text) && vertical2.Text.Equals(vertical3.Text) && !String.IsNullOrEmpty(vertical3.Text))
            {
                winner = true;
                changeBackColor((Button)vertical1, (Button)vertical2, (Button)vertical3);
               
            }

            //checks diagonal

            else if (A1.Text.Equals(B2.Text) && B2.Text.Equals(C3.Text) && !String.IsNullOrEmpty(B2.Text))
                {
                    winner = true;
                changeBackColor(A1, B2, C3);
            }
           else if (A3.Text.Equals(B2.Text) && B2.Text.Equals(C1.Text) && !String.IsNullOrEmpty(B2.Text))
                {
                    winner = true;
                    changeBackColor(A3, B2, C1);
            }

            
            if (winner == true)
            {
                disableButtons();
                int playerNum = player_Ones_Turn ? 2 : 1;
                WinnerTxt.Text = "Player: " + playerNum + " is the winner!";
                WinnerTxt.Visible = true;
            }


        }
        private void disableButtons()
        {

            foreach (Control control in TicTacToeBoard.Controls)
            {
                Button gridButtons = (Button)control;
                gridButtons.Enabled = false;

            }
        }

        private void resetButtons()
        {

            foreach (Control control in TicTacToeBoard.Controls)
            {
                Button gridButtons = (Button)control;
                gridButtons.Enabled = true;
                gridButtons.Text = "";
                gridButtons.BackColor = System.Drawing.Color.Transparent;

            }
        }

       

        private void changeBackColor(Button b1, Button b2, Button b3)
        {
           
                b1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                b2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                b3.BackColor = System.Drawing.Color.LightGoldenrodYellow;

        }

       

      
    }
}
