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
    /// Логика взаимодействия для PageMenuAdminGlav.xaml
    /// </summary>
    public partial class PageMenuAdminGlav : Page
    {
        User user;
        public PageMenuAdminGlav()
        {
            InitializeComponent();
        }
        private void BtnInf_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenuAdmin());
        }
        private void OnGlav_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAvt());
        }

        private void Btn_Book(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBook());
        }
    }
}
