FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MemberService/MemberService.csproj", "MemberService/"]
RUN dotnet restore "MemberService/MemberService.csproj"
COPY . .
WORKDIR "/src/MemberService"
RUN dotnet build "MemberService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MemberService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemberService.dll"]
