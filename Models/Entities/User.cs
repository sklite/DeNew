using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DeNew.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }

        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public int AccessLevel { get; set; }
    }
}