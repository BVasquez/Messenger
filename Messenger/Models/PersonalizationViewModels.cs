using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class PersonalizationViewModels
    {
        [Key]
        public int PersonalizationId {get; set;}
        public int User { get; set; }
        public string PhotoProfile { get; set; }
        public string PhotoBackground { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string Status { get; set; }
        public string ConnectionStatus { get; set; }
    }
}