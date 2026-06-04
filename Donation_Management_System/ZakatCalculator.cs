using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donation_Management_System;

namespace DonationManagementSystem
{
    public partial class ZakatCalculator : Form
    {
        int userId;
        public ZakatCalculator(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Please select the gold type!  ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Please enter the gold amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            double gold = textBox1.Text == "" ? 0 : Convert.ToDouble(textBox1.Text);
            double silver = textBox2.Text == "" ? 0 : Convert.ToDouble(textBox2.Text);
            double money = textBox3.Text == "" ? 0 : Convert.ToDouble(textBox3.Text);

            double goldCarat;
            if (comboBox1.SelectedIndex == 0)
            {
                goldCarat = gold * 14757;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                goldCarat = gold * 14086;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                goldCarat = gold * 12074;
            }
            else
            {
                 goldCarat = gold * 9987;
            }

            double total = goldCarat + silver*145 + money;


            double zakat = total * 0.025;


            textBox4.Text = zakat.ToString("F2");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for using this", "Goodbye", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DonerDashboardForm dashboard = new DonerDashboardForm(this.userId);
            dashboard.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t=sender as TextBox;
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(e.KeyChar.ToString()==".")
            { 
                if(t.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
                    
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString() == ".")
            {
                if (t.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

            }
            else
            {
                e.Handled = true;
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.ToString() == ".")
            {
                if (t.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
