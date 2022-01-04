namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Bool for tracking if it is turn for X or turn for O. If true it is X's turn, if false it is O's turn
        bool turn = true;
        // Keeps track of the turns 
        int count = 0;
        // Bool to keep game going
        bool gameGoing = true;
        // Ints to keep track of each player's win count
        int XWins = 0;
        int OWins = 0;
        //Initializes form (i.e the UI)
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "Current Turn: X";
        }
        // Method for what happens when one of the buttons is clicked
        private void button_Click(object sender, EventArgs e)
        {
            // Try/catch for exception handling 
            try
            {
                // Intialize button changer 
                Button button = (Button)sender;
                /* If/else to check in the box is already filled. If text is not blank then it is filled so send a message then return.
                If text is blank fill it with whose turn it is based on turn bool*/
                if (button.Text != "")
                {
                    MessageBox.Show("That box is already in use");
                    return;
                }
                else
                { 
                    if (turn == true)
                    {
                        button.Text = "X";

                    }
                    else
                    {
                        button.Text = "O";
                    }
                }
                
            }
            //Exception caught so the game doesn't just crash
            catch (Exception ex)
            {
                MessageBox.Show("Error, try again!");
            }
            togglePlayer();
        }
        // Method to swap the players after checking win conditions 
        public void togglePlayer()
        {
            count++;
            Game();
            turn = !turn;
            if (turn == true)
            {
                textBox2.Text = "Current Turn: X";
            }
            else
            {
                textBox2.Text = "Current Turn: O";
            }
        }
        // Method for win conditions
        public void Game()
        {
            // Win conditions. If one of the if statements is true then gameGoing is set to false so the game can end and declare the winner
            // Top row filled
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text != ""))
            {
                gameGoing = false;
            }
            // Middle row filled
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (button4.Text != ""))
            {
                gameGoing = false;
            }
            // Bottom row filled
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (button7.Text != ""))
            {
                gameGoing = false;
            }
            // Left column filled
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (button1.Text != ""))
            {
                gameGoing=false;
            }
            // Middle column filled
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (button2.Text != ""))
            {
                gameGoing = false;
            }
            // Right column filled
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Text != ""))
            {
                gameGoing = false;
            }
            // First diagnol
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (button1.Text != ""))
            {
                gameGoing = false;
            }
            // Second diagnol
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Text != ""))
            {
                gameGoing = false;
            }
            //If count reaches 9 the board is full so the game must end
            else if (count == 9)
            {
                MessageBox.Show("It is a tie!");
                gameGoing = false;
                Restart();
            }
            // Once gameGoing has been marked false declare the winner based on whose turn it was last
            if (gameGoing == false)
            {
                string winner = " ";
                if (turn == true)
                {
                    winner = "X";
                    XWins++;
                    textBox3.Text = "Player X win count: " + XWins;
                }
                else
                {
                    winner = "O";
                    OWins++;
                    textBox4.Text = "Player O win count: " + OWins;
                }
                MessageBox.Show("The winner is " + winner + "!");
                Restart();
            }
        }
        public void Restart()
        {
            count = 0;
            gameGoing = true;
            DialogResult playAgain = MessageBox.Show("Would you like to play again? ", "Game Over", MessageBoxButtons.YesNo);
            if(playAgain == DialogResult.Yes)
            { 
                MessageBox.Show("Clearing the board and swapping players.");
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
            else if (playAgain == DialogResult.No)
            {
                Application.Exit();
            }
        }
 
    }
}