using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the Pokemon Name.")]
        public string Name { get; set; }
        public DateTime BirthDate{ get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }

        //public ICollection<ImageUpload> DisplayPhotos { get; set; }
    }
 }