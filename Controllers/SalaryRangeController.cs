using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;
using EmployeeManager.Data_Acees;
using EmployeeManager.View_Model;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.View_Model;
namespace EmployeeManager.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SalaryRangeController : ControllerBase

{
    private readonly EmployeeContext _Context;
 public SalaryRangeController(EmployeeContext context)
 {
   _Context =context;
 }
[HttpGet]
 public IEnumerable<SalaryRnageVm>Get()
 {
  var salaryRanges = _Context.SalaryRanges.ToList();
        return salaryRanges.Select(j => new SalaryRnageVm
        {
            MinSalary = j.MinSalary,
            MaxSalary =  j.MaxSalary,
        }).ToList();/////

  }   // var result =new List<EmployeeVM>();
   // var employees=_Context.Employees.ToList();
   // foreach(var employee in employees)
   // {
   //    result.Add(new EmployeeVM{
   //       Name =employee.Name,
   //       DateOfBirth =employee.DateOfBirth
   //    });
   // }
   // return result;

    [HttpPost]
    public ActionResult<int>Create(SalaryRnageVm vm)
    { 
       var newSalary = new SalaryRange
        {
            MinSalary = vm.MinSalary,
            MaxSalary =vm.MaxSalary,
            
        };

        _Context.SalaryRanges.Add(newSalary);

        _Context.SaveChanges();
        return Ok(newSalary.Id);
    }

}
