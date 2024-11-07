# Use the stable .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Use dotnet run with your specific project
CMD ["dotnet", "run", "--project", "WebToDoApp/WebToDoApp.csproj"]
