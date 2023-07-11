using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonReviewApp.Models
{
    public class ImageUpload
    {
        public int Id{ get; set; }

        [NotMapped]
        public IFormFile imageFile { get; set; }

        //public Pokemon Pokemon { get; set; }
    }
}
