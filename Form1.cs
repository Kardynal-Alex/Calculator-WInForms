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
            label1.Text = "";
            result=0;
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
            button20.Enabled = false; button22.Enabled = false; button23.Enabled = false;
            button24.Enabled = false; button25.Enabled = false; button26.Enabled = false;
            button27.Enabled = false; button28.Enabled = false; button29.Enabled = false;
            button30.Enabled = false; button31.Enabled = false; button32.Enabled = false;
            button33.Enabled = false; button34.Enabled = false; button35.Enabled = false;
            button36.Enabled = false; button37.Enabled = false; button38.Enabled = false;
            button39.Enabled = false; button40.Enabled = false;
        }
        private void available_buttons()
        {
            button2.Enabled = true; button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true; button7.Enabled = true;
            button8.Enabled = true; button9.Enabled = true; button10.Enabled = true;
            button11.Enabled = true; button12.Enabled = true; button13.Enabled = true;
            button14.Enabled = true; button15.Enabled = true; button16.Enabled = true;
            button17.Enabled = true; button18.Enabled = true; button19.Enabled = true;
            button20.Enabled = true; button22.Enabled = true; button23.Enabled = true;
            button24.Enabled = true; button25.Enabled = true; button26.Enabled = true;
            button27.Enabled = true; button28.Enabled = true; button29.Enabled = true;
            button30.Enabled = true; button31.Enabled = true; button32.Enabled = true;
            button33.Enabled = true; button34.Enabled = true; button35.Enabled = true;
            button36.Enabled = true; button37.Enabled = true; button38.Enabled = true;
            button39.Enabled = true; button40.Enabled = true;
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
                if ((label1.Text.Contains("+") || label1.Text.Contains("-") || label1.Text.Contains("*") || label1.Text.Contains("/")) && textBox1.Text=="")
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
            }
            else
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

        private void button22_Click(object sender, EventArgs e)//3,1415
        {
            textBox1.Text = Math.PI.ToString();
        }

        private void button23_Click(object sender, EventArgs e)//log[2](x)
        {
            if(textBox1.Text!="" && Double.Parse(textBox1.Text)>0)
            {
                double log = Double.Parse(textBox1.Text);
                log= Math.Log(log, 2);
                textBox1.Text = log.ToString();
                button20.PerformClick();
            }
        }

        private void button24_Click(object sender, EventArgs e)//sqrt(x)
        {
            if (textBox1.Text != "" && Double.Parse(textBox1.Text) >= 0)
            {
                double sqrt = Double.Parse(textBox1.Text);
                sqrt = Math.Sqrt(sqrt);
                textBox1.Text = sqrt.ToString();
                button20.PerformClick();
            }
        }

        private void button25_Click(object sender, EventArgs e)//1/x
        {
            if (textBox1.Text != "" && Double.Parse(textBox1.Text) != 0)
            {
                double obx = Double.Parse(textBox1.Text);
                obx = 1/obx;
                textBox1.Text = obx.ToString();
                button20.PerformClick();
            }
        }

        private void button26_Click(object sender, EventArgs e)//x^2
        {
            if (textBox1.Text != "")
            {
                double square = Double.Parse(textBox1.Text);
                square = Math.Pow(square,2);
                textBox1.Text = square.ToString();
                button20.PerformClick();
            }
        }

        private void button27_Click(object sender, EventArgs e)//x^3
        {
            if (textBox1.Text != "")
            {
                double square = Double.Parse(textBox1.Text);
                square = Math.Pow(square, 3);
                textBox1.Text = square.ToString();
                button20.PerformClick();
            }
        }

        private void button28_Click(object sender, EventArgs e)//Sin(x)
        {
            if (textBox1.Text != "")
            {
                double sin = Double.Parse(textBox1.Text);
                sin = Math.Sin(sin);
                textBox1.Text = sin.ToString();
                button20.PerformClick();
            }
        }

        private void button29_Click(object sender, EventArgs e)//Cos(x)
        {
            if (textBox1.Text != "")
            {
                double cos = Double.Parse(textBox1.Text);
                cos = Math.Cos(cos);
                textBox1.Text = cos.ToString();
                button20.PerformClick();
            }
        }

        private void button30_Click(object sender, EventArgs e)//Tan(x)
        {
            if (textBox1.Text != "")
            {
                double tg = Double.Parse(textBox1.Text);
                tg = Math.Tan(tg);
                textBox1.Text = tg.ToString();
                button20.PerformClick();
            }
        }

        private void button31_Click(object sender, EventArgs e)//Asin(x)
        {
            if (textBox1.Text != "" && (Double.Parse(textBox1.Text) >= -1 && Double.Parse(textBox1.Text) <= 1))
            {
                double asin = Double.Parse(textBox1.Text);
                asin = Math.Asin(asin);
                textBox1.Text = asin.ToString();
                button20.PerformClick();
            }
        }

        private void button32_Click(object sender, EventArgs e)//Acos(x)
        {
            if (textBox1.Text != "" && (Double.Parse(textBox1.Text) >= -1 && Double.Parse(textBox1.Text) <= 1))
            {
                double acos = Double.Parse(textBox1.Text);
                acos = Math.Acos(acos);
                textBox1.Text = acos.ToString();
                button20.PerformClick();
            }
        }

        private void button33_Click(object sender, EventArgs e)//Atan(x)
        {
            if (textBox1.Text != "")
            {
                double atg = Double.Parse(textBox1.Text);
                atg = Math.Atan(atg);
                textBox1.Text = atg.ToString();
                button20.PerformClick();
            }
        }

        private void button34_Click(object sender, EventArgs e)//e
        {
            textBox1.Text = Math.E.ToString();
        }

        private void button35_Click(object sender, EventArgs e)//|x|
        {
            if(Double.Parse(textBox1.Text)<0)
            {
                double abs = Double.Parse(textBox1.Text);
                abs = Math.Abs(abs);
                textBox1.Text = abs.ToString();
            }
        }

        private void button36_Click(object sender, EventArgs e)//SinH(x)
        {
            if (textBox1.Text != "")
            {
                double sinh = Double.Parse(textBox1.Text);
                sinh = Math.Sinh(sinh);
                textBox1.Text = sinh.ToString();
                button20.PerformClick();
            }
        }

        private void button37_Click(object sender, EventArgs e)//CosH(x)
        {
            if (textBox1.Text != "")
            {
                double cosh = Double.Parse(textBox1.Text);
                cosh = Math.Cosh(cosh);
                textBox1.Text = cosh.ToString();
                button20.PerformClick();
            }
        }

        private void button38_Click(object sender, EventArgs e)//Tan(x)
        {
            if (textBox1.Text != "")
            {
                double tanh = Double.Parse(textBox1.Text);
                tanh = Math.Tanh(tanh);
                textBox1.Text = tanh.ToString();
                button20.PerformClick();
            }
        }

        private void button39_Click(object sender, EventArgs e)//log[10]
        {
            if (textBox1.Text != "" && Double.Parse(textBox1.Text) > 0)
            {
                double lg = Double.Parse(textBox1.Text);
                lg = Math.Log10(lg);
                textBox1.Text = lg.ToString();
                button20.PerformClick();
            }
        }

        private void button40_Click(object sender, EventArgs e)//ln(x)
        {
            if (textBox1.Text != "" && Double.Parse(textBox1.Text) > 0)
            {
                double ln = Double.Parse(textBox1.Text);
                ln = Math.Log(ln);
                textBox1.Text = ln.ToString();
                button20.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mENUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
