FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Diary/Diary.csproj Diary/
RUN dotnet restore Diary/Diary.csproj

COPY . .

WORKDIR /src/Diary
RUN dotnet build Diary.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Diary.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Установка инструментов командной строки SQL Server
RUN apt-get update \
    && apt-get install -y gnupg2 curl \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev \
    && echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc \
    && /bin/bash -c "source ~/.bashrc"

ENTRYPOINT [ "dotnet", "Diary.dll" ]
