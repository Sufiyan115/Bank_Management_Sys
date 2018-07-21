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
    public partial class adminPnl : Form
    {
        public adminPnl()
        {
            InitializeComponent();
        }
        myConn conn = new myConn();

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ForeColor = Color.Black;
            this.dataGridView1.ReadOnly = true;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from users", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void adminPnl_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select uid from users", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cbx_uID.Items.Add(dr["uid"].ToString());
            }
            conn.sqlConnection1.Close();

            this.tbx_Password.PasswordChar = '*';
            this.tbx2_Pass.PasswordChar = '*';



        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into users(uFullName,username,upassword,emailID) values (@uFullName,@username,@upassword,@emailID)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@uFullName", tbx_Name.Text);
                cmd.Parameters.AddWithValue("@username", tbx_UName.Text);
                cmd.Parameters.AddWithValue("@upassword", tbx_Password.Text);
                cmd.Parameters.AddWithValue("@emailID", tbx_Email.Text);
                cmd.ExecuteNonQuery();
                conn.sqlConnection1.Close();
                MessageBox.Show("User added successfully");
                tbx_Email.Clear();
                tbx_Name.Clear();
                tbx_Password.Clear();
                tbx_UName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    conn.sqlConnection1.Open();
                    SqlCommand cmd = new SqlCommand("delete from users where uID=@UID", conn.sqlConnection1);
                    cmd.Parameters.AddWithValue("@uID", cbx_uID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully!");
                    conn.sqlConnection1.Close();
                    tbx2_email.Clear();
                    tbx2_Name.Clear();
                    tbx_Password.Clear();
                    tbx2_uName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("update users set uFullName=@uFullName, username=@username, upassword=@upassword, emailID=@emailID where uID=@uID", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@uID", cbx_uID.Text);
                cmd.Parameters.AddWithValue("@uFullName", tbx2_Name.Text);
                cmd.Parameters.AddWithValue("@username", tbx2_uName.Text);
                cmd.Parameters.AddWithValue("@upassword", tbx2_Pass.Text);
                cmd.Parameters.AddWithValue("@emailID", tbx2_email.Text);
                cmd.ExecuteNonQuery();
                conn.sqlConnection1.Close();
                MessageBox.Show("User updated successfully");
                tbx2_email.Clear();
                tbx2_Name.Clear();
                tbx_Password.Clear();
                tbx2_uName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbx_uID_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from users where uID=@uID", conn.sqlConnection1);
            cmd1.Parameters.AddWithValue("@uid", Convert.ToInt32(cbx_uID.Text));
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                tbx2_Name.Text = dr1["uFullName"].ToString();
                tbx2_uName.Text = dr1["username"].ToString();
                tbx2_Pass.Text = dr1["uPassword"].ToString();
                tbx2_email.Text = dr1["emailID"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
          

        }
    }
}
