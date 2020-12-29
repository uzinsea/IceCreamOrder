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
    public partial class MyOrder : Form
    {
        public MyOrder()
        {
            InitializeComponent();
        }
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\PROJECT\ICECREAMORDER\ICECREAM31.MDF;Integrated Security=True;Connect Timeout=30";


        private void MyOrder_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = connString;
            sConn.Open();
            sCmd.Connection = sConn;

        }
 
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            string id = tbMyID.Text;
            sCmd.CommandText = $"delete OrderList where id = '{id}'";
            sCmd.ExecuteNonQuery();

            lbNotice.Text = "주문이 취소되었습니다";
        }

        private void btnModifyOrder_Click(object sender, EventArgs e)
        {
            string id = tbMyID.Text;
            string store = cbMyStore.Text.ToString();
            string time = cbMyTime.Text.ToString();
            string size = "", Icecream1 = "", Icecream2 = "", Icecream3 = "", Icecream4 = "", Icecream5 = "";

            if (cbMySize.SelectedIndex == 0)
            {
                size = cbMySize.SelectedItem.ToString();
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
                    lbNotice.Text = "한 가지의 맛을 선택하세요";
                    return;
                }
            }
            if (cbMySize.SelectedIndex == 1)
            {
                size = cbMySize.SelectedItem.ToString();
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
                    lbNotice.Text = "두 가지의 맛을 선택하세요";
                    return;
                }

            }
            if (cbMySize.SelectedIndex == 2)
            {
                size = cbMySize.SelectedItem.ToString();
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
                    lbNotice.Text = "세 가지의 맛을  선택하세요";
                    return;
                }
            }
            if (cbMySize.SelectedIndex == 3)
            {
                size = cbMySize.SelectedItem.ToString();
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
                    lbNotice.Text = "네 가지의 맛을 선택하세요";
                    return;
                }
            }
            if (cbMySize.SelectedIndex == 4)
            {
                size = cbMySize.SelectedItem.ToString();
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
                    lbNotice.Text = "다섯 가지의 맛을 선택하세요";
                    return;
                }
            }

            string str =  $"update OrderList set store = '{store}',time = '{time}', size='{size}',Icecream1='{Icecream1}',Icecream2='{Icecream2}',Icecream3='{Icecream3}',Icecream4='{Icecream4}',Icecream5='{Icecream5}' where id = '{id}'";
            sCmd.CommandText = str;
            sCmd.ExecuteNonQuery();
            Close();
        }

        private void cbMyStore_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
