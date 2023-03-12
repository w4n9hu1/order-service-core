
## Order.Application

Application layer that implements the use cases of the application based on the domain.

## Order.Application.Contracts

A thin project that contains the application service interfaces and the DTOs used by these interfaces. This project can be shared by the client applications (including the UI).

### Object To Object Mapping

- Use auto object mapping only for Entity to output DTO mappings.
- Do not use auto object mapping for input DTO to Entity mappings.

## Application Layer Building Blocks

### Application Service

An Application Service is a stateless service that implements use cases of the application.
An application service typically gets and returns DTOs.It is used by the Presentation Layer.
It uses and coordinates the domain objects to implement the use cases. A use case is typically considered as a Unit Of Work.

### Data Transfer Object (DTO)

A DTO is a simple object without any business logic that is used to transfer state (data) between the Application and Presentation Layers.

### Unit of Work (UOW)

A Unit of Work is an atomic work that should be done as a transaction unit. All the operations inside a UOW should be committed on success or rolled back on a failure.