using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasMass
{
    public partial class Form1 : Form
    {
        readonly Dictionary<string, double> gas = new Dictionary<string, double> {{"АИ-92", 0.735}, 
                                                                                 { "АИ-95", 0.750}, 
                                                                                 { "АИ-98", 0.776},
                                                                                 { "Дизель", 0.840},
                                                                                 { "Пропан", 0.560},
                                                                                 { "Метан", 0.465}};
        private double distantion;
        private double consumption;

        public void setDistantion(double distantion)
        {
            this.distantion = distantion;
        }

        public double getDistantion()
        {
            return this.distantion;
        }
        public void setConsumption(double consumption)
        {
            this.consumption = consumption;
        }

        public double getConsumption()
        {
            return this.consumption;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private bool checkText(TextBox elementForCheck)
        {
            String text = elementForCheck.Text;
            double value;
            double.TryParse(text, out value);
            if (double.TryParse(text, out value))
            {
                if (value > 0)
                {
                    return true;
                }
            }
                
            return false;
        }
        private bool checkValues()
        {
            return checkText(textBox1) && checkText(textBox2);
        }
        private void setValues()
        {
            setDistantion(double.Parse(textBox1.Text));
            setConsumption(double.Parse(textBox2.Text));
        }
        private void calcMass()
        {
            double mass = this.consumption * this.distantion / 100 * (gas[comboBox1.Text]);
            setMass(mass);
        }
        private void setMass(double mass)
        {
            label6.Text = "Необходимо " + mass + " кг топлива.";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkValues())
            {
                label6.Text = "Исправьте введенные значения!";
                return;
            }
            setValues();
            calcMass();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1787";
            textBox2.Text = "5";
        }
    }
}
