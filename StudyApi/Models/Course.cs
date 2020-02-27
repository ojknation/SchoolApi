namespace StudyApi.Models
{
    public enum Semester 
    {
        First, Second
    }
   
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }
        public int Level { get; set; }
        public Semester Semester { get; set; }

    }
}