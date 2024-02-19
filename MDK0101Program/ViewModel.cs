using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MDK0101Program
{
    public partial class User
    {
        public string gender;
        public string Genders
        {
            get { return gender; }
            set { gender = value; }
        }

        public string role;
        public string Roles
        {
            get { return role; }
            set { role = value; }
        }
    }
    public class Users
    {
        public List<User> usr;
        public Users()
        {
            usr = newuser();
        }

        public List<User> newuser()
        {
            List<User> users = new List<User>();
            User buff;
            List<User> bdusers = Base.dataBase.User.ToList();

            foreach (User user in bdusers)
            {
                buff = new User();
                buff.ID_User = user.ID_User;
                buff.SurName = user.SurName;
                buff.Name = user.Name;
                buff.Patronymic = user.Patronymic;
                buff.Login = user.Login;
                buff.Password = user.Password;
                buff.ID_Gender = user.ID_Gender;
                buff.Date_Of_Birth = user.Date_Of_Birth;
                buff.ID_Role = user.ID_Role;
                buff.ID_Gender = user.ID_Gender;
                Gender gender = Base.dataBase.Gender.FirstOrDefault(x => x.ID_Gender == buff.ID_Gender);
                buff.gender = gender.Title;
                Role role = Base.dataBase.Role.FirstOrDefault(x => x.ID_Role == buff.ID_Role);
                buff.role = role.Title;
                users.Add(buff);
            }
            return users;
        }
    }
    public partial class Books
    {
        public string autor;
        public string Autors
        {
            get { return autor; }
            set { autor = value; }
        }

        public string genre;
        public string Genres
        {
            get { return genre.Remove(genre.Length - 2); }
            set { genre = value; }
        }
        public bool Sale { get => Convert.ToInt32(Year) == 2024; }
        public string PriceForSale
        {
            get
            {
                if (Sale)
                    return " " + Price * 0.2 ;
                else
                    return "";
            }
        }
        public bool Color { get => PriceForSale !=""; }
        public SolidColorBrush SaleColor 
        {
            get
            {
                if(Color)
                {
                    return Brushes.Pink;
                }
                else
                {
                    return Brushes.White;
                }
                
            }
        }
        public  string SaleText
        {
            get
            {
                if (Color)
                {
                    return "Visible";
                }
                else
                {
                    return "Hidden";
                }

            }
        }
    }

    public class Book
    {
        public List<Books> book;
        public Book()
        {
            book = newbook();
        }

        public List<Books> newbook()
        {
            List<Books> books = new List<Books>();
            Books buff;
            List<Books> bdbooks = Base.dataBase.Books.ToList();
            List<GenreBooks> bdgenrebook = Base.dataBase.GenreBooks.ToList();
            List<Genre> bdgenre = Base.dataBase.Genre.ToList();
            foreach (Books book in bdbooks)
            {
                buff = new Books();
                buff.ID_Books = book.ID_Books;
                buff.Title_Book = book.Title_Book;
                //int Skidka = book.Price * 0.1;
                //if (Convert.ToInt32(book.Year) <= 2023)
                //{
                //    (Convert.ToInt32(book.Price)) *= 0.1;
                //}
                //else
                //{
                buff.Year = book.Year;
                //} 

                buff.Price = book.Price;
                buff.ID_Autor = book.ID_Autor;
                Autor autor = Base.dataBase.Autor.FirstOrDefault(x => x.ID_Autor == buff.ID_Autor);
                string allgenre = "";

                foreach (GenreBooks genreBook in bdgenrebook)
                {
                    if (book.ID_Books == genreBook.ID_Books)
                    {
                        foreach (Genre genre in bdgenre)
                        {
                            if (genreBook.ID_Genre == genre.ID_Genre)
                            {
                                allgenre += genre.Title_Genre + ", ";
                                book.genre = allgenre;
                                break;
                            }
                        }
                    }
                }
                buff.genre = book.genre;
                buff.autor = autor.First_name + " " + autor.Second_name;
                books.Add(buff);

            }
            return books;
        }

    }
}
