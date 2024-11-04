using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sprint1_2semestre.Models
{
    public class KPI
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O texto da KPI é obrigatório")]
        public string Texto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo EmpresaId é obrigatório")]
        public int EmpresaId { get; set; }

        // Ignorar Empresa na serialização para evitar ciclos de referência
        [JsonIgnore]
        public Empresa? Empresa { get; set; }
    }
}
