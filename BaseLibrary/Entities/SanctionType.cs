
namespace BaseLibrary.Entities
{
    public class SanctionType : BaseEntity
    {
        // Relationship: Many to One
        public List<Sanction>? Sanctions { get; set; }
    }
}
