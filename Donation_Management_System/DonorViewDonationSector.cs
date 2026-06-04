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
    public partial class DonorViewDonationSector : Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public DonorViewDonationSector(int userId)
        {
            InitializeComponent();
            this.userId = userId;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                string selectedSector = clickedRow.Cells["Title"]?.Value?.ToString() ?? string.Empty;
                object sectorIdValue = clickedRow.Cells["SectorId"].Value;
                if (sectorIdValue != null)
                {
                    string sId = sectorIdValue.ToString();
                    if (sId != null)
                    {
                        int sectorId;
                        if (int.TryParse(sId, out sectorId))
                        {
                            Donate donateForm = new Donate(this.userId, selectedSector, sectorId);
                            donateForm.Show();
                            this.Hide();
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonerDashboardForm dashboard = new DonerDashboardForm(this.userId);
            dashboard.Show();
            this.Hide();
        }

        private void DonorViewDonationSector_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SECTORS WHERE SectorStatus = @Status", con);
            cmd.Parameters.AddWithValue("@Status", "Enabled");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}

