FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ARG URL_EXPOSE_PORT=80
ARG URL_EXPOSE_PORT_HTTPS=443
ARG BUILDER_VERSION=latest
ARG RELEASE_DATE="2020-04-02"

LABEL h2020.ipmdecisions.sch.version=${BUILDER_VERSION} \
    vendor="RSK ADAS Ltd" \
    h2020.ipmdecisions.sch.release-date=${RELEASE_DATE}

WORKDIR /app
EXPOSE ${URL_EXPOSE_PORT}
EXPOSE ${URL_EXPOSE_PORT_HTTPS}

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["H2020.IPMDecisions.SCH.API/H2020.IPMDecisions.SCH.API.csproj", "H2020.IPMDecisions.SCH.API/"]
COPY ["H2020.IPMDecisions.SCH.API/appsettingsTemplate.json", "H2020.IPMDecisions.SCH.API/appsettings.json"]
RUN dotnet restore "H2020.IPMDecisions.SCH.API/H2020.IPMDecisions.SCH.API.csproj"

COPY . .
WORKDIR /src/H2020.IPMDecisions.SCH.API
RUN dotnet build "H2020.IPMDecisions.SCH.API.csproj" -c Release -o /app/build

WORKDIR /src/H2020.IPMDecisions.SCH.API
FROM build AS publish
RUN dotnet publish "H2020.IPMDecisions.SCH.API.csproj" -c Release -o /app/publish

FROM base AS final
ARG URL_PORT=5006
ARG URL_PORT_HTTPS=443

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "H2020.IPMDecisions.SCH.API.dll"]