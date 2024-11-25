# API Web de Rastreamento de Workshops

## Descrição

Esta API RESTful foi desenvolvida em .NET 8 para gerenciar informações sobre workshops, colaboradores e suas presenças. A aplicação permite a criação e consulta de workshops, registro de colaboradores e o controle de sua presença através de atas. Ela utiliza o padrão CQRS (Command Query Responsibility Segregation) e Mediator e autenticação via JWT.

### Principais Funcionalidades:
- Criação e consulta de **Workshops**.
- Adicionar e remover **Colaboradores**.
- Registrar e listar **Atas** de presença de colaboradores nos workshops.
- Autenticação segura com **JWT**.
- Documentação interativa da API utilizando **Swagger**.

## Dependências


- **MediatR**: Implementação dos padrões de projeto CQRS e Mediator.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: Autenticação via JWT.
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: Gestão de usuários e autenticação com ASP.NET Identity.
- **Microsoft.EntityFrameworkCore**: ORM para interação com o banco de dados.
- **Swashbuckle.AspNetCore**: Geração de documentação Swagger para a API.
- **SQL Server**: Banco de dados para persistir informações de workshops, colaboradores e atas.

## Como Rodar Localmente

### Pré-requisitos

Antes de rodar a aplicação localmente, certifique-se de que você tem os seguintes softwares instalados:

- **.NET 8 SDK** - Certifique-se de que você tem a versão mais recente do .NET 8 instalada no seu sistema.
- **SQL Server** ou **SQL Server Express** - A aplicação utiliza o SQL Server para persistir os dados.
- **Visual Studio** ou **VS Code** (opcional, mas recomendado) para desenvolvimento.

### Passos para Rodar a API Localmente

1. **Clone o repositório**:

   Primeiro, clone o repositório da aplicação:

   ```bash
   git clone https://github.com/lunadev55/RastreamentoWorkshopsWebApi.git   
   
2. **Configuração do Banco de Dados**:
    
   Atualize o arquivo **appsettings.json** e configure a ConnectionString para o seu banco de dados.
       
      
       "DefaultConnection": "Server=localhost;Database=WorkshopDb;Trusted_Connection=True;"

3. **Instale as dependências**:

   Restaure as dependências do projeto:

   ```bash
   dotnet restore
   
4. **Execute as Migrations**:

   Aplique as migrations para configurar o banco de dados: (Como temos migrations para os 2 contextos, precisamos aplicar o comando para cada contexto)
   
   Nota: Certifique-se de que o banco de dados esteja ativo e acessível.

   ```bash
   dotnet ef database update --context UserDbContext
   dotnet ef database update --context AppDbContext
   
5. **Execute a Aplicação**:

   Inicie o servidor local:

   ```bash
   dotnet run

   O App estará disponível no http://localhost:5004/index.html
