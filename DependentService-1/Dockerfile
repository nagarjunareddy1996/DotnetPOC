#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DependentService-1/DependentService-1.csproj", "DependentService-1/"]
RUN dotnet restore "DependentService-1/DependentService-1.csproj"
COPY . .
WORKDIR "/src/DependentService-1"
RUN dotnet build "DependentService-1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DependentService-1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DependentService-1.dll"]