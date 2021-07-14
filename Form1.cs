using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationperformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox1_Result.Text == "0" || (isOperationPerformed))
            {
                textBox1_Result.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox1_Result.Text.Contains("."))
                {
                    textBox1_Result.Text = textBox1_Result.Text + button.Text;
                }
            }
            else
            {
                textBox1_Result.Text = textBox1_Result.Text + button.Text;
            }  
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                EqualTO_button.PerformClick();
                operationperformed = button.Text;
                lable_CurrentOperation.Text = resultValue + " " + operationperformed;
                isOperationPerformed = true;
            }
            else
            {
                operationperformed = button.Text;
                resultValue = Double.Parse(textBox1_Result.Text);
                lable_CurrentOperation.Text = resultValue + " " + operationperformed;
                isOperationPerformed = true;
            }
        }

        private void CE_button_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = "0";
        }

        private void C_button_Click(object sender, EventArgs e)
        {
            textBox1_Result.Text = "0";
            resultValue = 0;
        }

        private void EqualTO_button_Click(object sender, EventArgs e)
        {
            switch (operationperformed)
            {
                case "+":
                    textBox1_Result.Text = (resultValue + Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "-":
                    textBox1_Result.Text = (resultValue - Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "*":
                    textBox1_Result.Text = (resultValue * Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                case "/":
                    textBox1_Result.Text = (resultValue / Double.Parse(textBox1_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox1_Result.Text);
            lable_CurrentOperation.Text = "";
        }
    }
}
