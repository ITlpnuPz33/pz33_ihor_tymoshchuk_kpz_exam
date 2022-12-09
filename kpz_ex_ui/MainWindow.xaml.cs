using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace kpz_ex_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

     
        public static readonly String path = "https://localhost:7107/api/Book";

        public MainWindow()
        {
            InitializeComponent();
         
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            GetAllBooks();
        }

        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBook();
        }

        void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
           ReturnBook();
        }

        void BorrowButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowBook();
        }

        private async void GetAllBooks()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();
                    IList<BookDTO> ls = await response.Content.ReadAsAsync<IList<BookDTO>>();
                    dataGridBooks.ItemsSource = ls;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private async void AddBook()
        {
            using (HttpClient client = new HttpClient())
            {

                var book = new BookDTO()
                {
                    Book_Name = BookNameTxt.Text,
                    Book_Author = AuthorNameTxt.Text,
                    Book_Quantity = Convert.ToInt32(QuantityTxt.Text)
                };
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync($"{path}", book);
                    response.EnsureSuccessStatusCode();
                    

                    GetAllBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void ReturnBook()
        {
            using (HttpClient client = new HttpClient())
            {
                var book = new BookDTO()
                {
                    Book_Name = "test",
                    Book_Author = "test",
                    Book_Quantity = 1
                };

                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{path}/ReturnBook/{Convert.ToInt32(Book_Id.Text)}", book);


                    GetAllBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void BorrowBook()
        {
            using (HttpClient client = new HttpClient())
            {
                var book = new BookDTO()
                {
                    Book_Name = "test",
                    Book_Author = "test",
                    Book_Quantity = 1
                };

                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{path}/BorrowBook/{Convert.ToInt32(Book_Id.Text)}", book);


                    GetAllBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

