#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Identity DotNet 8/Identity DotNet 8.csproj", "Identity DotNet 8/"]
RUN dotnet restore "Identity DotNet 8/Identity DotNet 8.csproj"
COPY . .
WORKDIR "/src/Identity DotNet 8"
RUN dotnet build "Identity DotNet 8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity DotNet 8.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity DotNet 8.dll"]