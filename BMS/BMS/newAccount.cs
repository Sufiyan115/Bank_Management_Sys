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
    public partial class newAccount : Form
    {
        myConn conn = new myConn();
        public newAccount()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void newAccount_Load(object sender, EventArgs e)

        {
            this.comboBox1.Text = "Select Branch";
            this.comboBox2.Text = "Account Type";

            this.radioButton1.Checked = true;


            string[] ctry = { "Pakistan", "India", "China", "Turkey" };
            this.comboBox3.Items.AddRange(ctry);

            string[] accType = { "Saving Account", "Current Account" };
            this.comboBox2.Items.AddRange(accType);


            int aid = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(accountID) from accounts", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                aid = Convert.ToInt32(dr[0]);
                aid++;
            }
            conn.sqlConnection1.Close();
            this.textBox1.Text = "YB-000" + aid + "-" + System.DateTime.Today.Year;


            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select branchname from branch", conn.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while(dr1.Read())
            {
                this.comboBox1.Items.Add(dr1["branchName"].ToString());
            }
            conn.sqlConnection1.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into accounts(accountId,branchId,customerName,accountnumber,accounttype,gender,dob,nationality,postaladdress,contactNo,nic,InititalDeposit,company,occupation,balance,modifiedDate) values (@accountId,@branchId,@customerName,@accountnumber,@accounttype,@gender,@dob,@nationality,@postaladdress,@contactNo,@nic,@InititalDeposit,@company,@occupation,@balance,@modifiedDate)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@accountId", textBox1.Text);
                cmd.Parameters.AddWithValue("@branchid", textBox2.Text);
                cmd.Parameters.AddWithValue("@customerName", textBox3.Text);
                cmd.Parameters.AddWithValue("@accountnumber", textBox4.Text);
                cmd.Parameters.AddWithValue("@accounttype", comboBox2.Text);
                if (radioButton2.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", "Female");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gender", "Male");
                }


                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@nationality", comboBox3.Text);
                cmd.Parameters.AddWithValue("@postaladdress", textBox5.Text);
                cmd.Parameters.AddWithValue("@contactNo", textBox6.Text);
                cmd.Parameters.AddWithValue("@nic", textBox8.Text);
                cmd.Parameters.AddWithValue("@InititalDeposit", textBox9.Text);
                cmd.Parameters.AddWithValue("@company", textBox10.Text);
                cmd.Parameters.AddWithValue("@occupation", textBox11.Text);
                cmd.Parameters.AddWithValue("@balance", textBox9.Text);
                cmd.Parameters.AddWithValue("@modifiedDate", System.DateTime.Today.ToShortDateString());
                cmd.ExecuteNonQuery();
                conn.sqlConnection1.Close();
                MessageBox.Show("Account created successfully");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();


            }
            catch(Exception ex)
            {
                conn.sqlConnection1.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Close();
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select branchid from branch where branchname=@branchname", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@branchname", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox2.Text = "00"+dr["branchID"].ToString();
            }
            conn.sqlConnection1.Close();

            int accNum = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select count(accountNumber) from accounts", conn.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dr1.Read())
            {
                accNum = Convert.ToInt32(dr1[0]);
                accNum++;
            }
            conn.sqlConnection1.Close();
            this.textBox4.Text = textBox2.Text + textBox1.Text + "000" + accNum;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
