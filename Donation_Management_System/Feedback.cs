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
    public partial class Feedback : Form
    {
        private int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public Feedback(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter your feedback comment.", "Missing Feedback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sqlcon();

            SqlCommand cmd = new SqlCommand(@"
        INSERT INTO FEEDBACK 
        (SubmissionDate, Comment, UserId) 
        VALUES 
        (@Date, @Comment, @UserId)", con);

            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Comment", textBox1.Text);
            cmd.Parameters.AddWithValue("@UserId", this.userId);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DonerDashboardForm dashboard = new DonerDashboardForm(this.userId);
            dashboard.Show();  
            this.Hide();
        }
    }
}

