using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class ConversationGroupViewModels
    {
        [Key]
        public int ConversationId { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int From { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string DataType { get; set; }
        public string FormatWeight { get; set; }
        public string FormatCursive { get; set; }
        public string FormatColor { get; set; }
        public string FormatSize { get; set; }
    }
}