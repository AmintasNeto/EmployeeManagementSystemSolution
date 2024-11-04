
namespace BaseLibrary.Entities
{
    public class OvertimeType : BaseEntity
    {
        // Relationship: Many to One
        public List<Overtime>? Overtimes { get; set; }
    }
}
