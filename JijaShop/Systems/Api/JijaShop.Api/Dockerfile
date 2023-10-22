#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/JijaShop.Api/JijaShop.Api.csproj", "Systems/Api/JijaShop.Api/"]
COPY ["Extentions/JijaShop.Settings/JijaShop.Settings.csproj", "Extentions/JijaShop.Settings/"]
COPY ["Services/JijaShop.Services.Settings/JijaShop.Services.Settings.csproj", "Services/JijaShop.Services.Settings/"]
RUN dotnet restore "Systems/Api/JijaShop.Api/JijaShop.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/JijaShop.Api"
RUN dotnet build "JijaShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JijaShop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JijaShop.Api.dll"]