using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CI.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Логин")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}