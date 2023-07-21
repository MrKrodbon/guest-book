#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GuestBook.Service/GuestBook.Service.csproj", "src/GuestBook.Service/"]
RUN dotnet restore "src/GuestBook.Service/GuestBook.Service.csproj"
COPY . .
WORKDIR "/src/GuestBook.Service"
RUN dotnet build "GuestBook.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuestBook.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuestBook.Service.dll"]
