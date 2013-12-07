using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CI.Entities
{
    [Serializable]
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        [DisplayName("Автор/Исполнитель")]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [DisplayName("Изображение")]
        public string Image { get; set; }

        public virtual ICollection<Audiofile> Files { get; set; }
    }
}