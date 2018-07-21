using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BMS
{
    public partial class Withdrawl : Form
    {
        public Withdrawl()
        {
            InitializeComponent();
        }
        myConn conn = new myConn();

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {





        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select * from accounts where accountNumber=@accountNumber or nic=@nic", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@accountNumber", tbx_accNum.Text);
                cmd.Parameters.AddWithValue("@nic", tbx_nicNum.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tbx_accNum.Text = dr["accountNumber"].ToString();
                    tbx_nicNum.Text = dr["nic"].ToString();
                    tbx_cusName.Text = dr["customerName"].ToString();
                    tbx_accType.Text = dr["accountType"].ToString();
                    tbx_curBal.Text = dr["balance"].ToString();
                }
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Withdrawl_Load(object sender, EventArgs e)
        {
            this.tbx_date.Text = System.DateTime.Today.ToShortDateString();
            int tId = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(trnsID) from transactions", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tId = Convert.ToInt32(dr[0]);
                tId++;
            }
            conn.sqlConnection1.Close();
            this.tbx_tID.Text = "YB-000" + tId + "-" + System.DateTime.Today.Year;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try {
                double curBal = Convert.ToDouble(tbx_curBal.Text);
                double withdrawl = Convert.ToDouble(tbx_wdrAmnt.Text);
                if (withdrawl <= curBal)
                {
                    conn.sqlConnection1.Open();
                    double bal = Convert.ToDouble(tbx_curBal.Text) - Convert.ToDouble(tbx_wdrAmnt.Text);
                    SqlCommand cmd = new SqlCommand("update accounts set balance = @balance where accountNumber=@accountNumber", conn.sqlConnection1);
                    cmd.Parameters.AddWithValue("@balance", bal);
                    cmd.Parameters.AddWithValue("@accountNumber", tbx_accNum.Text);
                    cmd.ExecuteNonQuery();
                    conn.sqlConnection1.Close();

                    conn.sqlConnection1.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into transactions(trnsID,trnsDate, trnsType, accountNumber, accountTitle, debit, credit)values(@tid,@trnsDate, @trnsType, @accountNumber, @accountTitle, @debit, @credit)", conn.sqlConnection1);
                    cmd1.Parameters.AddWithValue("@tid", tbx_tID.Text);
                    cmd1.Parameters.AddWithValue("@trnsDate", tbx_date.Text);
                    cmd1.Parameters.AddWithValue("@trnsType", "Withdrawl");
                    cmd1.Parameters.AddWithValue("@accountNumber", tbx_accNum.Text);
                    cmd1.Parameters.AddWithValue("@accountTitle", tbx_cusName.Text);
                    cmd1.Parameters.AddWithValue("@debit", Convert.ToDouble(tbx_wdrAmnt.Text));
                    cmd1.Parameters.AddWithValue("@credit", "0");
                    cmd1.ExecuteNonQuery();
                    conn.sqlConnection1.Close();
                    tbx_accNum.Clear();
                    tbx_accType.Clear();
                    tbx_curBal.Clear();
                    tbx_cusName.Clear();
                    tbx_date.Clear();
                    tbx_wdrAmnt.Clear();
                    tbx_wdrAmnt.Clear();
                    tbx_nicNum.Clear();
                    tbx_tID.Clear();
                    MessageBox.Show("Amount withdrawl Successfully!\nNew Balance: " + bal);
                }
                else
                {
                    MessageBox.Show("Sorry! Insufficient Balance\nNew Balance: " + curBal);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
