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
    public partial class VolunteerViewSector: Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public VolunteerViewSector(int userId)
        {
            InitializeComponent();
            this.userId = userId;   
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void VolunteerViewSector_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM SECTORS WHERE SectorStatus=@SStatus", con);
            sq1.Parameters.AddWithValue("@SStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Total Sectors: " + dt.Rows.Count.ToString();
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                object sectorIdValue = clickedRow.Cells["SectorId"].Value;
                if (sectorIdValue != null)
                {
                    string sId = sectorIdValue.ToString();
                    if (sId != null)
                    {
                        int sectorId; 
                        if (int.TryParse(sId, out sectorId))
                        {
                            VolunteerViewDonation v1 = new VolunteerViewDonation(this.userId, sectorId);
                            v1.Show();
                            this.Hide();
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
