FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
LABEL maintainer="AZZOUZ Fadi"
LABEL description="Mower.Application"

# Non-root user configuration
RUN groupadd -r dotnet-user && useradd --no-log-init -r -g dotnet-user dotnet-user
USER dotnet-user

WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Build
WORKDIR /src
COPY ["src/Mower.Application.csproj", "Mower.Application/"]
RUN dotnet restore "Mower.Application/Mower.Application.csproj"

COPY ./src .
WORKDIR /src
RUN dotnet build "Mower.Application.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Mower.Application.csproj" -c Release -o /app/publish

# App
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mower.Application.dll"]

