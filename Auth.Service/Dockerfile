FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["auth-microservice/Auth.Service/Auth.Service.csproj", "Auth.Service/"]
COPY ["local-nuget-packages/", "/local-nuget-packages/"]
COPY ["auth-microservice/nuget.config", "./"]
RUN dotnet restore "Auth.Service/Auth.Service.csproj"

COPY ["auth-microservice/Auth.Service/", "Auth.Service/"]
WORKDIR "/src/Auth.Service"
RUN dotnet build "Auth.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Auth.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Service.dll"]
