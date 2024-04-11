FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env 
WORKDIR /App

COPY . .
RUN dotnet restore "Tuki.Catalogs.Api.csproj"
RUN dotnet publish "Tuki.Catalogs.Api.csproj" -c Release -o /App/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/publish .
ENTRYPOINT ["dotnet", "Tuki.Catalogs.Api.dll"]