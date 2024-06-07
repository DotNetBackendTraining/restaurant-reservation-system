FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RestaurantReservation.Migrate/RestaurantReservation.Migrate.csproj", "RestaurantReservation.Migrate/"]
RUN dotnet restore "RestaurantReservation.Migrate/RestaurantReservation.Migrate.csproj"
COPY . .
WORKDIR "/src/RestaurantReservation.Migrate"
RUN dotnet build "RestaurantReservation.Migrate.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RestaurantReservation.Migrate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestaurantReservation.Migrate.dll"]
