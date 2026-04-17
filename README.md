# deseulance
Desafio técnico Deseulance

## 🏗️ Arquitetura

O projeto foi desenvolvido seguindo os princípios da **Clean Architecture**, visando a separação de preocupações, independência de frameworks e facilidade de testes.

### Divisão de Camadas:
* **Domain:** Contém as entidades de negócio, interfaces, exceções de domínio e regras fundamentais (DDD). Não possui dependências externas.
* **Application:** Onde residem os casos de uso, DTOs, Mappers e as interfaces de serviços e repositórios. Aqui é definido *o que* o sistema faz. Todas a validações foram feitas pelo Fluent Validation nesta camada.
* **Infrastructure:** Implementações técnicas de acesso a dados (Entity Framework).
* **API / Presentation:** A porta de entrada da aplicação (ASP.NET Core), responsável pelas rotas, controllers e configuração de Injeção de Dependência.

#### 🛠️ Tecnologias e Padrões
* **MediatR:** Para desacoplamento entre a camada de API e os Handlers de aplicação.
* **FluentValidation:** Validação de contratos e regras de negócio de forma elegante.
* **Repository Pattern:** Abstração da camada de persistência. 
* **Migration**
* **Minimal APIs**


#### Docker
* *O projeto utiliza Docker Compose para orquestrar o ambiente de desenvolvimento, garantindo que a API e o banco de dados estejam configurados corretamente e se comuniquem.
* *Serviços Configurados
* *api (ASP.NET Core)
* *Container Name: deseulance-api
* *Porta Exposta: 5000 (mapeada para a 8080 interna do container).
* *Dependência: Aguarda a inicialização do serviço sqlserver.
* *sqlserver (Microsoft SQL Server 2022)
* *Container Name: deseulance-sql
* *Imagem: mcr.microsoft.com/mssql/server:2022-latest
* *Porta Exposta: 1433.
* *Alias de Rede: Configurado como sqlserver para ser resolvido pela API na connection string.

* *Certifique-se de ter o Docker desktop está instalado em sua máquina.
* *Ao clonar e abrir o projeto, automaticamente o docker desktop será aberto e iniciará os containers configurados no docker-compose.yml conforme imagem abaixo:
* ![Iniciando os containers](./assets/iniciandocontainers.png)
* ![Docker desktop](./assets/dockerdesktop.png)

🌐 Rede e Persistência
* *Network (deseulancenet): Foi criada uma rede do tipo bridge chamada deseulancenet. Isso isola os containers do projeto, permitindo que eles se comuniquem de forma segura e eficiente pelo nome do serviço.
* *Volume (sql_data): Um volume nomeado foi configurado e mapeado para /var/opt/mssql. Isso garante a persistência dos dados, permitindo que as informações do banco não sejam perdidas ao remover ou reiniciar os containers.

##### Rodar o projeto
* *Após a inicialização dos containers, rode o projeto pelo docker compose, acesse a janela dos containers, clique na porta do container da API e o projeto estará disponível em http://localhost:5000/swagger/index.html.
* *Você poderá acessar os endpoints através do swagger.
 
