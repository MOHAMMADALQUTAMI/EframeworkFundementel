namespace EmployeeManager.Models
{
    public class Job
    {
        public int Id {get;set;}
        public string Position {get;set;}
        public double Salary {get;set;}
        public int SalaryRangeId { get; set; }
        public SalaryRange SalaryRange {get;set;}
        public List<Employee> Employees { get; set; }
    }
}