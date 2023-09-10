using LearnWebAPI.OptionModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly SmtpOptions _smtp;
        private readonly AppsettingGroupOptions _groupOptions;
        public EmployeeController(IConfiguration configuration,
            IOptions<SmtpOptions> smtpOptions,
            IOptions<AppsettingGroupOptions> groupOptions
             )
        {   // 1. Reading connection string
            string connectionString = configuration.GetConnectionString("SQLConnection");

            //2. Reading key;value pair using Key
            string myValue = configuration["MyKey"];

            //3. Reading Smtp object through IOptions 
            _smtp = smtpOptions.Value;

            //4. Reading AppsettingGroup which contains the Region Arrays through Ioption
            _groupOptions = groupOptions.Value;

            //5. Reading AppsettingGroup using GetSection and GetChildren
            IConfigurationSection regionSection = configuration
                                           .GetSection("AppsettingGroup:Regions");
            var regionArray = regionSection.GetChildren();
            var regionsValues = regionArray?.Select(configSection =>
            {
                return new Region()
                {
                    Id= int.Parse(configSection["Id"]),
                    Code = configSection["Code"],
                    DisplayName = configSection["DisplayName"]

                };
            });
        
        }


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
    private bool CreateEmployee()
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
