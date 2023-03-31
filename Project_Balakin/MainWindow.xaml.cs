﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class GlobalVar
    {
        public static bool ThemeChanged = false;
        public static bool isAction1 = true;
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassChangePage.frame1 = Frame;
            ClassChangePage.frame1.Navigate(new Login());
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                label_time.Content = DateTime.Now.ToString("dd MMMM HH:mm");
            }, Dispatcher);
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Оператор скоро прибудет, ожидайте.");
        }

        private void UserPanel_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void UserPanel_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();

            if (GlobalVar.isAction1)
            {
                Frame.Background = (Brush)converter.ConvertFromString("#FF1F1F1F");
                GlobalVar.ThemeChanged = true;
            }
            else
            {
                Frame.Background = (Brush)converter.ConvertFromString("White");
                GlobalVar.ThemeChanged = false;
            }
            GlobalVar.isAction1 = !GlobalVar.isAction1;  
           
        }

    }
}