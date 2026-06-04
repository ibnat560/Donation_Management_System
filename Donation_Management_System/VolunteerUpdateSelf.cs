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
    public partial class VolunteerUpdateSelf : Form
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
        public VolunteerUpdateSelf(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            textBox6.Text = this.userId.ToString();

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
                    textBox5.Text = reader["Address"].ToString();
                    textBox4.Text = reader["PhoneNo"].ToString();
                    textBox1.Text = reader["Email"].ToString();
                }
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (!textBox1.Text.Contains(".") || !textBox1.Text.Contains("@"))
            {
                MessageBox.Show("Please provide a valid Email!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                sqlcon();
                SqlCommand sq2 = new SqlCommand("UPDATE USSER SET Email=@Email,Address=@Address,PhoneNo=@PhoneNo WHERE UserId=@UserID", con);
                sq2.Parameters.AddWithValue("@Email", textBox1.Text);
                sq2.Parameters.AddWithValue("@Address", textBox5.Text);
                sq2.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
                sq2.Parameters.AddWithValue("@UserID", this.userId);
                sq2.ExecuteNonQuery();

                MessageBox.Show("Profile Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerDashboardForm vdf = new VolunteerDashboardForm(this.userId);
            vdf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox3.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox3.Text.Length < 8 || flag == 0)
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
                        sq2.Parameters.AddWithValue("@Password", textBox3.Text);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox3.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (textBox3.Text.Length < 8 || flag != 1)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(".") || !textBox1.Text.Contains("@"))
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
