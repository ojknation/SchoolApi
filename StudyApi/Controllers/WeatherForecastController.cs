using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudyApi.Data;
using StudyApi.Models;

namespace StudyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DataContext _context;

        public WeatherForecastController(DataContext dataContext) 
        {
             _context = dataContext;
        }

        [HttpGet]
        public IEnumerable<School> Get()
        {
            School school = new School();
            school.SchoolName = "SCOM";

            // Department dept = new Department();
            // dept.DepartmentName = "IFT";
            // dept.SchoolID = school.SchoolID;

            // _context.Departments.Add(dept);
            // _context.SaveChanges();
            


            _context.Schools.Add(school);
            _context.SaveChanges();

            return _context.Schools.ToList(); 
        }
    }
}
