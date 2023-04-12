using IMDBSearch.Data;
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
    /// Interaction logic for ActorsPage.xaml
    /// </summary>
    public partial class ActorsPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        //data context
        private CollectionViewSource actorViewSource;

        public ActorsPage()
        {
            InitializeComponent();
            actorViewSource = (CollectionViewSource)FindResource(nameof(actorViewSource));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Names.Where(actor => actor.PrimaryName.Contains(textSearch.Text)).ToList();

            listActorSearchResults.ItemsSource = query;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
