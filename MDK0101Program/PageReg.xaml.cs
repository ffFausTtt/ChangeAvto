using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace MDK0101Program
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
            CB_Pol.ItemsSource = Base.dataBase.Gender.ToList();
            CB_Pol.SelectedValue = "ID_Gender";
            CB_Pol.DisplayMemberPath = "Title";

            CB_Role.ItemsSource = Base.dataBase.Role.ToList();
            CB_Role.SelectedValue = "ID_Role";
            CB_Role.DisplayMemberPath = "Title";
            CB_Role.SelectedIndex = 1;
        }

        private void Reg_Btn(object sender, RoutedEventArgs e)
        {
            string surname = TB_Surname.Text.Trim();
            string name = TB_Name.Text.Trim();
            string otch = TB_Otch.Text.Trim();
            string login = TB_Login.Text.Trim();
            string password = PB_Password.Password.Trim();
            string pol = CB_Pol.Text.Trim();
            var DateBirthday = Convert.ToDateTime(DP_Date.SelectedDate);
            string role = CB_Role.Text.Trim();

            Regex pass1 = new Regex("[A-Z]");
            Regex pass2 = new Regex("[a-z]");
            Regex pass3 = new Regex("[0-9]");
            Regex pass4 = new Regex(@"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]");
            Regex pass5 = new Regex(".");

            if (pass1.IsMatch(PB_Password.Password) == false)
            {
                PB_Password.ToolTip = "Это поле введено не корректно";
                PB_Password.Background = Brushes.LightCoral;
                MessageBox.Show("Пароль должен содержать хотя бы 1 заглавную латискую букву");
            }
            else if (pass2.Matches(PB_Password.Password).Count < 3)
            {
                PB_Password.ToolTip = "Это поле введено не корректно";
                PB_Password.Background = Brushes.LightCoral;
                MessageBox.Show("Пароль должен содержать не менее 3 прописных латинских символов");
            }
            else if (pass3.Matches(PB_Password.Password).Count < 2)
            {
                PB_Password.ToolTip = "Это поле введено не корректно";
                PB_Password.Background = Brushes.LightCoral;
                MessageBox.Show("Пароль должен содержать минимум 2 цифры");
            }
            else if (pass4.IsMatch(PB_Password.Password) == false)
            {
                PB_Password.ToolTip = "Это поле введено не корректно";
                PB_Password.Background = Brushes.LightCoral;
                MessageBox.Show("Пароль должен содержать хотя бы 1 спецсимвол");
            }
            else if (pass5.Matches(PB_Password.Password).Count < 8)
            {
                PB_Password.ToolTip = "Это поле введено не корректно";
                PB_Password.Background = Brushes.LightCoral;
                MessageBox.Show("Пароль должен содержать не менее 8 символов");
            }
            User user = Base.dataBase.User.FirstOrDefault(x => x.Login == TB_Login.Text);
            if (user != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует.");

                TB_Login.ToolTip = "Это поле введено не корректно";
                TB_Login.Background = Brushes.LightCoral;
            }
            else if (true)
            {
                try
                {
                    PB_Password.ToolTip = "";
                    PB_Password.Background = Brushes.Transparent;
                    TB_Login.ToolTip = "";
                    TB_Login.Background = Brushes.Transparent;
                    User newUser = new User()
                    {
                        SurName = TB_Surname.Text,
                        Name = TB_Name.Text,
                        Patronymic = TB_Otch.Text,
                        Login = TB_Login.Text,
                        Password = PB_Password.Password.GetHashCode().ToString(),
                        ID_Gender = CB_Pol.SelectedIndex + 1,
                        Date_Of_Birth = Convert.ToDateTime(DP_Date.Text),
                        ID_Role = CB_Role.SelectedIndex + 1,
                    };
                    Base.dataBase.User.Add(newUser);
                    Base.dataBase.SaveChanges();
                    MessageBox.Show("Вы зарегистрировались!");

                    NavigationService.Navigate(new PageAvt());

                }
                catch
                {
                    MessageBox.Show("Проверьте заполнение всех полей!");
                }
            }
        }
        private void OnGlav_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageGlav());
        }

    }
}

