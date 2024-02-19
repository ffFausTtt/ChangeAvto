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

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для ChangeAvto.xaml
    /// </summary>
    public partial class ChangeAvto : Page
    {
        public User listuser;
        public static int ID;
        public ChangeAvto(int id)
        {
            InitializeComponent();
            listuser = Base.dataBase.User.FirstOrDefault(x => x.ID_User == id);
            TBLogin.Text = listuser.Login;
            ID = id;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            listuser.Login = TBLogin.Text;
            listuser.Password = PBPassword.Password.GetHashCode().ToString();
           Base.dataBase.SaveChanges();
            MessageBox.Show("Изменения сохранены успешно!");
            NavigationService.Navigate(new PageMenuUser(ID));
        }
    }
}
