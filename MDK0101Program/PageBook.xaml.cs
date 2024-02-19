using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для PageBook.xaml
    /// </summary>
    public partial class PageBook : Page
    {
        Book book = new Book();
        List<Books> filter;
        public PageBook()
        {
            InitializeComponent();
            LVBook.ItemsSource = book.book.ToList();
            CB2.ItemsSource = Base.dataBase.Autor.ToList(); 
            CB2.SelectedValuePath = "ID_Autor";
            CB2.DisplayMemberPath = "First_name";
            CB2.SelectedIndex = 4;

        }

        private void BackBtn_AMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenuAdminGlav());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button sp = (Button)sender;
            int id = Convert.ToInt32(sp.Uid);
            Books bookRed = Base.dataBase.Books.FirstOrDefault(x => x.ID_Books == id);
            new WinRedDob(bookRed).ShowDialog();

        }
        private void Filter(object sender, RoutedEventArgs e)
        {
            filter = book.book.ToList();

            if (CB2.SelectedIndex == 4)
            {
                filter = filter;
            }
            else
            {
                filter = filter.Where(x => x.ID_Autor == CB2.SelectedIndex +1).ToList();
            }

            switch (CB.SelectedIndex)
            {
                case 0:
                    filter = filter.OrderBy(x => x.Title_Book).ToList();
                    break;
                case 1:
                    filter = filter.OrderBy(x => x.Title_Book).ToList();
                    filter.Reverse();
                    break;
            }

            if (TB.Text != "")
            {
                filter = filter.Where(x => x.Title_Book.Contains(TB.Text)).ToList();
            }
            LVBook.ItemsSource = filter;
        }

    }
}
