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

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для PageAvt.xaml
    /// </summary>
    public partial class PageAvt : Page
    {
        public PageAvt()
        {
            InitializeComponent();
        }
        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string hashedPassword = PB_Password.Password.GetHashCode().ToString();
            User user = Base.dataBase.User.FirstOrDefault(x => x.Login == TB_Login.Text && x.Password == hashedPassword);
            if (user != null)
            {
                if (user.ID_Role == 1)
                {
                    NavigationService.Navigate(new PageMenuAdminGlav());
                }
                if (user.ID_Role == 2)
                {
                    NavigationService.Navigate(new PageMenuUser(user.ID_User));
                }
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует! Попробуйте снова или зарегистрируйтесь.");
            }
        }
        private void OnGlav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageGlav());
        }
    }
}
