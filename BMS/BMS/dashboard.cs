using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class dashboard : Form
    {
        newAccount newAcc;
        deposit deposit;
        Withdrawl withdrawl;
        searchAccount searchAcc;
        Transfer transfer;
        CusList cuslist;
        trnsList trList;
        adminPnl adminPanel;
        

        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Today.Date.ToString("dd");
            label2.Text = System.DateTime.Now.ToString("MMMM");
            label3.Text = System.DateTime.Now.Year.ToString();
            label4.Text = login.loginuser;


            MdiClient chld;
            foreach (Control ctrl in this.Controls)
            {
                try
                {
                    chld = (MdiClient)ctrl;

                    chld.BackColor = this.BackColor;
                }

                catch (InvalidCastException exe)

                {

                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.panel6_Click(sender, e);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (newAcc == null || newAcc.Text == "")
            {
                newAcc = new newAccount();
                newAcc.MdiParent = this;
                newAcc.Dock = DockStyle.Fill;
                newAcc.Show();
            }
            else if (CheckOpened(newAcc.Text))
            {
                newAcc.WindowState = FormWindowState.Normal;
                newAcc.Dock = DockStyle.Fill;
                newAcc.Show();
                newAcc.Focus();

            }

        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (deposit == null || deposit.Text == "")
            {
                deposit = new deposit();
                deposit.MdiParent = this;
                deposit.Dock = DockStyle.Fill;
                deposit.Show();
            }
            else if (CheckOpened(deposit.Text))
            {
                deposit.WindowState = FormWindowState.Normal;
                deposit.Dock = DockStyle.Fill;
                deposit.Show();
                deposit.Focus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notepad np = new notepad();
            np.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (searchAcc == null || searchAcc.Text == "")
            {
                searchAcc = new searchAccount();
                searchAcc.MdiParent = this;
                searchAcc.Dock = DockStyle.Fill;
                searchAcc.Show();
            }
            else if (CheckOpened(searchAcc.Text))
            {
                searchAcc.WindowState = FormWindowState.Normal;
                searchAcc.Dock = DockStyle.Fill;
                searchAcc.Show();
                searchAcc.Focus();

            }

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (transfer == null || transfer.Text == "")
            {
                transfer = new Transfer();
                transfer.MdiParent = this;
                transfer.Dock = DockStyle.Fill;
                transfer.Show();
            }
            else if (CheckOpened(transfer.Text))
            {
                transfer.WindowState = FormWindowState.Normal;
                transfer.Dock = DockStyle.Fill;
                transfer.Show();
                transfer.Focus();
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (withdrawl == null || withdrawl.Text == "")
            {
                withdrawl = new Withdrawl();
                withdrawl.MdiParent = this;
                withdrawl.Dock = DockStyle.Fill;
                withdrawl.Show();
            }
            else if (CheckOpened(withdrawl.Text))
            {
                withdrawl.WindowState = FormWindowState.Normal;
                withdrawl.Dock = DockStyle.Fill;
                withdrawl.Show();
                withdrawl.Focus();

            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (cuslist == null || cuslist.Text == "")
            {
                cuslist = new CusList();
                cuslist.MdiParent = this;
                cuslist.Dock = DockStyle.Fill;
                cuslist.Show();
            }
            else if (CheckOpened(cuslist.Text))
            {
                cuslist.WindowState = FormWindowState.Normal;
                cuslist.Dock = DockStyle.Fill;
                cuslist.Show();
                cuslist.Focus();

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.panel5_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.panel5_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panel6_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel7_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.panel7_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.panel8_Click(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.panel8_Click(sender, e);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Hide();
            if (trList == null || trList.Text == "")
            {
                trList = new trnsList();
                trList.MdiParent = this;
                trList.Dock = DockStyle.Fill;
                trList.Show();
            }
            else if (CheckOpened(trList.Text))
            {
                trList.WindowState = FormWindowState.Normal;
                trList.Dock = DockStyle.Fill;
                trList.Show();
                trList.Focus();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (label4.Text=="admin")
            {
                pnl_dashboard.Hide();
                if (adminPanel == null || adminPanel.Text == "")
                {
                    adminPanel = new adminPnl();
                    adminPanel.MdiParent = this;
                    adminPanel.Dock = DockStyle.Fill;
                    adminPanel.Show();
                }
                else if (CheckOpened(adminPanel.Text))
                {
                    adminPanel.WindowState = FormWindowState.Normal;
                    adminPanel.Dock = DockStyle.Fill;
                    adminPanel.Show();
                    adminPanel.Focus();

                }
            }
            else
            {
                MessageBox.Show("Your are not allowed to access here!\nAdmin acces only!");
            }

        }

        private void pnl_dashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel3_Click(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel3_Click(sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2_Click(sender, e);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panel2_Click(sender, e);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel1_Click(sender, e);

        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel1_Click(sender, e);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
