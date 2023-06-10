using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;
using EmployeeManager.Data_Acees;
using EmployeeManager.View_Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeController : ControllerBase

{
    private readonly EmployeeContext _Context;
 public EmployeeController(EmployeeContext context)
 {
   _Context =context;
 }
[HttpGet]
 public IEnumerable<EmployeeVM>Get()
 {
   var employees =_Context.Employees.Include(e =>e.job).ToList();
  return employees.Select(e => new EmployeeVM{
   Name =e.Name,
    DateOfBirth =  e.DateOfBirth.ToDateTime(new TimeOnly()),
          jobId = e.job.Id

  });   // var result =new List<EmployeeVM>();
   // var employees=_Context.Employees.ToList();
   // foreach(var employee in employees)
   // {
   //    result.Add(new EmployeeVM{
   //       Name =employee.Name,
   //       DateOfBirth =employee.DateOfBirth
   //    });
   // }
   // return result;
 }
    [HttpPost]
    public ActionResult<int>Create(EmployeeVM vm)
    { 
      try
      {
      var newEmployee= new Employee{
         Name=vm.Name,
         DateOfBirth =DateOnly.FromDateTime(vm.DateOfBirth),
         job =_Context.Jobs.Find(vm.jobId)
      };
        _Context.Employees.Add(newEmployee);
        _Context.SaveChanges();
        return Ok(newEmployee.Id); 
      }
      catch(Exception){
         return BadRequest("Couldn't create employee! please contact the administrator");
      }
    }
}
