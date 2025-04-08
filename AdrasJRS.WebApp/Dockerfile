FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AdrasJRS.WebApp/AdrasJRS.WebApp.csproj", "AdrasJRS.WebApp/"]
COPY ["AdrasJRS.Data/AdrasJRS.Data.csproj", "AdrasJRS.Data/"]
COPY ["AdrasJRS.Common/AdrasJRS.Common.csproj", "AdrasJRS.Common/"]
RUN dotnet restore "AdrasJRS.WebApp/AdrasJRS.WebApp.csproj"
COPY . .
WORKDIR "/src/AdrasJRS.WebApp"
RUN dotnet build "AdrasJRS.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdrasJRS.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdrasJRS.WebApp.dll"]
