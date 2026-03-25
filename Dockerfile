FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

#  Find and copy csproj (adjust folder name if needed)
COPY */*.csproj ./
RUN dotnet restore

# Copy full project
COPY . ./

# Publish
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

#  IMPORTANT: change this to your DLL name
CMD ["dotnet", "electric_inventory.dll"]
