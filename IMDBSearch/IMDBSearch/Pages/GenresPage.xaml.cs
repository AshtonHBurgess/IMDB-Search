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

        public GenresPage()
        {
            InitializeComponent();
            _context.Genres.Load();
            _context.Titles.Load();
            _context.TitleAliases.Load();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = textsearch.Text;

            var query =
                from genre in _context.Genres
                where genre.Titles.Any( title => title.TitleAliases.Any(ta => ta.Title.Contains(searchTerm)))
                select genre;

            listTitlesSearchResults.Items.Clear();
            foreach (var genre in query)
            {
                listTitlesSearchResults.Items.Add(genre);
            }
        }
    }
}
