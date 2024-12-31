namespace HRM.UI.Models
{
    public class OrganizationVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public bool? IsActive { get; set; }

        public string? Description { get; set; }

        public int? ParentId { get; set; }
    }
}
