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
        string selectedgenre;
        public GenresPage()
        {
            InitializeComponent();
            _context.Genres.Load();
            _context.Titles.Load();
            _context.TitleAliases.Load();
            var genrequery =
                from genre in _context.Genres
                orderby genre.Name
                select genre;

            foreach (var genre in genrequery)
            {
                GenreList.Items.Add(genre.Name);
            }
            GenreList.SelectedIndex = 0;
            selectedgenre = "";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = textsearch.Text;
            
            var query =
                from title in _context.Titles
                where title.TitleAliases.Any(ta => ta.Title.Contains(searchTerm)) && title.Genres.Any(g => g.Name.Contains(selectedgenre ?? string.Empty))
                orderby title.PrimaryTitle
                select title;

            listTitlesSearchResults.Items.Clear();
            foreach (var title in query.Take(500))
            {
                listTitlesSearchResults.Items.Add(title);
            }
        }

        private void GenreList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreList.SelectedItem == "All")
            {
                selectedgenre = "";
            }
            else
            {
                selectedgenre = GenreList.SelectedItem as string;
            }
        }
    }
}
