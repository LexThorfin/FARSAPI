#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FARS_GetData/FARS_GetData.csproj", "FARS_GetData/"]
RUN dotnet restore "FARS_GetData/FARS_GetData.csproj"
COPY . .
WORKDIR "/src/FARS_GetData"
RUN dotnet build "FARS_GetData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FARS_GetData.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FARS_GetData.dll"]