using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Calc : Form
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        String strCurrentOperations = "";



        public readonly POSForm frm1;
        POSForm objDateController = new POSForm();

        public Calc(POSForm frm)
        {
            InitializeComponent();

            frm1 = frm;
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtResult.Text == "0") || (isOperationPerformed))
               txtResult.Clear();

            if (frm1.lblResult.Text == "0") {
                frm1.lblResult.Text = "";
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtResult.Text.Contains("."))
                    txtResult.Text = txtResult.Text + button.Text;
                frm1.lblResult.Text = txtResult.Text;
                //frm1.lblResult.Text = button.Text;
            }
            else
                txtResult.Text = txtResult.Text + button.Text;

            if (button.Text != ".")
            {
                if (txtResult.Text != "0")
                {
                    frm1.lblResult.Text = frm1.lblResult.Text + " " + button.Text;
                }
                else
                {
                    frm1.lblResult.Text = button.Text;

                }
            }

                
               


        }


        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnequal.PerformClick();
                operationPerformed = button.Text;
                strCurrentOperations = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(txtResult.Text);
                //frm1.lblResultFinal.Text = resultValue.ToString();
                txtResult.Text = resultValue + " " + operationPerformed;
                frm1.lblResult.Text = frm1.lblResult.Text + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }


        private void Calc_Load(object sender, EventArgs e)
        {

        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtResult.Text = (resultValue + Double.Parse(txtResult.Text)).ToString();
                    break;

                case "x":
                    txtResult.Text = (resultValue * Double.Parse(txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(txtResult.Text);
            frm1.lblResultFinal.Text = resultValue.ToString();
            strCurrentOperations = "";
        }

        private void btnac_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";

            resultValue = 0;

            frm1.lblResult.Text = "0";

            frm1.lblResultFinal.Text = "0";
        }
    }
}
