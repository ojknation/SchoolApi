using System.Collections.Generic;

namespace StudyApi.Models
{
    public class University
    {
        public University(){
            Users = new HashSet<User>();
        }
        public int UniID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public int MyProperty { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}