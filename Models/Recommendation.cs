namespace Sprint1_2semestre.Models
{
    /// <summary>
    /// Representa uma recomendação gerada pelo sistema de IA para empresas relacionadas.
    /// Contém informações sobre a empresa recomendada e a relevância da recomendação.
    /// </summary>
    public class Recommendation
    {
        /// <summary>
        /// ID da empresa recomendada, representando uma conexão ou sugestão relevante para a empresa alvo.
        /// </summary>
        public uint RelatedCompanyId { get; set; }

        /// <summary>
        /// Pontuação ou grau de relevância da recomendação.
        /// Um valor mais alto indica uma recomendação mais forte ou relevante.
        /// </summary>
        public float Score { get; set; }
    }
}
