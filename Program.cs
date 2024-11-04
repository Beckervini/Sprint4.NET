using Microsoft.EntityFrameworkCore;
using Sprint1_2semestre.Data;
using Sprint1_2semestre.Services;
using Sprint1_2semestre.Interfaces;
using Sprint1_2semestre.services;

/// <summary>
/// Classe principal que configura e executa a aplicação.
/// </summary>
public class Program
{
    /// <summary>
    /// Ponto de entrada principal da aplicação.
    /// </summary>
    /// <param name="args">Argumentos de linha de comando</param>
    public static void Main(string[] args)
    {
        /// <summary>
        /// Cria o construtor da aplicação.
        /// </summary>
        var builder = WebApplication.CreateBuilder(args);

        /// <summary>
        /// Obtém a string de conexão do arquivo de configuração appsettings.json.
        /// Certifique-se de configurar corretamente a string de conexão para o Oracle.
        /// </summary>
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        /// <summary>
        /// Adiciona o ApplicationDbContext ao contêiner de injeção de dependências.
        /// Configura o Entity Framework Core para usar o Oracle como provedor de banco de dados.
        /// </summary>
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseOracle(connectionString));  // Certifique-se de ter o pacote Oracle.EntityFrameworkCore instalado

        /// <summary>
        /// Registra o ConfigManager como um serviço Singleton no contêiner de injeção de dependências.
        /// </summary>
        builder.Services.AddSingleton<ConfigManager>();

        /// <summary>
        /// Registra o IEmpresaService como um serviço Scoped no contêiner de injeção de dependências.
        /// Essa linha resolve o erro de injeção de dependência no EmpresasController.
        /// </summary>
        builder.Services.AddScoped<IEmpresaService, EmpresaService>();
        builder.Services.AddScoped<IRecommendationService, RecommendationService>();


        /// <summary>
        /// Adiciona serviços de controladores à aplicação e configura opções de serialização JSON.
        /// Configura a serialização para preservar referências circulares e usar indentação nos dados JSON.
        /// </summary>
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

        /// <summary>
        /// Configura o CORS para permitir requisições de qualquer origem, método e cabeçalho.
        /// </summary>
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        /// <summary>
        /// Adiciona suporte ao Swagger para gerar documentação da API.
        /// </summary>
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        /// <summary>
        /// Registra o serviço de tempo.
        /// </summary>
        builder.Services.AddHttpClient<WeatherService>();

        /// <summary>
        /// Constrói a aplicação.
        /// </summary>
        var app = builder.Build();

        /// <summary>
        /// Se estiver em ambiente de desenvolvimento, habilita o Swagger e a interface do Swagger UI.
        /// </summary>
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        /// <summary>
        /// Habilita o CORS utilizando a política configurada.
        /// </summary>
        app.UseCors("AllowAll");

        /// <summary>
        /// Habilita o middleware de autorização da aplicação.
        /// </summary>
        app.UseAuthorization();

        /// <summary>
        /// Mapeia todos os controladores da API para que possam responder às requisições HTTP.
        /// </summary>
        app.MapControllers();

        /// <summary>
        /// Executa a aplicação.
        /// </summary>
        app.Run();
    }
}
