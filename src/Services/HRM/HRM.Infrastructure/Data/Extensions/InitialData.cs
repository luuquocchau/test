using HRM.Domain.Employees;
using HRM.Domain.Organizations;

namespace HRM.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static List<Organization> Organizations() => new List<Organization>()
        {
            Organization.Create("Tổng công ty", "Hà Nội", true, "", null).Value,
            Organization.Create("Công ty thành viên 1", ".", true, "", 1).Value,
            Organization.Create("Công ty thành viên 1.1", ".", true, "", 2).Value,
            Organization.Create("Công ty thành viên 1.2", ".", true, "", 2).Value,
            Organization.Create("Công ty thành viên 2", ".", true, "", 1).Value,
            Organization.Create("Công ty thành viên 2.1", ".", true, "", 5).Value,
            Organization.Create("Công ty thành viên 2.2", ".", true, "", 5).Value,
        };

        public static List<Employee> Employees() => new List<Employee>()
        {
            Employee.Create("Employee 1", DateTime.Now, "Nhân viên", "", 1).Value,
            Employee.Create("Employee 2", DateTime.Now, "Nhân viên", "", 2).Value,
            Employee.Create("Employee 3", DateTime.Now, "Nhân viên", "", 2).Value,
            Employee.Create("Employee 4", DateTime.Now, "Nhân viên", "", 3).Value,
            Employee.Create("Employee 5", DateTime.Now, "Nhân viên", "", 3).Value,
            Employee.Create("Employee 6", DateTime.Now, "Nhân viên", "", 3).Value,
            Employee.Create("Employee 7", DateTime.Now, "Nhân viên", "", 3).Value
        };
    }
}