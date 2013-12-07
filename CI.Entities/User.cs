using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CI.Entities
{
    [Serializable]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Логин")]
        public string Username { get; set; }

        public virtual ICollection<Rating> Votes { get; set; }
    }
}