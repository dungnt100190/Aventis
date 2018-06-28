FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Kiss4Web.IdentityServer/Kiss4Web.IdentityServer.csproj Kiss4Web.IdentityServer/
RUN dotnet restore
COPY . .
WORKDIR /src/Kiss4Web.IdentityServer
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Kiss4Web.IdentityServer.dll"]
