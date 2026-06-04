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
    public partial class Signup : Form
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
        public Signup()
        {
            InitializeComponent();
            DateTime yesterday = DateTime.Today.AddDays(-1);
            dateTimePicker1.MaxDate = yesterday;
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox7.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || !(radioButton1.Checked || radioButton2.Checked))
            {
                MessageBox.Show("Please fill up all the fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            else if (textBox7.Text.Length < 8 || flag == 0)
            {
                MessageBox.Show("Please provide a good password!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else if (!textBox4.Text.Contains(".com") || !textBox4.Text.Contains("@"))
            {
                MessageBox.Show("Please provide a valid Email!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else if (textBox6.Text.Length != 11)
            {
                MessageBox.Show("Please provide a valid Phone Number!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else
            {
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                sqlcon();

                SqlCommand sq1 = new SqlCommand("INSERT INTO USSER (Name,Gender,DateOfBirth,Email,Address,PhoneNo,Role,Password,SecurityAns,UserStatus) OUTPUT INSERTED.UserId VALUES(@Name,@Gender,@DOB,@Email,@Address,@PhoneNo,@Role,@Password,@SecurityAns,@Ustatus)", con);
                sq1.Parameters.AddWithValue("@Name", textBox2.Text);
                sq1.Parameters.AddWithValue("@Gender", gender);
                sq1.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                sq1.Parameters.AddWithValue("@Email", textBox4.Text);
                sq1.Parameters.AddWithValue("@Address", textBox5.Text);
                sq1.Parameters.AddWithValue("@PhoneNo", textBox6.Text);
                sq1.Parameters.AddWithValue("@Role", "Donor");
                sq1.Parameters.AddWithValue("@Password", textBox7.Text);
                sq1.Parameters.AddWithValue("@SecurityAns", textBox8.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                userId = (int)sq1.ExecuteScalar();

                MessageBox.Show("Successfully Signed up!\nYour UserId is: " + userId.ToString() + "\nLogin to your account with this Id and the password you've set!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
                textBox2.Text = "";
                dateTimePicker1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                label11.Visible = false;
                label12.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!textBox4.Text.Contains(".com") || !textBox4.Text.Contains("@"))
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            foreach (string i in arr)
            {
                if (textBox7.Text.Contains(i))
                {
                    flag = 1;
                    break;
                }
            }
            if (textBox7.Text.Length < 8 || flag != 1)
            {
                label12.Text = "Weak Password";
                label12.ForeColor = Color.Red;
                label12.Visible = true;
            }
            else
            {
                label12.Text = "";
                label12.Visible = false;
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
