using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    /// <summary>
    /// Construtor para inicializar o serviço de clima com dependências de HttpClient e configuração.
    /// </summary>
    /// <param name="httpClient">Instância de HttpClient para realizar chamadas HTTP.</param>
    /// <param name="configuration">Instância de IConfiguration para acessar as configurações da API.</param>
    /// <exception cref="ArgumentNullException">Lançado se httpClient, _baseUrl ou _apiKey forem nulos.</exception>
    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _baseUrl = configuration["WeatherApi:BaseUrl"] ?? throw new ArgumentNullException(nameof(_baseUrl), "BaseUrl não pode ser nulo.");
        _apiKey = configuration["WeatherApi:ApiKey"] ?? throw new ArgumentNullException(nameof(_apiKey), "ApiKey não pode ser nulo.");
    }

    /// <summary>
    /// Obtém informações de clima para a cidade especificada.
    /// </summary>
    /// <param name="city">Nome da cidade para a qual obter os dados climáticos.</param>
    /// <returns>Uma string contendo os dados de clima em formato JSON.</returns>
    /// <exception cref="HttpRequestException">Lançado se a requisição para a API de clima falhar.</exception>
    public virtual async Task<string> GetWeatherAsync(string city)
    {
        // Realiza uma requisição HTTP GET à API de clima, incluindo a cidade e a unidade métrica nos parâmetros.
        var response = await _httpClient.GetAsync($"{_baseUrl}?q={city}&appid={_apiKey}&units=metric");
        response.EnsureSuccessStatusCode(); // Verifica se a resposta foi bem-sucedida, caso contrário, lança uma exceção.
        return await response.Content.ReadAsStringAsync(); // Retorna o conteúdo da resposta como string JSON.
    }
}
