namespace HRM.UI.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public int? OrganizationId { get; set; }

        public int? ParentOrganizationId { get; set; }

        public string? OrganizationName { get; set; }
    }
}
