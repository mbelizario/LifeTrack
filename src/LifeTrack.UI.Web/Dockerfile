#Entre na pasta LifeTrack
#Rode docker build --no-cache -t lifetrack -f src/LifeTrack.UI.Web/Dockerfile . 

# Etapa 1: Imagem base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa 2: Imagem para compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar a solution e os arquivos de projeto
COPY ./LifeTrack.sln .
COPY ./src/LifeTrack.Application/LifeTrack.Application.csproj ./src/LifeTrack.Application/
COPY ./src/LifeTrack.Domain/LifeTrack.Domain.csproj ./src/LifeTrack.Domain/
COPY ./src/LifeTrack.Infra.CrossCutting.IoC/LifeTrack.Infra.CrossCutting.IoC.csproj ./src/LifeTrack.Infra.CrossCutting.IoC/
COPY ./src/LifeTrack.Infra.Data/LifeTrack.Infra.Data.csproj ./src/LifeTrack.Infra.Data/
COPY ./src/LifeTrack.UI.Web/LifeTrack.UI.Web.csproj ./src/LifeTrack.UI.Web/

# Restaurar dependências
RUN dotnet restore ./LifeTrack.sln

# Copiar os arquivos restantes e compilar a aplicação
COPY ./src ./src
RUN dotnet build ./src/LifeTrack.UI.Web/LifeTrack.UI.Web.csproj -c $BUILD_CONFIGURATION -o /app/build

# Etapa 3: Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
RUN dotnet publish ./src/LifeTrack.UI.Web/LifeTrack.UI.Web.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa 4: Imagem final para execução
FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:8080"
ENV ASPNETCORE_ENVIRONMENT="Development"

# Copiar os arquivos publicados para a imagem final
COPY --from=publish /app/publish .

# Corrigido o nome do arquivo DLL no ENTRYPOINT
ENTRYPOINT ["dotnet", "LifeTrack.UI.Web.dll"]