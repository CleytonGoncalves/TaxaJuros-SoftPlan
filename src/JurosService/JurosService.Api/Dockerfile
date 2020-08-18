FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY TaxaJuros-Softplan.sln TaxaJuros-Softplan.sln
COPY . ./
WORKDIR /src/JurosService
RUN dotnet restore JurosService.Api/JurosService.Api.csproj
RUN dotnet publish JurosService.Api/JurosService.Api.csproj --no-restore -c Release -o /app

FROM build AS unittest
WORKDIR JurosService.UnitTests

FROM build as functionaltest
WORKDIR JurosService.FunctionalTests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT dotnet JurosService.Api.dll
