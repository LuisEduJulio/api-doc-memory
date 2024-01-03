#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api-doc-memory.api/api-doc-memory.api.csproj", "api-doc-memory.api/"]
RUN dotnet restore "api-doc-memory.api/api-doc-memory.api.csproj"
COPY . .
WORKDIR "/src/api-doc-memory.api"
RUN dotnet build "api-doc-memory.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-doc-memory.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-doc-memory.api.dll"]