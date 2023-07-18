using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
            
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the Pokemon Name.")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}