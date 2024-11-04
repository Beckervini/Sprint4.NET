using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sprint1_2semestre.Models
{
    /// <summary>
    /// Representa uma empresa no sistema.
    /// </summary>
    public class Empresa
    {
        /// <summary>
        /// Identificador único da empresa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// CNPJ da empresa.
        /// Deve conter exatamente 14 caracteres.
        /// </summary>
        /// <example>12345678000195</example>
        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Email da empresa.
        /// Deve ser um endereço de email válido.
        /// </summary>
        /// <example>empresa@exemplo.com</example>
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Senha da empresa.
        /// Deve ter no mínimo 6 caracteres.
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; } = string.Empty;

        /// <summary>
        /// Nome da empresa.
        /// </summary>
        /// <example>Empresa X</example>
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Setor de atuação da empresa.
        /// </summary>
        /// <example>Varejo</example>
        [Required(ErrorMessage = "O setor de atuação é obrigatório")]
        public string SetorAtuacao { get; set; } = string.Empty;

        /// <summary>
        /// Lista de KPIs associados à empresa.
        /// Não é serializado para evitar ciclos de referência.
        /// </summary>
        [JsonIgnore]
        public List<KPI> KPIs { get; set; } = new List<KPI>();
    }
}
