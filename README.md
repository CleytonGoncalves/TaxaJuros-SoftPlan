## Serviços de Taxa de Juros

São 2 serviços:
 - **Juros Service**: Optei por mantê-lo bem simples e direto, apenas um projeto principal com um endpoint que chama um service
 responsável por trazer o valor da taxa.
 - **Calculadora Service**: Segue princípios da Clean Architecture, baseado em Use Cases, e utilizando CQRS.
 ![](https://www.methodsandtools.com/archive/onion11.jpg)
 
Ambos serviços possuem:
- Princípios SOLID
- REST API com Swagger e Versionamento de API
- Docker (com Compose p/ subir os 2 serviços juntos)
- Logging com Serilog
- Testes unitários com xUnit, AutoFixture, Moq, e FluentAssertions
- Testes de integração

Algumas melhorias possíveis:
 - Testes de integração entre os 2 serviços
 - Cache na chamada da API pela Calculadora

### Como rodar o projeto localmente

Opção 1. Docker: Na raiz do repositório, execute no terminal `docker-compose run`. Pode ser que demore um pouquinho, mas será apenas na primeira execução enquanto o docker inicializa os contêineres.

Opção 2. VS/Rider/CLI do dotnet: deve ser configurado a URL pela qual o JurosService pode ser encontrado, por meio do `appSettings.json`, opção do dotnet run, ou variáveis de ambiente.
