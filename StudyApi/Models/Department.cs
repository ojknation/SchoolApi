using System.Collections.Generic;

namespace StudyApi.Models
{
    public class Department
    {

        public Department() {
            Courses = new HashSet<Course>();
        }
        public int DepartmentID { get; set; }
        public int SchoolID { get; set; }
        public string DepartmentName { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }
        
    }
}