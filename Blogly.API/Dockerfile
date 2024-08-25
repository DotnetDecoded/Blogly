FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Blogly.API/Blogly.API.csproj", "Blogly.API/"]
COPY ["Blogly.Application/Blogly.Application.csproj", "Blogly.Application/"]
COPY ["Blogly.Contracts/Blogly.Contracts.csproj", "Blogly.Contracts/"]
COPY ["Blogly.Domain/Blogly.Domain.csproj", "Blogly.Domain/"]
COPY ["Blogly.Sharedkernel/Blogly.Sharedkernel.csproj", "Blogly.Sharedkernel/"]
COPY ["Blogly.Infrastructure/Blogly.Infrastructure.csproj", "Blogly.Infrastructure/"]
RUN dotnet restore "Blogly.API/Blogly.API.csproj"
COPY . .
WORKDIR "/src/Blogly.API"
RUN dotnet build "Blogly.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blogly.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blogly.API.dll"]
