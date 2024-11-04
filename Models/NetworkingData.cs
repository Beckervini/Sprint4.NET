using Microsoft.ML.Data;

namespace Sprint1_2semestre.Models
{
    /// <summary>
    /// Representa os dados de relacionamento entre empresas para fins de recomendação.
    /// Utilizado no modelo de machine learning para identificar conexões e avaliações entre empresas.
    /// </summary>
    public class NetworkingData
    {
        /// <summary>
        /// ID da empresa principal no relacionamento.
        /// Este campo é do tipo chave, com limite de 100 IDs únicos para facilitar o processamento.
        /// </summary>
        [KeyType(count: 100)]
        public uint CompanyId { get; set; }

        /// <summary>
        /// ID da empresa relacionada no relacionamento.
        /// Este campo também é do tipo chave, com limite de 100 IDs únicos, representando conexões com outras empresas.
        /// </summary>
        [KeyType(count: 100)]
        public uint RelatedCompanyId { get; set; }

        /// <summary>
        /// Avaliação (Rating) entre as empresas, indicando a força ou qualidade da relação entre elas.
        /// Um valor em ponto flutuante que pode ser usado em algoritmos de recomendação.
        /// </summary>
        public float Rating { get; set; }
    }
}
