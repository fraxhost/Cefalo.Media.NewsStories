# Blog Posting Platform API

This repository contains the API for a blog posting platform built using ASP.NET Core. The project follows the repository pattern and uses an MSSQL database server. The core logic is separated into four layers: API, Service, Repository, and Database.

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- .NET 6 SDK
- MSSQL Server
- Visual Studio 2022

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/blog-posting-platform-api.git
    cd blog-posting-platform-api
    ```

2. Set up the MSSQL database:
    - Create a new database in MSSQL Server.
    - Update the connection string in `appsettings.json` with your database details.

3. Restore the dependencies:
    ```bash
    dotnet restore
    ```

4. Apply migrations to the database:
    ```bash
    dotnet ef database update
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

### Usage

Once the application is running, you can access the API at `https://localhost:5001` (or the port specified in your launch settings).

### Project Structure

The project is structured into the following layers:

- **API**: Contains the controllers and routes for handling HTTP requests.
- **Service**: Contains the business logic and service classes.
- **Repository**: Contains the repository classes for data access.
- **Database**: Contains the Entity Framework Core models and database context.
