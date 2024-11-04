using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sprint1_2semestre.Data;
using Sprint1_2semestre.Models;
using System.Linq;

namespace Sprint1_2sem.Tests.Factories
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove o ApplicationDbContext registrado e substitui pelo InMemory
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Adiciona um novo contexto de banco de dados InMemory para os testes
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                // Garante que o banco de dados seja criado ao iniciar o teste
                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.EnsureCreated();

                    // Populando o banco de dados com dados de teste
                    if (!db.Empresas.Any())
                    {
                        db.Empresas.Add(new Empresa
                        {
                            Nome = "Empresa X",
                            Cnpj = "12345678000100"
                        });
                        db.SaveChanges();
                    }
                }
            });
        }
    }
}
