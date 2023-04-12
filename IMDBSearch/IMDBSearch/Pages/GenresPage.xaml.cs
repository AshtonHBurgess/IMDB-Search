using IMDBSearch.Data;
using IMDBSearch.Models;
using Microsoft.EntityFrameworkCore;
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

namespace IMDBSearch.Pages
{
    /// <summary>
    /// Interaction logic for GenresPage.xaml
    /// </summary>
    public partial class GenresPage : Page
    {
        ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource genresViewSource;

        public GenresPage()
        {
            InitializeComponent();
            _context.Genres.Load();
            _context.Titles.Load();
            _context.TitleAliases.Load();
            genresViewSource = (CollectionViewSource)FindResource(nameof(genresViewSource));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = textsearch.Text;
            listTitlesSearchResults.DataContext = _context;
            _context.Titles.Load();
            var query =
                from genre in _context.Genres
                //where genre.Titles.Any(title => title.TitleAliases.Any(ta => ta.Title.Contains(searchTerm)))
                select genre;
            
            foreach ( var item in query )
            {
                foreach (var title in item.Titles )
                {
                    Console.WriteLine( title );
                }
            }

            genresViewSource.Source = query.ToList();
        }
    }
}
