# Base image for running the app
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

# SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore
COPY 20MRows.csproj ./
RUN dotnet restore 20MRows.csproj

# Copy the rest of the source code
COPY . ./
RUN dotnet build 20MRows.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish 20MRows.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "20MRows.dll"]
