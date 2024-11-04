FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["api_pi_pi_2.csproj", "./"]
RUN dotnet restore "api_pi_pi_2.csproj"
COPY . .
RUN dotnet build "api_pi_pi_2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_pi_pi_2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_pi_pi_2.dll"]
