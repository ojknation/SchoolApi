using System.Collections.Generic;

namespace StudyApi.Models
{
    public class School
    {
         public School() {
            Departments = new HashSet<Department>();
        }
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}