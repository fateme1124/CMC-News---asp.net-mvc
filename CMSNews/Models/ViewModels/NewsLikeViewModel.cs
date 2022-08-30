using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSNews.Models.ViewModels
{
    public class NewsLikeViewModel
    {
        public int NewsId { get; set; }
        public int Like { get; set; }
        public bool NewsState { get; set; }
    }
}