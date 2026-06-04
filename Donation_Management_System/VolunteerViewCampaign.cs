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
    public partial class VolunteerViewCampaign: Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public VolunteerViewCampaign(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void VolunteerViewCampaign_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM CAMPAIGNS WHERE Status=@CStatus", con);
            sq1.Parameters.AddWithValue("@CStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Total campaigns: " + dt.Rows.Count.ToString();
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                object campaignIdValue = clickedRow.Cells["CampaignId"].Value;
                object campaignDateValue=clickedRow.Cells["StartDate"].Value;
                if (campaignIdValue != null && campaignDateValue!= null && campaignDateValue!=DBNull.Value)
                {
                    if(campaignDateValue is DateTime cDate) 
                    {
                        if (cDate.Date < DateTime.Today)
                        {
                            MessageBox.Show("Your selected campaign has already passed!", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string cId= campaignIdValue.ToString();
                            if(cId!=null)
                            { 
                                int campaignId = int.Parse(cId);
                                DialogResult result = MessageBox.Show("Do you want to participate in this campaign?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    VolunteerUseDonation vd = new VolunteerUseDonation(this.userId,campaignId);
                                    vd.Show();
                                    this.Hide();
                                }
                            }
                        }
                    } 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolunteerDashboardForm vdf = new VolunteerDashboardForm(this.userId);
            vdf.Show();
            this.Hide();
        }

        
    }
}
