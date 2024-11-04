# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the Razor Pages project
COPY ["KhumaloCraft.Web/KhumaloCraft.Web.csproj", "KhumaloCraft.Web/"]

# Copy the shared project
COPY ["../KhumaloCraft.Shared/KhumaloCraft.Shared.csproj", "../KhumaloCraft.Shared/"]

# Restore dependencies for both projects
RUN dotnet restore "KhumaloCraft.Web/KhumaloCraft.Web.csproj"

# Copy all the files (this assumes you want all the source files)
COPY . .

# Build the Razor Pages project
WORKDIR "/src/KhumaloCraft.Web"
RUN dotnet build "KhumaloCraft.Web.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "KhumaloCraft.Web.csproj" -c Release -o /app/publish

# Final stage: run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KhumaloCraft.Web.dll"]
