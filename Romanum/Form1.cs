using System;
using System.Drawing;

using System.Collections.Generic;
using System.Windows.Forms;




namespace Romanum
{


    public partial class Form1 : Form
    {
        public static string IntToRoman(int number)
        {
            string romanNumeral = "";

            // Define the roman numerals
            string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] romanNumeralValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            // Iterate through the roman numerals and append the appropriate symbol to the romanNumeral string
            for (int i = 0; i < romanNumeralValues.Length; i++)
            {
                while (number >= romanNumeralValues[i])
                {
                    romanNumeral += romanNumerals[i];
                    number -= romanNumeralValues[i];
                }
            }

            return romanNumeral;
        }

        public static int RomanToInt(string roman)
        {
            int result = 0;
    

            // Create a dictionary to map each Roman numeral to its corresponding integer value
            Dictionary<char, int> romanValues = new Dictionary<char, int>
                {
                    {'I', 1},
                    {'V', 5},
                    {'X', 10},
                    {'L', 50},
                    {'C', 100},
                    {'D', 500},
                    {'M', 1000}
                };


            // Iterate through the string of Roman numerals from right to left
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                // Get the integer value of the current Roman numeral
                int value = romanValues[roman[i]];

                // If the previous Roman numeral has a greater value, subtract its value from the result
                if (i < roman.Length - 1 && romanValues[roman[i + 1]] > value)
                {
                    result -= value;
                }
                // Otherwise, add the value to the result
                else
                {
                    result += value;
                }
            }

            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }
        bool isRomanText(string text)
        {
            foreach (char item in text)
            {
                if (item == 'I' || item == 'V' || item == 'X' || item == 'L' ||
                    item == 'C' || item == 'D' || item == 'M')
                    continue;
                return false;
            }
            return true ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
               
            if (label2.Text == "Roman Numerals")
            {
                if(!isRomanText(textBox1.Text))
                {
                    textBox1.Text = "";
                    MessageBox.Show("Only Roman Numerals Allowed [ I V X L C D M ]", "Invalid Value",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                label4.Text =  RomanToInt(textBox1.Text).ToString();
                return;
            }

           
            if (int.TryParse(textBox1.Text, out int ss))
            {
                if (ss > 999999)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length -1);
                    MessageBox.Show("Only You Can Do Calculations between 1 and 999999", "Invalid Larg Number",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                label4.Text = IntToRoman(ss);
                return;
            }
            textBox1.Text = "";
            MessageBox.Show("Only Digits Allowed [ 1 2 3 4 5 6 7 8 9 0 ]", "Invalid Value",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Invalidate();
            if (label2.Text == "Integers")
            {
                label2.Text = "Roman Numerals";
                label2.ForeColor = Color.DimGray;
                label3.Text = "Integers";
                label3.ForeColor = Color.FromArgb(0, 192, 192);
                textBox1.Text = "";
                label4.Text = "";
                return;
            }
            label2.Text = "Integers";
            label2.ForeColor = Color.FromArgb(0, 192, 192);
            label3.Text = "Roman Numerals";
            label3.ForeColor = Color.DimGray;

            textBox1.Text = "";
            label4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            //textBox1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

        }
    }
}
