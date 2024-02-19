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
using System.Windows.Shapes;

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для WinRedDob.xaml
    /// </summary>
    public partial class WinRedDob : Window
    {
        public WinRedDob(Books bookRed)
        {
            InitializeComponent();
            if(bookRed == null )
            {
                Frame.Navigate(new PageDob()); 
                FrameClass.frameMain = new Frame();
            }
            else
            {
                Frame.Navigate(new PageRed(bookRed));
                FrameClass.frameMain = new Frame();
            }
        }
    }
}
