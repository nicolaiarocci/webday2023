FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /build

# copy csproj and restore as distinct layers
COPY src/*.csproj ./src/
RUN dotnet restore src/

# copy everything else and build app
COPY src/. ./src/
RUN dotnet publish src/ -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "blazorapp.dll"]
