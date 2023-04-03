using System;
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

namespace Project_Balakin
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            
            myLabel.Content = "Уровень доступа: " + GetUserNameByLogin(GlobalVar.PanelLogin);
        }

        private DataBaseEntities dataBase = new DataBaseEntities();

        private string GetUserNameByLogin(string login)
        {
            // Получить объект пользователя из БД по login:
            var user = dataBase.admins.FirstOrDefault(u => u.login == login);

            // Если у пользователя есть имя, то вернуть его:
            if (user != null && !string.IsNullOrEmpty(user.root))
            {
                return user.root;
            }

            // В противном случае вернуть пустую строку:
            return string.Empty;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ClassChangePage.frame1.Navigate(new Login());
        }
    }
}
