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
    /// Логика взаимодействия для PageMenuAdmin.xaml
    /// </summary>
    public partial class PageMenuAdmin : Page
    {
        Users users = new Users();
        public PageMenuAdmin()
        {
            InitializeComponent();
            All.ItemsSource = users.usr.ToList();
            CB_Pol.ItemsSource = Base.dataBase.Gender.ToList();
            CB_Pol.SelectedValue = "ID_Gender";
            CB_Pol.DisplayMemberPath = "Title";
            CB_Pol.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList().OrderBy(x=>x.SurName).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList().OrderBy(x => x.SurName).Reverse().ToList();
        }

        private void CB_Pol_Selected(object sender, RoutedEventArgs e)
        {
            if(CB_Pol.SelectedIndex == -1)
            {
                All.ItemsSource = users.usr.ToList();
            }
            else
            {
                 All.ItemsSource = users.usr.ToList().Where(x=>x.ID_Gender==(CB_Pol.SelectedIndex+1)).ToList();
            }
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Poisk.Text))
            {
                All.ItemsSource = users.usr.ToList().Where(x => (x.SurName.ToLower().Contains(Poisk.Text.ToLower()))||(x.Name.ToLower().Contains(Poisk.Text.ToLower()))).ToList();
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            All.ItemsSource = users.usr.ToList();
        }
        private void OnGlav_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenuAdminGlav());
        }
    }
}
