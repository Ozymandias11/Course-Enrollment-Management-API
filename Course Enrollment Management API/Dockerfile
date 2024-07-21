#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Course Enrollment Management APi/Course Enrollment Management APi.csproj", "Course Enrollment Management APi/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "./Course Enrollment Management APi/Course Enrollment Management APi.csproj"
COPY . .
WORKDIR "/src/Course Enrollment Management APi"
RUN dotnet build "./Course Enrollment Management APi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Course Enrollment Management APi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Course Enrollment Management APi.dll"]