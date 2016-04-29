using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public byte[] Poster { get; set; }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}