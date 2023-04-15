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
    public partial class GenresPage : Page
    {
        ImdbProjectContext _context = new ImdbProjectContext(); // creates an instance of the database context
        string selectedgenre; // stores the currently selected genre
        public GenresPage()
        {
            InitializeComponent();
            // Loads all the genres, titles, and aliases from the database
            _context.Genres.Load();
            _context.Titles.Load();
            _context.TitleAliases.Load();

            var genrequery =
                from genre in _context.Genres
                orderby genre.Name
                select genre;

            foreach (var genre in genrequery)
            {
                GenreList.Items.Add(genre.Name); // adds each genre to the genre list
            }
            GenreList.SelectedIndex = 0; // selects the first item in the genre list by default
        }
        private void Search()
        {
            string searchTerm = textsearch.Text; // gets the search term entered by the user

            var query =
                from title in _context.Titles
                where (title.TitleAliases.Any(ta => ta.Title.Contains(searchTerm)) || title.PrimaryTitle.Contains(searchTerm)) && title.Genres.Any(g => g.Name.Contains(selectedgenre ?? string.Empty)) // performs a LINQ query to find all titles that match the search term and the selected genre
                orderby title.PrimaryTitle // sorts the titles alphabetically by primary title
                select title;

            listTitlesSearchResults.Items.Clear(); // clears the list of titles in the search results
            foreach (var title in query.Take(500)) // adds 500 titles to the list of search results
            {
                listTitlesSearchResults.Items.Add(title);
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void GenreList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set selectedgenre to an empty string if selected item is "All" otherwise set to selected genre as a string
            selectedgenre = (GenreList.SelectedItem == "All") ? "" : (GenreList.SelectedItem as string);
            Search(); // Refresh search once the genre changes
        }
    }
}
