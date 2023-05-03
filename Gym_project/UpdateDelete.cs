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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MCA\C#\project\Gym_project\Gym_project\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select* from MemberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            GridView2.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tb_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Member_name.Text = "";
            combox_timeing.Text = "";
            mobile_no.Text = "";
            age.Text = "";
            txtAmaunt.Text = "";
            Comobox_gender.Text = "";

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (Member_name.Text == "" || Comobox_gender.Text == "" || mobile_no.Text == "" || age.Text == "" || txtAmaunt.Text == "" || combox_timeing.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTbl where MId=" + txtID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Delete Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void GridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(GridView2.SelectedRows[0].Cells[0].Value.ToString());
            Member_name.Text = GridView2.SelectedRows[0].Cells[1].Value.ToString();
            Comobox_gender.Text = GridView2.SelectedRows[0].Cells[3].Value.ToString();
            mobile_no.Text = GridView2.SelectedRows[0].Cells[2].Value.ToString();
            age.Text = GridView2.SelectedRows[0].Cells[4].Value.ToString();
            txtAmaunt.Text = GridView2.SelectedRows[0].Cells[5].Value.ToString();
            combox_timeing.Text = GridView2.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Comobox_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            if ( Member_name.Text == "" || Comobox_gender.Text == "" || mobile_no.Text == "" || age.Text == "" || txtAmaunt.Text == "" || combox_timeing.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTbl set MName='"+Member_name.Text+ "',Moblie='" + mobile_no.Text + "',MGen='" + Comobox_gender.Text + "',MAge='" + age.Text + "',MAmaunt='" + txtAmaunt.Text + "',MTimnig='" + combox_timeing.Text + "' where Mid="+ txtID.Text+ ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Update Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select * from MemberTbl where Mid = '" + txtID.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            Member_name.Text = ds.Tables[0].Rows[0][1].ToString();
            Comobox_gender.Text = ds.Tables[0].Rows[0][3].ToString();
            mobile_no.Text = ds.Tables[0].Rows[0][2].ToString();
            age.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAmaunt.Text = ds.Tables[0].Rows[0][5].ToString();
            combox_timeing.Text = ds.Tables[0].Rows[0][6].ToString();
            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
