FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60750
EXPOSE 44380

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ReceVitas/ReceVitas.csproj", "ReceVitas/"]
RUN dotnet restore "ReceVitas/ReceVitas.csproj"
COPY . .
WORKDIR "/src/ReceVitas"
RUN dotnet build "ReceVitas.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ReceVitas.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ReceVitas.dll"]