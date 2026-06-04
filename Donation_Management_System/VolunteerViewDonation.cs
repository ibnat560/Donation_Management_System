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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DonationManagementSystem
{
    public partial class VolunteerViewDonation: Form
    {
        int userId;
        int sectorId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public VolunteerViewDonation(int userId,int sectorId)
        {
            InitializeComponent();
            this.userId = userId;
            this.sectorId = sectorId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolunteerViewSector s1 = new VolunteerViewSector(this.userId);
            s1.Show();
            this.Hide();
        }

        private void VolunteerViewDonation_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM DONATIONS WHERE SectorId=@SectorId", con);
            sq1.Parameters.AddWithValue("@SectorId", this.sectorId);
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Total Donation: " + dt.Rows.Count.ToString();
            con.Close();
        }
    }
}
