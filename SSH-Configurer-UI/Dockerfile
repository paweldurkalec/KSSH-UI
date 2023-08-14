#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SSH-Configurer-UI/SSH-Configurer-UI.csproj", "SSH-Configurer-UI/"]
RUN dotnet restore "SSH-Configurer-UI/SSH-Configurer-UI.csproj"
COPY . .
WORKDIR "/src/SSH-Configurer-UI"
RUN dotnet build "SSH-Configurer-UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSH-Configurer-UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSH-Configurer-UI.dll"]