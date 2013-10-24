using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CI.Services;
using System.Web.Configuration;

namespace CI.ViewModels
{
    public class AudiofileUploadViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Название")]
        public String Name { get; set; }

        [Required]
        [DisplayName("Автор/Исполнитель")]
        public int AuthorID { get; set; }

        [Required]
        [DisplayName("Жанр")]
        public int GenreID { get; set; }

        [RegularExpression(@"^\d{4}$")]
        [DisplayName("Год")]
        public int? Year { get; set; }

        [StringLength(300)]
        [DisplayName("Описание")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Выберите файл")]
        //[FileSize(102400000)]
        //[FileTypes("mp3")]
        [DisplayName("Файл")]
        public HttpPostedFileBase File { get; set; }
    }
}