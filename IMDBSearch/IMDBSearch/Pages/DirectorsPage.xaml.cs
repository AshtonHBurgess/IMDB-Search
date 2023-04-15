using IMDBSearch.Data;
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
    /// Interaction logic for DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {


        ImdbProjectContext _context = new ImdbProjectContext();
        string selected_director;
        public DirectorsPage()
        {

            InitializeComponent();

            //_context.Titles.Load();
            //_context.Names.Load();

        }

        //private void Search()
        //{
        //    var directorquery =
        //      from name in _context.Names
        //      where name.PrimaryProfession.Contains("director") && name.PrimaryName.Contains(textsearch.Text)
        //      orderby name.PrimaryName
        //      select name;

        //    DirectorList.Items.Clear();
        //    foreach (var name in directorquery.Take(20))
        //    {
        //        DirectorList.Items.Add(name.PrimaryName);
        //    }
        //    DirectorList.SelectedIndex = 0;
        //}
        //private void SearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Search();
        //}
        //private void GenreList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var query =
        //        from title in _context.Titles
        //        where title.Names.Any(g => g.PrimaryName.Contains(selected_director ?? string.Empty)) || title.Names1.Any(g => g.PrimaryName.Contains(selected_director ?? string.Empty))
        //        orderby title.PrimaryTitle
        //        select title;

        //    listTitlesSearchResults.Items.Clear();
        //    foreach (var title in query.Take(500))
        //    {
        //        listTitlesSearchResults.Items.Add(title);
        //    }
        //}
    }
}

