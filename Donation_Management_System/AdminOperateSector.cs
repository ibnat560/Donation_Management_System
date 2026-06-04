using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Donation_Management_System
{
    public partial class AdminOperateSector : Form
    {
        int userId;
        SqlConnection con;

        public void sqlcon()
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public AdminOperateSector(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill up all the fields!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please don't fill up the SectorId field to add a sector!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();

                SqlCommand sq1 = new SqlCommand("INSERT INTO SECTORS (Title,Description,SectorStatus)VALUES(@Title,@Description,@SStatus)", con);
                sq1.Parameters.AddWithValue("@Title", textBox2.Text);
                sq1.Parameters.AddWithValue("@Description", textBox3.Text);
                sq1.Parameters.AddWithValue("@SStatus", "Enabled");
                sq1.ExecuteNonQuery();

                MessageBox.Show("Sector Added Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM SECTORS WHERE SectorId=@SectorId AND SectorStatus=@SStatus", con);
            sq1.Parameters.AddWithValue("@SectorId", textBox1.Text);
            sq1.Parameters.AddWithValue("@SStatus", "Enabled");
            sq1.ExecuteNonQuery();
            int count = (int)sq1.ExecuteScalar();
            if (count != 0)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please fill up the SectorId field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Please fill up the Description field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE SECTORS SET Description=@Description WHERE SectorId=@SectorId", con);
                    sq2.Parameters.AddWithValue("@Description", textBox3.Text);
                    sq2.Parameters.AddWithValue("@SectorId", textBox1.Text);
                    sq2.ExecuteNonQuery();

                    MessageBox.Show("Sector Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();

                }
            }
            else
            {
                MessageBox.Show("Please provide a valid sector ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the Sector ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM SECTORS WHERE SectorId=@SectorID AND SectorStatus=@SStatus", con);
                sq1.Parameters.AddWithValue("@SectorID", textBox1.Text);
                sq1.Parameters.AddWithValue("@SStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE SECTORS SET SectorStatus=@SStatus WHERE SectorId=@SectorID", con);
                    sq2.Parameters.AddWithValue("@SStatus", "Disabled");
                    sq2.Parameters.AddWithValue("@SectorID", textBox1.Text);
                    sq2.ExecuteNonQuery();
                    MessageBox.Show("Sector Disabled Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please provide a valid Sector ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM SECTORS WHERE SectorStatus=@SStatus", con);
            sq1.Parameters.AddWithValue("@SStatus", "Enabled");
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Number Of Sectors: " + dt.Rows.Count.ToString();
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the Sector ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM SECTORS WHERE SectorId=@SectorID AND SectorStatus=@SStatus", con);
                sq1.Parameters.AddWithValue("@SectorID", textBox1.Text);
                sq1.Parameters.AddWithValue("@SStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("SELECT * FROM SECTORS WHERE SectorId=@SectorID", con);
                    sq2.Parameters.AddWithValue("@SectorID", textBox1.Text);
                    SqlDataReader reader = sq2.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox2.Text = reader["Title"].ToString();
                        textBox3.Text = reader["Description"].ToString();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Information found under this ID", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please provide a valid Sector ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            MessageBox.Show("Reset successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dash d = new Dash(this.userId);
            d.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the Sector ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM SECTORS WHERE SectorId=@SectorID AND SectorStatus=@SStatus", con);
                sq1.Parameters.AddWithValue("@SectorID", textBox1.Text);
                sq1.Parameters.AddWithValue("@SStatus", "Disabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE SECTORS SET SectorStatus=@SStatus WHERE SectorID=@SectorID", con);
                    sq2.Parameters.AddWithValue("@SStatus", "Enabled");
                    sq2.Parameters.AddWithValue("@SectorID", textBox1.Text);
                    sq2.ExecuteNonQuery();
                    MessageBox.Show("Sector Enabled Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please provide a valid Sector ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

        }

        private void AdminOperateSector_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM SECTORS WHERE SectorStatus=@SStatus", con);
            sq1.Parameters.AddWithValue("@SStatus", "Enabled");
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Number Of Sectors: " + dt.Rows.Count.ToString();
            con.Close();
        }
    }
}
