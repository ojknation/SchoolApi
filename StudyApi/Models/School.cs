using System.Collections.Generic;

namespace StudyApi.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}