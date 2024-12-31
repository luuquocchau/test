using HRM.Domain.Employees;
using HRM.Domain.Organizations;

namespace HRM.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static List<Organization> Organizations() => new List<Organization>()
        {
            Organization.Create("Tổng công ty", "Hà Nội", true, "", null),
            Organization.Create("Công ty thành viên 1", ".", true, "", 1),
            Organization.Create("Công ty thành viên 1.1", ".", true, "", 2),
            Organization.Create("Công ty thành viên 1.2", ".", true, "", 2),
            Organization.Create("Công ty thành viên 2", ".", true, "", 1),
            Organization.Create("Công ty thành viên 2.1", ".", true, "", 5),
            Organization.Create("Công ty thành viên 2.2", ".", true, "", 5),
        };

        public static List<Employee> Employees() => new List<Employee>()
        {
            Employee.Create("Employee 1", DateTime.Now, "Nhân viên", "", 1),
            Employee.Create("Employee 2", DateTime.Now, "Nhân viên", "", 2),
            Employee.Create("Employee 3", DateTime.Now, "Nhân viên", "", 2),
            Employee.Create("Employee 4", DateTime.Now, "Nhân viên", "", 3),
            Employee.Create("Employee 5", DateTime.Now, "Nhân viên", "", 3),
            Employee.Create("Employee 6", DateTime.Now, "Nhân viên", "", 3),
            Employee.Create("Employee 7", DateTime.Now, "Nhân viên", "", 3)
        };
    }
}