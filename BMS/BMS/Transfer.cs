using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BMS
{
    public partial class Transfer : Form
    {
        myConn conn = new myConn();
        public Transfer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from accounts where accountNumber=@accountNumber", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@accountNumber", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["nic"].ToString();
                textBox3.Text = dr["customerName"].ToString();
                textBox5.Text = dr["balance"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from accounts where accountNumber=@accountNumber", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@accountNumber", textBox7.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["nic"].ToString();
                textBox6.Text = dr["customerName"].ToString();
                textBox4.Text = dr["balance"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                double senCurBal = Convert.ToDouble(textBox5.Text);
                double recCurBal = Convert.ToDouble(textBox4.Text);
                double trnsAmnt = Convert.ToDouble(textBox9.Text);

                if (trnsAmnt <= senCurBal)
                {
                    double senNewbal = senCurBal - trnsAmnt;
                    Double recNewBal = recCurBal + trnsAmnt;
                    conn.sqlConnection1.Open();
                    SqlCommand cmd = new SqlCommand("update accounts set balance = @balance where accountNumber=@accountNumber", conn.sqlConnection1);
                    cmd.Parameters.AddWithValue("@balance", senNewbal);
                    cmd.Parameters.AddWithValue("@accountNumber", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    conn.sqlConnection1.Close();

                    conn.sqlConnection1.Open();
                    SqlCommand cmd1 = new SqlCommand("update accounts set balance = @balance where accountNumber=@accountNumber", conn.sqlConnection1);
                    cmd1.Parameters.AddWithValue("@balance", recNewBal);
                    cmd1.Parameters.AddWithValue("@accountNumber", textBox7.Text);
                    cmd1.ExecuteNonQuery();
                    conn.sqlConnection1.Close();

                    conn.sqlConnection1.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into transactions(trnsID,trnsDate, trnsType, accountNumber, accountTitle, debit, credit, DestinationAccName, DestinationAccNum)values(@tid,@trnsDate, @trnsType, @accountNumber, @accountTitle, @debit, @credit,@DestinationAccName ,@DestinationAccNum)", conn.sqlConnection1);
                    cmd2.Parameters.AddWithValue("@tid", textBox12.Text);
                    cmd2.Parameters.AddWithValue("@trnsDate", textBox11.Text);
                    cmd2.Parameters.AddWithValue("@trnsType", "Transfer");
                    cmd2.Parameters.AddWithValue("@accountNumber", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@accountTitle", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@debit", Convert.ToDouble(textBox9.Text));
                    cmd2.Parameters.AddWithValue("@credit", "0");
                    cmd2.Parameters.AddWithValue("@DestinationAccName", textBox6.Text);
                    cmd2.Parameters.AddWithValue("@DestinationAccNum", textBox7.Text);
                    cmd2.ExecuteNonQuery();
                    conn.sqlConnection1.Close();





                    MessageBox.Show("Amount transfered Successfully!\nAccount Number: " + textBox1.Text + " New Balance: " + senNewbal + "\nAccount Number: " + textBox7.Text + " New Balance: " + recNewBal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            this.textBox11.Text = System.DateTime.Today.ToShortDateString();
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
            this.textBox12.Text = "YB-000" + tId + "-" + System.DateTime.Today.Year;


         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
