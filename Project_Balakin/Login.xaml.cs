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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Balakin
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            if (box_login.Text.Length > 0)
            {
                if (box_Password.Password.Length > 0)
                {
                    /*FIXME*/
                    ClassChangePage.frame1.Navigate(new Main());
                    
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }

        private void click_Reg(object sender, RoutedEventArgs e)
        {
            ClassChangePage.frame1.Navigate(new Registration());
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if(box_Password.Password.Length > 0) 
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }
    }
}
