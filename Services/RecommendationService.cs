using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Sprint1_2semestre.Interfaces;
using Sprint1_2semestre.Models;

namespace Sprint1_2semestre.services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public RecommendationService()
        {
            _mlContext = new MLContext();

            // Configura e treina o modelo
            var data = LoadSampleData(); // Implementar carregamento de dados de exemplo
            var trainingData = _mlContext.Data.LoadFromEnumerable(data);
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(NetworkingData.CompanyId),
                MatrixRowIndexColumnName = nameof(NetworkingData.RelatedCompanyId),
                LabelColumnName = nameof(NetworkingData.Rating),
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var estimator = _mlContext.Recommendation().Trainers.MatrixFactorization(options);
            _model = estimator.Fit(trainingData);
        }

        // Método de recomendação
        public List<Recommendation> GetRecommendations(uint companyId, int numberOfRecommendations = 5)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<NetworkingData, Recommendation>(_model);
            var recommendations = new List<Recommendation>();

            for (int i = 1; i <= 100; i++) // Assumindo até 100 empresas
            {
                var prediction = predictionEngine.Predict(new NetworkingData
                {
                    CompanyId = companyId,
                    RelatedCompanyId = (uint)i // Conversão explícita para uint
                });
                recommendations.Add(new Recommendation
                {
                    RelatedCompanyId = (uint)i, // Conversão explícita para uint
                    Score = prediction.Score
                });
            }

            return recommendations.OrderByDescending(r => r.Score).Take(numberOfRecommendations).ToList();
        }

        // Simula dados de exemplo
        private IEnumerable<NetworkingData> LoadSampleData()
        {
            var sampleData = new List<NetworkingData>();

            // Simular algumas empresas com relacionamentos de networking
            for (int empresaId = 1; empresaId <= 10; empresaId++)
            {
                for (int outraEmpresaId = 1; outraEmpresaId <= 10; outraEmpresaId++)
                {
                    if (empresaId != outraEmpresaId)
                    {
                        sampleData.Add(new NetworkingData
                        {
                            CompanyId = (uint)empresaId,                // Conversão explícita para uint
                            RelatedCompanyId = (uint)outraEmpresaId,     // Conversão explícita para uint
                            Rating = new Random().Next(1, 5)             // Rating aleatório
                        });
                    }
                }
            }
            return sampleData;
        }
    }
}
