﻿using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }


        private Double numUm;
        private Double numDois;
        private String operacao;
        private Double resultado;

        private Boolean PressionouIgual;

        private void limparDisplay()
        {
            txtDisplay.Clear();
            numUm = 0;
            numDois = 0;
            resultado = 0;
            operacao = String.Empty;
            PressionouIgual = false;
        }


        private void addCaracterNum(String valorNum)
        {
            if (PressionouIgual == true)
            {
                txtDisplay.Clear();
                PressionouIgual = false;
            }


            if (txtDisplay.Text.Trim().Equals("0"))
            {
                txtDisplay.Text = valorNum;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + valorNum;
            }
        }


        private void addCaracterOperacao(String caracter)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                if (txtDisplay.Text.Trim().Contains("."))
                {
                    numUm = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                }
                else
                {
                    numUm = Convert.ToDouble(txtDisplay.Text.Trim());
                }
                operacao = caracter;
                txtDisplay.Clear();
            }
            else
            {
                MessageBox.Show("É preciso informar algum valor");
                return;
            }
        }

        
        private void Calcular()
        {
            switch (operacao)
            {
                case "/":

                    if (numDois == 0)
                    {
                        MessageBox.Show("Não é possível dividir por 0");
                        break;
                    }

                    resultado = numUm / numDois;
                    break;

                case "*":

                    resultado = numUm * numDois;
                    break;

                case "-":

                    resultado = numUm - numDois;
                    break;

                case "+":

                    resultado = numUm + numDois;
                    break;

                case "^":

                    resultado = CalcularPotencia(numUm, numDois);
                    break;
            }
            txtDisplay.Text = resultado.ToString().Replace(",", ".");
        }


        public Double CalcularPotencia(Double valorBase, Double valorExpoente)
        {
            return Math.Pow(valorBase, valorExpoente);
        }


        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            addCaracterNum("1");
        }


        private void btn2_Click(object sender, EventArgs e)
        {
            addCaracterNum("2");
        }


        private void btn3_Click(object sender, EventArgs e)
        {
            addCaracterNum("3");
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            addCaracterNum("4");
        }


        private void btn5_Click(object sender, EventArgs e)
        {
            addCaracterNum("5");
        }


        private void btn6_Click(object sender, EventArgs e)
        {
            addCaracterNum("6");
        }


        private void btn7_Click(object sender, EventArgs e)
        {
            addCaracterNum("7");
        }


        private void btn8_Click(object sender, EventArgs e)
        {
            addCaracterNum("8");
        }


        private void btn9_Click(object sender, EventArgs e)
        {
            addCaracterNum("9");
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            addCaracterNum("0");
        }


        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (PressionouIgual)
            {
                txtDisplay.Text = "0.";
                PressionouIgual = false;
                return;
            }


            //Adiciona ponto na operação
            if (txtDisplay.Text.Trim().Equals(String.Empty))
            {
                txtDisplay.Text = "0.";
            }


            //Verifica se a String . já está presente no txtDisplay
            if (txtDisplay.Text.Trim().Contains("."))
            {
                return;
            }

            txtDisplay.Text = txtDisplay.Text + ".";
        }


        private void btnDivisao_Click(object sender, EventArgs e)
        {
            addCaracterOperacao("/");
            
        }


        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            addCaracterOperacao("*");
        }


        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            addCaracterOperacao("-");
        }


        private void btnAdicao_Click(object sender, EventArgs e)
        {
            addCaracterOperacao("+");
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }


        private void btnRemoveUltimoDigito_Click(object sender, EventArgs e)
        {
            int tamanho = txtDisplay.Text.Trim().Length;
            String texto = txtDisplay.Text.Trim();
            txtDisplay.Clear();

            for (int i = 0; i < tamanho - 1; i++)
            {
                txtDisplay.Text = txtDisplay.Text + texto[i]; 
            }
        }


        private void btnPotenciacao_Click(object sender, EventArgs e)
        {
            addCaracterOperacao("^");
        }


        private void btnElevadoAoQuadrado_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                numUm = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                numDois = 2;
                var resultado = CalcularPotencia(numUm, numDois);

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }


        private void btnRaizQuadrada_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                numUm = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                resultado = Math.Sqrt(numUm);

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }


        private void btnUmPorX_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                numUm = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                
                if (numUm == 0)
                {
                    MessageBox.Show("Não é possível dividir por 0");
                    return;
                }

                resultado = 1 / numUm;

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }


        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (PressionouIgual)
            {
                txtDisplay.Clear();
                PressionouIgual = false;
                return;
            }

            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                if (txtDisplay.Text.Trim().Contains("."))
                {
                    numDois = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                }
                else
                {
                    numDois = Convert.ToDouble(txtDisplay.Text.Trim());
                }

                Calcular();

                PressionouIgual = true;
            }
        }


        private void Calculadora_Load(object sender, EventArgs e)
        {
            limparDisplay();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            limparDisplay();
        }

        
        private void btnCE_Click(object sender, EventArgs e)
        {
            if (operacao.Equals(String.Empty) || PressionouIgual)
            {
                limparDisplay();
            }
            else
            {
                txtDisplay.Clear();
            }
        }


        private void byjvxdev_Click(object sender, EventArgs e)
        {
            MessageBox.Show("github.com/jvxdev && linkedin.com/in/jvddm");
        }

        private void btnMaisMenos_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                txtDisplay.Text = (Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ",")) * (-1)).ToString().Replace(",", ".");
            }
        }
    }
}
