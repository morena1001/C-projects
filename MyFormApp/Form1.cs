using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    public int Player = 2; // even = X turn; odd = O turn
    public int turns  = 0; // counting turns

    // counting for both players and draws
    public int s1     = 0;
    public int s2     = 0;
    public int sd     = 0;

    private void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.Text == "")
        {
            if (Player % 2 == 0)
            {
                button.Text = "X";
                Player++;
                turns++;
            }
            else
            {
                button.Text = "O";
                Player++;
                turns++;
            }

            if (CheckDraw() == true)
            {
                MessageBox.Show("Tie Game!");
                sd++;
                NewGame();
            }

            if (CheckWinner() == true)
            {
                if (button.Text == "X")
                {
                    MessageBox.Show("X Won!");
                    s1++;
                    NewGame();
                }
                else
                {
                    MessageBox.Show("O Won!");
                    s2++;
                    NewGame();
                }
            }
        }
    }

    private void EButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void RButton_Click(object sender, EventArgs e)
    {
        s1 = s2 = sd = 0;
        NewGame();
    }

     private void NGButton_Click(object sender, EventArgs e)
    {
        NewGame();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        XWin.Text  = "X: " + s1;
        OWin.Text  = "O: " + s2;
        Draws.Text = "Draws: " + sd;
    }

    void NewGame()
    {
        Player = 2;
        turns = 0;
        A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
        XWin.Text = "X: " + s1;
        OWin.Text = "O: " + s2;
        Draws.Text = "Draws: " + sd;
    }

    bool CheckDraw()
    {
        if (turns == 9 && CheckWinner() == false)
            return true;
        else
            return false;
    }

    bool CheckWinner()
    {
        // horizontal check
        if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && A00.Text != "")
            return true;
        else if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && A10.Text != "")
            return true;
        else if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && A20.Text != "")
            return true;

        // vertical check
        if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && A00.Text != "")
            return true;
        else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && A01.Text != "")
            return true;
        else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && A02.Text != "")
            return true;

        // diagonal check
        if ((A00.Text == A11.Text) && (A11.Text == A22.Text) && A00.Text != "")
            return true;
        else if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && A02.Text != "")
            return true;
        else
            return false;
    }
}
