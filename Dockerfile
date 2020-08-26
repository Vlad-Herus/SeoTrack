#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
WORKDIR /src
COPY . .
RUN dotnet restore
WORKDIR /src/SeoTrack
RUN libman restore
RUN dotnet build "SeoTrack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeoTrack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeoTrack.dll"]