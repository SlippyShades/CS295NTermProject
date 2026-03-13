using System.ComponentModel.DataAnnotations;
namespace MTG295NTermProject.Models
{
    public class WantedCardModel 
    {

        [Key]
        [Required(ErrorMessage = "Card Name must be between less than 100 characters.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Card Name must be between less than 100 characters.")]
        public string? CardName { get; set; }
    
    }
}
