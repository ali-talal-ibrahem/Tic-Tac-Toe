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

        private void button_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
