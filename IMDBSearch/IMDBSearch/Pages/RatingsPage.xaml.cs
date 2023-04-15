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
using IMDBSearch.Data;
using Microsoft.EntityFrameworkCore;


namespace IMDBSearch.Pages
{
    /// <summary>
    /// Interaction logic for RatingsPage.xaml
    /// </summary>
    /// 

    //Sorted by Ratings, Highest to lowest. No nesting, just titles (movies and TV shows mixed up). Include filled stars and the rating in umbers
    public partial class RatingsPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource ratingsViewSource;

        public RatingsPage()
        {
            InitializeComponent();
            ratingsViewSource = (CollectionViewSource)FindResource(nameof(ratingsViewSource));
            _context.Titles.Load();
            ratingsListView.DataContext = _context;
            Search();
        }
        
         private void Search()
        {
            string searchTerm = textsearch.Text;
            _context.Titles.Load();
            ratingsListView.DataContext = _context;
            //ratingsViewSource.Source = _context.Titles.Local.ToObservableCollection();
            var query =
                from title in _context.Titles
                where title != null && title.Rating != null && title.PrimaryTitle != null && title.Rating.AverageRating != null && title.PrimaryTitle.Contains(searchTerm)
                orderby title.Rating.AverageRating descending
                select title;
            //query = query.Contains(searchTerm);
            ratingsViewSource.Source = query.Take(500).ToList();
            ratingsListView.Items.Refresh();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();

        }
    }
}
