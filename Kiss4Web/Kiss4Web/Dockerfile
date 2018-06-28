FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Kiss4Web/Kiss4Web.csproj Kiss4Web/
RUN dotnet restore
COPY . .
WORKDIR /src/Kiss4Web
RUN dotnet build -c Release -o /app


#ENV certPassword CE1F9F41-695F-468C-BC22-1CC412B3F609
#RUN openssl genrsa -des3 -passout pass:${certPassword} -out server.key 2048
#RUN openssl rsa -passin pass:${certPassword} -in server.key -out server.key
#RUN openssl req -sha256 -new -key server.key -out server.csr -subj '/CN=localhost'
#RUN openssl x509 -req -sha256 -days 365 -in server.csr -signkey server.key -out server.crt
#RUN openssl pkcs12 -export -out cert.pfx -inkey server.key -in server.crt -certfile server.crt -passout pass:${certPassword}

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Kiss4Web.dll"]
