﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            }
            , Dispatcher);

        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            if (box_login.Text.Length > 0)
            {
                if (box_password.Password.Length > 0)
                {
                    using (var DataBase = new DataBaseEntities())
                    {
                        string login = box_login.Text;
                        string password = box_password.Password;

                        GlobalVar.PanelLogin = login;

                        var isUserExistsLoginAdm = DataBase.admins.Any(u => u.login == login);
                        var isUserExistsPassAdm = DataBase.admins.Any(u => u.password == password);
                        var isUserExistsLogin = DataBase.users.Any(u => u.login == login);
                        var isUserExistsPass = DataBase.users.Any(u => u.password == password);
                        if(isUserExistsLoginAdm && isUserExistsPassAdm)
                        {
                            MessageBox.Show("Админ авторизовался");
                            ClassChangePage.frame1.Navigate(new AdminPage());
                        }
                        else
                        { 
                            if (isUserExistsLogin && isUserExistsPass)
                            {
                                MessageBox.Show("Пользователь авторизовался");
                                ClassChangePage.frame1.Navigate(new Main());
                            }
                            else MessageBox.Show("Неверный логин или пароль");
                        }
                    }
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
            if(box_password.Password.Length > 0) 
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
