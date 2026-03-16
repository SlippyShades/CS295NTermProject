using System.ComponentModel.DataAnnotations;
namespace MTG295NTermProject.Models
{
    public class CardModel 
    {
        [Key]
        public int CardModelId { get; set; }
        public double? PriceUSD { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Card Name must be between less than 100 characters.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Card Name must be between less than 100 characters.")]
        public string? CardName { get; set; }

        [Required(ErrorMessage = "Converted Mana Cost is required.")]
        public int? ManaCost { get; set; }
        [Required(ErrorMessage = "Card Type is required.")]
        public AllowedTypes.CardType CardType { get; set; }
        public string? CardType2 { get; set; }
        public string? CardType3 { get; set; }
        [Required(ErrorMessage = "Card Color is required.")]
        public AllowedColors.CardColor CardColor { get; set; }

        public string? CardColor2 { get; set; }
        public string? CardColor3 { get; set; }
        public string? CardColor4 { get; set; }
        public string? CardColor5 { get; set; }

        public string OracleText { get; set; }
        public string? Legendary { get; set; }
        public string? Kindred { get; set; }
        public string? CreatureType { get; set; }
        public string? CreatureType2 { get; set; }
        public string? CreatureType3 { get; set; }
        public string? CreatureType4 { get; set; }
        public string? Toughness { get; set; }
        public string? Power { get; set; }
        public int? Quantity { get; set; }





    }
}
