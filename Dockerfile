FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EmployeeTable.WebApi/EmployeeTable.WebApi.csproj", "src/EmployeeTable.WebApi/"]
COPY ["src/EmployeeTable.Application/EmployeeTable.Application.csproj", "src/EmployeeTable.Application/"]
COPY ["src/EmployeeTable.Domain/EmployeeTable.Domain.csproj", "src/EmployeeTable.Domain/"]
COPY ["src/EmployeeTable.Infrastructure/EmployeeTable.Infrastructure.csproj", "src/EmployeeTable.Infrastructure/"]
RUN dotnet restore "src/EmployeeTable.WebApi/EmployeeTable.WebApi.csproj"
COPY . .
WORKDIR "/src/src/EmployeeTable.WebApi"
RUN dotnet build "EmployeeTable.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmployeeTable.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeTable.WebApi.dll"]
