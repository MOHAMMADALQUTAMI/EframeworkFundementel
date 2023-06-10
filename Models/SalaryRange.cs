namespace EmployeeManager.Models
{
    public class SalaryRange
    {
        public int Id { get; set; }

        public double MinSalary { get; set; }

        public double MaxSalary { get; set; }
         public List<Job> Jobs { get; set; }
    }
}