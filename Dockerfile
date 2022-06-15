#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 3001


FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["CringeLazer.Bancho/CringeLazer.Bancho.csproj", "CringeLazer.Bancho/"]
RUN dotnet restore "CringeLazer.Bancho/CringeLazer.Bancho.csproj"
COPY . .
WORKDIR "/src/CringeLazer.Bancho"
RUN dotnet build "CringeLazer.Bancho.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CringeLazer.Bancho.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CringeLazer.Bancho.dll"]
