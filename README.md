# Offer Management System

![Angular](https://img.shields.io/badge/Angular-18-DD0031?style=flat-square)
![.NET](https://img.shields.io/badge/.NET-9-512BD4?style=flat-square)
![MS SQL Server](https://img.shields.io/badge/MS_SQL_Server-✔-CC2927?style=flat-square)
![Docker](https://img.shields.io/badge/Docker-✔-2496ED?style=flat-square)

**Offer Management System** — это full-stack веб-приложение для управления автомобильными офферами, реализованное на .NET 9 и Angular 18.

## 🚀 Быстрый старт
Склонируйте репозиторий
```bash
git clone https://github.com/PavelKozaev/OfferManagementSystem.git
```
Перейдите в корневую папку решения
```bash
cd OfferManagementSystem
```
Выполните команду
```bash
docker-compose up -d --build
```

## Доступно по адресу:
- Frontend приложение: 🔗 http://localhost:81
- Документация API: 📚 http://localhost:8080/swagger

## 📌 Основные возможности
- Backend API на .NET с использованием Чистой архитектуры и CQRS.
- Frontend SPA на Angular, реализующий интерактивный интерфейс.
- Полная контейнеризация с помощью Docker Compose.
- Фильтрация офферов в реальном времени.
- Агрегация данных для отображения популярных поставщиков.
- Автоматические миграции и начальное заполнение базы данных.

## API Endpoints
- Создать новый оффер
```bash
POST /api/Offers
```
- Получить список офферов (с фильтрацией)
```bash
GET /api/Offers?searchTerm={value}
```
- Получить список популярных поставщиков
```bash
GET /api/Suppliers/popular
```

## Модели данных
- Offer (DTO)
```bash
{
  "id": 0,
  "brand": "string",
  "model": "string",
  "supplierName": "string",
  "registeredAt": "2025-07-16T12:00:00Z"
}
```

- Popular Supplier (DTO)
```bash
{
  "name": "string",
  "offersCount": 0
}
```

## Контрибьютинг

Если вы хотите внести свой вклад в проект, пожалуйста, создайте форк репозитория, создайте новую ветку, внесите свои изменения и отправьте pull request.

## Лицензия

Данный проект не лицензирован.

## Автор

[Pavel Kozaev](https://github.com/PavelKozaev)