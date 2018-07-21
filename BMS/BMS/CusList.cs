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
    public partial class CusList : Form
    {
        myConn conn = new myConn();
        public CusList()
        {
            InitializeComponent();
        }

        private void CusList_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ForeColor = Color.Black;
            this.dataGridView1.ReadOnly = true;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from accounts", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
