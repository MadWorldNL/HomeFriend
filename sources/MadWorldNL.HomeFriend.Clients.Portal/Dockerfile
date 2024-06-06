FROM  --platform=$BUILDPLATFORM nginx:latest AS base
ARG BUILDPLATFORM
ARG DEVEXPRESS_FEED

EXPOSE 80
EXPOSE 443

FROM  --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILDPLATFORM

WORKDIR /src
RUN dotnet nuget add source ${DEVEXPRESS_FEED} -n devexpress-nuget

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
