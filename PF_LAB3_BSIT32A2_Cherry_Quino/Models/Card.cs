using System.ComponentModel.DataAnnotations;

namespace PF_LAB3_BSIT32A2_Cherry_Quino.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Rarity { get; set; }  // Example: Common, Rare, Ultra Rare

        [Display(Name = "Character Image URL")]
        public string CharacterImageUrl { get; set; }

        public string Description { get; set; }
    }
}
