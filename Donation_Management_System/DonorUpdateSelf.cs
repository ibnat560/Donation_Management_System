using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donation_Management_System;

namespace DonationManagementSystem
{
    public partial class DonorUpdateSelf : Form
    {
        int userId;
        private int flag = 0;
        private string[] arr = { "!", "@", "#" };
        SqlConnection con;

        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public DonorUpdateSelf(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            textBox1.Text = this.userId.ToString();

            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID", con);
            sq1.Parameters.AddWithValue("@UserID", this.userId);
            sq1.ExecuteNonQuery();
            int count = (int)sq1.ExecuteScalar();
            if (count != 0)
            {
                SqlCommand sq2 = new SqlCommand("SELECT * FROM USSER WHERE UserId=@UserID", con);
                sq2.Parameters.AddWithValue("@UserID", this.userId);
                SqlDataReader reader = sq2.ExecuteReader();
                if (reader.Read())
                {
                    textBox6.Text = reader["Address"].ToString();
                    textBox4.Text = reader["PhoneNo"].ToString();
                    textBox3.Text = reader["Email"].ToString();
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (!textBox3.Text.Contains(".") || !textBox3.Text.Contains("@"))
            {
                MessageBox.Show("Please provide a valid Email!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                sqlcon();
                SqlCommand sq2 = new SqlCommand("UPDATE USSER SET Email=@Email,Address=@Address,PhoneNo=@PhoneNo WHERE UserId=@UserID", con);
                sq2.Parameters.AddWithValue("@Email", textBox3.Text);
                sq2.Parameters.AddWithValue("@Address", textBox6.Text);
                sq2.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
                sq2.Parameters.AddWithValue("@UserID", this.userId);
                sq2.ExecuteNonQuery();

                MessageBox.Show("Profile Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DonerDashboardForm ddf = new DonerDashboardForm(this.userId);
            ddf.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox5.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox5.Text.Length < 8 || flag == 0)
                {
                    MessageBox.Show("Please provide a good password!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    sqlcon();
                    SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND password=@Password", con);
                    sq1.Parameters.AddWithValue("@UserID", this.userId);
                    sq1.Parameters.AddWithValue("@Password", textBox2.Text);
                    sq1.ExecuteNonQuery();
                    int count = (int)sq1.ExecuteScalar();
                    if (count != 0)
                    {
                        SqlCommand sq2 = new SqlCommand("UPDATE USSER SET password=@Password WHERE UserId=@UserID", con);
                        sq2.Parameters.AddWithValue("@Password", textBox5.Text);
                        sq2.Parameters.AddWithValue("@UserID", this.userId);
                        sq2.ExecuteNonQuery();

                        MessageBox.Show("Password Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Old password is incorrect!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox5.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (textBox5.Text.Length < 8 || flag != 1)
            {
                label10.Text = "Weak Password";
                label10.ForeColor = Color.Red;
                label10.Visible = true;
            }
            else
            {
                label10.Text = "";
                label10.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!textBox3.Text.Contains(".") || !textBox3.Text.Contains("@"))
            {
                label11.Text = "Invalid Email";
                label11.ForeColor = Color.Red;
                label11.Visible = true;
            }
            else
            {
                label11.Text = "";
                label11.Visible = false;
            }
        }
    }
}
