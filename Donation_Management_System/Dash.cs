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
    public partial class Dash : Form
    {
        int userId;
        public Dash(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminOperateAdmin ada = new AdminOperateAdmin(this.userId);
            ada.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminOperateSector aos = new AdminOperateSector(this.userId);
            aos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageCampaign mc = new ManageCampaign(this.userId);
            mc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminViewDonation avd = new AdminViewDonation(this.userId);
            avd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminViewFeedback avf = new AdminViewFeedback(this.userId);
            avf.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminUpdateSelf aus = new AdminUpdateSelf(this.userId);
            aus.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserDeleteSelf uds=new UserDeleteSelf(this.userId);
            uds.Show();
            this.Hide();
        }
    }
}
