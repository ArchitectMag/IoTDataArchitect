#M.Armağan Gültekin
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyIoT.Api/MyIoT.Api.csproj", "MyIoT.Api/"]
COPY ["MyIoT.Core/MyIoT.Core.csproj", "MyIoT.Core/"]
COPY ["MyIoT.Business/MyIoT.Business.csproj", "MyIoT.Business/"]
COPY ["MyIoT.Entities/MyIoT.Entities.csproj", "MyIoT.Entities/"]
COPY ["MyIoT.DataAccess/MyIoT.DataAccess.csproj", "MyIoT.DataAccess/"]
RUN dotnet restore "MyIoT.Api/MyIoT.Api.csproj"
COPY . .
WORKDIR "/src/MyIoT.Api"
RUN dotnet build "MyIoT.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyIoT.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyIoT.Api.dll"]
