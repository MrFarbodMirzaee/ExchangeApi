<a id="top" style="display: none;"></a>
- [Introduction](#introduction)
- [Architecture Overview](#architecture-overview)
- [API Protocols](#api-protocols)
- [Usage Guide](#usage-guide)
    - [Prerequisites](#prerequisites)
    - [Infrastructure Dependencies](#infrastructure-dependencies)
    - [Configuration](#configuration)
    - [Database Configuration](#database-configuration)
    - [REST API](#rest-api)
    - [gRPC API](#grpc-api)
    - [GraphQL API](#graphql-api)
    - [Running the Application](#running-the-application)
    - [Running Tests](#running-tests)
    - [Future To Do List](#future-to-do-list)
---

# Introduction

# 💱 ExchangeApi
ExchangeApi is a currency exchange API project built with **.NET 8 and C#**.

The project follows:

- Clean Architecture (layered)
- CQRS Pattern

The system exposes **three API protocols** — REST, gRPC, and GraphQL — over a shared Application/Domain core, using an API Gateway with **Ocelot** as the entry point.

> **Project Status: Under Development**
>
> ExchangeApi is currently under active development. New features, improvements, and architectural enhancements are being added continuously.
>
> As the project is evolving, there may still be bugs, incomplete features, or areas that require further refinement. The codebase is continuously being improved with the goal of building a scalable, maintainable API project.
>
> If you find any issues, have suggestions, or would like to contribute, please feel free to open an issue or fork the repository. Contributions and feedback are welcome and help improve the project as it continues to evolve.

---

## Architecture Overview
[⬆ Back to Top](#top)

ExchangeApi follows a **layered Clean Architecture** approach. It is not a microservice or a DDD project — it's a single deployable solution with separate projects per layer/concern, where one Application/Domain core is shared across three API surfaces (REST, gRPC, GraphQL), so business logic is written once and exposed through whichever protocol a client needs.

### Solution Structure

```text
ExchangeApi
│
├── ExchangeApi.Gateway
│   └── Ocelot Reverse Proxy
│
├── ExchangeApi.Domain
│   ├── Entities
│   └── Value Objects
│
├── ExchangeApi.Application
│   ├── CQRS Commands
│   ├── CQRS Queries
│   ├── MediatR Handlers
│   ├── DTOs
│   └── Validators
│
├── ExchangeApi.Infrastructure
│   ├── Entity Framework Core
│   ├── Repository Pattern
│   └── Database Factory
│
├── ExchangeApi.Infrastructure.Shered
│   └── Shared infrastructure concerns
│
├── ExchangeApi.Infrastructure.Identity
│   ├── ASP.NET Core Identity
│   ├── JWT Authentication
│
├── ResourceApi
│   ├── Controllers
│   ├── REST Routing
│   └── OpenAPI / Swagger
│
├── Exchange.gRPCServer
│   ├── Proto Contracts
│   ├── Grpc Services
│   └── Interceptors
│
├── Exchange.gRPCClient
│   └── Client stubs / consumer for the gRPC service
│
└── ExchangeApi.GraphQl
    ├── Schema
    ├── Queries
    ├── Mutations
    ├── Subscriptions
    └── Resolvers
```

---

## API Protocols
[⬆ Back to Top](#top)

ExchangeApi exposes the same underlying exchange-rate/order functionality through three protocols, so clients can pick whichever fits their integration best.

| Protocol | Project | Typical Use Case |
|---|---|---|
| REST | `ExchangeApi.Api.Rest` | Public HTTP clients, browser/mobile apps, simple integrations |
| gRPC | `ExchangeApi.Grpc` | Internal service-to-service calls, low-latency/high-throughput scenarios |
| GraphQL | `ExchangeApi.GraphQl` | Flexible querying, clients that need to shape their own response payloads |

All three protocols route through the Ocelot Gateway, so external clients only ever need one entry point.

---
# Usage Guide
[⬆ Back to Top](#top)

This section explains how to configure, run, and use the ExchangeApi application.

Before running the application, make sure all required dependencies are installed and infrastructure services are available.

---

## Prerequisites

[⬆ Back to Top](#top)

Before starting the project, install the following tools:

### Required Software

| Tool | Version |
|---|---|
| .NET SDK | .NET 8 |
| Docker Desktop | Latest |
| SQL Server | 2025 or Docker SQL Server Container |
| Git | Latest |
| Visual Studio / Rider / VS Code | Latest |

### Recommended Tools

- SQL Server Management Studio (SSMS)
- Docker Desktop
- Postman (REST)
- grpcurl / BloomRPC / Postman gRPC (gRPC)
- Banana Cake Pop / GraphQL Playground / Postman (GraphQL)
- Navicat or another database management tool

---

# Infrastructure Dependencies
[⬆ Back to Top](#top)

ExchangeApi requires the following infrastructure to run correctly:

| Service | Purpose |
|---|---|
| SQL Server | Application database storage |
| Identity Database | Authentication and user management |

---

## Docker Infrastructure
[⬆ Back to Top](#top)

Example: running SQL Server locally via Docker.

```bash
docker run -e "ACCEPT_EULA=Y" \
-e "MSSQL_SA_PASSWORD=YourStrong@Password123" \
-p 1433:1433 \
--name exchange-api-sqlserver \
-d mcr.microsoft.com/mssql/server:2025-latest
```

# Configuration

[⬆ Back to Top](#top)

ExchangeApi uses ASP.NET Core configuration providers to manage application settings.

Configuration can be provided through:

- `appsettings.json`
- `appsettings.Development.json`
- User Secrets
- Environment Variables

# Database Configuration

[⬆ Back to Top](#top)

ExchangeApi uses **SQL Server** as its only supported database provider (no provider-switching support at this time).

Configure your connection strings via User Secrets:

```
dotnet user-secrets set "ConnectionStrings:ExchangeApi" "<your_connection_string>"
dotnet user-secrets set "ConnectionStrings:ExchangeApi_Identity" "<your_connection_string>"
```

Current configuration:

```json
{
  "ConnectionStrings": {
    "ExchangeApi": "Your connection string",
    "ExchangeApi_Identity": "Your connection string"
  }
}
```

# REST API
[⬆ Back to Top](#top)

The REST API is served from `ExchangeApi` and documented via OpenAPI/Swagger.

Example base URL (through the gateway):

Health check:

```
https://localhost:7233/health
```

Swagger UI (direct, non-gateway):

```
https://localhost:{rest_port}/swagger
```

# gRPC API
[⬆ Back to Top](#top)
Server reflection is enabled in Development, so gRPC clients (Postman, BloomRPC, grpcurl) can discover services without importing `.proto` files manually.

# GraphQL API
[⬆ Back to Top](#top)

The GraphQL API is served from `ExchangeApi.Api.GraphQl`.

GraphQL endpoint:

```
https://localhost:{graphql_port}/graphql
```

Example query:

```graphql
query {
  exchangeRate(base: "USD", quote: "EUR") {
    rate
    lastUpdated
  }
}
```

The interactive GraphQL IDE (Banana Cake Pop / Playground) is available at the same endpoint in Development.

---

# Running the Application
[⬆ Back to Top](#top)

Before running the application, make sure SQL Server is available and migrations have been applied.

## Running with the Ocelot API Gateway

If you want to use the Ocelot API Gateway, you must run both the gateway and the required application services (REST, gRPC, GraphQL) together.

The API Gateway acts as the single entry point for client requests and routes incoming traffic to the appropriate protocol-specific service.

After starting:

- `ExchangeApi.Gateway`
- `ExchangeApi.Api.Rest`
- `ExchangeApi.Api.Grpc`
- `ExchangeApi.Api.GraphQl`

You should send your API requests through the gateway instead of calling the services directly.

---
# Running Tests
[⬆ Back to Top](#top)

There are currently no automated tests in the project. Test coverage is planned — see the Future To Do List below.

---
# Future To Do List
[⬆ Back to Top](#top)

ExchangeApi is continuously evolving. The following features and improvements are planned for future development.

| Category | Planned Improvement |
|---|---|
| Framework | Migrate the project to .NET 10 |
| Framework | Update Entity Framework Core packages |
| Data | Integrate a real currency exchange rate data provider |
| Logging | Add Serilog for structured logging |
| Notifications | Add Email service support |
| Notifications | Add SMS service support |
| Real-time | Add WebSocket support |
| Real-time | Add SignalR for live/streaming updates |
| API | Add GraphQL subscriptions for live rate updates |
| API | Add gRPC streaming endpoints for real-time rate feeds |
| Testing | Add Unit Tests across all layers |
| Testing | Add Integration Tests for REST, gRPC, and GraphQL endpoints |
| Testing | Implement End-to-End (E2E) testing |
| Testing | Add Performance and Load Testing |
| Infrastructure | Containerize the complete application using Docker |
| Infrastructure | Create a Docker Compose environment for local development |
| Performance | Add Redis caching support |
| Performance | Cache frequently accessed exchange rates |
| Performance | Improve API response times across all three protocols |
| Observability | Integrate Prometheus for metrics collection |
| Observability | Configure Grafana dashboards for real-time monitoring |
| Observability | Implement centralized logging |
| Observability | Add distributed tracing across REST, gRPC, and GraphQL calls |
| Security | Implement API rate limiting |
| Security | Add configurable rate limiting policies per protocol |
| CI/CD | Automate testing within CI/CD pipelines |
| CI/CD | Automate Docker image building and publishing |
| CI/CD | Automate deployments to staging and production |
| Documentation | Expand REST/gRPC/GraphQL API documentation and developer guides |
