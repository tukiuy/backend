FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env 
WORKDIR /App

ARG NUGET_USERNAME
ARG NUGET_PASSWORD

ENV NUGET_USERNAME=${NUGET_USERNAME}
ENV NUGET_PASSWORD=${NUGET_PASSWORD}

COPY . .

RUN dotnet nuget add source https://nuget.pkg.github.com/tukiuy/index.json \
    --name="Tuki.Nuget" \
    --username ${NUGET_USERNAME} \
    --store-password-in-clear-text \
    --password ${NUGET_PASSWORD} 
    #--configfile nuget.config
RUN dotnet restore "Tuki.Catalogs.Api.csproj"
RUN dotnet publish "Tuki.Catalogs.Api.csproj" -c Release -o /App/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/publish .
ENTRYPOINT ["dotnet", "Tuki.Catalogs.Api.dll"]