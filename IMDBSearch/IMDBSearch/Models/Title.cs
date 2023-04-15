using IMDBSearch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.Resources;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.IO;

namespace IMDBSearch.Models
{
    public partial class Title
    {
        //return image of stars?
        ImdbProjectContext _context = new ImdbProjectContext();

        //from: https://stackoverflow.com/questions/37890121/fast-conversion-of-bitmap-to-imagesource
        private BitmapImage ConvertBitmap(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }
        public BitmapImage getRating
        {
            
            get
            {
                // load an image of 10 stars to a bitmap, then crop it depending on the rating, before converting it to a BitmapImage that can be displayed

                // string fullPath = "C:\\Users\\asbur\\Source\\Repos\\IMDB-Search\\IMDBSearch\\IMDBSearch\\bin\\Debug\\net7.0-windows\\Images\\stars.png"

               
                Bitmap stars = new Bitmap("../../../Images/stars.png");
                decimal rating = (decimal)_context.Ratings.Where(o => o.TitleId == TitleId).Select(t => t.AverageRating).FirstOrDefault();
                Bitmap croppedStars = stars.Clone(new Rectangle(0, 0, (Decimal.ToInt32((stars.Width/10)*rating)), stars.Height), stars.PixelFormat);
                return ConvertBitmap(croppedStars);
            }
        }

    }
}
