namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        // Relationship: Many to One
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        // Relationship: One to Many
        public List<Branch>? Branches { get; set; }
    }
}
