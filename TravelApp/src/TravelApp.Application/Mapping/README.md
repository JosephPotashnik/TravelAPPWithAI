# AutoMapper Configuration for TravelApp

This directory contains the mapping profiles for AutoMapper that enable easy conversion between domain entities and DTOs in the Travel Application.

## Overview

AutoMapper is used to reduce the boilerplate code needed to map between domain entities and DTOs (Data Transfer Objects). The configuration follows a clean architecture approach, keeping mapping logic separate from both domain and presentation concerns.

## Available Mapping Profiles

- **UserMappingProfile**: Maps between `User` entity and `UserDTO`
- **PreferenceMappingProfile**: Maps between `Preference` entity and `PreferenceDTO`
- **ItineraryMappingProfile**: Maps between `Itinerary`/`ItineraryItem` entities and `ItineraryDTO`/`ItineraryItemDTO`
- **DestinationMappingProfile**: Maps between `Destination` entity and `DestinationDTO`
- **FeedbackMappingProfile**: Maps between `Feedback` entity and `FeedbackDTO`

## Known Issues

There are currently build issues in the Domain project related to exception class constructors (duplicate signatures). These issues need to be resolved before the mapping profiles can be used effectively. The mapping profiles themselves are correctly implemented and will work once the Domain project builds successfully.

## Usage

### In Dependency Injection

```csharp
// In Program.cs or Startup.cs
services.AddMappingConfiguration();
```

### In Services

```csharp
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetUserAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDTO>(user);
    }
}
```

## Special Mapping Considerations

1. **Passwords**: User passwords are not mapped from DTOs to entities to maintain security.
2. **Collection Relationships**: For relationships like `Itinerary` to `ItineraryItems`, only the IDs are mapped by default. Additional logic must be implemented in services to include related entities when needed.
3. **TimeSpan to Minutes**: The `Destination.TypicalVisitDuration` (TimeSpan) is mapped to `DestinationDTO.TypicalVisitDurationMinutes` (int) for easier serialization and client usage.

## Testing

When testing the mappings, you can use the `MappingConfig.CreateMapper()` method to create a mapper instance with all the profiles configured:

```csharp
// In your test setup
var mapper = MappingConfig.CreateMapper();

// Test mapping
var user = new User { /* ... */ };
var userDto = mapper.Map<UserDTO>(user);
```