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
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayerTurn PlayerTurn = enPlayerTurn.Player1;



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
            player1, player2, draw , GameInProgress
        }


        public void ChangeImage(Button Btn) 
        {

            switch (PlayerTurn)
            {
                case enPlayerTurn.Player1 :
                    Player2_lbl.ForeColor = Color.Yellow;
                    Player1_lbl.ForeColor = Color.Gray;

                    CARD_PLAYER1.Image = Properties.Resources.CARD_PLYAER;
                    CARD_PLAYER2.Image = Properties.Resources.CARD_PLYAER_TURN;

                    Btn.BackgroundImage = Properties.Resources.X;
                    Btn.Tag = "X";

                    PlayerTurn = enPlayerTurn.Player2;
                    GameStatus.PlayCount++;

                    break;

                case enPlayerTurn.Player2:
                    Player1_lbl.ForeColor = Color.Yellow;
                    Player2_lbl.ForeColor = Color.Gray;

                    CARD_PLAYER1.Image = Properties.Resources.CARD_PLYAER_TURN;
                    CARD_PLAYER2.Image = Properties.Resources.CARD_PLYAER;

                    Btn.BackgroundImage = Properties.Resources.O;
                    Btn.Tag = "O";

                    PlayerTurn = enPlayerTurn.Player1;
                    GameStatus.PlayCount++;

                    break;
            }
        
        }

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeImage((Button)sender);
        }
    }
}
