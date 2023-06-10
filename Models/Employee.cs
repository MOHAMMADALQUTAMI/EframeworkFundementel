namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public DateOnly DateOfBirth {get;set;}
        public int jobId { get; set; }
        public Job job {get;set;}
       
        // public Job Job {get;set;} 
    }
}