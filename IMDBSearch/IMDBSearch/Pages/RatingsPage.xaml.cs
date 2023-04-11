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
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Titles.Load();
            ratingsListView.DataContext = _context;
            //ratingsViewSource.Source = _context.Titles.Local.ToObservableCollection();
            var query = 
                from title in _context.Titles
                where title != null && title.Rating != null
                select title;
            ratingsViewSource.Source = query.ToList();
            ratingsListView.Items.Refresh();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = textSearch.Text;

        }
    }
}
