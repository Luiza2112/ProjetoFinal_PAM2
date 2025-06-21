using System;
using System.ComponentModel.DataAnnotations;

namespace API_Feedback.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Remetente { get; set; } = string.Empty; //Declarar valor inicial vazio
        [MaxLength(50)]
        public string Destinatario { get; set; } = string.Empty;
        [MaxLength(450)]
        public string Descricao { get; set; } = string.Empty;
        public DateTime? Data { get; set; }  // using System;

    }
}