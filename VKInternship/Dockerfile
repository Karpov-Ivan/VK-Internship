#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VKInternship/VKInternship.csproj", "VKInternship/"]
COPY ["DBCore/DBCore.csproj", "DBCore/"]
COPY ["DBModels/DBModels.csproj", "DBModels/"]
COPY ["ProjectEnum/ProjectEnum.csproj", "ProjectEnum/"]
COPY ["DTOModels/DTOModels.csproj", "DTOModels/"]
COPY ["ProjectModels/ProjectModels.csproj", "ProjectModels/"]
COPY ["Project/Project.csproj", "Project/"]
RUN dotnet restore "VKInternship/VKInternship.csproj"
COPY . .
WORKDIR "/src/VKInternship"
RUN dotnet build "VKInternship.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VKInternship.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VKInternship.dll"]
