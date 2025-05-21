# Travel App with AI - Backend

This is the backend for the Travel App with AI, built using C# with ASP.NET Core Minimal APIs following Clean Architecture principles.

## Project Structure

The backend follows Clean Architecture with the following layers:

- **Domain**: Contains business entities, repository interfaces, and domain logic
- **Application**: Contains DTOs, services, and business logic
- **Infrastructure**: Contains database access, external service clients, and other infrastructure concerns
- **API**: Contains API endpoints and request/response handling

## Getting Started

### Prerequisites

- .NET SDK 8.0 or later
- MongoDB (for database)

### Setup Instructions

1. Clone the repository
2. Navigate to the solution directory
```bash
cd TravelApp
```

3. Restore dependencies
```bash
dotnet restore
```

4. Build the solution
```bash
dotnet build
```

5. Run the API
```bash
cd src/TravelApp.API
dotnet run
```

### Running Tests

```bash
dotnet test
```

## Technologies

- ASP.NET Core Minimal APIs
- MongoDB
- xUnit (for testing)

## Common Commands

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run all tests
dotnet test

# Run with hot reload
cd src/TravelApp.API && dotnet watch run
```

## Architectural Overview

For more detailed information about the architecture, please refer to the [ARCHITECTURE.md](../ARCHITECTURE.md) file.