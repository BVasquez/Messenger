using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class ConversationViewModels
    {
        public int ConversationId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Message { get; set; }
        public DateTime Time {get; set;}
    }
}
