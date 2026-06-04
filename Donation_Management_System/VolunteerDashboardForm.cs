using DonationManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donation_Management_System
{
    public partial class VolunteerDashboardForm : Form
    {
        int userId;
        public VolunteerDashboardForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VolunteerOperateDonor vod = new VolunteerOperateDonor(this.userId);
            vod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerViewCampaign vvc = new VolunteerViewCampaign(this.userId);
            vvc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VolunteerViewDonor vvd = new VolunteerViewDonor(this.userId);
            vvd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VolunteerUpdateSelf vus = new VolunteerUpdateSelf(this.userId);
            vus.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VolunteerDeleteSelf v= new VolunteerDeleteSelf(this.userId);
            v.Show();
            this.Hide();
        }
    }
}
