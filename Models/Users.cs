using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmpregaSENAI.Models
{
    public class Users : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[]? Img { get; set; }
    }
}
