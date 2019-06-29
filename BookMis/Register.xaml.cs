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
    ///123dsdsdsdddfdfd
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            string uid = txtUID.Text.Trim();
            string pwd1 = txtPWD.Password;
            string pwd2 = txtRePWD.Password;

            string usera, readera, booka, borrowa;

            if (uid.Length == 0 || pwd1.Length == 0)
            {
                MessageBox.Show("用户名和口令都不能为空，请检查！");
                txtUID.Focus();
                return;
            }
            if (pwd1.CompareTo(pwd2) != 0)
            {
                MessageBox.Show("两次口令不相同，请检查！");
                txtPWD.Focus();
                return;
            }

            usera = chRightA.IsChecked.ToString();
            readera = chRightB.IsChecked.ToString();
            booka = chRightC.IsChecked.ToString();
            borrowa = chRightD.IsChecked.ToString();

            if (UserInfo.newUser(uid, pwd1, usera, readera, booka, borrowa, DateTime.Now.ToString()) == true)
            {
                MessageBox.Show("用户注册成功，请记住账号和密码！");
                return;
            }
            MessageBox.Show("该用户已经被注册，请检查！");
            txtUID.Focus();
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtUID_GotFocus(object sender, RoutedEventArgs e)
        {
            string uid = ((TextBox)sender).Text.Trim();
            if (UserInfo.isExistUser(uid) == true)
            {
                MessageBox.Show("该用户已经被注册，请检查！");
                return;
            }
        }

        private void TxtPWD_GotFocus(object sender, RoutedEventArgs e)
        {
            string pwd1 = txtPWD.Password;
            string pwd2 = txtRePWD.Password;
            if (pwd1.CompareTo(pwd2) != 0)
            {
                MessageBox.Show("");
                txtPWD.Focus();
                return;
            }
        }
    }
}
