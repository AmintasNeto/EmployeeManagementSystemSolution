using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping2
    {
        [Required]
        public string JobName { get; set; } = string.Empty;
        [Required, Range(0, int.MaxValue, ErrorMessage = "You must select a branch")]
        public int BranchId { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "You must select a town")]
        public int TownId { get; set; }
        [Required]
        public string Other { get; set; } = string.Empty;
    }
}
