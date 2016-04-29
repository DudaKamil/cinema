using System.ComponentModel.DataAnnotations;

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

//            MemoryStream ms = new MemoryStream();
//        {
//        public byte[] imageToByteArray(System.Drawing.Image imageIn)
//

//        public byte[] Poster { get; set; }
//            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
//            return ms.ToArray();
//        }
//
//        public Image byteArrayToImage(byte[] byteArrayIn)
//        {
//            MemoryStream ms = new MemoryStream(byteArrayIn);
//            Image returnImage = Image.FromStream(ms);
//            return returnImage;
//        }
    }
}