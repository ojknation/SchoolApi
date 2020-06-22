using System.ComponentModel.DataAnnotations;
namespace StudyApi.ClientModels
{
    public class AuthModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}