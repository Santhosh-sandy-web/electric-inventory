# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet restore ElectricInventorySystem/ElectricInventorySystem.csproj
RUN dotnet publish ElectricInventorySystem/ElectricInventorySystem.csproj -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "ElectricInventorySystem.dll"]
