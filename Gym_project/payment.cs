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

namespace Gym_project
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MCA\C#\project\Gym_project\Gym_project\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillName()
        {
            Con.Open();
            SqlCommand cmd =new  SqlCommand("select Mname from MemberTbl",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mname",typeof(string));
            dt.Load(rdr);
            cbMname.ValueMember = "Mname";
            cbMname.DataSource = dt;

            Con.Close();
        }
        private void filterByName()
        {
            Con.Open();
            string query = "select * from PaymentTbl where PMember = '" + txtSearchName.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            GridView2.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select* from PaymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            GridView2.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            cbMname.Text = "";
            txtAmou.Text = "";

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (cbMname.Text == "" || txtAmou.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string paypariode = PMonth.Value.Month.ToString() + PMonth.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember= '"+cbMname.SelectedValue.ToString()+"' and PMonth='"+ paypariode+ "'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already Paid For this Month");
                }
                else
                {
                    string query = "insert into PaymentTbl values('"+paypariode+"','"+cbMname.SelectedValue.ToString()+"','"+txtAmou.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Paid Successfully");

                }
                Con.Close();
                populate();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterByName();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
