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
    /// Логика взаимодействия для PageMenuUser.xaml
    /// </summary>
    public partial class PageMenuUser : Page
    {
        public static int id = 0;
        public User listuser;
        public PageMenuUser(int ID)
        {
            InitializeComponent();
            List<Gender> gen = Base.dataBase.Gender.ToList();
            id = ID;
            listuser = Base.dataBase.User.FirstOrDefault(x => x.ID_User == id);
            Name.Text = listuser.Name;
            Surname.Text = listuser.SurName;
            Otch.Text = listuser.Patronymic;
            DR.Text = listuser.Date_Of_Birth.ToString();
            foreach (Gender gender in gen)
            {
                Pol.Items.Add(gender.Title);
            }
            foreach (Gender gender in gen)
            {
                if (listuser.ID_Gender == gender.ID_Gender)
                {
                    Pol.SelectedIndex = gender.ID_Gender - 1;
                }
            }
        }
        private void OnGlav_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAvt());
        }

        private void avto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeAvto(id));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            listuser.Name = Name.Text;
            listuser.SurName = Surname.Text;
            listuser.Patronymic = Otch.Text;
            listuser.Date_Of_Birth = Convert.ToDateTime(DR.Text);
            listuser.ID_Gender = Pol.SelectedIndex + 1;
            Base.dataBase.SaveChanges();
            MessageBox.Show("Изменения сохранены успешно!");
        }

    }
}


