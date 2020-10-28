using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.DTO
{
    public class UserForRegisterDto
    {
        [Required]
        public string  Username { get; set; }

        [StringLength(8,MinimumLength =3,ErrorMessage ="not valid")]
        public string Password { get; set; }
    }
}