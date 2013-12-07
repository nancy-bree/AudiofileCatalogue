using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CI.Entities
{
    [Serializable]
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Жанр")]
        public string Name { get; set; }

        public virtual ICollection<Audiofile> Files { get; set; }
    }
}