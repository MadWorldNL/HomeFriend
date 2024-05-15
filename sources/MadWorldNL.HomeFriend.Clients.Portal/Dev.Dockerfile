FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "/"]
COPY ["Directory.Packages.props", "/"]
COPY ["MadWorldNL.HomeFriend.Clients.Portal/Portal.csproj", "MadWorldNL.HomeFriend.Clients.Portal/"]
RUN dotnet restore "MadWorldNL.HomeFriend.Clients.Portal/Portal.csproj"
COPY . .
WORKDIR "/src/MadWorldNL.HomeFriend.Clients.Portal"
RUN dotnet build "Portal.csproj" -c $BUILD_CONFIGURATION -o /app/build

ENTRYPOINT ["dotnet", "run", "--urls", "http://0.0.0.0:80"]