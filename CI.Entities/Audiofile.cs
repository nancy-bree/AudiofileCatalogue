using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CI.Entities
{
    public class Audiofile
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(256, MinimumLength = 1)]
        [DisplayName("Название")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Автор/Исполнитель")]
        public int AuthorID { get; set; }

        [Required]
        [DisplayName("Жанр")]
        public int GenreID { get; set; }

        [DisplayName("Год")]
        public int? Year { get; set; }

        [DisplayName("Описание")]
        [StringLength(256)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберите файл")]
        [StringLength(255)]
        [DisplayName("Файл")]
        public string Filename { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}