Task3
Social Media Minimal API
===

# A minimal social media backend built with .NET 9, Minimal API architecture, Dapper, and PostgreSQL. The application supports basic CRUD operations for users and posts, with features for liking posts and following users




Features

Users: Create, Read, Update, Delete users.

Posts: Create, fetch, and delete posts by authors.

Likes: Like/unlike posts and fetch like counts.

Follows: Follow/unfollow users and retrieve followers/following lists.

Built with N-layered architecture:

DataAccess: Models and database connection.

Repository: Data access layer for PostgreSQL.

Service: Business logic layer.

Server: Minimal API for endpoint handling.



Requirements

.NET 9 SDK

PostgreSQL ,Dapper

Postman/Swagger for testing API endpoints


Feedback for Each Task

1\. Basic Level

Task: Setup Project and Create Users API

Ease of Completion: Easy, as .NET and Minimal API were straightforward to configure using ChatGPT.

Time Taken: ~1.5 hours.

Code Ready After Generation?: Mostly ready. Minor adjustments (e.g., naming conventions, query bindings) were required.

Challenges:

Integrating Dapper for PostgreSQL required slight debugging when dealing with queries for foreign keys.

Mapping DTOs to models and vice-versa for good separation of layers.

Best Practices Learned:

Use DTOs for clear API contracts.

Centralizing Dependency Injection in a single file (e.g., DependencyInjection.cs).

2\. Intermediate Level

Task: Write Unit Tests

Ease of Completion: Medium, especially for mocking repositories using Moq.

Time Taken: ~2 hours for UserService tests.

Was Code Ready?: Required tweaking mock setups, especially for repository methods returning collections (e.g., IEnumerable<User>).

Challenges:

Handling mapping logic during tests to validate DTO transformations from models.

Best Practices Learned:

Mocking repository dependencies isolates the service layer.

FluentAssertions made assertions far more readable and meaningful.

3\. Advanced Level

Task: Add Quality Checks and Test Coverage

Ease of Completion: Hard, configuring coverage tooling took effort.

Time Taken: ~4 hours.


