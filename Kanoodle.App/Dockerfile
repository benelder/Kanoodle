#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kanoodle.App/Kanoodle.App.csproj", "Kanoodle.App/"]
COPY ["Kanoodle.Core/Kanoodle.Core.csproj", "Kanoodle.Core/"]
RUN dotnet restore "Kanoodle.App/Kanoodle.App.csproj"
COPY . .
WORKDIR "/src/Kanoodle.App"
RUN dotnet build "Kanoodle.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanoodle.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanoodle.App.dll"]