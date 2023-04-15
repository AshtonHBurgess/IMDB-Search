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
    // This class represents the Ratings page of the application.
    // The page displays a list of titles (movies and TV shows) sorted by rating, highest to lowest.
    // Each title is displayed with filled stars correlating to the score.
    public partial class RatingsPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource ratingsViewSource;

        public RatingsPage()
        {
            InitializeComponent();
            ratingsViewSource = (CollectionViewSource)FindResource(nameof(ratingsViewSource));
            //on page load, display top 500 movies and ratings
            Search();
        }

        // This method is called when the "Search" button is clicked.
        // It searches for titles containing the specified search term in their primary title.
        // It then loads the top 500 results into the ratings list view, sorted by rating.
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        public void Search() {
            string searchTerm = textSearch.Text;
            _context.Titles.Where(x => x.PrimaryTitle.Contains(searchTerm)).Take(500).Load(); //only take top 500 to avoid hogging RAM
            ratingsListView.DataContext = _context;

            // Perform LINQ query to select titles with non-null ratings and primary titles that contain the search term.
            // Sort the results by rating, highest to lowest.
            var query =
                from title in _context.Titles
                where title != null && title.Rating != null && title.PrimaryTitle != null && title.PrimaryTitle.Contains(searchTerm)
                orderby title.Rating.AverageRating descending // sort by highest ratings
                select title;

            ratingsViewSource.Source = query.ToList().Take(500); // take the top 500 results
            ratingsListView.Items.Refresh(); // refresh the view
        }
    }
}
