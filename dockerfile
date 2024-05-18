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
ENTRYPOINT [ "dotnet", "Diary.dll" ]