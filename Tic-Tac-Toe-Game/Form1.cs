using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{

    public partial class Form1 : Form
    {

        enPlayerTurn StartingPlayer = enPlayerTurn.Player1;

        public Form1()
        {
            InitializeComponent();
            StartingPlayer = enPlayerTurn.Player1;
            PlayerTurn = StartingPlayer;
        }

        public Form1(short x)
        {
            InitializeComponent();

            if (x == 0)
            {
                StartingPlayer = enPlayerTurn.Player1;
            }
            else
            {
                StartingPlayer = enPlayerTurn.Player2;
            }

            PlayerTurn = StartingPlayer;
            SetInitialUI();

        }


        stGameStatus GameStatus;
        enPlayerTurn PlayerTurn;



        struct stGameStatus { 
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        enum enPlayerTurn { 
        Player1,
        Player2
        }
        
        enum enWinner {
            player1, player2, Draw , GameInProgress
        }


        public void SetInitialUI() 
        {
            if (PlayerTurn == enPlayerTurn.Player1)
            {
                Player1_lbl.ForeColor = Color.Yellow;
                Player2_lbl.ForeColor = Color.Gray;
                CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER_TURN;
                CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER;
            }
            else
            {
                Player1_lbl.ForeColor = Color.Gray;
                Player2_lbl.ForeColor = Color.Yellow;
                CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER;
                CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER_TURN;
            }

            CARD_PLAYER1.BackgroundImageLayout = ImageLayout.Stretch;
            CARD_PLAYER2.BackgroundImageLayout = ImageLayout.Stretch;
        }


        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {

            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.Green;
                btn2.BackColor = Color.Green;
                btn3.BackColor = Color.Green;

                if (btn1.Tag.ToString() == "X")
                {

                    GameStatus.Winner = enWinner.player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }
                else
                {

                    GameStatus.Winner = enWinner.player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }

            }

            GameStatus.GameOver = false;
            return false;

        }


        public void CheckWinner()
        {

            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

        }


        public void EndGame()
        {
            if (GameStatus.Winner == enWinner.player1)
            {
                CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER_WINNER;
                CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER;

                Player1_lbl.ForeColor = Color.Yellow;
                Player2_lbl.ForeColor = Color.Gray;

                lb_Winner_Pl1.Text = "WINNER";
                lb_Winner_Pl1.ForeColor = Color.Lime;
                lb_Winner_Pl1.Visible = true;

                lb_Winner_Pl2.Text = "Loser";
                lb_Winner_Pl2.ForeColor = Color.Red;
                lb_Winner_Pl2.Visible = true;

                MessageBox.Show("Player 1 Wins", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (GameStatus.Winner == enWinner.player2)
            {
                CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER_WINNER;
                CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER;

                Player1_lbl.ForeColor = Color.Gray;
                Player2_lbl.ForeColor = Color.Yellow;

                lb_Winner_Pl2.Text = "WINNER";
                lb_Winner_Pl2.ForeColor = Color.Lime;
                lb_Winner_Pl2.Visible = true;

                lb_Winner_Pl1.Text = "Loser";
                lb_Winner_Pl1.ForeColor = Color.Red;
                lb_Winner_Pl1.Visible = true;

                MessageBox.Show("Player 2 Wins", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (GameStatus.Winner == enWinner.Draw)
            {
                CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER_WINNER;
                CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER_WINNER;

                Player2_lbl.ForeColor = Color.Yellow;
                Player1_lbl.ForeColor = Color.Yellow;

                lb_Winner_Pl1.Text = "Draw";
                lb_Winner_Pl2.Text = "Draw";

                lb_Winner_Pl1.ForeColor = Color.Yellow;
                lb_Winner_Pl2.ForeColor = Color.Yellow;

                lb_Winner_Pl1.Visible = true;
                lb_Winner_Pl2.Visible = true;

                MessageBox.Show("Draw", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ChangeImage(Button Btn) 
        {

            if (GameStatus.GameOver) return;

            if (Btn.Tag.ToString() == "?") 
            { 

            switch (PlayerTurn) {

                case enPlayerTurn.Player1 :
                    Player2_lbl.ForeColor = Color.Yellow;
                    Player1_lbl.ForeColor = Color.Gray;

                    CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER;
                    CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER_TURN;
                    CARD_PLAYER2.BackgroundImageLayout = ImageLayout.Stretch;
                    CARD_PLAYER1.BackgroundImageLayout = ImageLayout.Stretch;

                    Btn.BackgroundImage = Properties.Resources.X;
                    Btn.Tag = "X";

                    PlayerTurn = enPlayerTurn.Player2;
                    GameStatus.PlayCount++;
                    CheckWinner();

                    break;

                case enPlayerTurn.Player2:

                    Player1_lbl.ForeColor = Color.Yellow;
                    Player2_lbl.ForeColor = Color.Gray;

                    CARD_PLAYER1.BackgroundImage = Properties.Resources.CARD_PLYAER_TURN;
                    CARD_PLAYER2.BackgroundImage = Properties.Resources.CARD_PLYAER;
                    CARD_PLAYER2.BackgroundImageLayout = ImageLayout.Stretch;
                    CARD_PLAYER1.BackgroundImageLayout = ImageLayout.Stretch;

                    Btn.BackgroundImage = Properties.Resources.O;
                    Btn.Tag = "O";

                    PlayerTurn = enPlayerTurn.Player1;
                    GameStatus.PlayCount++;
                    CheckWinner();
                    
                    break;

            }

                if (GameStatus.PlayCount == 9 && !GameStatus.GameOver)
                {
                    GameStatus.GameOver = true;
                    GameStatus.Winner = enWinner.Draw;
                    EndGame();
                }
            }


            else if (Btn.Tag.ToString() == "X" || Btn.Tag.ToString() == "O")
            {
                MessageBox.Show("Error", "This Is Checkes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeImage((Button)sender);
        }


        public void ResetButton(Button Btn)
        {
            Btn.BackgroundImage = Properties.Resources.BOX;
            Btn.Tag = "?";
            Btn.BackColor = Color.Transparent;
        }

        public void RestartGame()
        {

            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            PlayerTurn = StartingPlayer;
            SetInitialUI();


            lb_Winner_Pl1.Visible = false;
            lb_Winner_Pl2.Visible = false;

            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;

        }


        private void btn_Reset_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

    }
}   
