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


namespace Gym_project
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MCA\C#\project\Gym_project\Gym_project\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_mambername.Text == "" || txt_mobile.Text == "" || txt_age.Text == ""|| txt_amount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
                else
            {
                try
                {
                    Con.Open();
                    string query = "insert into MemberTbl values('" + txt_mambername.Text + "','" + txt_mobile.Text + "','" + cb_gender.SelectedItem.ToString() + "'," + txt_age.Text + "," + txt_amount.Text + ",'" + cb_timing.SelectedItem.ToString() + "')";
                    SqlCommand cmd =new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Susscessfully Added");
                    Con.Close();
                    txt_mambername.Text = "";
                    txt_mobile.Text = "";
                    txt_age.Text = "";
                    cb_gender.Text = "";
                    txt_amount.Text = "";
                    cb_timing.Text = "";

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_mambername.Text = "";
            txt_mobile.Text = "";
            txt_age.Text = "";
            cb_gender.Text = "";
            txt_amount.Text = "";
            cb_timing.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void AddMember_Load(object sender, EventArgs e)
        {

        }
    }
}
