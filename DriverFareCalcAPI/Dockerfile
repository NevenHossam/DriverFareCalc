# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5084

ENV ASPNETCORE_URLS=http://+:5084
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "DriverFareCalcAPI.dll"]

#TO USE DOCKER
#docker build -t driverfarecalcapi .
#docker run -p 5084:5084 --name fare-api driverfarecalcapi