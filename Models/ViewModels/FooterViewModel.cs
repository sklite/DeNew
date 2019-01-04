using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeNew.Models.ViewModels
{
    public class FooterViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Как с Вами связаться?")]
        public string ContactData { get; set; }

        [Required(ErrorMessage = "Что Вам необходимо сделать?")]
        public string Message { get; set; }
    }
}
