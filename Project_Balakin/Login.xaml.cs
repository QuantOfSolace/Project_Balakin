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
using System.Windows.Threading;

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
            BrushConverter converter = new BrushConverter();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 1), DispatcherPriority.Normal, delegate
            {

                if (GlobalVar.ThemeNegr == true)
                {
                    label1.Foreground = (Brush)converter.ConvertFromString("White");
                    label2.Foreground = (Brush)converter.ConvertFromString("White");
                }
                if (GlobalVar.ThemeNegr == false)
                {
                    label1.Foreground = (Brush)converter.ConvertFromString("Black");
                    label2.Foreground = (Brush)converter.ConvertFromString("Black");
                }
            }, Dispatcher);
        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            if (box_login.Text.Length > 0)
            {
                if (box_Password.Password.Length > 0)
                {
                    /*Burachenock_BaraguzinEntities db = new Burachenock_BaraguzinEntities();
                    admins user1 = db.admins.FirstOrDefault(w => w.login.Equals(box_login.Text));
                    if (user1.password.Equals(box_Password))
                    {
                        MessageBox.Show("Админ авторизовался");
                        ClassFrame1.frame1.Navigate(new MainPage());
                    }

                    users user2 = db.users.FirstOrDefault(w => w.login.Equals(box_login.Text));
                    if (user2.password.Equals(box_Password))
                    {
                    / FIXME /
                    MessageBox.Show("Пользователь авторизовался");
                    */
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
