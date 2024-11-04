
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Pubishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        // Relationship: Many to One
        public SanctionType? SanctionType { get; set; }
    }
}
