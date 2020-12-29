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

namespace project1
{
    public partial class SignUp : Form
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\PROJECT\ICECREAMORDER\ICECREAM31.MDF;Integrated Security=True;Connect Timeout=30";

        public SignUp()
        {
            InitializeComponent();
        }
        private void SignUp_Load_1(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;

        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbID.Text;
                string password = tbPwd.Text;
                string name = tbName.Text;
                string phone = tbPhone.Text;
                string address = tbAddress.Text;
                string payment;
                if (rbCard.Checked) payment = "Card";
                else payment = "Cash";
                string str = "";
                str = $"insert into Customer values ('{id}','{password}','{name}','{phone}','{address}','{payment}')";
                sCmd.CommandText = str;
                sCmd.ExecuteNonQuery();//===================================***
                Close();
            }
            catch (Exception e1)
            {
                lbNotice.Text = "빈칸없이 입력해주십시오";
            }


        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
