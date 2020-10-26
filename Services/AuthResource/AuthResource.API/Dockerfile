FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/AuthResource/AuthResource.API/AuthResource.API.csproj", "Services/AuthResource/AuthResource.API/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Services/AuthResource/AuthResource.Domain/AuthResource.Domain.csproj", "Services/AuthResource/AuthResource.Domain/"]
COPY ["Services/AuthResource/AuthResource.Infrastructure/AuthResource.Infrastructure.csproj", "Services/AuthResource/AuthResource.Infrastructure/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/AuthResource/AuthResource.API/"
COPY . .
WORKDIR "/src/Services/AuthResource/AuthResource.API"
RUN dotnet build "AuthResource.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AuthResource.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AuthResource.API.dll"]
