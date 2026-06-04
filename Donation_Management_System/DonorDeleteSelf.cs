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
    public partial class DonorDeleteSelf : Form
    {
        int userId;
        SqlConnection con;

        public void sqlcon()
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public DonorDeleteSelf(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            textBox1.Text = this.userId.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please type your password!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND Password=@password", con);
                sq1.Parameters.AddWithValue("@UserID", this.userId);
                sq1.Parameters.AddWithValue("@password", textBox2.Text);
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete your profile?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SqlCommand sq2 = new SqlCommand("UPDATE USSER SET UserStatus=@UStatus WHERE UserId=@UserID", con);
                        sq2.Parameters.AddWithValue("@UStatus", "Disabled");
                        sq2.Parameters.AddWithValue("@UserID", this.userId);
                        sq2.ExecuteNonQuery();
                        con.Close();
                        Login l = new Login();
                        l.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonerDashboardForm ddf=new DonerDashboardForm(this.userId);
            ddf.Show();
            this.Hide();
        }
    }
}
