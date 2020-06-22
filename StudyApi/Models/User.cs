using System.Collections.Generic;

namespace StudyApi.Models
{
    public class User
    {
        public User() {
            Courses = new HashSet<Course>();
        }
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        

        
    }
}