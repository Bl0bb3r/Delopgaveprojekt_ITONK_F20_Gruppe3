#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "." "Delopgaveprojekt_ITONK_F20_Gruppe3/"
RUN dotnet restore "Delopgaveprojekt_ITONK_F20_Gruppe3/Delopgaveprojekt_ITONK_F20_Gruppe3.csproj"
COPY . .
WORKDIR "/src/Delopgaveprojekt_ITONK_F20_Gruppe3"
RUN dotnet build "Delopgaveprojekt_ITONK_F20_Gruppe3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Delopgaveprojekt_ITONK_F20_Gruppe3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Delopgaveprojekt_ITONK_F20_Gruppe3.dll"]