using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EmployeeManager.Models;
using EmployeeManager.Data_Acees;
using EmployeeManager.View_Model;
namespace EmployeesManager.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController : ControllerBase
{
    private readonly EmployeeContext _context;
    public JobController(EmployeeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<JobVM>> Get()
    {
        var jobs = _context.Jobs.Include(j =>j.SalaryRange).ToList();
        return jobs.Select(j => new JobVM
        {
            Position = j.Position,
            Salary =j.Salary,
                      SalaryRangeId = j.SalaryRange.Id

        }).ToList();
        
    }

    [HttpPost]
    public ActionResult<int> Create(JobVM vm)
    {
        var newJob = new Job
        {
            Position = vm.Position,
            Salary = vm.Salary,
            SalaryRangeId=vm.SalaryRangeId
        };

        _context.Jobs.Add(newJob);

        _context.SaveChanges();
        return Ok(newJob.Id);
    }
}