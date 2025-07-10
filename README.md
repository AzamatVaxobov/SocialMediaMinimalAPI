Task3
Social Media Minimal API
===

# A minimal social media backend built with .NET 9, Minimal API architecture, Dapper, and PostgreSQL. The application supports basic CRUD operations for users and posts, with features for liking posts and following users.

# 

# Features

# Users: Create, Read, Update, Delete users.

# Posts: Create, fetch, and delete posts by authors.

# Likes: Like/unlike posts and fetch like counts.

# Follows: Follow/unfollow users and retrieve followers/following lists.

# Built with N-layered architecture:

# DataAccess: Models and database connection.

# Repository: Data access layer for PostgreSQL.

# Service: Business logic layer.

# Server: Minimal API for endpoint handling.

# Testing: Unit tests with xUnit and Moq.

Sure! Let’s create a structured README.md file that explains the project, how to run it, how to test it, and documents the feedback for the various tasks you’ve completed.



Here’s the complete README.md for your project:



Social Media Minimal API

A minimal social media backend built with .NET 9, Minimal API architecture, Dapper, and PostgreSQL. The application supports basic CRUD operations for users and posts, with features for liking posts and following users.



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

Testing: Unit tests with xUnit and Moq.

Table of Contents

Setup Instructions

Requirements

How to Run the Application

How to Test

Project Structure

Feedback

Setup Instructions

Clone the Repository

bash





git clone <repository-url>

cd SocialMediaMinimalAPI

Add PostgreSQL

Install PostgreSQL locally.

Create a new database:

sql





CREATE DATABASE SocialMediaDB;

Add the required tables for users, posts, likes, and follows:

sql





CREATE TABLE Users (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   Username VARCHAR(100) NOT NULL,

&nbsp;   Email VARCHAR(100) NOT NULL UNIQUE

);



CREATE TABLE Posts (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   Title VARCHAR(255) NOT NULL,

&nbsp;   Body TEXT NOT NULL,

&nbsp;   AuthorId INT NOT NULL REFERENCES Users(Id)

);



CREATE TABLE Likes (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   PostId INT NOT NULL REFERENCES Posts(Id),

&nbsp;   UserId INT NOT NULL REFERENCES Users(Id)

);



CREATE TABLE Follows (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   FollowerId INT NOT NULL REFERENCES Users(Id),

&nbsp;   FolloweeId INT NOT NULL REFERENCES Users(Id)

);

Requirements

.NET 9 SDK

PostgreSQL

IDE (e.g., Visual Studio or VSCode)

Postman/Swagger for testing API endpoints

Sure! Let’s create a structured README.md file that explains the project, how to run it, how to test it, and documents the feedback for the various tasks you’ve completed.



Here’s the complete README.md for your project:



Social Media Minimal API

A minimal social media backend built with .NET 9, Minimal API architecture, Dapper, and PostgreSQL. The application supports basic CRUD operations for users and posts, with features for liking posts and following users.



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

Testing: Unit tests with xUnit and Moq.

Table of Contents

Setup Instructions

Requirements

How to Run the Application

How to Test

Project Structure

Feedback

Setup Instructions

Clone the Repository

bash





git clone <repository-url>

cd SocialMediaMinimalAPI

Add PostgreSQL

Install PostgreSQL locally.

Create a new database:

sql





CREATE DATABASE SocialMediaDB;

Add the required tables for users, posts, likes, and follows:

sql





CREATE TABLE Users (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   Username VARCHAR(100) NOT NULL,

&nbsp;   Email VARCHAR(100) NOT NULL UNIQUE

);



CREATE TABLE Posts (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   Title VARCHAR(255) NOT NULL,

&nbsp;   Body TEXT NOT NULL,

&nbsp;   AuthorId INT NOT NULL REFERENCES Users(Id)

);



CREATE TABLE Likes (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   PostId INT NOT NULL REFERENCES Posts(Id),

&nbsp;   UserId INT NOT NULL REFERENCES Users(Id)

);



CREATE TABLE Follows (

&nbsp;   Id SERIAL PRIMARY KEY,

&nbsp;   FollowerId INT NOT NULL REFERENCES Users(Id),

&nbsp;   FolloweeId INT NOT NULL REFERENCES Users(Id)

);

Requirements

.NET 9 SDK

PostgreSQL

IDE (e.g., Visual Studio or VSCode)

Postman/Swagger for testing API endpoints

How to Run the Application

1\. Update Connection String

In the Server/appsettings.json, update the following value with your PostgreSQL connection details:



json





{

&nbsp; "ConnectionStrings": {

&nbsp;   "DefaultConnection": "Host=localhost;Database=SocialMediaDB;Username=postgres;Password=yourpassword"

&nbsp; }

}

2\. Build and Run the Project

Run the following commands:



bash





\# Restore dependencies

dotnet restore



\# Build the solution

dotnet build



\# Run the server

dotnet run --project ./Server

3\. Verify API

Open a browser and visit:



plaintext





http://localhost:7036/swagger

This will load the Swagger UI where you can interact with the API and test endpoints.



How to Test

1\. Run Unit Tests

Unit tests are in the Test project:



bash





dotnet test

Example Coverage Check:

bash





dotnet test --collect:"XPlat Code Coverage"

2\. Test Endpoints with Postman

Use Postman or Swagger to test these endpoints:



Users:



POST /users: Create a user.

GET /users: Get all users.

GET /users/{id}: Get a user by ID.

PUT /users/{id}: Update a user.

DELETE /users/{id}: Delete a user.

Posts:



POST /posts: Create a post.

GET /posts: Get all posts.

GET /posts/{id}: Get a post by ID.

DELETE /posts/{id}: Delete a post.

Likes:



POST /likes?postId={postId}\&userId={userId}: Like a post.

GET /likes/{postId}/count: Get like count for a post.

DELETE /likes: Remove a like.

Follows:



POST /follows?followerId={followerId}\&followeeId={followeeId}: Follow a user.

GET /follows/{userId}/followers: Retrieve followers by user ID.

GET /follows/{userId}/following: Retrieve following by user ID.

DELETE /follows: Unfollow a user.

Project Structure

The solution follows an N-Tier Architecture:







SocialMediaMinimalAPI/

├── DataAccess/           # Database models and DbContext

│   ├── Models/

│   └── DbContext/

├── Repository/           # Interfaces and logic for database access

├── Service/              # Business logic layer

├── Server/               # Minimal API with endpoints

│   ├── Endpoints/

│   └── appsettings.json

├── Test/                 # Unit and integration tests

│   ├── UnitTests/

│   └── IntegrationTests/

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

Time Taken: ~1.5 hours.

Was Code Ready?: Yes, after adding coverlet and addressing style issues from StyleCop.

Challenges:

Learning how to read code coverage reports and addressing uncovered branches.

Configuring StyleCop analyzers required code clean-up.

Best Practices Learned:

Write clear, modular methods to reduce complexity metrics.

High-quality tests improve confidence in code changes.

