#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/Catalog/WebApi/MobileStore.Services.Catalog.WebApi/MobileStore.Services.Catalog.WebApi.csproj", "src/Services/Catalog/WebApi/MobileStore.Services.Catalog.WebApi/"]
COPY ["src/Services/Catalog/Core/Application/MobileStore.Services.Catalog.Application/MobileStore.Services.Catalog.Application.csproj", "src/Services/Catalog/Core/Application/MobileStore.Services.Catalog.Application/"]
COPY ["src/Services/Catalog/Core/Domain/MobileStore.Services.Catalog.Domain/MobileStore.Services.Catalog.Domain.csproj", "src/Services/Catalog/Core/Domain/MobileStore.Services.Catalog.Domain/"]
COPY ["src/BuildingBlocks/Shared/MobileStore.BuildingBlocks.Shared.Shared/MobileStore.BuildingBlocks.Shared.Shared.csproj", "src/BuildingBlocks/Shared/MobileStore.BuildingBlocks.Shared.Shared/"]
COPY ["src/Services/Catalog/Infrastructure/MobileStore.Services.Catalog.Infrastructure/MobileStore.Services.Catalog.Infrastructure.csproj", "src/Services/Catalog/Infrastructure/MobileStore.Services.Catalog.Infrastructure/"]
COPY ["src/Services/Identity/Core/Domain/MobileStore.Services.Identity.Domain/MobileStore.Services.Identity.Domain.csproj", "src/Services/Identity/Core/Domain/MobileStore.Services.Identity.Domain/"]
RUN dotnet restore "src/Services/Catalog/WebApi/MobileStore.Services.Catalog.WebApi/MobileStore.Services.Catalog.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/WebApi/MobileStore.Services.Catalog.WebApi"
RUN dotnet build "MobileStore.Services.Catalog.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobileStore.Services.Catalog.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileStore.Services.Catalog.WebApi.dll"]