# Travel App with AI: Architecture Specification

## System Overview
Clean Architecture implementation with C# Minimal API backend and Next.js frontend, communicating via REST API.

## Technology Stack
- **Backend**: C# ASP.NET Core Minimal APIs
- **Frontend**: Next.js (React)
- **Database**: MongoDB (document-based NoSQL)
- **Styling**: Tailwind CSS
- **Package Management**: NuGet (backend), npm (frontend)

## Architectural Layers

### Backend Architecture

#### 1. Domain Layer
- Core business entities and rules
- No external dependencies
- Contains:
  - Entity models (User, Itinerary, Destination)
  - Domain exceptions
  - Repository interfaces
  - Domain services interfaces

#### 2. Application Layer
- Contains application logic
- Implements use cases
- Depends only on Domain layer
- Contains:
  - DTOs (Data Transfer Objects)
  - Service implementations
  - Mapping profiles
  - Command/query handlers

#### 3. Infrastructure Layer
- External concerns implementation
- Database access (MongoDB)
- Third-party services
- Contains:
  - Repository implementations
  - External API clients
  - MongoDB configurations
  - Authentication services

#### 4. API Layer (Minimal API)
- HTTP request handling
- Route definitions
- Authentication middleware
- API documentation
- Response formatting

### Frontend Architecture

#### 1. Pages/App Router
- Next.js routing structure
- Page templates
- Route-specific logic

#### 2. Components
- Reusable UI components
- Page-specific components
- Layout components

#### 3. Services
- API integration
- External service clients
- Authentication handling

#### 4. Hooks & Utils
- Custom React hooks
- Utility functions
- Helper methods

## Data Models

### Core Entities
- **User**: Authentication and profile data
- **Preference**: User travel preferences
- **Itinerary**: Complete trip plan
- **ItineraryItem**: Individual activity/location
- **Destination**: Location data
- **Feedback**: User ratings and suggestions

## Communication Patterns

### API Design
- RESTful endpoints following resource naming
- HTTP methods mapped to CRUD operations
- Consistent response format
- JWT authentication
- Status codes follow HTTP standards

### Data Flow
1. Client request → API endpoint
2. API layer → Application service
3. Service → Domain entities/repositories
4. Repository → Database
5. Response follows reverse path

## Database Design

### MongoDB Collections
- **Users**: Profile and authentication
- **Itineraries**: Trip plans with items
- **Destinations**: Locations and attractions
- **Feedback**: User ratings and input

### Indexing Strategy
- User email (unique)
- Itinerary user ID + creation date
- Destination location (geospatial)

## Security Architecture
- JWT for stateless authentication
- Role-based authorization
- Password hashing with salt
- HTTPS requirement
- API rate limiting
- Input validation

## AI Integration
- LLM for natural language processing
- Custom recommendation algorithm
- Feedback-driven improvement
- Caching for common requests

## Error Handling
- Try/catch blocks with detailed logging
- Domain-specific exceptions
- Consistent error response format
- Logging levels (Info, Warning, Error)
- Correlation IDs for request tracking

## System Interfaces
- Maps API integration
- Weather data services
- External image services

## Deployment Architecture
- Docker containerization
- Environment segregation
- CI/CD pipeline integration
- Automated testing in pipeline
- Separate database instances per environment

## Scalability Considerations
- Stateless design
- Connection pooling
- Caching strategy
- Potential for service separation

## Project Structure

### Backend Structure
```
TravelApp/
├── src/
│   ├── TravelApp.Domain/
│   ├── TravelApp.Application/
│   ├── TravelApp.Infrastructure/
│   └── TravelApp.API/
└── tests/
    ├── TravelApp.Domain.Tests/
    ├── TravelApp.Application.Tests/
    ├── TravelApp.Infrastructure.Tests/
    └── TravelApp.API.Tests/
```

### Frontend Structure
```
travel-app-frontend/
├── pages/
├── components/
├── services/
├── hooks/
├── utils/
├── public/
└── styles/
```

## Related Documents
- See [FUNCTIONAL.md](FUNCTIONAL.md) for feature requirements
- See [CLAUDE.md](CLAUDE.md) for development standards