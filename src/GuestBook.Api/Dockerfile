#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GuestBook.Api/GuestBook.Api.csproj", "src/GuestBook.Api/"]
COPY ["src/GuestBook.Models/GuestBook.Models.csproj", "src/GuestBook.Models/"]
RUN dotnet restore "src/GuestBook.Api/GuestBook.Api.csproj"
COPY . .
WORKDIR "/src/GuestBook.Api"
RUN dotnet build "GuestBook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuestBook.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuestBook.Api.dll"]