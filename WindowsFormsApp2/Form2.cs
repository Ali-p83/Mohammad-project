using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(textBox1.Text);
            int qree;
            Random x = new Random();
            qree = x.Next(001,y);
            lblwincode.Text = qree.ToString();
            Display();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename="+Application.StartupPath+@"\Database1.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from adduser where Id ='" +Convert.ToInt32( lblwincode.Text) + "'";
            adp.Fill(ds, "adduser");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "adduser";
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
