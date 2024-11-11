using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        // Relationship: Many to One
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        // Relationship: One to Many
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
