using MaterialDesignThemes.Wpf.Converters;
using Microsoft.Win32;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для PageRed.xaml
    /// </summary>
    public partial class PageRed : Page
    {
        Book vm = new Book();
        Books book;

        public PageRed(Books bookRed)
        {
            InitializeComponent();
            DataContext = bookRed;
            book = bookRed;
            CB.ItemsSource = Base.dataBase.Autor.ToList();
            CB.SelectedValue = "ID_Autor";
            CB.DisplayMemberPath = "Second_name";
            CB.SelectedIndex = (int)bookRed.ID_Autor;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = Price.Text.Replace(".", ",");
                book.Title_Book = Title_Book.Text;
                book.Year = Year.Text;
                book.ID_Autor = CB.SelectedIndex;
                book.Price = Convert.ToInt32(str);

                if (Convert.ToInt32(book.Year) > 1800 && Convert.ToInt32(book.Year) < 2025)
                {
                    Base.dataBase.SaveChanges();
                    vm.book = vm.newbook();
                }
                else
                {
                    throw new Exception("Минимальное количесво и стоимость не могут быть отрицательными");
                }

            }
            catch (Exception message)
            {
                MessageBox.Show("Ошибка данных" + message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Books delite = Base.dataBase.Books.FirstOrDefault(x => x.ID_Books == book.ID_Books);
                Base.dataBase.Books.Remove(delite);
                Base.dataBase.SaveChanges();
                Book vm = new Book();
                MessageBox.Show("Удалил");
            }
            catch
            {
                MessageBox.Show("Запись связана. Ее удаление не может быть выполнено");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if(window != null)
            {
                window.Close();
            }
        }
        }
}
