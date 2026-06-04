using Microsoft.Data.SqlClient;
using System;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Donation_Management_System
{
    public partial class AdminOperateAdmin : Form
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
        public AdminOperateAdmin(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            DateTime yesterday = DateTime.Today.AddDays(-1);
            dateTimePicker1.MaxDate = yesterday;
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
            this.userId = userId;
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

            else if (textBox6.Text.Length!=11)
            {
                MessageBox.Show("Please provide a valid Phone Number!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please don't fill up the UserId field to add a User!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

                string role;
                if (radioButton3.Checked)
                {
                    role = "Admin";
                }
                else if (radioButton4.Checked)
                {
                    role = "Volunteer";
                }
                else
                {
                    role = "Donor";
                }
                    sqlcon();

                SqlCommand sq1 = new SqlCommand("INSERT INTO USSER (Name,Gender,DateOfBirth,Email,Address,PhoneNo,Role,Password,SecurityAns,UserStatus)VALUES(@Name,@Gender,@DOB,@Email,@Address,@PhoneNo,@Role,@Password,@SecurityAns,@Ustatus)", con);
                sq1.Parameters.AddWithValue("@Name", textBox2.Text);
                sq1.Parameters.AddWithValue("@Gender", gender);
                sq1.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                sq1.Parameters.AddWithValue("@Email", textBox4.Text);
                sq1.Parameters.AddWithValue("@Address", textBox5.Text);
                sq1.Parameters.AddWithValue("@PhoneNo", textBox6.Text);
                sq1.Parameters.AddWithValue("@Role", role);
                sq1.Parameters.AddWithValue("@Password", textBox7.Text);
                sq1.Parameters.AddWithValue("@SecurityAns", textBox8.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();

                MessageBox.Show("User Added Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
            }



        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", textBox1.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    if (string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrEmpty(textBox6.Text))
                    {
                        MessageBox.Show("You need to fill up any of the email, address or phone number fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                    else if (!string.IsNullOrEmpty(textBox4.Text) && (!textBox4.Text.Contains(".com") || !textBox4.Text.Contains("@")))
                    {
                        MessageBox.Show("Please provide a valid Email!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else if (textBox6.Text.Length != 11)
                    {
                        MessageBox.Show("Please provide a valid Phone Number!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlCommand sq2 = new SqlCommand("UPDATE USSER SET Email=@Email,Address=@Address,PhoneNo=@PhoneNo WHERE UserId=@UserID", con);
                        sq2.Parameters.AddWithValue("@Email", textBox4.Text);
                        sq2.Parameters.AddWithValue("@Address", textBox5.Text);
                        sq2.Parameters.AddWithValue("@PhoneNo", textBox6.Text);
                        sq2.Parameters.AddWithValue("@UserID", textBox1.Text);
                        sq2.ExecuteNonQuery();

                        MessageBox.Show("User Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        con.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid User ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill up the User ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the User ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", textBox1.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE USSER SET UserStatus=@UStatus WHERE UserId=@UserID", con);
                    sq2.Parameters.AddWithValue("@UStatus", "Disabled");
                    sq2.Parameters.AddWithValue("@UserID", textBox1.Text);
                    sq2.ExecuteNonQuery();
                    MessageBox.Show("User Disabled Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please provide a valid User ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AdminViewAdmin a = new AdminViewAdmin(this.userId);
            a.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the User ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", textBox1.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("SELECT * FROM USSER WHERE UserId=@UserID", con);
                    sq2.Parameters.AddWithValue("@UserID", textBox1.Text);
                    SqlDataReader reader = sq2.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox2.Text = reader["Name"].ToString();
                        textBox4.Text = reader["Email"].ToString();
                        textBox5.Text = reader["Address"].ToString();
                        textBox6.Text = reader["PhoneNo"].ToString();
                        textBox7.Text = reader["Password"].ToString();
                        textBox8.Text = reader["SecurityAns"].ToString();
                        if (reader["DateOfBirth"] != DBNull.Value)
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                        }
                        else
                        {
                            dateTimePicker1.Value = DateTime.Today;
                        }
                        if (reader["Gender"].ToString() == "Male")
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Information found under this ID", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please provide a valid User ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
            label15.Visible = false;

            MessageBox.Show("Reset successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Dash d = new Dash(this.userId);
            d.Show();
            this.Hide();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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
                label15.Text = "Weak Password";
                label15.ForeColor = Color.Red;
                label15.Visible = true;
            }
            else
            {
                label15.Text = "";
                label15.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the User ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM USSER WHERE UserId=@UserID AND UserStatus=@UStatus", con);
                sq1.Parameters.AddWithValue("@UserID", textBox1.Text);
                sq1.Parameters.AddWithValue("@UStatus", "Disabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE USSER SET UserStatus=@UStatus WHERE UserId=@UserID", con);
                    sq2.Parameters.AddWithValue("@UStatus", "Enabled");
                    sq2.Parameters.AddWithValue("@UserID", textBox1.Text);
                    sq2.ExecuteNonQuery();
                    MessageBox.Show("User Enabled Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please provide a disabled User ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Dash d = new Dash(this.userId);
            d.Show();
            this.Hide();
        }
    }
}
