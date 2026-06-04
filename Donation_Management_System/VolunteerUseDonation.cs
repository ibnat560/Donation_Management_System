using Donation_Management_System;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DonationManagementSystem
{
    public partial class VolunteerUseDonation: Form
    {
        int userId;
        int campaignId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public VolunteerUseDonation(int userId,int campaignId)
        {
            InitializeComponent();
            this.campaignId = campaignId;
            this.userId = userId;
        }

        private void VolunteerUseDonation_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM DONATIONS WHERE DonationStatus=@DStatus", con);
            sq1.Parameters.AddWithValue("@DStatus", "Unused");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) 
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                object donationIdValue= clickedRow.Cells["DonationId"].Value;
                if (donationIdValue != null)
                {
                    string dId = donationIdValue.ToString();
                    if(dId!=null) 
                    {
                        int donationId;
                        if (int.TryParse(dId, out donationId))
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to use this donation in this campaign?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                sqlcon();
                                SqlCommand sq2 = new SqlCommand("UPDATE DONATIONS SET DonationStatus=@DStatus,CampaignId=@campaignId WHERE DonationId=@DonationId", con);
                                sq2.Parameters.AddWithValue("@DStatus", "Used");
                                sq2.Parameters.AddWithValue("@campaignId", this.campaignId);
                                sq2.Parameters.AddWithValue("@DonationId", donationId);
                                sq2.ExecuteNonQuery();

                                SqlCommand sq3 = new SqlCommand("SELECT * FROM DONATIONS WHERE DonationStatus=@DStatus", con);
                                sq3.Parameters.AddWithValue("@DStatus", "Unused");
                                sq3.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                SqlDataAdapter sd = new SqlDataAdapter(sq3);
                                sd.Fill(dt);
                                dataGridView1.DataSource = dt;
                                con.Close();
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolunteerViewCampaign vc = new VolunteerViewCampaign(this.userId);
            vc.Show();
            this.Hide();
        }

        
    }
}
