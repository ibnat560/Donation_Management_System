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

namespace Donation_Management_System
{
    public partial class Login : Form
    {
        int userId;
        string role;
        SqlConnection con;

        public void sqlcon()
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the required fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                userId = Convert.ToInt32(textBox1.Text);
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND Password=@password AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", userId);
                sq1.Parameters.AddWithValue("@password", textBox2.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPwd f = new ForgotPwd();
            f.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup s= new Signup();
            s.Show();
            this.Hide();
        }
    }
}
