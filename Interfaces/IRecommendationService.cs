using Sprint1_2semestre.Models;
using System.Collections.Generic;

namespace Sprint1_2semestre.Interfaces
{
    /// <summary>
    /// Interface para o serviço de recomendações.
    /// Define a estrutura básica para obter recomendações de produtos ou itens relevantes para uma empresa específica.
    /// </summary>
    public interface IRecommendationService
    {
        /// <summary>
        /// Obtém uma lista de recomendações baseada na empresa especificada.
        /// </summary>
        /// <param name="companyId">ID único da empresa para a qual as recomendações são geradas.</param>
        /// <param name="numberOfRecommendations">Número de recomendações desejadas. O valor padrão é 5.</param>
        /// <returns>Uma lista de objetos <see cref="Recommendation"/> contendo as recomendações geradas.</returns>
        List<Recommendation> GetRecommendations(uint companyId, int numberOfRecommendations = 5);
    }
}
