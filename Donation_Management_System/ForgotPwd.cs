using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Donation_Management_System
{
    public partial class ForgotPwd : Form
    {
        int userId;
        string role;
        private int flag = 0;
        private string[] arr = { "!", "@", "#" };
        SqlConnection con;

        public void sqlcon()
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public ForgotPwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
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
                label8.Text = "Weak Password";
                label8.ForeColor = Color.Red;
                label8.Visible = true;
            }
            else
            {
                label8.Text = "";
                label8.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox3.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length < 8 || flag == 0)
            {
                MessageBox.Show("Please provide a good password!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                userId = Convert.ToInt32(textBox1.Text);
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND SecurityAns=@secAns AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", userId);
                sq1.Parameters.AddWithValue("@secAns", textBox2.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq3 = new SqlCommand("UPDATE USSER SET Password=@password WHERE UserId=@UserID", con);
                    sq3.Parameters.AddWithValue("@password", textBox3.Text);
                    sq3.Parameters.AddWithValue("@UserID", textBox1.Text);
                    sq3.ExecuteNonQuery();
                    SqlCommand sq2 = new SqlCommand("SELECT * FROM USSER WHERE UserId=@UserID", con);
                    sq2.Parameters.AddWithValue("@UserID", userId);
                    SqlDataReader reader = sq2.ExecuteReader();
                    if (reader.Read())
                    {
                        role = reader["Role"].ToString();
                    }
                    con.Close();
                    if (role == "Admin")
                    {
                        Dash d = new Dash(userId);
                        d.Show();
                        this.Hide();
                    }
                    if (role == "Volunteer")
                    {
                        VolunteerDashboardForm vdf = new VolunteerDashboardForm(userId);
                        vdf.Show();
                        this.Hide();
                    }
                    if (role == "Donor")
                    {
                        DonerDashboardForm ddf = new DonerDashboardForm(userId);
                        ddf.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Account not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
