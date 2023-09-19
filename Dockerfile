#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackEndCubos.OPENAPI/BackEndCubos.OPENAPI.csproj", "BackEndCubos.OPENAPI/"]
COPY ["BackEndCubos.Application/BackEndCubos.Application.csproj", "BackEndCubos.Application/"]
COPY ["BackEndCubos.Domain/BackEndCubos.Domain.csproj", "BackEndCubos.Domain/"]
COPY ["BackEndCubos.Infra/BackEndCubos.Infra.csproj", "BackEndCubos.Infra/"]
COPY ["BackEndCubos.Domain.Core/BackEndCubos.Domain.Core.csproj", "BackEndCubos.Domain.Core/"]
COPY ["BackEndCubos.Domain.Services/BackEndCubos.Domain.Services.csproj", "BackEndCubos.Domain.Services/"]
RUN dotnet restore "BackEndCubos.OPENAPI/BackEndCubos.OPENAPI.csproj"
COPY . .
WORKDIR "/src/BackEndCubos.OPENAPI"
RUN dotnet build "BackEndCubos.OPENAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEndCubos.OPENAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEndCubos.OPENAPI.dll"]