FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RestaurantReservation.Api.Auth/RestaurantReservation.Api.Auth.csproj", "RestaurantReservation.Api.Auth/"]
RUN dotnet restore "RestaurantReservation.Api.Auth/RestaurantReservation.Api.Auth.csproj"
COPY . .
WORKDIR "/src/RestaurantReservation.Api.Auth"
RUN dotnet build "RestaurantReservation.Api.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RestaurantReservation.Api.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestaurantReservation.Api.Auth.dll"]
