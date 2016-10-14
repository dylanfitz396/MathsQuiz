using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsQuiz
{
    public partial class Form1 : Form
    {
        //Create a Random object to generate random numbers.
        Random randomizer = new Random();

        //these ints will store the numbers
        // for the addition problem
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        // this int will keep track of the time left
        int timeLeft;       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            // Fill in the addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Fill in the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(0, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem
            multiplicand = randomizer.Next(11);
            multiplier = randomizer.Next(11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //if the user got the answer right, stop the time
                //and show a messageBox
                timer1.Stop();
                MessageBox.Show("Congrats", "You got all the answers right!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //Display the new time left
                //by updating the time left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //if the user ran out of time, stop the timer, show
                //a messageBox, and fill in the answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;


            }
        }

        /// <summary>
        /// check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
            private bool CheckTheAnswer()
            {
                if ((sum.Value == addend1 + addend2)
                    && (minuend - subtrahend == difference.Value)
                    && (multiplicand * multiplier == product.Value)
                    && (dividend / divisor == quotient.Value))
                    return true;
                else
                    return false;

            }

            private void answer_Enter(object sender, EventArgs e)
            {
                //Select the whole answer in the numericUpDown control.
                NumericUpDown answerBox = sender as NumericUpDown;

                if (answerBox != null)
                {
                    int lengthOfAnswer = answerBox.Value.ToString().Length;
                    answerBox.Select(0, lengthOfAnswer);
                }
            }

        
    }
}
