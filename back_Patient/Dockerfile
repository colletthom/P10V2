#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
#doit correspondre au launchsettings.json


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#Je peux mettre Release ou Debug ca ne change rine
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["back_Patient/back_Patient.csproj", "back_Patient/"]
RUN dotnet restore "./back_Patient/back_Patient.csproj"
COPY . .
WORKDIR "/src/back_Patient"
RUN dotnet build "./back_Patient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./back_Patient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "back_Patient.dll"]