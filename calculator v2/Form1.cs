

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace calculator_v2
{
    public partial class Form1 : Form
    {
        public const int PLUS= 0;
        public const int MINUS = 1;
        public const int INMULTIRE = 2;
        public const int IMPARTIRE = 3;

        int stare = 0;
        bool operatie = false;
        
        bool numardinnou = true;
        
        bool primuegal = true;
        bool virgula = false;

        double operand1,operandegal;
        int operatieCurenta, operatieTrecuta;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numere(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Numere(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Numere(1);
        }

        private void Numere(double v)
        {
            if (operatie||numardinnou)
            {
                textBox1.Text = v.ToString(); operatie = false;
                numardinnou = false;
                
            }
            else
            {
                double p = double.Parse(textBox1.Text);
                if (virgula) { textBox1.Text = textBox1.Text + v.ToString();Console.WriteLine(virgula); }
                else { p = v + p * 10; textBox1.Text = p.ToString(); }
                
            }
            if (stare == 2) { stare = 1; }
            primuegal = true;

        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            Numere(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Numere(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Numere(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Numere(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Numere(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Numere(9);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Operatie(MINUS); 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Operatie(INMULTIRE); 
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Operatie(IMPARTIRE); 
        }

        private void button11_Click(object sender, EventArgs e)
        {

            Operatie(PLUS);
            
        }
        private void Operatie(int oper)

        {
            operatieTrecuta = operatieCurenta;
            operatieCurenta = oper;
            operatie = true;
            if (stare == 0) { operand1 = double.Parse(textBox1.Text);stare = 1;  return; }
            
            if (stare == 1) { operandegal = operand1; calcul(operatieTrecuta,operand1, double.Parse(textBox1.Text)); operand1 = double.Parse(textBox1.Text);   return; }


            /*
              operatie = true;
              if (primu)
              {
                  operand1 = double.Parse(textBox1.Text);
                  primu = false;
              }
              else
              {
                  operand2 = double.Parse(textBox1.Text);
                  double p = operand1 + operand2;
                  textBox1.Text = p.ToString();

              }*/
            virgula = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Numere(0);
        }

        private void button19_Click(object sender, EventArgs e)
        {

            int p = textBox1.Text.Length - 1;
            if (p > 0)
            {
                Console.WriteLine(textBox1.Text.ElementAt(p));
                if (textBox1.Text.ElementAt(p - 1).Equals('.')) { p--; Console.WriteLine("Am intrat"); };
                textBox1.Text = textBox1.Text.Substring(0, p);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            virgula = true;
            textBox1.Text = textBox1.Text + ".";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.Sqrt(Double.Parse(textBox1.Text)).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            stare = 0;
            operatie = false;

            numardinnou = true;

            primuegal = true;
            virgula = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Console.WriteLine(primuegal);
            if (primuegal)
            {
                operandegal = double.Parse(textBox1.Text);
                primuegal = false;
                calcul(operatieCurenta, operand1, operandegal);
            }
            else

            
            {
               
                    calcul(operatieCurenta, double.Parse(textBox1.Text), operandegal);
                operand1 = double.Parse(textBox1.Text);
                stare = 0;
            }
            numardinnou = true;operand1 = Double.Parse(textBox1.Text);


        }

        private void calcul(int oper,double o1,double o2)
        {
            double rezultat = 0;
            if (oper == INMULTIRE) rezultat = o1 * o2;
            if (oper == IMPARTIRE) rezultat = o1 / o2;
            if (oper == PLUS) rezultat = o1 + o2;
            if (oper == MINUS) rezultat = o1 - o2;
            textBox1.Text = rezultat.ToString();stare = 2;
        }
    }
}
