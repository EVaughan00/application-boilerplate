FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/APIGateway/APIGateway.csproj", "Services/APIGateway/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/APIGateway/"
COPY . .
WORKDIR "/src/Services/APIGateway"
RUN dotnet build "APIGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "APIGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "APIGateway.dll"]
