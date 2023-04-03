using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Project_Balakin
{
    
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
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 1), DispatcherPriority.Normal, delegate
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

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();

            if (GlobalVar.FlagToAction)
            {
                ColorAnimationUsingKeyFrames animation = new ColorAnimationUsingKeyFrames();
                animation.Duration = new Duration(TimeSpan.FromSeconds(2.4));
                animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Gray, TimeSpan.FromSeconds(0.8)));
                animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.DarkGray, TimeSpan.FromSeconds(0.6)));
                animation.KeyFrames.Add(new LinearColorKeyFrame(((SolidColorBrush)Bebra.Background).Color, TimeSpan.FromSeconds(1.2)));

                SolidColorBrush brush = new SolidColorBrush();
                Frame.Background = brush;
                brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);


                GlobalVar.ThemeNegr = true;
            }
            else
            {
                ColorAnimationUsingKeyFrames animation = new ColorAnimationUsingKeyFrames();
                animation.Duration = new Duration(TimeSpan.FromSeconds(1));
                animation.KeyFrames.Add(new LinearColorKeyFrame(((SolidColorBrush)Frame.Background).Color, TimeSpan.FromSeconds(0)));
                animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Transparent, TimeSpan.FromSeconds(2)));

                SolidColorBrush brush = new SolidColorBrush();
                Frame.Background = brush;
                brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);

                GlobalVar.ThemeNegr = false;
                //"#FF1F1F1F"
            }
            GlobalVar.FlagToAction = !GlobalVar.FlagToAction;  
           
        }

    }
}
