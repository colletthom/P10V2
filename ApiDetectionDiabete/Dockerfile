#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8095
EXPOSE 8096

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiDetectionDiabete/ApiDetectionDiabete.csproj", "ApiDetectionDiabete/"]
RUN dotnet restore "./ApiDetectionDiabete/ApiDetectionDiabete.csproj"
COPY . .
WORKDIR "/src/ApiDetectionDiabete"
RUN dotnet build "./ApiDetectionDiabete.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiDetectionDiabete.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiDetectionDiabete.dll"]