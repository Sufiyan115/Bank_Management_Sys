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
    public partial class deposit : Form
    {
        myConn conn = new myConn();
        public deposit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double bal = Convert.ToDouble(tbx_curBal.Text) + Convert.ToDouble(tbx_depAmnt.Text);
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("update accounts set balance = @balance where accountNumber=@accountNumber", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@balance", bal);
                cmd.Parameters.AddWithValue("@accountNumber", tbx_accNum.Text);
                cmd.ExecuteNonQuery();
                conn.sqlConnection1.Close();

                conn.sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("insert into transactions(trnsID,trnsDate, trnsType, accountNumber, accountTitle, debit, credit)values(@tid,@trnsDate, @trnsType, @accountNumber, @accountTitle, @debit, @credit)", conn.sqlConnection1);
                cmd1.Parameters.AddWithValue("@tid", tbx_tID.Text);
                cmd1.Parameters.AddWithValue("@trnsDate", tbx_date.Text);
                cmd1.Parameters.AddWithValue("trnsType", "Deposit");
                cmd1.Parameters.AddWithValue("@accountNumber", tbx_accNum.Text);
                cmd1.Parameters.AddWithValue("@accountTitle", tbx_cusName.Text);
                cmd1.Parameters.AddWithValue("@credit", Convert.ToDouble(tbx_depAmnt.Text));
                cmd1.Parameters.AddWithValue("@debit", "0");
                cmd1.ExecuteNonQuery();
                conn.sqlConnection1.Close();
                tbx_accNum.Clear();
                tbx_accType.Clear();
                tbx_curBal.Clear();
                tbx_cusName.Clear();
                tbx_date.Clear();
                tbx_depAmnt.Clear();
                tbx_depAmnt.Clear();
                tbx_nicNum.Clear();
                tbx_tID.Clear();
                MessageBox.Show("Amount Deposited Successfully!\nNew Balance: " + bal);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void deposit_Load(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
