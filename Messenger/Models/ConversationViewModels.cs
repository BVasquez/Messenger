using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class ConversationViewModels
    {
        [Key]
        public int ConversationId { get; set; }
        public string Conversation { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Message { get; set; }
        public DateTime Time {get; set;}
        public string DataType { get; set; }
        public string FormatWeight { get; set; }
        public string FormatCursive { get; set; }
        public string FormatColor { get; set; }
        public string FormatSize { get; set; }
    }
}
