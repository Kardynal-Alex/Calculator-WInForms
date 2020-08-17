using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULATOR
{
    public partial class Form1 : Form
    {
        double result;
        string operation = "";
        bool znak = true;
        public Form1()
        {
            InitializeComponent();
            not_available_buttons();
            button1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)//off
        {
            not_available_buttons();
            button21.Hide();
            button21.Show();
            textBox1.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)//on
        {
            button21.Hide();
            button1.Show();
            available_buttons();

        }

        private void not_available_buttons()
        {
            button2.Enabled = false; button3.Enabled = false; button4.Enabled = false;
            button5.Enabled = false; button6.Enabled = false; button7.Enabled = false;
            button8.Enabled = false; button9.Enabled = false; button10.Enabled = false;
            button11.Enabled = false; button12.Enabled = false; button13.Enabled = false;
            button14.Enabled = false; button15.Enabled = false; button16.Enabled = false;
            button17.Enabled = false; button18.Enabled = false; button19.Enabled = false;
            button20.Enabled = false;
        }
        private void available_buttons()
        {
            button2.Enabled = true; button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true; button7.Enabled = true;
            button8.Enabled = true; button9.Enabled = true; button10.Enabled = true;
            button11.Enabled = true; button12.Enabled = true; button13.Enabled = true;
            button14.Enabled = true; button15.Enabled = true; button16.Enabled = true;
            button17.Enabled = true; button18.Enabled = true; button19.Enabled = true;
            button20.Enabled = true;
        }

        private void Click_on_numbers(object sender, EventArgs e)//'1'..'9'+','
        {
            Button b = (Button)sender;

            if (b.Text == ",")
            {
                if (!textBox1.Text.Contains(","))
                {
                    if (textBox1.Text.Length != 0)
                        textBox1.Text += b.Text;
                }
            } else
            {
                textBox1.Text += b.Text;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)// + - * /
        {
            Button b = (Button)sender;
            if (result != 0)
            {
                if (label1.Text.Contains("+") || label1.Text.Contains("-") || label1.Text.Contains("*") || label1.Text.Contains("/"))
                {
                    operation = b.Text;
                    label1.Text = "";
                    label1.Text = result + " " + operation;
                }else
                {
                    button20.PerformClick();
                    operation = b.Text;
                    textBox1.Text = "";
                    label1.Text = result + " " + operation;
                }
                
            }else
            {
                    operation = b.Text;
                    result = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                    label1.Text = result + " " + operation;
            }
        }

        private void button20_Click(object sender, EventArgs e)//equals =
        {
            label1.Text = "";
            switch (operation)
            {
                case "+":
                    textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textBox1.Text);
            operation = "";
        }

        private void button2_Click(object sender, EventArgs e)//delete all
        {
            result = 0;
            textBox1.Text = "";
            label1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)//+/-
        {
            if(znak==true)
            {
                if(textBox1.Text=="0")
                {
                    textBox1.Text = "";
                }
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else
            if(znak==false)
            {
                textBox1.Text = textBox1.Text.Replace("-","");
                znak = true;
            }
              
        }

        private void button3_Click(object sender, EventArgs e)//clear 1 symbol
        {   
            if(textBox1.Text.Length>0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }

            if(textBox1.Text=="")
            {
                textBox1.Text = "";
            }
        }

        private void cOSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
