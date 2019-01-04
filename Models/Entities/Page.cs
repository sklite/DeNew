using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeNew.Models.Entities
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        public string Alias { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int OrderNum { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public string Content { get; set; }

        public IEnumerable<Page> SubPages { get; set; }
        public Page ParentPage { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }
    }
}
