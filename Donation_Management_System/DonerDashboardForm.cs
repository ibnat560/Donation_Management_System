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
    public partial class DonerDashboardForm : Form
    {
        int userId;
        public DonerDashboardForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonorViewDonationSector dvs = new DonorViewDonationSector(this.userId);
            dvs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DonorViewCampaigns dvc = new DonorViewCampaigns(this.userId);
            dvc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DonationHistory dh = new DonationHistory(this.userId);
            dh.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZakatCalculator zc = new ZakatCalculator(this.userId);
            zc.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Feedback f = new Feedback(this.userId);
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DonorUpdateSelf dus = new DonorUpdateSelf(this.userId);
            dus.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DonorDeleteSelf d= new DonorDeleteSelf(this.userId);
            d.Show();
            this.Hide();
        }
    }
}
