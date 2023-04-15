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

namespace IMDBSearch
{
    public partial class MainWindow : Window
    {
        private Page homePage;
        private Page episodepage;
        private Page genrePage;
        private Page ratingPage;

        public MainWindow()
        {
            InitializeComponent();
            homePage = new Pages.HomePage();
            episodepage = new Pages.EpisodesPage();
            genrePage = new Pages.GenresPage();
            ratingPage = new Pages.RatingsPage();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(homePage);
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(homePage);
        }

        private void EpisodeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(episodepage);
        }

        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(genrePage);
        }

        private void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(ratingPage);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
