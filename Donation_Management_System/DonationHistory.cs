using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class DonationHistory : Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public DonationHistory(int userId)
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

        private void DonationHistory_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DONATIONS WHERE UserId = @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", this.userId);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
