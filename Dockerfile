# Use the stable .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies and publish the app
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WebToDoApp.dll"]
