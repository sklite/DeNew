using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeNew.Models.ViewModels.Interfaces;

namespace DeNew.Models.ViewModels
{
    public class PageViewModel : IEditable
    {
        public int Id { get; set; }

        public int OrderNum { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Alias { get; set; }

        public string Link { get; set; }

        public bool IsDeleted { get; set; }

        public string ImagePath { get; set; }

        public string Content { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }

        public PageViewModel ParentPage { get; set; }

        public IEnumerable<PageViewModel> SubPages { get; set; }
        public bool CanEdit { get; set; }
    
    }
}
