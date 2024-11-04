
namespace BaseLibrary.Entities
{
    public class VacationType : BaseEntity
    {
        // Relationship: Many to One
        public List<Vacation>? Vacations { get; set; }
    }
}
