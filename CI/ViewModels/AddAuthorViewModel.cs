using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CI.Services;

namespace CI.ViewModels
{
    public class AddAuthorViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DisplayName("Автор/Исполнитель")]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        [DisplayName("Изображение")]
        [Required]
        [FileSize(10240000)]
        [FileTypes("jpg,jpeg")]
        public HttpPostedFileBase Image { get; set; }
    }
}