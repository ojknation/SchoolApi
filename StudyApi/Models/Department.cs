using System.Collections.Generic;

namespace StudyApi.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public int SchoolID { get; set; }
        public int DepartmentName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}