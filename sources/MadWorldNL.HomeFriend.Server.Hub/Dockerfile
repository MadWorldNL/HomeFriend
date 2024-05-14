FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "/"]
COPY ["Directory.Packages.props", "/"]
COPY ["MadWorldNL.HomeFriend.Server.Hub/Hub.csproj", "MadWorldNL.HomeFriend.Server.Hub/"]
RUN dotnet restore "MadWorldNL.HomeFriend.Server.Hub/Hub.csproj"
COPY . .
WORKDIR "/src/MadWorldNL.HomeFriend.Server.Hub"
RUN dotnet build "Hub.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Hub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MadWorldNL.HomeFriend.Server.Hub.dll"]
