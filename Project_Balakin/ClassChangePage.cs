using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Balakin
{
    public static class ClassChangePage
    {
        static public Frame frame1 = new Frame();
    }
    public class GlobalVar
    { 
        public static string PanelLogin;
        public static bool ThemeNegr = false;
        public static bool FlagToAction = true;
    }
    public class MyMethods
    {
        public static string GetUserNameByLogin(string login)
        {
            DataBaseEntities dataBase = new DataBaseEntities();

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
    }
}
