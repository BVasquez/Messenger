using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Messenger.Models
{
    public class UserViewModels
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Nickname")]
        public string NickName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Date Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Remote("UserExists","Account",ErrorMessage ="This User already exits")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
