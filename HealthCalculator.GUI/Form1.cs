using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCalculator.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            HealthCalculator cal = new HealthCalculator();
            try
            {
                int age = int.Parse(textBoxAge.Text);
                double height = double.Parse(textBoxHeight.Text);
                double weight = double.Parse(textBoxWeight.Text);

                labelResultBMI.Text = cal.countBMI(height, weight).ToString();
                labelResultText.Text = cal.showResultText(cal.countBMI(height, weight));

                if (radioButtonFemale.Checked)
                {
                    labelResultBMR.Text = cal.countBMRWoman(age, height, weight).ToString();
                }
                else
                {
                    labelResultBMR.Text = cal.countBMRMan(age, height, weight).ToString();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid value! No data has been entered or the data entered are not numbers!", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
