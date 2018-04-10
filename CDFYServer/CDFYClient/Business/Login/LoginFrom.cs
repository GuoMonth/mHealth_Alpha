using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CDFYClient.CommUtil;

namespace CDFYClient.Business.Login
{
    public partial class LoginFrom : Form
    {
        public LoginFrom()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string url = @"http://localhost/CDFYServer/Control/Login.ashx";
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic.Add("FunctionName", "DoLogin");
            dic.Add(this.txt_account.Text,this.txt_password.Text);
            CommUtil_RequestServer.PostHttpRequest(url, dic, 30000, dic);
            
        }
    }
}
