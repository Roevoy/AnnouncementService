# AnnouncementService
Development Time: 20 hours
Technology Stack: ASP.NET Core, Entity Framework Core, MS SQL, MediatR, FluentValidation, JWT Bearer, Identity, React.

The back-end is designed following the CQRS pattern and adheres to the principles of multi-layered (Onion) architecture, including the following layers:

Core – domain entities

BLL – business logic, commands, handlers, validators

DAL – repositories for database operations, DbContext

API – controllers, configuration

Shared – DTO objects

Tests – unit tests

In addition to the functionality specified in the requirements, user registration and authentication were implemented. Unit tests cover part of the application logic.

The front-end part was partially implemented using React. Its source files are located in the Client folder of the API layer.
