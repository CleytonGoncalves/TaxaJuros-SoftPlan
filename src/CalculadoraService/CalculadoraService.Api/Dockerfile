FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY TaxaJuros-Softplan.sln TaxaJuros-Softplan.sln
COPY . ./
WORKDIR /src/CalculadoraService
RUN dotnet restore CalculadoraService.Api/CalculadoraService.Api.csproj
RUN dotnet publish CalculadoraService.Api/CalculadoraService.Api.csproj --no-restore -c Release -o /app

FROM build AS unittest
WORKDIR CalculadoraService.UnitTests

FROM build as functionaltest
WORKDIR CalculadoraService.FunctionalTests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD dotnet CalculadoraService.Api.dll
