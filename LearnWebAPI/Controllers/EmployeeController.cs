using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody]Employee employee)
        {
            // Create Employee in DB
            return Ok();
        }

        /// <summary>
        /// Manual Data Annontation Validtion example, It can use in console app or other place
        /// </summary>
        /// <returns></returns>
    public bool CreateEmployee()
    {
        var emp = new Employee()
        {
            Email = "test@example.com"
        };

        var validationContext = new ValidationContext(emp);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(emp, validationContext, validationResults, true);

        if (!isValid)
        {
            foreach (var result in validationResults)
            {
                Console.WriteLine(result.ErrorMessage);
            }
            return false;
        }
         // Create Employee in DB
        return true;
        }       
    }

    public class Employee
    {
        [Required]
        [EmailAddress]
        [DomainValidation("microsoft.com")]
        public string Email { get; set; }
    }
}
