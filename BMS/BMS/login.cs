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
    public partial class login : Form
    {
        public static string loginuser;
        myConn conn = new myConn();
        public login()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username=@username and upassword=@upassword", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@upassword", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                loginuser = textBox1.Text;
                dashboard dbrd = new dashboard();
                dbrd.ShowDialog();
                this.Close();
                
            
            }
            else
            {
                MessageBox.Show("Login Failed!");
                conn.sqlConnection1.Close();
            }

        }

        private void login_Load(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';
            this.AcceptButton = Login_btn;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
