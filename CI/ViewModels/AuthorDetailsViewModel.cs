using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CI.Entities;
using PagedList;
using CI.Properties;

namespace CI.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public string AuthorName { get; set; }

        public string Image { get; set; }

        public IPagedList<Audiofile> Audiofiles { get; set; }

        public AuthorDetailsViewModel(string name, string image, IEnumerable<Audiofile> audiofiles, int page = 1)
        {
            AuthorName = name;
            Image = image;
            Audiofiles = audiofiles.ToPagedList(page, Settings.Default.ItemsPerPage);
        }
    }
}