# Order Service

This is a sample ASP.NET Core API project that follows Domain-Driven Design (DDD) principles.
 
It aims to provide practical experience and insight into implementing DDD concepts and techniques in a backend application. The project demonstrates how DDD can be effectively applied in a real-world scenario.

## Architecture

![architecture](./design/architecture.png)

Layering of this solution:

- WebAPI - contains controllers and API endpoints.
- [Application](./Order.Application/README.md) - contains application services and DTOs.
- [Domain](./Order.Domain//README.md) - contains entities, domain services, and repositories.
- Infrastructure - contains data access and external services implementations.

## Tech Stack

This project is planning to utilize the following technologies or third-party libraries:

- [x] DDD
- [x] AutoMapper
- [x] Serilog
- [ ] xUnit
- [ ] Refit
- [ ] Kafka
- [ ] Mysql
- [ ] Dapper
- [ ] MongoDB
- [ ] ElasticSearch
- [ ] Docker
- [ ] Azure
- [ ] CI/CD