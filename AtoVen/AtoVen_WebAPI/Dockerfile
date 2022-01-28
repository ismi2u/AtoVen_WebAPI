#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AtoVen_WebAPI/AtoVen_WebAPI.csproj", "AtoVen_WebAPI/"]
RUN dotnet restore "AtoVen_WebAPI/AtoVen_WebAPI.csproj"
COPY . .
WORKDIR "/src/AtoVen_WebAPI"
RUN dotnet build "AtoVen_WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AtoVen_WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AtoVen_WebAPI.dll"]