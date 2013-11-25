using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodedHomes.Models;

namespace CodedHomes.Web.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Home Home { get; set; }
        public bool IsNew { get; set; }

        public string ImageUrlPrefix
        {
            get
            {
                return Config.ImagesUrlPrefix;
            }
        }

        public HomeViewModel()
        {
            Home = new Home();
        }
    }
}