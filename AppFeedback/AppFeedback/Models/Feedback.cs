using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFeedback.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Remetente { get; set; } = string.Empty;
        public string Destinatario { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }
    }
}
