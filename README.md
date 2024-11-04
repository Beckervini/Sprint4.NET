# Sprint4-2semestre API

RM98163 - Júlia Martins Santana Figueiredo  
RM550562 - Larissa Akemi Iwamoto  
RM98893 - Marcelo Henrique Góes da Costa Borgas  
RM98370 - Ricardo Brito Ponticelli Prieto  
RM94679 - Vinicius Becker Prediger  

Esta é uma API para gerenciamento de empresas e KPIs, desenvolvida em .NET Core com integração ao banco de dados Oracle. A aplicação foi construída utilizando princípios de arquitetura limpa, injeção de dependências, práticas de Clean Code, princípios SOLID, e documentação via Swagger. Além disso, a API integra funcionalidades de IA generativa com ML.NET.

## Arquitetura

A API segue uma arquitetura monolítica, onde todos os componentes do sistema estão contidos em um único projeto. Optamos por uma arquitetura monolítica neste projeto por ser uma solução mais simples e adequada para o escopo atual. A arquitetura monolítica permite desenvolver, testar e implantar a aplicação como uma única unidade, facilitando o gerenciamento e a manutenção, especialmente em projetos de menor escala ou em fases iniciais. Além disso, ela reduz a complexidade operacional, uma vez que não requer a sobrecarga de gerenciar múltiplos serviços ou interações entre eles, o que é mais eficiente para este cenário de API simples com poucos componentes.

Dentro da API, os principais componentes incluem:

- **Controllers**: Responsáveis por gerenciar as requisições HTTP, processar a entrada e devolver a resposta apropriada.
- **Services**: Classes de serviços, como o `ConfigManager` e o `RecommendationService`, que gerenciam regras de negócios, configurações específicas e funcionalidades de IA.
- **Data**: Acessa e gerencia a comunicação com o banco de dados através do `ApplicationDbContext`, que é uma classe derivada de `DbContext` do Entity Framework Core.
- **DesignTimeDbContextFactory**: Classe utilizada durante o tempo de design para configurar e fornecer o contexto do banco de dados para o Entity Framework Core, especialmente em cenários de migração e scaffolding.
- **Models**: Definem as entidades do sistema, como `Empresa` e `KPI`, mapeadas diretamente para as tabelas no banco de dados.

### Camadas

1. **Camada de Controle (Controllers)**: Gerencia a entrada do usuário (requisições HTTP) e aciona os serviços apropriados para processar os dados. Exemplo: `EmpresasController`.
2. **Camada de Serviços**: Contém lógica de negócio, incluindo `ConfigManager` para gerenciamento de configurações e `RecommendationService` para recomendações baseadas em IA.
3. **Camada de Acesso a Dados (Data)**: Faz a comunicação com o banco de dados usando o `ApplicationDbContext` configurado para trabalhar com Oracle e o Entity Framework Core.
4. **DesignTimeDbContextFactory**: Garante que o `ApplicationDbContext` possa ser instanciado durante o tempo de design para o Entity Framework Core, principalmente para suportar comandos de migração como `dotnet ef migrations add`.

## Testes Implementados

Os testes da API utilizam o framework xUnit e estão organizados nas seguintes categorias:
- **Testes Unitários**: Realizam testes específicos para as funcionalidades de CRUD, como a criação, leitura, atualização e exclusão de empresas, utilizando Moq para simular comportamentos.
- **Testes de Integração**: Verificam a integração entre a API e o banco de dados, garantindo que as operações CRUD estejam funcionando conforme esperado.
- **Testes de Sistema**: Validam o comportamento da API como um todo, incluindo o fluxo completo das requisições.

## Clean Code e Princípios SOLID

- **S (Single Responsibility)**: Cada classe tem uma única responsabilidade, como `EmpresasController` para o controle e `RecommendationService` para as recomendações.
- **O (Open/Closed)**: A utilização de interfaces (`IEmpresaService`, `IRecommendationService`) permite adicionar novas implementações sem modificar as existentes.
- **L (Liskov Substitution)**: Interfaces facilitam a substituição de implementações sem quebrar o código.
- **I (Interface Segregation)**: Interfaces são específicas para cada responsabilidade, evitando métodos desnecessários.
- **D (Dependency Inversion)**: Utiliza a injeção de dependência para configurar as dependências da API, melhorando a manutenção e escalabilidade.

## Funcionalidades de IA Generativa

O projeto integra ML.NET para oferecer recomendações personalizadas entre empresas. A funcionalidade de recomendação é implementada no `RecommendationService`, onde:
- **Recomendações**: Baseadas em dados de relacionamento entre empresas, gerando sugestões conforme relevância e avaliação.


## Design Patterns Utilizados

1. **Singleton Pattern**:
   O `ConfigManager` é implementado como um Singleton para garantir que haja apenas uma instância compartilhada em toda a aplicação. Ele é utilizado para gerenciar configurações globais.

   ```csharp
   builder.Services.AddSingleton<ConfigManager>();
   ```

2. **Factory Pattern**:
   A `CustomWebApplicationFactory` é utilizada nos testes para criar uma instância da aplicação com configuração específica, permitindo simulação do ambiente real e execução de testes de integração.

--- 

