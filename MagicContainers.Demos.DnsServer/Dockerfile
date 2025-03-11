FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 53

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MagicContainers.Demos.DnsServer/MagicContainers.Demos.DnsServer.csproj", "MagicContainers.Demos.DnsServer/"]
RUN dotnet restore "MagicContainers.Demos.DnsServer/MagicContainers.Demos.DnsServer.csproj"
COPY . .
WORKDIR "/src/MagicContainers.Demos.DnsServer"
RUN dotnet build "MagicContainers.Demos.DnsServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MagicContainers.Demos.DnsServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicContainers.Demos.DnsServer.dll"]
