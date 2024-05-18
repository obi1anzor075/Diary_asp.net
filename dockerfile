# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем файл решения и восстанавливаем зависимости
COPY *.sln .
COPY Diary/*.csproj ./Diary/
RUN dotnet restore

# Копируем остальные файлы и собираем приложение
COPY Diary/. ./Diary/
WORKDIR /app/Diary
RUN dotnet publish -c Release -o out

# Используем официальный образ .NET Runtime для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Diary/out .

# Открываем порт
EXPOSE 80

# Устанавливаем команду запуска
ENTRYPOINT ["dotnet", "Diary.dll"]
