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

namespace FilmManangemenSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Hyper_film_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FilmWindow filmWindow = new FilmWindow();
            filmWindow.Show();
        }

        private void Hyper_actor_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ActorWindow actorWindow = new ActorWindow();
            actorWindow.Show();
        }

        private void Hyper_language_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LanguageWindow languageWindow = new LanguageWindow();
            languageWindow.Show();

        }

        private void Hyper_category_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CategoryWindow categoryWindow = new CategoryWindow();
            categoryWindow.Show();
        }
        private void btn_LogoutClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }
    }
}
