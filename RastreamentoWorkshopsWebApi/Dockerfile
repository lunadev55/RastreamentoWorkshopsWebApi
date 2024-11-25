# Etapa 1: Construção da imagem
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar o arquivo .csproj e restaurar as dependências (para cache de camadas do Docker)
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante dos arquivos da aplicação
COPY . ./

# Construir a aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Definir o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar os arquivos publicados da etapa de construção para a imagem de execução
COPY --from=build /app/publish .

# Expor a porta em que a aplicação será executada
EXPOSE 8080

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "RastreamentoWorkshopsWebApi.dll"]
