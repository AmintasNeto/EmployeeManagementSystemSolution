using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        // Relationship: One to Many
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        // Relationship: One to Many
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
