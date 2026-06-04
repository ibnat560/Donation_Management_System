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
    public partial class VolunteerViewDonor: Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public VolunteerViewDonor(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolunteerOperateDonor v1 = new VolunteerOperateDonor(this.userId);
            v1.Show();
            this.Hide();
        }

        private void VolunteerViewDonor_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM USSER WHERE UserStatus=@UStatus AND Role=@Role", con);
            sq1.Parameters.AddWithValue("@UStatus", "Enabled");
            sq1.Parameters.AddWithValue("@Role", "Donor");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Number of Donors: " + dt.Rows.Count.ToString();
            con.Close();

        }
    }
}
