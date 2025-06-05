# BIOSINC - Back-End

A Clean Architecture oferece vantagens significativas ao promover um design de software altamente organizado e sustentável. Seu principal benefício é a separação clara de responsabilidades entre as camadas do sistema, garantindo que as regras de negócio (domínio) permaneçam independentes de frameworks, bancos de dados ou interfaces externas. Isso resulta em:

😍 Vantagens Principais:
Independência tecnológica - O domínio não depende de bibliotecas externas, facilitando migrações.

Testabilidade aprimorada - Regras de negócio podem ser testadas isoladamente (sem infraestrutura).

Manutenção simplificada - Mudanças em uma camada (ex: banco de dados) não afetam outras.

Escalabilidade - Novas features são adicionadas sem impactar o núcleo existente.

Alinhamento com SOLID - Princípios como Inversão de Dependência são aplicados naturalmente.

Comunicação clara entre stakeholders - O fluxo de dados é explícito entre camadas (ex: API → Application → Domain).
├── NomedoProjeto.API/          
[ Camada de apresentação (ASP.NET Core) ]

├── NomedoProjeto.Application/  
[ Casos de uso e serviços ]

├── NomedoProjeto.Domain/       
[ Entidades e regras de negócio ]

├── NomedoProjeto.Infra.Data/   
[ Implementação de persistência ]

├── NomedoProjeto.Infra.IoC/    
[ Configuração de DI ]

└── NomedoProjeto.Domain.Tests/ 
[ Testes de unidade ]

Este é o diagrama da estrutura:

                          +---------------------------------+
                          |              API               |
                          |        (Controllers, Swagger)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |            Application          |
                          |         (DTOs, Mediators)       |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |               Domain            |
                          |  (Entities, Interfaces, Specs)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |          Infra.IoC              |
                          |  (Dependency Injection Config)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |           Infra.Data            |
                          |  (Repositories, Migrations)     |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |         Azure SQL Server        |
                          |      (Entity Framework)         |
                          +---------------------------------+

Representação da Injeção de DependÊncias:


![Back-End Dependencies](https://github.com/user-attachments/assets/42618e8d-b517-4a50-b0bb-3868cbb601c2)


