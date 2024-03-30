using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onluyen
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        string Constring = "Data Source=DESKTOP-93NLVCJ;Initial Catalog=QLkhachhang;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        
      
        public Form1()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from TB_KhachHang";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataG.DataSource = dt;
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(Constring);
            conn.Open();
            loaddata();
        }

        private void dataG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataG.CurrentRow.Index;
            txtMa.Text = dataG.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataG.Rows[i].Cells[1].Value.ToString();
        }
    }
}
