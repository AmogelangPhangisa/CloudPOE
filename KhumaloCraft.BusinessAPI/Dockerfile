# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files for the API
COPY ["KhumaloCraft.BusinessAPI/KhumaloCraft.BusinessAPI.csproj", "KhumaloCraft.BusinessAPI/"]

# Copy the shared project files
COPY ["KhumaloCraft.Shared/KhumaloCraft.Shared.csproj", "KhumaloCraft.Shared/"]
COPY ["KhumaloCraft.Business/KhumaloCraft.Business.csproj", "KhumaloCraft.Business/"]
COPY ["KhumaloCraft.Data/KhumaloCraft.Data.csproj", "KhumaloCraft.Data/"]

# Restore dependencies for the API
RUN dotnet restore "KhumaloCraft.BusinessAPI/KhumaloCraft.BusinessAPI.csproj"

# Copy all source files into the container
COPY . .

# Build the API
WORKDIR "/src/KhumaloCraft.BusinessAPI"
RUN dotnet build "KhumaloCraft.BusinessAPI.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "KhumaloCraft.BusinessAPI.csproj" -c Release -o /app/publish

# Final stage: run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KhumaloCraft.BusinessAPI.dll"]
