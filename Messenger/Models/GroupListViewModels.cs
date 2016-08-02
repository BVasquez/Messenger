using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class GroupListViewModels
    {
        [Key]
        public int GroupListId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string Background { get; set; }
        public string ProfilePhoto { get; set; }
    }
}