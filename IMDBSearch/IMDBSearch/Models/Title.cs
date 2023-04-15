using IMDBSearch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBSearch.Models
{
    public partial class Title
    {
        //ImdbProjectContext _context = new ImdbProjectContext();
        //public List<Title> getTitles
        //{
        //    get
        //    {
        //        return _context.Titles.Where(o => o. == AlbumId)
        //    }
        //}

        public string TitleDetails {
            get
            {
                string a = "";
                if (StartYear != null)
                {
                    a += string.Format(" Release Year: {0}", StartYear);
                }
                if (RuntimeMinutes != null)
                {
                    a += string.Format(" Runtime (Minutes): {0}", RuntimeMinutes);
                }
                return a;
            }
        }
    }
}
