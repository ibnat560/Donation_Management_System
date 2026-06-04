using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Donation_Management_System;

namespace DonationManagementSystem
{
    public partial class Donate : Form
    {
        string selectedPaymentMethod = "";
        private int userId;
        private int sectorId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public Donate(int userId, string sectorName, int sectorId)
        {
            InitializeComponent();
            this.userId = userId;
            this.sectorId = sectorId;
            if (textBox5 != null)
            {
                textBox5.Text = sectorName;
                textBox5.ReadOnly = true;
            }

            dateTimePicker1.Value = DateTime.Now;
            LoadUserInfo();

        }
        private void LoadUserInfo()
        {
            sqlcon();

            SqlCommand sq = new SqlCommand("SELECT Name, Address, PhoneNo FROM USSER WHERE UserId = @UserID", con);
            sq.Parameters.AddWithValue("@UserID", this.userId);

            SqlDataReader reader = sq.ExecuteReader();

            if (reader.Read())
            {
                textBox1.Text = reader["Name"].ToString();
                textBox2.Text = reader["Address"].ToString();
                textBox3.Text = reader["PhoneNo"].ToString();
            }

            con.Close();
        }




        private void button7_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) ||
         string.IsNullOrEmpty(textBox2.Text) ||
         string.IsNullOrEmpty(textBox3.Text) ||
         string.IsNullOrEmpty(textBox4.Text) ||
         string.IsNullOrEmpty(selectedPaymentMethod))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(textBox4.Text, out decimal donationAmount) || donationAmount <= 0)
            {
                MessageBox.Show("Please enter a valid donation amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sqlcon();

            SqlCommand sq1 = new SqlCommand(@"
        INSERT INTO DONATIONS 
        (Amount, DonationStatus, DonationDate, PayMethod,  SectorId, UserId) 
        VALUES 
        (@Amount, @Status, @Date, @Method,  @SectorId, @DonorId)", con);
            sq1.Parameters.AddWithValue("@Amount", donationAmount);
            sq1.Parameters.AddWithValue("@Status", "Unused");
            sq1.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            sq1.Parameters.AddWithValue("@Method", selectedPaymentMethod);
            sq1.Parameters.AddWithValue("@SectorId", this.sectorId);
            sq1.Parameters.AddWithValue("@DonorId", this.userId);

            sq1.ExecuteNonQuery();

            MessageBox.Show("Donation submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;
            selectedPaymentMethod = "";
            label8.Text = "Payment Method:";

        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Bkash";
            label8.Text = "Payment Method: Bkash";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Nagad";
            label8.Text = "Payment Method: Nagad";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Bank Transfer";
            label8.Text = "Payment Method: Bank Transfer";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DonorViewDonationSector sectorForm = new DonorViewDonationSector(this.userId);
            sectorForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for using ", "Goodbye", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }
    }
}
