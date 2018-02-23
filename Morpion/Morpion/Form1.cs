using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBtn = new List<Button>(9)
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9
            };
            random = new Random();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender.Text.Equals(""))
            {
                btnSender.Text = "X";
                btnSender.Enabled = false;
                listBtn.Remove(btnSender);
                if (listBtn.Count > 0)
                {
                    Button btn = listBtn.ElementAt(random.Next(0, listBtn.Count));
                    btn.Text = "O";
                    listBtn.Remove(btn);
                    btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Partie terminée");
                    this.Close();
                }
            }
        }

        private void CheckWin()
        {
            // TODO check if someone win !
        }

        private Random random;
        private List<Button> listBtn = null;
    }
}
