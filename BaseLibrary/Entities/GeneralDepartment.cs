namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        // Relationship: One to Many
        public List<Department>? Departments { get; set; }
    }
}
