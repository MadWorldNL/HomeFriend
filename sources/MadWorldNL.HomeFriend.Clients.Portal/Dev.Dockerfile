FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG PRIVATE_MADWORLD_FEED
ARG NUGET_USERNAME
ARG NUGET_ACCESS_TOKEN

WORKDIR /app
EXPOSE 80

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Add NuGet source
RUN dotnet nuget add source \
    --username "${NUGET_USERNAME}" \
    --password "${NUGET_ACCESS_TOKEN}" \
    --store-password-in-clear-text \
    --name PrivateMadWorld "${PRIVATE_MADWORLD_FEED}"
    
COPY ["Directory.Build.props", "/"]
COPY ["Directory.Packages.props", "/"]
COPY ["MadWorldNL.HomeFriend.Clients.Portal/Portal.csproj", "MadWorldNL.HomeFriend.Clients.Portal/"]
RUN dotnet restore "MadWorldNL.HomeFriend.Clients.Portal/Portal.csproj"
COPY . .
WORKDIR "/src/MadWorldNL.HomeFriend.Clients.Portal"
RUN dotnet build "Portal.csproj" -c $BUILD_CONFIGURATION -o /app/build

ENTRYPOINT ["dotnet", "run", "--urls", "http://0.0.0.0:80"]