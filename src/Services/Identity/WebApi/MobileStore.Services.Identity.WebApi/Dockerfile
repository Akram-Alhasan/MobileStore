#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/Identity/WebApi/MobileStore.Services.Identity.WebApi/MobileStore.Services.Identity.WebApi.csproj", "src/Services/Identity/WebApi/MobileStore.Services.Identity.WebApi/"]
COPY ["src/Services/Identity/Core/Application/MobileStore.Services.Identity.Application/MobileStore.Services.Identity.Application.csproj", "src/Services/Identity/Core/Application/MobileStore.Services.Identity.Application/"]
COPY ["src/Services/Identity/Core/Domain/MobileStore.Services.Identity.Domain/MobileStore.Services.Identity.Domain.csproj", "src/Services/Identity/Core/Domain/MobileStore.Services.Identity.Domain/"]
COPY ["src/BuildingBlocks/Shared/MobileStore.BuildingBlocks.Shared.Shared/MobileStore.BuildingBlocks.Shared.Shared.csproj", "src/BuildingBlocks/Shared/MobileStore.BuildingBlocks.Shared.Shared/"]
COPY ["src/Services/Identity/Infrastructure/MobileStore.Services.Identity.Infrastructure/MobileStore.Services.Identity.Infrastructure.csproj", "src/Services/Identity/Infrastructure/MobileStore.Services.Identity.Infrastructure/"]
RUN dotnet restore "src/Services/Identity/WebApi/MobileStore.Services.Identity.WebApi/MobileStore.Services.Identity.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/WebApi/MobileStore.Services.Identity.WebApi"
RUN dotnet build "MobileStore.Services.Identity.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobileStore.Services.Identity.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileStore.Services.Identity.WebApi.dll"]