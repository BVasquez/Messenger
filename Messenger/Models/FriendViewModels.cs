using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class FriendViewModels
    {
        [Key]
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public int Friend { get; set; }
    }
}