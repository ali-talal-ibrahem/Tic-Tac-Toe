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
    public partial class FormSelectPlayer : Form
    {
        public FormSelectPlayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short playerTag = Convert.ToInt16(button1.Tag);

            this.Hide();

            using (Form1 frm = new Form1(playerTag))
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            short playerTag = Convert.ToInt16(button2.Tag);

            this.Hide();

            using (Form1 frm = new Form1(playerTag))
            {
                frm.ShowDialog();
            }

            this.Close();
        }
    }
}
