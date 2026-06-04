using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Donation_Management_System
{
    public partial class ManageCampaign : Form
    {
        int userId;
        SqlConnection con;

        public void sqlcon()
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public ManageCampaign(int userId)
        {
            InitializeComponent();

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime nextMonth = DateTime.Today.AddMonths(1);
            dateTimePicker1.MinDate = tomorrow;
            dateTimePicker1.MaxDate = nextMonth;
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill up the Venue field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please don't fill up the CampaignId field to add a campaign!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();

                SqlCommand sq1 = new SqlCommand("INSERT INTO CAMPAIGNS (StartDate,Venue,Status)VALUES(@CampaignDate,@Venue,@CStatus)", con);
                sq1.Parameters.AddWithValue("@CampaignDate", dateTimePicker1.Value);
                sq1.Parameters.AddWithValue("@Venue", textBox3.Text);
                sq1.Parameters.AddWithValue("@CStatus", "Enabled");
                sq1.ExecuteNonQuery();

                MessageBox.Show("Campaign Added Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM CAMPAIGNS WHERE CampaignId=@CampaignId AND Status=@CStatus", con);
            sq1.Parameters.AddWithValue("@CampaignId", textBox1.Text);
            sq1.Parameters.AddWithValue("@CStatus", "Enabled");
            sq1.ExecuteNonQuery();
            int count = (int)sq1.ExecuteScalar();
            if (count != 0)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please fill up the campaign Id field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Please fill up the Venue field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE CAMPAIGNS SET Venue=@Venue WHERE CampaignId=@CampaignId", con);
                    sq2.Parameters.AddWithValue("@Venue", textBox3.Text);
                    sq2.Parameters.AddWithValue("@CampaignId", textBox1.Text);
                    sq2.ExecuteNonQuery();

                    MessageBox.Show("Campaign Updated Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();

                }
            }
            else
            {
                MessageBox.Show("Please provide a valid campaign ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the Campaign ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM CAMPAIGNS WHERE CampaignId=@CampaignID  AND Status=@CStatus", con);
                sq1.Parameters.AddWithValue("@CampaignID", textBox1.Text);
                sq1.Parameters.AddWithValue("@CStatus", "Enabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE CAMPAIGNS SET Status=@CStatus WHERE CampaignId=@CampaignID", con);
                    sq2.Parameters.AddWithValue("@CStatus", "Disabled");
                    sq2.Parameters.AddWithValue("@CampaignID", textBox1.Text);
                    sq2.ExecuteNonQuery();
                    MessageBox.Show("Campaign Disabled Successfully!", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please provide a valid Campaign ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM CAMPAIGNS WHERE Status=@CStatus", con);
            sq1.Parameters.AddWithValue("@CStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Number Of Campaigns: " + dt.Rows.Count.ToString();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the Campaign ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM CAMPAIGNS WHERE CampaignId=@CampaignID AND Status=@CStatus", con);
                sq1.Parameters.AddWithValue("@CampaignID", textBox1.Text);
                sq1.Parameters.AddWithValue("@CStatus", "Enabled");

                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("SELECT * FROM CAMPAIGNS WHERE CampaignId=@CampaignID", con);
                    sq2.Parameters.AddWithValue("@CampaignID", textBox1.Text);
                    SqlDataReader reader = sq2.ExecuteReader();
                    if (reader.Read())
                    {

                        textBox3.Text = reader["Venue"].ToString();
                        if (reader["StartDate"] != DBNull.Value)
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(reader["StartDate"]);
                        }
                        else
                        {
                            dateTimePicker1.Value = DateTime.Today;
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
                    MessageBox.Show("Please provide a valid Campaign ID!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            textBox3.Text = "";



            MessageBox.Show("Reset successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dash d = new Dash(this.userId);
            d.Show();
            this.Hide();
        }

        private void ManageCampaign_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM CAMPAIGNS WHERE Status=@CStatus", con);
            sq1.Parameters.AddWithValue("@CStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Number Of Campaigns: " + dt.Rows.Count.ToString();
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill up the campaign ID field!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                sqlcon();
                SqlCommand sq1 = new SqlCommand("SELECT COUNT(*) FROM CAMPAIGNS WHERE CampaignId=@CampaignID AND Status=@CStatus", con);
                sq1.Parameters.AddWithValue("@CampaignID", textBox1.Text);
                sq1.Parameters.AddWithValue("@CStatus", "Disabled");
                sq1.ExecuteNonQuery();
                int count = (int)sq1.ExecuteScalar();
                if (count != 0)
                {
                    SqlCommand sq2 = new SqlCommand("UPDATE CAMPAIGNS SET Status=@CStatus WHERE CampaignId=@CampaignID", con);
                    sq2.Parameters.AddWithValue("@CStatus", "Enabled");
                    sq2.Parameters.AddWithValue("@CampaignID", textBox1.Text);
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
    }
}
