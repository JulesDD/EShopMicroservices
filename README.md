#This project literally started because I was reading about Minimal API development. After which I sat for a weekend doing research and I am working developing a microservice with different methods and procedures.
Remembering what I learned from my previous job. I took a weekend to gather information to build Microservices on .Net platforms which used Asp.Net Web API, Docker, RabbitMQ, MassTransit, Grpc, Yarp API Gateway, PostgreSQL, 
Redis, SQLite, SqlServer, Marten, Entity Framework Core, CQRS, MediatR, DDD, Vertical and Clean Architecture implementation using latest codes and best practices of .NET 8 on cloud-native environments.


# WEEK 1 (Completed)
# Catalog microservice will include:
- ASP.NET Core Minimal APIs and latest features of .NET 8 and C# 12 
- Vertical Slice Architecture implementation with Feature folders 
- CQRS implementation using MediatR library 
- Mapping using Mapster instead of AutoMapper 
- CQRS Validation Pipeline Behaviours with MediatR and FluentValidation 
- Marten library for .NET Transactional Document DB on PostgreSQL
- Carter library for Minimal API endpoint definition 
- Cross-cutting concerns Logging, global Exception Handling and Health Checks 
- Dockerfile and docker-compose file for running Multi-container in Docker environment (pending) 

# Week 2
# Basket microservice will include:
- ASP.NET 8 Web API application, Following REST API principles, CRUD operations
- Redis as a Distributed Cache over basketdb
- Implements Proxy, Decorator and Cache-aside Design Patterns
- Consume Discount gRPC Service for inter-service sync communication to calculate product final price
- Publish BasketCheckout Queue with using MassTransit and RabbitMQ

## Reminder: 
- Replace PUT request with a PATCH. Personally never a fan of PUT.
