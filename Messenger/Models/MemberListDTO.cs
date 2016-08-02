using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class MemberListDTO
    {
        public int Id { get; set; }
        public string PhotoProfile { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}