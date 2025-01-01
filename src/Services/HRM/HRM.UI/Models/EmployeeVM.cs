using System.ComponentModel.DataAnnotations;

namespace HRM.UI.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int? OrganizationId { get; set; }

        public int? ParentOrganizationId { get; set; }

        public string? OrganizationName { get; set; }
    }
}
