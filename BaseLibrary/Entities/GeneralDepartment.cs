using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        // Relationship: One to Many
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}
