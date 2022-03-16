using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_MU6_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        bool currentPlayer = true;
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            myButton.Text = currentPlayer ? "X" : "O";
            myButton.IsEnabled = false;
            CheckGame();
            currentPlayer = !currentPlayer;
            if (!currentPlayer) {
                MachinePlay();
            }
        }

        private void CheckGame() {
            bool row0NotEmpty = btn00.Text != "" && btn01.Text != "" && btn02.Text != "";
            bool row1NotEmpty = btn10.Text != "" && btn11.Text != "" && btn12.Text != "";
            bool row2NotEmpty = btn20.Text != "" && btn21.Text != "" && btn22.Text != "";

            if (btn00.Text == btn01.Text && btn00.Text == btn02.Text && row0NotEmpty) {
                lblHeader.Text = btn00.Text == "X" ? "PLAYER 1 WON!" : "PLAYER 2 WON!";
            }
            else if (btn10.Text == btn11.Text && btn10.Text == btn12.Text && row1NotEmpty)
            {
                lblHeader.Text = btn10.Text == "X" ? "PLAYER 1 WON!" : "PLAYER 2 WON!";
            }
            else if (btn20.Text == btn21.Text && btn20.Text == btn22.Text && row2NotEmpty)
            {
                lblHeader.Text = btn20.Text == "X" ? "PLAYER 1 WON!" : "PLAYER 2 WON!";
            }
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            lblHeader.Text = "TIC TAC TOE";
            btn00.Text = "";
            btn00.IsEnabled = true;
            btn01.Text = "";
            btn01.IsEnabled = true;
            btn02.Text = "";
            btn02.IsEnabled = true;

            btn10.Text = "";
            btn10.IsEnabled = true;
            btn11.Text = "";
            btn11.IsEnabled = true;
            btn12.Text = "";
            btn12.IsEnabled = true;

            btn20.Text = "";
            btn20.IsEnabled = true;
            btn21.Text = "";
            btn21.IsEnabled = true;
            btn22.Text = "";
            btn22.IsEnabled = true;

            currentPlayer = true;
        }

        private void MachinePlay() {
            List<Button> myList = new List<Button>();
            if (btn00.Text == "") {
                myList.Add(btn00);
            }
            if (btn01.Text == "")
            {
                myList.Add(btn01);
            }
            if (btn02.Text == "")
            {
                myList.Add(btn02);
            }
            if (btn10.Text == "")
            {
                myList.Add(btn10);
            }
            if (btn11.Text == "")
            {
                myList.Add(btn11);
            }
            if (btn12.Text == "")
            {
                myList.Add(btn12);
            }
            if (btn20.Text == "")
            {
                myList.Add(btn20);
            }
            if (btn21.Text == "")
            {
                myList.Add(btn21);
            }
            if (btn22.Text == "")
            {
                myList.Add(btn22);
            }
            Random rdm = new Random();
            int op = rdm.Next(0, myList.Count);
            if(myList.Count>0)
                Button_Clicked(myList[op], null);
        }
    }
}