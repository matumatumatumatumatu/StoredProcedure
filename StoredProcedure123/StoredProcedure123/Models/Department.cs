using System.ComponentModel.DataAnnotations;

namespace StoredProcedure123.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentLocation {  get; set; }
        public int EmployeeCount { get; set; }
        public int WeeklySalary { get; set; }
    }
}
