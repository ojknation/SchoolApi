using System.ComponentModel.DataAnnotations;

namespace StudyApi.ClientModels
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Password { get; set; }
    }
}