# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src

# Copy solution and restore dependencies
COPY FCG_NOTIFICATIONSAPI.sln .
COPY FCG_NOTIFICATIONSAPI/*.csproj ./FCG_NOTIFICATIONSAPI/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /src/FCG_NOTIFICATIONSAPI
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FCG_NOTIFICATIONSAPI.dll"]
