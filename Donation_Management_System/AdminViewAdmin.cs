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

namespace Donation_Management_System
{
    public partial class AdminViewAdmin : Form
    {
        int userId;
        SqlConnection con;
        public void sqlcon()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Farah Ibnat\Documents\DonationDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public AdminViewAdmin(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminOperateAdmin a1 = new AdminOperateAdmin(this.userId);
            a1.Show();
            this.Hide();
        }

        private void AdminViewAdmin_Load(object sender, EventArgs e)
        {
            sqlcon();
            SqlCommand sq1 = new SqlCommand("SELECT * FROM USSER WHERE UserStatus=@UStatus ORDER BY Role, UserId", con);
            sq1.Parameters.AddWithValue("@UStatus", "Enabled");
            sq1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sq1);
            sd.Fill(dt);
            dataGridView2.DataSource = dt;
            label2.Text = "Number Of Users: " + dt.Rows.Count.ToString();
            con.Close();


        }
    }
}
