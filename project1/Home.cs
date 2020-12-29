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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\PROJECT\ICECREAMORDER\ICECREAM31.MDF;Integrated Security=True;Connect Timeout=30";


        private void Main_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;

            lbName.Text = "";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignUp frm = new SignUp();
            frm.Show();

        }

        private void btnAdclose_Click(object sender, EventArgs e)
        {
            lb1day.Visible = false;
            imgAd.Visible = false;
            btnAdclose.Visible = false;
        }
        private void btnHomeLogin_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();

        }
        private void btnOrder_Click(object sender, EventArgs e)
        {

            string id, store = "", time = "", size = "", Icecream1 = "", Icecream2 = "", Icecream3 = "", Icecream4 = "", Icecream5 = "";

            string date = dateTimePicker1.Value.ToShortDateString();
            if (lbName.Text != "") id = lbName.Text;
            else
            {
                label3.Text = "! 로그인 후 이용하세요 !";
                return;
            }
            store = cbStore.SelectedItem.ToString();

            time = cbTime.SelectedItem.ToString();

            if (rbOne.Checked)
            {
                size = rbOne.Text;
                if (listView1.CheckedItems.Count == 1)
                {
                    Icecream1 = listView1.CheckedItems[0].Text;
                    Icecream2 = "";
                    Icecream3 = "";
                    Icecream4 = "";
                    Icecream5 = "";
                }
                else
                {
                    label3.Text = "한 가지의 맛을 선택하세요";
                    return;
                }
            }
            if (rbTwo.Checked)
            {
                size = rbTwo.Text;
                if (listView1.CheckedItems.Count == 2)
                {
                    Icecream1 = listView1.CheckedItems[0].Text;
                    Icecream2 = listView1.CheckedItems[1].Text;
                    Icecream3 = "";
                    Icecream4 = "";
                    Icecream5 = "";
                }
                else
                {
                    label3.Text = "두 가지의 맛을 선택하세요";
                    return;
                }

            }
            if (rbThree.Checked)
            {
                size = rbThree.Text;

                if (listView1.CheckedItems.Count == 3)
                {
                    Icecream1 = listView1.CheckedItems[0].Text;
                    Icecream2 = listView1.CheckedItems[1].Text;
                    Icecream3 = listView1.CheckedItems[2].Text;
                    Icecream4 = "";
                    Icecream5 = "";
                }
                else
                {
                    label3.Text = "세 가지의 맛을  선택하세요";
                    return;
                }
            }
            if (rbFour.Checked)
            {
                size = rbFour.Text;
                if (listView1.CheckedItems.Count == 4)
                {
                    Icecream1 = listView1.CheckedItems[0].Text;
                    Icecream2 = listView1.CheckedItems[1].Text;
                    Icecream3 = listView1.CheckedItems[2].Text;
                    Icecream4 = listView1.CheckedItems[3].Text;
                    Icecream5 = "";
                }
                else
                {
                    label3.Text = "네 가지의 맛을 선택하세요";
                    return;
                }
            }
            if (rbFive.Checked)
            {
                size = rbFive.Text;
                if (listView1.CheckedItems.Count == 5)
                {
                    Icecream1 = listView1.CheckedItems[0].Text;
                    Icecream2 = listView1.CheckedItems[1].Text;
                    Icecream3 = listView1.CheckedItems[2].Text;
                    Icecream4 = listView1.CheckedItems[3].Text;
                    Icecream5 = listView1.CheckedItems[4].Text;
                }
                else
                {
                    label3.Text = "다섯 가지의 맛을 선택하세요";
                    return;
                }
            }

            string str = $"insert into OrderList values ('{id}','{date}','{store}','{time}','{size}','{Icecream1}','{Icecream2}','{Icecream3}','{Icecream4}','{Icecream5}')";
            sCmd.CommandText = str;
            sCmd.ExecuteNonQuery();
            label3.Text = "주문이 완료되었습니다";

        }



        private void btnHomeLogout_Click(object sender, EventArgs e)
        {
            lbName.Text = "";
            lbLogin.Text = "로그인 후 이용하세요";

            //주문 후 로그아웃시 모든 아이템 초기화 
            cbStore.Text = "";
            cbTime.Text = "";



        }

        public string GetDBData(string Field, string Table, string KField, string Kvalue)
        {

            sCmd.CommandText = $"select {Field} from {Table} where {KField} = '{Kvalue}'";
            return sCmd.ExecuteScalar().ToString();
        }

        private void btnMyorder_Click(object sender, EventArgs e)
        {
            if (lbName.Text != "")
            {
                MyOrder Mo = new MyOrder();
                Mo.Show();
                Mo.tbMyID.Text = lbName.Text;
                string id = Mo.tbMyID.Text;
                string s1 = GetDBData("Date", "OrderList", "ID", id).Trim();
                Mo.tbMyDate.Text = s1;
                string s2 = GetDBData("Store", "OrderList", "ID", id).Trim();
                Mo.cbMyStore.Text = s2;
                string s3 = GetDBData("Time", "OrderList", "ID", id).Trim();
                Mo.cbMyTime.Text = s3;
                string s4 = GetDBData("Size", "OrderList", "ID", id).Trim();
                Mo.cbMySize.Text = s4;
            }
            else
            {

            }



        }
    }
    
}
