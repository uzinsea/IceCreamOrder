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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\Icecream31.mdf;Integrated Security=True;Connect Timeout=30";



        private void Login_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;
        }
        public string GetDBData(string Field, string Table, string KField, string Kvalue)
        {
            sCmd.CommandText = $"select {Field} from {Table} where {KField} = '{Kvalue}'";
            return sCmd.ExecuteScalar().ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string id = tbID.Text;
            string pwd = tbPwd.Text;
            string s1 = GetDBData("Password", "Customer", "ID", id).Trim();
            if (pwd != s1) lbWelcome.Text = "아이디와 비밀번호를 다시 확인해주세요";
            else
            {
                this.Hide();
                Home HM = new Home();
                HM.lbName.Text = $"{id}";
                HM.lbLogin.Text = $"님 반갑습니다";
                HM.Show();
                HM.lb1day.Visible = false;
                HM.imgAd.Visible = false;
                HM.btnAdclose.Visible = false;
            }
            //***아이디와 비밀번호 둘다 틀렸을 때 상황을 구현하고 싶다. 지금은 무조건 아이디는 맞고 비밀번호 틀렸을 때 안내문구 등장

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
