using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Donation_Management_System;


namespace DonationManagementSystem
{
    public partial class DonorViewCampaigns : Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public DonorViewCampaigns(int userId)
        {
            InitializeComponent();
            this.userId = userId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonerDashboardForm dashboard = new DonerDashboardForm(this.userId);
            dashboard.Show();
            this.Hide();
        }

        private void DonorViewCampaigns_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM CAMPAIGNS WHERE Status=@CStatus", con);
            sq1.Parameters.AddWithValue("@CStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
