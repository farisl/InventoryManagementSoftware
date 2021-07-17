#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InventoryManagementSoftware/InventoryManagementSoftware.csproj", "InventoryManagementSoftware/"]
RUN dotnet restore "InventoryManagementSoftware/InventoryManagementSoftware.csproj"
COPY . .
WORKDIR "/src/InventoryManagementSoftware"
RUN dotnet build "InventoryManagementSoftware.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryManagementSoftware.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryManagementSoftware.dll"]