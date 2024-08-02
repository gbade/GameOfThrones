#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5100

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GameOfThrones.API/GameOfThrones.API.csproj", "GameOfThrones.API/"]
COPY ["GameOfThrones.Infrastructure/GameOfThrones.Infrastructure.csproj", "GameOfThrones.Infrastructure/"]
RUN dotnet restore "./GameOfThrones.API/GameOfThrones.API.csproj"

COPY . .

RUN dotnet tool install --global dotnet-ef --version 7.0.20
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR "/src/GameOfThrones.API"
#RUN /root/.dotnet/tools/dotnet-ef database update

#WORKDIR "/src"
RUN dotnet build "./GameOfThrones.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GameOfThrones.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5100

ENTRYPOINT ["dotnet", "GameOfThrones.API.dll"]