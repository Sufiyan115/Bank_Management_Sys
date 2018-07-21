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
    public partial class searchAccount : Form
    {
        public searchAccount()
        {
            InitializeComponent();
        }
        myConn conn = new myConn();

        private void searchAccount_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
            this.dataGridView1.ForeColor = Color.Black;
            this.dataGridView1.ReadOnly = true;
            tbx_AccType.Text = "";
            tbx_Address.Text = "";
            tbx_Balance.Text = "";
            tbx_Contact.Text = "";
            tbx_CusName.Text = "";
            tbx_DOB.Text = "";
            tbx_Gender.Text = "";
            tbx_Nationality.Text = "";
            tbx_NIC.Text = "";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select * from accounts where accountNumber=@accountNumber", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@accountNumber", tbx_AccNum.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tbx_AccType.Text = dr["AccountType"].ToString();
                    tbx_CusName.Text = dr["customerName"].ToString();
                    tbx_Gender.Text = dr["gender"].ToString();
                    tbx_NIC.Text = dr["nic"].ToString();
                    tbx_DOB.Text = dr["dob"].ToString();
                    tbx_Address.Text = dr["postalAddress"].ToString();
                    tbx_Contact.Text = dr["contactNo"].ToString();
                    tbx_Nationality.Text = dr["nationality"].ToString();
                    tbx_Balance.Text = dr["balance"].ToString();
                }
                conn.sqlConnection1.Close();


                conn.sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from transactions where accountnumber=@accountnumber", conn.sqlConnection1);
                cmd1.Parameters.AddWithValue("@accountNumber", tbx_AccNum.Text);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr1);
                dataGridView1.DataSource = dt;
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
