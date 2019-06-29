using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookMis
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        int loginCount = 1;
        public Login()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            string uid = txtUID.Text;
            string pwd = txtPWD.Password;
            if (uid.Length == 0 || pwd.Length == 0)
            {
                MessageBox.Show("用户名和口令都不能为空！");
                txtUID.Focus();
                return;
            }
            if (UserInfo.judgeUser(uid, pwd) == true)
            {
                UserInfo.IsCheckIn = true;
                UserInfo.UID = uid;
                UserInfo.IsUserAdmin = UserInfo.getUserAdmin(uid);
                UserInfo.IsReaderAdmin = UserInfo.getReaderAdmin(uid);
                UserInfo.IsBookAdmin = UserInfo.getBookAdmin(uid);
                UserInfo.IsBorrowAdmin = UserInfo.getBorrowAdmin(uid);
                UserInfo.LoginTime = DateTime.Now.ToString();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                return;
            }
            if (++loginCount == 3)
            {
                MessageBox.Show("连续登录失败3次，程序即将退出！");
                this.Close();
                return;
            }
            MessageBox.Show("用户名或口令不正确，请修改后再登录！");
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
