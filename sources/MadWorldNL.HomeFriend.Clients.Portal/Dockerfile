FROM  --platform=$BUILDPLATFORM nginx:latest AS base
ARG BUILDPLATFORM
ARG PRIVATE_MADWORLD_FEED
ARG NUGET_USERNAME
ARG NUGET_ACCESS_TOKEN

EXPOSE 80
EXPOSE 443

FROM  --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILDPLATFORM
ARG PRIVATE_MADWORLD_FEED
ARG NUGET_USERNAME
ARG NUGET_ACCESS_TOKEN

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
RUN dotnet build "Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
