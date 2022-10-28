FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjectService/ProjectService.csproj", "ProjectService/"]
RUN dotnet restore "ProjectService/ProjectService.csproj"
COPY . .
WORKDIR "/src/ProjectService"
RUN dotnet build "ProjectService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectService.dll"]
