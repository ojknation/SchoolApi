using System;
namespace StudyApi.ClientModels
{
    public class UserCourses
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime AddedOn { get; set; }
    }
}