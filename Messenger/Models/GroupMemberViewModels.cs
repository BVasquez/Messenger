using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class GroupMemberViewModels
    {
        [Key]
        public int GroupMemberId { get; set; }
        public int GroupId { get; set; }
        public int Member { get; set; }
    }
}