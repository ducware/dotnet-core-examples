#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hangfire with Twitter/Hangfire with Twitter.csproj", "Hangfire with Twitter/"]
RUN dotnet restore "Hangfire with Twitter/Hangfire with Twitter.csproj"
COPY . .
WORKDIR "/src/Hangfire with Twitter"
RUN dotnet build "Hangfire with Twitter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire with Twitter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire with Twitter.dll"]